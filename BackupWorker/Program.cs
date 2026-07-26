using System.IO.Compression;
using System.Text;
using Backuper.Models;
using Backuper.Services;
using Dropbox.Api;
using Dropbox.Api.Files;
using Microsoft.Data.SqlClient;

namespace BackupWorker;

internal class Program
{
    private static string? _logFilePath;
    private static readonly StringBuilder LogBuffer = new();

    private static void Log(string message)
    {
        string formatted = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
        Console.WriteLine(formatted);
        LogBuffer.AppendLine(formatted);

        try
        {
            if (!string.IsNullOrEmpty(_logFilePath))
            {
                string? dir = Path.GetDirectoryName(_logFilePath);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                File.AppendAllText(_logFilePath, formatted + Environment.NewLine);
            }
            
            // También guardar en un log general en ProgramData
            string generalLogDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Backuper", "logs");
            if (!Directory.Exists(generalLogDir))
            {
                Directory.CreateDirectory(generalLogDir);
            }
            string lastExecLog = Path.Combine(generalLogDir, "last_execution.log");
            File.AppendAllText(lastExecLog, formatted + Environment.NewLine);
        }
        catch
        {
            // Evitar que errores de escritura de log detengan la ejecución
        }
    }

    static async Task<int> Main(string[] args)
    {
        string logsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Backuper", "logs");
        _logFilePath = Path.Combine(logsFolder, $"execution_{DateTime.Now:yyyyMMdd_HHmmss}.log");

        Log("=================================================");
        Log($"[BackuperWorker] Iniciando tarea de respaldo");
        Log($"[BackuperWorker] Argumentos recibidos: {string.Join(" ", args)}");
        Log("=================================================");

        string? configPath = null;
        Guid? jobId = null;

        // Parsear argumentos de línea de comandos
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i].Equals("--config", StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length)
            {
                configPath = args[i + 1];
            }
            else if (args[i].Equals("--job-id", StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length)
            {
                if (Guid.TryParse(args[i + 1], out var parsedId))
                {
                    jobId = parsedId;
                }
            }
        }

        var repo = new JobConfigRepository();
        BackupJobConfig? config = null;

        if (!string.IsNullOrWhiteSpace(configPath) && File.Exists(configPath))
        {
            try
            {
                string json = await File.ReadAllTextAsync(configPath);
                config = System.Text.Json.JsonSerializer.Deserialize<BackupJobConfig>(json);
            }
            catch (Exception ex)
            {
                Log($"[ERROR FATAL] No se pudo leer el archivo de configuración en '{configPath}': {ex.Message}");
                return 1;
            }
        }
        else if (jobId.HasValue)
        {
            config = await repo.GetByIdAsync(jobId.Value);
        }

        if (config == null)
        {
            Log($"[ERROR FATAL] No se encontró la configuración. ConfigPath: '{configPath}', JobId: '{jobId}'");
            return 1;
        }

        // Asignar log específico del Job
        _logFilePath = Path.Combine(logsFolder, $"job_{config.Id:N}.log");

        Log($"[INFO] Nombre Tarea: {config.Name}");
        Log($"[INFO] Base de Datos: {config.DatabaseName}");
        Log($"[INFO] Servidor SQL: {config.SqlServer}");
        Log($"[INFO] Tipo de Respaldo: {config.BackupTypeDisplayName}");
        Log($"[INFO] Compresión seleccionada: {config.Compression}");
        Log($"[INFO] Destino Local: {config.LocalDestinationPath}");

        // Asegurar existencia de carpeta destino local
        try
        {
            if (!Directory.Exists(config.LocalDestinationPath))
            {
                Directory.CreateDirectory(config.LocalDestinationPath);
                Log($"[OK] Se creó la carpeta destino local: {config.LocalDestinationPath}");
            }
        }
        catch (Exception ex)
        {
            Log($"[ERROR FATAL] No se pudo crear la carpeta local de destino '{config.LocalDestinationPath}': {ex.Message}");
            return 1;
        }

        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string bakFileName = $"{config.DatabaseName}_{config.BackupType}_{timestamp}.bak";
        string bakFilePath = Path.Combine(config.LocalDestinationPath, bakFileName);

        // 1. Ejecutar Backup SQL Server
        try
        {
            string? sqlPassword = CryptoService.Decrypt(config.SqlPasswordEncrypted);
            string connString = SqlServerService.BuildConnectionString(
                config.SqlServer,
                config.SqlAuthType,
                config.SqlUsername,
                sqlPassword,
                "master"
            );

            Log($"[INFO] Conectando a SQL Server '{config.SqlServer}'...");

            using var connection = new SqlConnection(connString);
            await connection.OpenAsync();
            Log($"[OK] Conexión a SQL Server exitosa.");

            string compressionSqlOption = config.Compression == CompressionType.SqlNative ? ", COMPRESSION" : "";
            
            string backupQuery = config.BackupType switch
            {
                BackupType.Differential => $"BACKUP DATABASE [{config.DatabaseName}] TO DISK = N'{bakFilePath}' WITH DIFFERENTIAL, FORMAT, INIT, STATS = 10{compressionSqlOption};",
                BackupType.Log => $"BACKUP LOG [{config.DatabaseName}] TO DISK = N'{bakFilePath}' WITH FORMAT, INIT, STATS = 10{compressionSqlOption};",
                _ => $"BACKUP DATABASE [{config.DatabaseName}] TO DISK = N'{bakFilePath}' WITH FORMAT, INIT, STATS = 10{compressionSqlOption};"
            };

            Log($"[INFO] Ejecutando comando T-SQL: {backupQuery}");

            using var command = new SqlCommand(backupQuery, connection);
            command.CommandTimeout = 3600; // 1 hora máximo para bases de datos grandes
            await command.ExecuteNonQueryAsync();

            Log($"[OK] Respaldo generado correctamente en: {bakFilePath}");
        }
        catch (Exception ex)
        {
            Log($"[ERROR FATAL] Error al ejecutar respaldo en SQL Server: {ex.Message}");
            if (ex is SqlException sqlEx)
            {
                Log($"[SQL ERROR CODE] {sqlEx.Number} - Severidad: {sqlEx.Class}");
                if (sqlEx.Number == 3201 || sqlEx.Message.Contains("Access is denied") || sqlEx.Message.Contains("Acceso denegado"))
                {
                    Log($"[DIAGNÓSTICO] El servicio de SQL Server no tiene permisos para escribir en la carpeta '{config.LocalDestinationPath}'. Ocurrió un error de 'Acceso Denegado' del sistema operativo.");
                }
            }
            return 1;
        }

        // 2. Verificar integridad con RESTORE VERIFYONLY
        try
        {
            Log("[INFO] Verificando la integridad del respaldo con RESTORE VERIFYONLY...");
            string? sqlPassword = CryptoService.Decrypt(config.SqlPasswordEncrypted);
            string connString = SqlServerService.BuildConnectionString(
                config.SqlServer,
                config.SqlAuthType,
                config.SqlUsername,
                sqlPassword,
                "master"
            );

            using var connection = new SqlConnection(connString);
            await connection.OpenAsync();

            string verifyQuery = $"RESTORE VERIFYONLY FROM DISK = N'{bakFilePath}';";
            using var command = new SqlCommand(verifyQuery, connection);
            command.CommandTimeout = 1800;
            await command.ExecuteNonQueryAsync();

            Log("[OK] Verificación de integridad completada con éxito.");
        }
        catch (Exception ex)
        {
            Log($"[ADVERTENCIA] El archivo se generó pero falló la verificación de integridad: {ex.Message}");
        }

        // 3. Procesar compresión si el usuario eligió comprimir a .zip
        string finalFilePath = bakFilePath;
        if (config.Compression == CompressionType.Zip)
        {
            try
            {
                string zipFileName = $"{config.DatabaseName}_{config.BackupType}_{timestamp}.zip";
                string zipFilePath = Path.Combine(config.LocalDestinationPath, zipFileName);

                Log($"[INFO] Comprimiendo archivo a formato ZIP: {zipFilePath}...");

                using (var zipStream = new FileStream(zipFilePath, FileMode.Create))
                using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
                {
                    archive.CreateEntryFromFile(bakFilePath, bakFileName, CompressionLevel.Optimal);
                }

                // Eliminar el .bak temporal tras compresión exitosa
                if (File.Exists(zipFilePath))
                {
                    File.Delete(bakFilePath);
                    finalFilePath = zipFilePath;
                    Log($"[OK] Compresión ZIP completada. Tamaño final: {new FileInfo(zipFilePath).Length / 1024 / 1024} MB");
                }
            }
            catch (Exception ex)
            {
                Log($"[ADVERTENCIA] No se pudo comprimir a ZIP, se conservará el archivo .bak original: {ex.Message}");
            }
        }

        // 4. Aplicar retención local si está activada
        if (config.RetentionApplyLocal)
        {
            ApplyLocalRetention(config);
        }
        else
        {
            Log("[INFO] La retención local está desactivada por el usuario para esta tarea.");
        }

        // 5. Subir a la nube (Dropbox) si está activo y aplicar retención remota
        if (config.EnableCloudUpload && config.CloudProvider == CloudProviderType.Dropbox)
        {
            try
            {
                string? token = CryptoService.Decrypt(config.CloudTokenEncrypted);
                if (string.IsNullOrWhiteSpace(token))
                {
                    Log("[ADVERTENCIA] La subida a la nube está activada pero no se proporcionó un Token de Dropbox válido.");
                }
                else
                {
                    Log($"[INFO] Iniciando subida a Dropbox...");
                    await UploadToDropboxAsync(token, finalFilePath, config.CloudFolderPath ?? "/Backups", config);
                }
            }
            catch (Exception ex)
            {
                Log($"[ERROR] Error al subir el respaldo a Dropbox: {ex.Message}");
            }
        }

        Log("=================================================");
        Log("[OK] Proceso de respaldo finalizado con éxito.");
        Log("=================================================");
        return 0;
    }

    private static async Task UploadToDropboxAsync(string tokenInput, string localFilePath, string remoteFolderPath, BackupJobConfig config)
    {
        string token = tokenInput.Trim();
        string appKey = "";
        string appSecret = "";
        string refreshToken = token;

        // Si el token viene en formato "AppKey:AppSecret:RefreshToken"
        if (tokenInput.Contains(':'))
        {
            var parts = tokenInput.Split(':');
            if (parts.Length >= 3)
            {
                appKey = parts[0];
                appSecret = parts[1];
                refreshToken = parts[2];
            }
        }

        using var dbx = !string.IsNullOrEmpty(appKey) && !string.IsNullOrEmpty(appSecret)
            ? new DropboxClient(refreshToken, appKey, appSecret)
            : new DropboxClient(token);

        string fileName = Path.GetFileName(localFilePath);
        string folder = remoteFolderPath.StartsWith("/") ? remoteFolderPath : "/" + remoteFolderPath;
        string remotePath = $"{folder.TrimEnd('/')}/{fileName}";

        const int chunkSize = 4 * 1024 * 1024; // Chunks de 4MB para manejar archivos grandes de respaldo
        using var fileStream = File.OpenRead(localFilePath);
        long fileSize = fileStream.Length;

        if (fileSize <= chunkSize)
        {
            var updated = await dbx.Files.UploadAsync(
                remotePath,
                WriteMode.Overwrite.Instance,
                body: fileStream
            );
            Log($"[OK] Archivo subido correctamente a Dropbox: {updated.PathDisplay}");
        }
        else
        {
            Log($"[INFO] Archivo grande ({fileSize / 1024 / 1024} MB). Subiendo en partes a Dropbox...");
            byte[] buffer = new byte[chunkSize];
            string? sessionId = null;
            ulong offset = 0;

            while (offset < (ulong)fileSize)
            {
                int bytesRead = await fileStream.ReadAsync(buffer, 0, chunkSize);
                using var memStream = new MemoryStream(buffer, 0, bytesRead);

                if (offset == 0)
                {
                    var sessionStart = await dbx.Files.UploadSessionStartAsync(body: memStream);
                    sessionId = sessionStart.SessionId;
                }
                else
                {
                    var cursor = new UploadSessionCursor(sessionId, offset);
                    if (offset + (ulong)bytesRead >= (ulong)fileSize)
                    {
                        var commitInfo = new CommitInfo(remotePath, WriteMode.Overwrite.Instance);
                        var updated = await dbx.Files.UploadSessionFinishAsync(cursor, commitInfo, body: memStream);
                        Log($"[OK] Subida de archivo grande a Dropbox completada: {updated.PathDisplay}");
                        break;
                    }
                    else
                    {
                        await dbx.Files.UploadSessionAppendV2Async(cursor, body: memStream);
                    }
                }

                offset += (ulong)bytesRead;
                int percent = (int)((double)offset / fileSize * 100);
                Log($"[PROGRESS] Progreso de subida a Dropbox: {percent}%");
            }
        }

        // Aplicar retención remota en Dropbox si el usuario la activó
        if (config.RetentionApplyCloud)
        {
            await ApplyDropboxRetentionAsync(dbx, config, folder);
        }
        else
        {
            Log("[INFO] La retención en la nube (Dropbox) está desactivada por el usuario para esta tarea.");
        }
    }

    private static void ApplyLocalRetention(BackupJobConfig config)
    {
        int retentionCount = config.RetentionCount > 0 ? config.RetentionCount : 10;
        int retentionDays = config.RetentionDays > 0 ? config.RetentionDays : 30;
        RetentionMode mode = config.RetentionMode;

        try
        {
            Log($"[INFO] Aplicando política de retención local (Modo: {mode}, Máx respaldos: {retentionCount}, Antigüedad máx: {retentionDays} días)...");
            var directory = new DirectoryInfo(config.LocalDestinationPath);
            if (!directory.Exists) return;

            string patternFilter = $"{config.DatabaseName}_*";
            var files = directory.GetFiles(patternFilter)
                .Where(f => f.Extension.Equals(".bak", StringComparison.OrdinalIgnoreCase) || f.Extension.Equals(".zip", StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(f => f.LastWriteTime)
                .ToList();

            var filesToDelete = new HashSet<FileInfo>();

            // Regla 1: Por Antigüedad / Tiempo
            if (mode == RetentionMode.ByAge || mode == RetentionMode.Both)
            {
                DateTime cutoffDate = DateTime.Now.AddDays(-retentionDays);
                var expiredFiles = files.Where(f => f.LastWriteTime < cutoffDate).ToList();
                foreach (var f in expiredFiles)
                {
                    filesToDelete.Add(f);
                }
            }

            // Regla 2: Por Cantidad de Archivos
            if (mode == RetentionMode.ByCount || mode == RetentionMode.Both)
            {
                var remainingAfterAge = files.Where(f => !filesToDelete.Contains(f)).ToList();
                if (remainingAfterAge.Count > retentionCount)
                {
                    var excessFiles = remainingAfterAge.Skip(retentionCount);
                    foreach (var f in excessFiles)
                    {
                        filesToDelete.Add(f);
                    }
                }
            }

            if (filesToDelete.Count > 0)
            {
                Log($"[INFO] Se encontraron {files.Count} respaldos locales. Eliminando {filesToDelete.Count} según la regla de retención...");
                foreach (var oldFile in filesToDelete)
                {
                    try
                    {
                        oldFile.Delete();
                        Log($"[OK] Respaldo antiguo eliminado localmente: {oldFile.Name}");
                    }
                    catch (Exception ex)
                    {
                        Log($"[ADVERTENCIA] No se pudo eliminar el archivo local '{oldFile.Name}': {ex.Message}");
                    }
                }
            }
            else
            {
                Log($"[INFO] Retención local conforme: {files.Count} respaldos dentro de los límites de retención.");
            }
        }
        catch (Exception ex)
        {
            Log($"[ADVERTENCIA] Error durante la retención local: {ex.Message}");
        }
    }

    private static async Task ApplyDropboxRetentionAsync(DropboxClient dbx, BackupJobConfig config, string remoteFolderPath)
    {
        int retentionCount = config.RetentionCount > 0 ? config.RetentionCount : 10;
        int retentionDays = config.RetentionDays > 0 ? config.RetentionDays : 30;
        RetentionMode mode = config.RetentionMode;

        try
        {
            Log($"[INFO] Aplicando política de retención en Dropbox (Modo: {mode}, Máx respaldos: {retentionCount}, Antigüedad máx: {retentionDays} días)...");
            string folder = remoteFolderPath.StartsWith("/") ? remoteFolderPath : "/" + remoteFolderPath;
            var listResult = await dbx.Files.ListFolderAsync(folder.TrimEnd('/'));

            var matchingFiles = listResult.Entries
                .Where(e => e.IsFile && e.Name.StartsWith($"{config.DatabaseName}_", StringComparison.OrdinalIgnoreCase))
                .Select(e => e.AsFile)
                .OrderByDescending(f => f.ClientModified)
                .ToList();

            var filesToDelete = new HashSet<FileMetadata>();

            // Regla 1: Por Antigüedad / Tiempo
            if (mode == RetentionMode.ByAge || mode == RetentionMode.Both)
            {
                DateTime cutoffDate = DateTime.Now.AddDays(-retentionDays);
                var expiredFiles = matchingFiles.Where(f => f.ClientModified < cutoffDate).ToList();
                foreach (var f in expiredFiles)
                {
                    filesToDelete.Add(f);
                }
            }

            // Regla 2: Por Cantidad de Archivos
            if (mode == RetentionMode.ByCount || mode == RetentionMode.Both)
            {
                var remainingAfterAge = matchingFiles.Where(f => !filesToDelete.Contains(f)).ToList();
                if (remainingAfterAge.Count > retentionCount)
                {
                    var excessFiles = remainingAfterAge.Skip(retentionCount);
                    foreach (var f in excessFiles)
                    {
                        filesToDelete.Add(f);
                    }
                }
            }

            if (filesToDelete.Count > 0)
            {
                Log($"[INFO] Se encontraron {matchingFiles.Count} respaldos en Dropbox. Eliminando {filesToDelete.Count} según la regla de retención...");
                foreach (var oldFile in filesToDelete)
                {
                    try
                    {
                        await dbx.Files.DeleteV2Async(oldFile.PathLower);
                        Log($"[OK] Respaldo antiguo eliminado de Dropbox: {oldFile.Name}");
                    }
                    catch (Exception ex)
                    {
                        Log($"[ADVERTENCIA] No se pudo eliminar de Dropbox '{oldFile.Name}': {ex.Message}");
                    }
                }
            }
            else
            {
                Log($"[INFO] Retención en Dropbox conforme: {matchingFiles.Count} respaldos dentro de los límites de retención.");
            }
        }
        catch (Exception ex)
        {
            Log($"[ADVERTENCIA] Error durante la retención en Dropbox: {ex.Message}");
        }
    }
}
