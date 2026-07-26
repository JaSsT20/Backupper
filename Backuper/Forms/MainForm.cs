using System.Diagnostics;
using Backuper.Models;
using Backuper.Services;
using Dropbox.Api;

namespace Backuper.Forms;

public partial class MainForm : Form
{
    private readonly JobConfigRepository _repo = new();
    private readonly AppConfigRepository _appConfigRepo = new();
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

        cboSetBackupType.DataSource = new[]
        {
            new { Value = BackupType.Full, Text = "Respaldo Completo (Full)" },
            new { Value = BackupType.Differential, Text = "Respaldo Diferencial" },
            new { Value = BackupType.Log, Text = "Log de Transacciones" }
        };
        cboSetBackupType.DisplayMember = "Text";
        cboSetBackupType.ValueMember = "Value";

        cboSetCompression.DataSource = new[]
        {
            new { Value = CompressionType.Zip, Text = "Archivo Comprimido ZIP (.zip)" },
            new { Value = CompressionType.None, Text = "Sin Compresión (.bak plano)" },
            new { Value = CompressionType.SqlNative, Text = "Compresión Nativa de SQL Server" }
        };
        cboSetCompression.DisplayMember = "Text";
        cboSetCompression.ValueMember = "Value";

        await LoadAppSettingsAsync();
        await LoadJobsAsync();
    }

    private async Task LoadAppSettingsAsync()
    {
        try
        {
            var config = await _appConfigRepo.LoadAsync();
            txtSetSqlServer.Text = config.DefaultSqlServer;
            if (config.DefaultSqlAuthType == AuthType.Windows)
            {
                rdoSetAuthWindows.Checked = true;
            }
            else
            {
                rdoSetAuthSql.Checked = true;
                txtSetSqlUser.Text = config.DefaultSqlUsername;
                txtSetSqlPassword.Text = CryptoService.Decrypt(config.DefaultSqlPasswordEncrypted);
            }
            txtSetSqlDatabase.Text = config.DefaultDatabaseName;

            txtSetLocalPath.Text = config.DefaultLocalDestinationPath;
            cboSetBackupType.SelectedValue = config.DefaultBackupType;
            cboSetCompression.SelectedValue = config.DefaultCompression;

            chkSetEnableCloud.Checked = config.DefaultEnableCloudUpload;
            txtSetCloudToken.Text = CryptoService.Decrypt(config.DefaultCloudTokenEncrypted);
            txtSetCloudFolder.Text = config.DefaultCloudFolderPath;

            txtSetWindowsDomain.Text = config.DefaultWindowsDomainOrMachine;
            txtSetWindowsUser.Text = config.DefaultWindowsUsername;
            txtSetWindowsPassword.Text = CryptoService.Decrypt(config.DefaultWindowsPasswordEncrypted);
        }
        catch { }
    }

    private void rdoSetAuth_CheckedChanged(object sender, EventArgs e)
    {
        bool isSql = rdoSetAuthSql.Checked;
        txtSetSqlUser.Enabled = isSql;
        txtSetSqlPassword.Enabled = isSql;
    }

    private void btnSetBrowseFolder_Click(object sender, EventArgs e)
    {
        using var dialog = new FolderBrowserDialog();
        dialog.Description = "Seleccione la carpeta local por defecto para los respaldos";
        dialog.UseDescriptionForTitle = true;
        if (!string.IsNullOrWhiteSpace(txtSetLocalPath.Text) && Directory.Exists(txtSetLocalPath.Text))
        {
            dialog.SelectedPath = txtSetLocalPath.Text;
        }

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            txtSetLocalPath.Text = dialog.SelectedPath;
        }
    }

    private async void btnSaveSettings_Click(object sender, EventArgs e)
    {
        try
        {
            var config = new AppConfig
            {
                DefaultSqlServer = txtSetSqlServer.Text.Trim(),
                DefaultSqlAuthType = rdoSetAuthWindows.Checked ? AuthType.Windows : AuthType.SqlServer,
                DefaultSqlUsername = rdoSetAuthSql.Checked ? txtSetSqlUser.Text.Trim() : null,
                DefaultSqlPasswordEncrypted = rdoSetAuthSql.Checked ? CryptoService.Encrypt(txtSetSqlPassword.Text) : null,
                DefaultDatabaseName = txtSetSqlDatabase.Text.Trim(),

                DefaultLocalDestinationPath = txtSetLocalPath.Text.Trim(),
                DefaultBackupType = (BackupType)(cboSetBackupType.SelectedValue ?? BackupType.Full),
                DefaultCompression = (CompressionType)(cboSetCompression.SelectedValue ?? CompressionType.Zip),

                DefaultEnableCloudUpload = chkSetEnableCloud.Checked,
                DefaultCloudProvider = CloudProviderType.Dropbox,
                DefaultCloudFolderPath = txtSetCloudFolder.Text.Trim(),
                DefaultCloudTokenEncrypted = CryptoService.Encrypt(txtSetCloudToken.Text),

                DefaultWindowsDomainOrMachine = txtSetWindowsDomain.Text.Trim(),
                DefaultWindowsUsername = txtSetWindowsUser.Text.Trim(),
                DefaultWindowsPasswordEncrypted = CryptoService.Encrypt(txtSetWindowsPassword.Text)
            };

            await _appConfigRepo.SaveAsync(config);
            MessageBox.Show("Configuración General guardada correctamente.\n\nTodos los nuevos respaldos que cree se precargarán automáticamente con esta información.", "Ajustes Guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al guardar los ajustes: {ex.Message}", "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnNavDashboard_Click(object sender, EventArgs e)
    {
        SwitchView(1);
    }

    private async void btnNavExplorer_Click(object sender, EventArgs e)
    {
        SwitchView(2);
        await LoadBackupFilesAsync();
    }

    private void btnNavSettings_Click(object sender, EventArgs e)
    {
        SwitchView(3);
    }

    private void SwitchView(int viewIndex)
    {
        // 1: Dashboard, 2: Explorer, 3: Settings
        pnlViewDashboard.Visible = (viewIndex == 1);
        pnlViewExplorer.Visible = (viewIndex == 2);
        pnlViewSettings.Visible = (viewIndex == 3);

        btnNavDashboard.BackColor = Color.FromArgb(15, 23, 42);
        btnNavDashboard.ForeColor = Color.FromArgb(203, 213, 225);
        btnNavDashboard.Font = new Font("Segoe UI", 10F);

        btnNavExplorer.BackColor = Color.FromArgb(15, 23, 42);
        btnNavExplorer.ForeColor = Color.FromArgb(203, 213, 225);
        btnNavExplorer.Font = new Font("Segoe UI", 10F);

        btnNavSettings.BackColor = Color.FromArgb(15, 23, 42);
        btnNavSettings.ForeColor = Color.FromArgb(203, 213, 225);
        btnNavSettings.Font = new Font("Segoe UI", 10F);

        if (viewIndex == 1)
        {
            btnNavDashboard.BackColor = Color.FromArgb(30, 41, 59);
            btnNavDashboard.ForeColor = Color.FromArgb(56, 189, 248);
            btnNavDashboard.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

            lblPageTitle.Text = "Dashboard de Respaldos";
            lblPageSubtitle.Text = "Gestión y programación desatendida de bases de datos Microsoft SQL Server.";
        }
        else if (viewIndex == 2)
        {
            btnNavExplorer.BackColor = Color.FromArgb(30, 41, 59);
            btnNavExplorer.ForeColor = Color.FromArgb(56, 189, 248);
            btnNavExplorer.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

            lblPageTitle.Text = "Explorador de Archivos";
            lblPageSubtitle.Text = "Examine los respaldos generados en su disco local o sincronizados en Dropbox.";
        }
        else if (viewIndex == 3)
        {
            btnNavSettings.BackColor = Color.FromArgb(30, 41, 59);
            btnNavSettings.ForeColor = Color.FromArgb(56, 189, 248);
            btnNavSettings.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

            lblPageTitle.Text = "Configuración General";
            lblPageSubtitle.Text = "Ajustes y valores predeterminados para la creación automática de nuevos respaldos.";
        }
    }

    private async Task LoadJobsAsync()
    {
        btnGlobalRefresh.Enabled = false;
        try
        {
            _jobs = await _repo.GetAllAsync();
            dgvJobs.Rows.Clear();

            DateTime? earliestNextRun = null;

            foreach (var job in _jobs)
            {
                var taskInfo = _taskService.GetTaskInfo(job.Id);

                string lastRun = taskInfo.LastRunTime.HasValue 
                    ? taskInfo.LastRunTime.Value.ToString("dd/MM/yyyy HH:mm") 
                    : "Nunca";
                string nextRun = taskInfo.NextRunTime.HasValue 
                    ? taskInfo.NextRunTime.Value.ToString("dd/MM/yyyy HH:mm") 
                    : "No programada";

                if (taskInfo.NextRunTime.HasValue)
                {
                    if (!earliestNextRun.HasValue || taskInfo.NextRunTime.Value < earliestNextRun.Value)
                    {
                        earliestNextRun = taskInfo.NextRunTime.Value;
                    }
                }

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

            // Actualizar Métricas KPI en las Stat Cards
            lblStatTotalValue.Text = _jobs.Count.ToString();
            int activeJobsCount = _jobs.Count(j => j.IsActive);
            lblStatActiveValue.Text = activeJobsCount.ToString();
            
            bool hasCloud = _jobs.Any(j => j.EnableCloudUpload && j.IsActive);
            lblStatCloudValue.Text = hasCloud ? "Conectado" : "Inactivo";
            lblStatCloudValue.ForeColor = hasCloud ? Color.FromArgb(37, 99, 235) : Color.FromArgb(148, 163, 184);

            lblStatNextValue.Text = earliestNextRun.HasValue ? earliestNextRun.Value.ToString("dd/MM HH:mm") : "Sin Tareas";

            lblStatusCount.Text = $"Tareas configuradas: {_jobs.Count} | Activas: {activeJobsCount}";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar las tareas de respaldo: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnGlobalRefresh.Enabled = true;
        }
    }

    private void dgvJobs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == colTaskStatus.Index && e.Value != null && e.CellStyle != null)
        {
            string status = e.Value.ToString() ?? "";
            if (status.Contains("Listo", StringComparison.OrdinalIgnoreCase) || status.Contains("Ready", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                e.CellStyle.ForeColor = Color.FromArgb(22, 101, 52);
                e.CellStyle.SelectionBackColor = Color.FromArgb(187, 247, 208);
                e.CellStyle.SelectionForeColor = Color.FromArgb(22, 101, 52);
                e.CellStyle.Font = new Font(dgvJobs.Font, FontStyle.Bold);
            }
            else if (status.Contains("Ejecutando", StringComparison.OrdinalIgnoreCase) || status.Contains("Running", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.BackColor = Color.FromArgb(219, 234, 254);
                e.CellStyle.ForeColor = Color.FromArgb(30, 64, 175);
                e.CellStyle.SelectionBackColor = Color.FromArgb(191, 219, 254);
                e.CellStyle.SelectionForeColor = Color.FromArgb(30, 64, 175);
                e.CellStyle.Font = new Font(dgvJobs.Font, FontStyle.Bold);
            }
            else if (status.Contains("No Programada", StringComparison.OrdinalIgnoreCase) || status.Contains("Deshabilitada", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.BackColor = Color.FromArgb(254, 243, 199);
                e.CellStyle.ForeColor = Color.FromArgb(146, 64, 14);
                e.CellStyle.SelectionBackColor = Color.FromArgb(253, 230, 138);
                e.CellStyle.SelectionForeColor = Color.FromArgb(146, 64, 14);
                e.CellStyle.Font = new Font(dgvJobs.Font, FontStyle.Bold);
            }
        }
    }

    private void dgvBackupFiles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == colFileLocation.Index && e.Value != null && e.CellStyle != null)
        {
            string loc = e.Value.ToString() ?? "";
            if (loc.Contains("Local", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.BackColor = Color.FromArgb(240, 253, 244);
                e.CellStyle.ForeColor = Color.FromArgb(22, 101, 52);
                e.CellStyle.Font = new Font(dgvBackupFiles.Font, FontStyle.Bold);
            }
            else if (loc.Contains("Dropbox", StringComparison.OrdinalIgnoreCase) || loc.Contains("Nube", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.BackColor = Color.FromArgb(239, 246, 255);
                e.CellStyle.ForeColor = Color.FromArgb(29, 78, 216);
                e.CellStyle.Font = new Font(dgvBackupFiles.Font, FontStyle.Bold);
            }
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

    private async void btnDuplicateJob_Click(object sender, EventArgs e)
    {
        var selectedJob = GetSelectedJob();
        if (selectedJob == null)
        {
            MessageBox.Show("Por favor seleccione una tarea de la lista para duplicar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var clonedJob = new BackupJobConfig
        {
            Id = Guid.NewGuid(),
            Name = $"{selectedJob.Name}_Copia",
            SqlServer = selectedJob.SqlServer,
            SqlAuthType = selectedJob.SqlAuthType,
            SqlUsername = selectedJob.SqlUsername,
            SqlPasswordEncrypted = selectedJob.SqlPasswordEncrypted,
            DatabaseName = selectedJob.DatabaseName,
            BackupType = selectedJob.BackupType,
            Compression = selectedJob.Compression,
            RetentionMode = selectedJob.RetentionMode,
            RetentionCount = selectedJob.RetentionCount,
            RetentionDays = selectedJob.RetentionDays,
            RetentionApplyLocal = selectedJob.RetentionApplyLocal,
            RetentionApplyCloud = selectedJob.RetentionApplyCloud,
            LocalDestinationPath = selectedJob.LocalDestinationPath,
            Frequency = selectedJob.Frequency,
            ExecutionTime = selectedJob.ExecutionTime,
            WeeklyDays = selectedJob.WeeklyDays != null ? new List<DayOfWeek>(selectedJob.WeeklyDays) : new List<DayOfWeek>(),
            DayOfMonth = selectedJob.DayOfMonth,
            EnableCloudUpload = selectedJob.EnableCloudUpload,
            CloudProvider = selectedJob.CloudProvider,
            CloudFolderPath = selectedJob.CloudFolderPath,
            CloudTokenEncrypted = selectedJob.CloudTokenEncrypted,
            WindowsDomainOrMachine = selectedJob.WindowsDomainOrMachine,
            WindowsUsername = selectedJob.WindowsUsername,
            WindowsPasswordEncrypted = selectedJob.WindowsPasswordEncrypted
        };

        using var editForm = new JobEditForm(clonedJob, isDuplicateMode: true);
        if (editForm.ShowDialog(this) == DialogResult.OK)
        {
            await LoadJobsAsync();
        }
    }

    private void dgvJobs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
            _taskService.DeleteTask(job.Id);
            await _repo.DeleteAsync(job.Id);
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
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = jobLog,
                        UseShellExecute = true
                    });
                    return;
                }
            }

            Process.Start(new ProcessStartInfo
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
