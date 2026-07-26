using System.Data;
using Backuper.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;

namespace Backuper.Services;

public class SqlServerService
{
    public static string BuildConnectionString(string server, AuthType authType, string? username, string? password, string initialCatalog = "master")
    {
        var builder = new SqlConnectionStringBuilder
        {
            DataSource = server,
            InitialCatalog = initialCatalog,
            TrustServerCertificate = true, // Evita fallos por certificados autofirmados en SQL Server local/Express
            ConnectTimeout = 10
        };

        if (authType == AuthType.Windows)
        {
            builder.IntegratedSecurity = true;
        }
        else
        {
            builder.IntegratedSecurity = false;
            builder.UserID = username ?? string.Empty;
            builder.Password = password ?? string.Empty;
        }

        return builder.ConnectionString;
    }

    /// <summary>
    /// Intenta conectar a la instancia de SQL Server especificada.
    /// </summary>
    public async Task<(bool Success, string Message)> TestConnectionAsync(string server, AuthType authType, string? username, string? password)
    {
        if (string.IsNullOrWhiteSpace(server))
            return (false, "El nombre del servidor no puede estar vacío.");

        try
        {
            string connectionString = BuildConnectionString(server, authType, username, password);
            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            return (true, "¡Conexión a SQL Server exitosa!");
        }
        catch (SqlException ex)
        {
            return (false, $"Error de SQL Server ({ex.Number}): {ex.Message}");
        }
        catch (Exception ex)
        {
            return (false, $"Error al conectar: {ex.Message}");
        }
    }

    /// <summary>
    /// Obtiene la lista de bases de datos disponibles en la instancia de SQL Server.
    /// </summary>
    public async Task<List<string>> GetDatabasesAsync(string server, AuthType authType, string? username, string? password)
    {
        var databases = new List<string>();
        string connectionString = BuildConnectionString(server, authType, username, password);

        try
        {
            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            const string query = @"
                SELECT name 
                FROM sys.databases 
                WHERE state_desc = 'ONLINE' 
                  AND name NOT IN ('tempdb') 
                ORDER BY name;";

            using var command = new SqlCommand(query, connection);
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                databases.Add(reader.GetString(0));
            }
        }
        catch
        {
            // Retorna la lista vacía o lo capturado hasta el momento
        }

        return databases;
    }

    /// <summary>
    /// Detecta instancias locales conocidas de SQL Server buscando en el Registro de Windows y nombres comunes.
    /// </summary>
    public async Task<List<string>> GetLocalInstancesAsync()
    {
        return await Task.Run(() =>
        {
            var instances = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "localhost",
                @".\SQLEXPRESS",
                "localhost\\SQLEXPRESS",
                "(local)"
            };

            try
            {
                // Buscar en Registro de Windows (64-bit y 32-bit)
                using var view64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                using var sqlKey = view64.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");
                if (sqlKey != null)
                {
                    if (sqlKey.GetValue("InstalledInstances") is string[] installedInstances)
                    {
                        foreach (var instance in installedInstances)
                        {
                            if (instance.Equals("MSSQLSERVER", StringComparison.OrdinalIgnoreCase))
                                instances.Add("localhost");
                            else
                                instances.Add($@".\{instance}");
                        }
                    }
                }
            }
            catch
            {
                // Ignorar errores al leer el registro si la cuenta no tiene permisos
            }

            return instances.ToList();
        });
    }
}
