using System.Diagnostics;
using Backuper.Models;
using Backuper.Services;
using Dropbox.Api;

namespace Backuper.Forms;

public partial class MainForm : Form
{
    private readonly JobConfigRepository _repo = new();
    private readonly TaskSchedulerService _taskService = new();
    private List<BackupJobConfig> _jobs = new();
    private List<BackupFileItem> _allBackupFiles = new();

    public MainForm()
    {
        InitializeComponent();

        if (!DesignMode && System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
        {
            try
            {
                string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app_icon.ico");
                if (File.Exists(iconPath))
                {
                    this.Icon = new Icon(iconPath);
                }
            }
            catch { }
        }
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
        cboFileLocationFilter.Items.Clear();
        cboFileLocationFilter.Items.Add("Todos los Orígenes");
        cboFileLocationFilter.Items.Add("Solo Respaldos Locales");
        cboFileLocationFilter.Items.Add("Solo Respaldos en Nube (Dropbox)");
        cboFileLocationFilter.SelectedIndex = 0;

        await LoadJobsAsync();
    }

    private async Task LoadJobsAsync()
    {
        btnRefresh.Enabled = false;
        try
        {
            _jobs = await _repo.GetAllAsync();
            dgvJobs.Rows.Clear();

            foreach (var job in _jobs)
            {
                var taskInfo = _taskService.GetTaskInfo(job.Id);

                string lastRun = taskInfo.LastRunTime.HasValue 
                    ? taskInfo.LastRunTime.Value.ToString("dd/MM/yyyy HH:mm") 
                    : "Nunca";
                string nextRun = taskInfo.NextRunTime.HasValue 
                    ? taskInfo.NextRunTime.Value.ToString("dd/MM/yyyy HH:mm") 
                    : "No programada";

                int rowIndex = dgvJobs.Rows.Add(
                    job.Name,
                    job.DatabaseName,
                    job.SqlServer,
                    job.BackupTypeDisplayName,
                    job.FrequencyDisplayName,
                    taskInfo.Status,
                    lastRun,
                    nextRun
                );

                dgvJobs.Rows[rowIndex].Tag = job;
            }

            lblStatusCount.Text = $"Tareas configuradas: {_jobs.Count}";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar los respaldos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnRefresh.Enabled = true;
        }
    }

    private async Task LoadBackupFilesAsync()
    {
        btnRefreshFiles.Enabled = false;
        _allBackupFiles.Clear();

        try
        {
            _jobs = await _repo.GetAllAsync();

            foreach (var job in _jobs)
            {
                // 1. Escanear carpeta local de la tarea
                if (!string.IsNullOrWhiteSpace(job.LocalDestinationPath) && Directory.Exists(job.LocalDestinationPath))
                {
                    try
                    {
                        var dir = new DirectoryInfo(job.LocalDestinationPath);
                        string pattern = string.IsNullOrWhiteSpace(job.DatabaseName) ? "*.bak" : $"{job.DatabaseName}_*";
                        var files = dir.GetFiles(pattern)
                            .Where(f => f.Extension.Equals(".bak", StringComparison.OrdinalIgnoreCase) || f.Extension.Equals(".zip", StringComparison.OrdinalIgnoreCase))
                            .OrderByDescending(f => f.LastWriteTime);

                        foreach (var file in files)
                        {
                            _allBackupFiles.Add(new BackupFileItem
                            {
                                FileName = file.Name,
                                JobName = string.IsNullOrWhiteSpace(job.Name) ? job.DatabaseName : job.Name,
                                DatabaseName = job.DatabaseName,
                                Location = "Local",
                                IsLocal = true,
                                FileSizeBytes = file.Length,
                                CreatedTime = file.LastWriteTime,
                                FullPath = file.FullName
                            });
                        }
                    }
                    catch { }
                }

                // 2. Escanear Dropbox si está configurado
                if (job.EnableCloudUpload && job.CloudProvider == CloudProviderType.Dropbox)
                {
                    try
                    {
                        string? token = CryptoService.Decrypt(job.CloudTokenEncrypted);
                        if (!string.IsNullOrWhiteSpace(token))
                        {
                            string appKey = "";
                            string appSecret = "";
                            string refreshToken = token.Trim();

                            if (token.Contains(':'))
                            {
                                var parts = token.Split(':');
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

                            string folderPath = (job.CloudFolderPath ?? "/Backups").TrimEnd('/');
                            if (!folderPath.StartsWith("/")) folderPath = "/" + folderPath;

                            var list = await dbx.Files.ListFolderAsync(folderPath);
                            var remoteFiles = list.Entries
                                .Where(e => e.IsFile && (string.IsNullOrWhiteSpace(job.DatabaseName) || e.Name.StartsWith($"{job.DatabaseName}_", StringComparison.OrdinalIgnoreCase)))
                                .Select(e => e.AsFile)
                                .OrderByDescending(f => f.ClientModified);

                            foreach (var rFile in remoteFiles)
                            {
                                _allBackupFiles.Add(new BackupFileItem
                                {
                                    FileName = rFile.Name,
                                    JobName = string.IsNullOrWhiteSpace(job.Name) ? job.DatabaseName : job.Name,
                                    DatabaseName = job.DatabaseName,
                                    Location = "Dropbox (Nube)",
                                    IsLocal = false,
                                    FileSizeBytes = (long)rFile.Size,
                                    CreatedTime = rFile.ClientModified,
                                    FullPath = rFile.PathDisplay ?? rFile.PathLower
                                });
                            }
                        }
                    }
                    catch { }
                }
            }

            DisplayBackupFiles();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al consultar archivos de respaldo: {ex.Message}", "Error de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnRefreshFiles.Enabled = true;
        }
    }

    private void DisplayBackupFiles()
    {
        dgvBackupFiles.Rows.Clear();
        int filterIndex = cboFileLocationFilter.SelectedIndex;

        var filtered = _allBackupFiles.Where(item =>
        {
            if (filterIndex == 1) return item.IsLocal;
            if (filterIndex == 2) return !item.IsLocal;
            return true;
        }).OrderByDescending(i => i.CreatedTime);

        foreach (var item in filtered)
        {
            string sizeFormatted = FormatFileSize(item.FileSizeBytes);
            string dateFormatted = item.CreatedTime.ToString("dd/MM/yyyy HH:mm");

            int rowIndex = dgvBackupFiles.Rows.Add(
                item.FileName,
                item.JobName,
                item.Location,
                sizeFormatted,
                dateFormatted,
                item.FullPath
            );

            dgvBackupFiles.Rows[rowIndex].Tag = item;

            // Destacar visualmente el color según la ubicación
            if (item.IsLocal)
            {
                dgvBackupFiles.Rows[rowIndex].Cells[2].Style.ForeColor = Color.FromArgb(20, 100, 40);
                dgvBackupFiles.Rows[rowIndex].Cells[2].Style.Font = new Font(dgvBackupFiles.Font, FontStyle.Bold);
            }
            else
            {
                dgvBackupFiles.Rows[rowIndex].Cells[2].Style.ForeColor = Color.FromArgb(0, 100, 200);
                dgvBackupFiles.Rows[rowIndex].Cells[2].Style.Font = new Font(dgvBackupFiles.Font, FontStyle.Bold);
            }
        }
    }

    private static string FormatFileSize(long bytes)
    {
        if (bytes >= 1024 * 1024 * 1024)
            return $"{bytes / (1024.0 * 1024.0 * 1024.0):F2} GB";
        if (bytes >= 1024 * 1024)
            return $"{bytes / (1024.0 * 1024.0):F2} MB";
        if (bytes >= 1024)
            return $"{bytes / 1024.0:F2} KB";
        return $"{bytes} B";
    }

    private async void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (tabControlMain.SelectedTab == tabExplorer)
        {
            await LoadBackupFilesAsync();
        }
        else if (tabControlMain.SelectedTab == tabJobs)
        {
            await LoadJobsAsync();
        }
    }

    private void cboFileLocationFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplayBackupFiles();
    }

    private async void btnRefreshFiles_Click(object sender, EventArgs e)
    {
        await LoadBackupFilesAsync();
    }

    private void dgvBackupFiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        var selectedRow = dgvBackupFiles.Rows[e.RowIndex];
        if (selectedRow.Tag is BackupFileItem item)
        {
            if (item.IsLocal)
            {
                if (File.Exists(item.FullPath))
                {
                    try
                    {
                        // Abrir Windows Explorer resaltando el archivo exacto
                        Process.Start("explorer.exe", $"/select,\"{item.FullPath}\"");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"No se pudo abrir la ubicación en Windows Explorer: {ex.Message}", "Error de Explorador", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"El archivo '{item.FileName}' ya no existe en la ruta local:\n{item.FullPath}", "Archivo no Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Archivo alojado en Dropbox: abrir el navegador e ir directamente a la ubicación en la nube
                try
                {
                    string remotePath = item.FullPath.StartsWith("/") ? item.FullPath : "/" + item.FullPath;
                    string dropboxUrl = $"https://www.dropbox.com/home{remotePath}";
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = dropboxUrl,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo abrir la URL en el navegador: {ex.Message}", "Error al Abrir Navegador", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private BackupJobConfig? GetSelectedJob()
    {
        if (dgvJobs.SelectedRows.Count > 0)
        {
            return dgvJobs.SelectedRows[0].Tag as BackupJobConfig;
        }
        return null;
    }

    private async void btnNewJob_Click(object sender, EventArgs e)
    {
        using var editForm = new JobEditForm();
        if (editForm.ShowDialog(this) == DialogResult.OK)
        {
            await LoadJobsAsync();
        }
    }

    private async void btnEditJob_Click(object sender, EventArgs e)
    {
        var job = GetSelectedJob();
        if (job == null)
        {
            MessageBox.Show("Por favor seleccione una tarea de la lista para editar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var editForm = new JobEditForm(job);
        if (editForm.ShowDialog(this) == DialogResult.OK)
        {
            await LoadJobsAsync();
        }
    }

    private async void dgvJobs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            btnEditJob_Click(sender, e);
        }
    }

    private void btnRunNow_Click(object sender, EventArgs e)
    {
        var job = GetSelectedJob();
        if (job == null)
        {
            MessageBox.Show("Por favor seleccione una tarea para ejecutar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var confirm = MessageBox.Show(
            $"¿Desea disparar inmediatamente la tarea '{job.Name}' en el Programador de Tareas de Windows?",
            "Ejecutar Ahora",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (confirm == DialogResult.Yes)
        {
            var (success, message) = _taskService.RunTaskNow(job.Id);
            if (success)
            {
                MessageBox.Show(message, "Ejecución Iniciada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ = LoadJobsAsync();
            }
            else
            {
                MessageBox.Show(message, "Error al Ejecutar Tarea", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private async void btnDeleteJob_Click(object sender, EventArgs e)
    {
        var job = GetSelectedJob();
        if (job == null)
        {
            MessageBox.Show("Por favor seleccione una tarea para eliminar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var result = MessageBox.Show(
            $"¿Está seguro de que desea eliminar la tarea '{job.Name}'?\nEsto eliminará la configuración y desprogramará la tarea en Windows Task Scheduler.",
            "Confirmar Eliminación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        );

        if (result == DialogResult.Yes)
        {
            // 1. Eliminar de Task Scheduler
            _taskService.DeleteTask(job.Id);

            // 2. Eliminar JSON local
            await _repo.DeleteAsync(job.Id);

            // 3. Recargar lista
            await LoadJobsAsync();
        }
    }

    private async void btnRefresh_Click(object sender, EventArgs e)
    {
        await LoadJobsAsync();
    }

    private void btnViewLogs_Click(object sender, EventArgs e)
    {
        string logsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Backuper", "logs");
        try
        {
            if (!Directory.Exists(logsFolder))
            {
                Directory.CreateDirectory(logsFolder);
            }

            var job = GetSelectedJob();
            if (job != null)
            {
                string jobLog = Path.Combine(logsFolder, $"job_{job.Id:N}.log");
                if (File.Exists(jobLog))
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = jobLog,
                        UseShellExecute = true
                    });
                    return;
                }
            }

            // Abrir la carpeta de logs si no hay log específico seleccionado
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = logsFolder,
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show($"No se pudo abrir el registro de ejecuciones: {ex.Message}", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

internal class BackupFileItem
{
    public string FileName { get; set; } = string.Empty;
    public string JobName { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public bool IsLocal { get; set; }
    public long FileSizeBytes { get; set; }
    public DateTime CreatedTime { get; set; }
    public string FullPath { get; set; } = string.Empty;
}
