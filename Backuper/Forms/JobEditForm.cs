using Backuper.Models;
using Backuper.Services;

namespace Backuper.Forms;

public partial class JobEditForm : Form
{
    private readonly SqlServerService _sqlService = new();
    private readonly JobConfigRepository _repo = new();
    private readonly TaskSchedulerService _taskSchedulerService = new();

    public BackupJobConfig JobConfig { get; private set; }
    public bool IsEditMode { get; }

    /// <summary>
    /// Constructor sin parámetros requerido explícitamente por el Diseñador de Visual Studio.
    /// </summary>
    public JobEditForm() : this(null)
    {
    }

    public JobEditForm(BackupJobConfig? existingJob)
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

        if (existingJob != null)
        {
            JobConfig = existingJob;
            IsEditMode = true;
        }
        else
        {
            JobConfig = new BackupJobConfig();
            IsEditMode = false;
        }
    }

    private async void JobEditForm_Load(object sender, EventArgs e)
    {
        // Cargar enums en los combos
        cboBackupType.DataSource = new[]
        {
            new { Value = BackupType.Full, Text = "Respaldo Completo (Full)" },
            new { Value = BackupType.Differential, Text = "Respaldo Diferencial" },
            new { Value = BackupType.Log, Text = "Log de Transacciones" }
        };
        cboBackupType.DisplayMember = "Text";
        cboBackupType.ValueMember = "Value";

        cboCompression.DataSource = new[]
        {
            new { Value = CompressionType.Zip, Text = "Archivo Comprimido ZIP (.zip)" },
            new { Value = CompressionType.None, Text = "Sin Compresión (.bak plano)" },
            new { Value = CompressionType.SqlNative, Text = "Compresión Nativa de SQL Server" }
        };
        cboCompression.DisplayMember = "Text";
        cboCompression.ValueMember = "Value";

        cboRetentionMode.DataSource = new[]
        {
            new { Value = RetentionMode.ByCount, Text = "Por Cantidad (Conservar máximo N respaldos)" },
            new { Value = RetentionMode.ByAge, Text = "Por Antigüedad (Eliminar si supera X días)" },
            new { Value = RetentionMode.Both, Text = "Ambos (Por Días Y límite máximo de respaldos)" }
        };
        cboRetentionMode.DisplayMember = "Text";
        cboRetentionMode.ValueMember = "Value";

        cboFrequency.DataSource = new[]
        {
            new { Value = FrequencyType.Daily, Text = "Diario" },
            new { Value = FrequencyType.Weekly, Text = "Semanal" },
            new { Value = FrequencyType.Monthly, Text = "Mensual" }
        };
        cboFrequency.DisplayMember = "Text";
        cboFrequency.ValueMember = "Value";

        cboCloudProvider.DataSource = Enum.GetValues(typeof(CloudProviderType));

        // Cargar valores por defecto o del objeto a editar
        if (IsEditMode)
        {
            lblHeader.Text = "Editar Tarea de Respaldo";
            txtJobName.Text = JobConfig.Name;
            cboSqlServer.Text = JobConfig.SqlServer;

            if (JobConfig.SqlAuthType == AuthType.Windows)
            {
                rdoAuthWindows.Checked = true;
            }
            else
            {
                rdoAuthSql.Checked = true;
                txtSqlUser.Text = JobConfig.SqlUsername;
                txtSqlPassword.Text = CryptoService.Decrypt(JobConfig.SqlPasswordEncrypted);
            }

            cboDatabase.Text = JobConfig.DatabaseName;
            cboBackupType.SelectedValue = JobConfig.BackupType;
            cboCompression.SelectedValue = JobConfig.Compression;
            cboRetentionMode.SelectedValue = JobConfig.RetentionMode;
            numRetentionCount.Value = Math.Clamp(JobConfig.RetentionCount > 0 ? JobConfig.RetentionCount : 10, 1, 100);
            numRetentionDays.Value = Math.Clamp(JobConfig.RetentionDays > 0 ? JobConfig.RetentionDays : 30, 1, 365);
            chkRetentionLocal.Checked = JobConfig.RetentionApplyLocal;
            chkRetentionCloud.Checked = JobConfig.RetentionApplyCloud;
            txtLocalPath.Text = JobConfig.LocalDestinationPath;

            cboFrequency.SelectedValue = JobConfig.Frequency;
            dtpExecutionTime.Value = DateTime.Today.Add(JobConfig.ExecutionTime);
            numDayOfMonth.Value = Math.Clamp(JobConfig.DayOfMonth, 1, 31);

            SetWeeklyDaysCheckboxes(JobConfig.WeeklyDays);

            chkEnableCloud.Checked = JobConfig.EnableCloudUpload;
            cboCloudProvider.SelectedItem = JobConfig.CloudProvider;
            txtCloudToken.Text = CryptoService.Decrypt(JobConfig.CloudTokenEncrypted);
            txtCloudFolder.Text = JobConfig.CloudFolderPath ?? "/Backups";

            txtWindowsDomain.Text = JobConfig.WindowsDomainOrMachine ?? Environment.UserDomainName;
            txtWindowsUser.Text = JobConfig.WindowsUsername ?? Environment.UserName;
            txtWindowsPassword.Text = CryptoService.Decrypt(JobConfig.WindowsPasswordEncrypted);
        }
        else
        {
            lblHeader.Text = "Nueva Tarea de Respaldo";
            txtJobName.Text = $"Respaldo_{DateTime.Now:yyyyMMdd_HHmm}";
            txtLocalPath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BackupsSQL");
            txtWindowsDomain.Text = Environment.UserDomainName;
            txtWindowsUser.Text = Environment.UserName;
            dtpExecutionTime.Value = DateTime.Today.AddHours(2); // 02:00 AM

            await DiscoverSqlInstancesAsync();
        }

        UpdateVisibilityAndState();
    }

    private async Task DiscoverSqlInstancesAsync()
    {
        btnDiscoverInstances.Enabled = false;
        btnDiscoverInstances.Text = "Buscando...";
        try
        {
            var instances = await _sqlService.GetLocalInstancesAsync();
            cboSqlServer.Items.Clear();
            foreach (var inst in instances)
            {
                cboSqlServer.Items.Add(inst);
            }
            if (cboSqlServer.Items.Count > 0 && string.IsNullOrEmpty(cboSqlServer.Text))
            {
                cboSqlServer.SelectedIndex = 0;
            }
        }
        finally
        {
            btnDiscoverInstances.Enabled = true;
            btnDiscoverInstances.Text = "Buscar Instancias";
        }
    }

    private async void btnDiscoverInstances_Click(object sender, EventArgs e)
    {
        await DiscoverSqlInstancesAsync();
    }

    private void rdoAuth_CheckedChanged(object sender, EventArgs e)
    {
        bool isSqlAuth = rdoAuthSql.Checked;
        txtSqlUser.Enabled = isSqlAuth;
        txtSqlPassword.Enabled = isSqlAuth;
    }

    private async void btnTestSqlConnection_Click(object sender, EventArgs e)
    {
        string server = cboSqlServer.Text.Trim();
        AuthType authType = rdoAuthWindows.Checked ? AuthType.Windows : AuthType.SqlServer;
        string? user = rdoAuthSql.Checked ? txtSqlUser.Text.Trim() : null;
        string? pass = rdoAuthSql.Checked ? txtSqlPassword.Text : null;

        btnTestSqlConnection.Enabled = false;
        btnTestSqlConnection.Text = "Conectando...";

        try
        {
            var (success, message) = await _sqlService.TestConnectionAsync(server, authType, user, pass);
            if (!success)
            {
                MessageBox.Show(message, "Error de Conexión SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dbs = await _sqlService.GetDatabasesAsync(server, authType, user, pass);
            string selectedDb = cboDatabase.Text;
            cboDatabase.Items.Clear();
            foreach (var db in dbs)
            {
                cboDatabase.Items.Add(db);
            }

            if (!string.IsNullOrEmpty(selectedDb) && cboDatabase.Items.Contains(selectedDb))
            {
                cboDatabase.SelectedItem = selectedDb;
            }
            else if (cboDatabase.Items.Count > 0)
            {
                cboDatabase.SelectedIndex = 0;
            }

            MessageBox.Show($"{message}\nSe encontraron {dbs.Count} bases de datos activas.", "Conexión Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        finally
        {
            btnTestSqlConnection.Enabled = true;
            btnTestSqlConnection.Text = "Probar Conexión y Cargar BDs";
        }
    }

    private void btnBrowseFolder_Click(object sender, EventArgs e)
    {
        using var dialog = new FolderBrowserDialog();
        dialog.Description = "Seleccione la carpeta local de destino para los archivos .bak";
        dialog.UseDescriptionForTitle = true;
        if (!string.IsNullOrWhiteSpace(txtLocalPath.Text) && Directory.Exists(txtLocalPath.Text))
        {
            dialog.SelectedPath = txtLocalPath.Text;
        }

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            txtLocalPath.Text = dialog.SelectedPath;
        }
    }

    private void cboFrequency_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateVisibilityAndState();
    }

    private void cboRetentionMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateVisibilityAndState();
    }

    private void chkEnableCloud_CheckedChanged(object sender, EventArgs e)
    {
        UpdateVisibilityAndState();
    }

    private void UpdateVisibilityAndState()
    {
        if (cboFrequency.SelectedValue is FrequencyType frequency)
        {
            pnlWeeklyDays.Visible = frequency == FrequencyType.Weekly;
            lblDayOfMonth.Visible = frequency == FrequencyType.Monthly;
            numDayOfMonth.Visible = frequency == FrequencyType.Monthly;
        }

        if (cboRetentionMode.SelectedValue is RetentionMode retentionMode)
        {
            numRetentionCount.Enabled = retentionMode == RetentionMode.ByCount || retentionMode == RetentionMode.Both;
            numRetentionDays.Enabled = retentionMode == RetentionMode.ByAge || retentionMode == RetentionMode.Both;
        }

        bool cloudEnabled = chkEnableCloud.Checked;
        cboCloudProvider.Enabled = cloudEnabled;
        txtCloudToken.Enabled = cloudEnabled;
        txtCloudFolder.Enabled = cloudEnabled;
    }

    private List<DayOfWeek> GetWeeklyDaysFromCheckboxes()
    {
        var days = new List<DayOfWeek>();
        if (chkMon.Checked) days.Add(DayOfWeek.Monday);
        if (chkTue.Checked) days.Add(DayOfWeek.Tuesday);
        if (chkWed.Checked) days.Add(DayOfWeek.Wednesday);
        if (chkThu.Checked) days.Add(DayOfWeek.Thursday);
        if (chkFri.Checked) days.Add(DayOfWeek.Friday);
        if (chkSat.Checked) days.Add(DayOfWeek.Saturday);
        if (chkSun.Checked) days.Add(DayOfWeek.Sunday);
        return days;
    }

    private void SetWeeklyDaysCheckboxes(List<DayOfWeek> days)
    {
        if (days == null) return;
        chkMon.Checked = days.Contains(DayOfWeek.Monday);
        chkTue.Checked = days.Contains(DayOfWeek.Tuesday);
        chkWed.Checked = days.Contains(DayOfWeek.Wednesday);
        chkThu.Checked = days.Contains(DayOfWeek.Thursday);
        chkFri.Checked = days.Contains(DayOfWeek.Friday);
        chkSat.Checked = days.Contains(DayOfWeek.Saturday);
        chkSun.Checked = days.Contains(DayOfWeek.Sunday);
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        // Validaciones
        if (string.IsNullOrWhiteSpace(txtJobName.Text))
        {
            MessageBox.Show("Por favor ingrese un nombre para la tarea.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            tabControl.SelectedTab = tabSql;
            txtJobName.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(cboSqlServer.Text))
        {
            MessageBox.Show("Por favor especifique la instancia de SQL Server.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            tabControl.SelectedTab = tabSql;
            cboSqlServer.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(cboDatabase.Text))
        {
            MessageBox.Show("Por favor seleccione la base de datos a respaldar.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            tabControl.SelectedTab = tabSql;
            cboDatabase.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtLocalPath.Text))
        {
            MessageBox.Show("Por favor ingrese la carpeta de destino local para los respaldos.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            tabControl.SelectedTab = tabBackup;
            txtLocalPath.Focus();
            return;
        }

        // Crear carpeta destino si no existe
        try
        {
            if (!Directory.Exists(txtLocalPath.Text))
            {
                Directory.CreateDirectory(txtLocalPath.Text);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"No se pudo crear la carpeta destino: {ex.Message}", "Error de Carpeta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            tabControl.SelectedTab = tabBackup;
            return;
        }

        // Asignar propiedades
        JobConfig.Name = txtJobName.Text.Trim();
        JobConfig.SqlServer = cboSqlServer.Text.Trim();
        JobConfig.SqlAuthType = rdoAuthWindows.Checked ? AuthType.Windows : AuthType.SqlServer;
        JobConfig.SqlUsername = rdoAuthSql.Checked ? txtSqlUser.Text.Trim() : null;
        JobConfig.SqlPasswordEncrypted = rdoAuthSql.Checked ? CryptoService.Encrypt(txtSqlPassword.Text) : null;
        JobConfig.DatabaseName = cboDatabase.Text.Trim();

        JobConfig.BackupType = (BackupType)(cboBackupType.SelectedValue ?? BackupType.Full);
        JobConfig.Compression = (CompressionType)(cboCompression.SelectedValue ?? CompressionType.Zip);
        JobConfig.RetentionMode = (RetentionMode)(cboRetentionMode.SelectedValue ?? RetentionMode.ByCount);
        JobConfig.RetentionCount = Convert.ToInt32(numRetentionCount.Value);
        JobConfig.RetentionDays = Convert.ToInt32(numRetentionDays.Value);
        JobConfig.RetentionApplyLocal = chkRetentionLocal.Checked;
        JobConfig.RetentionApplyCloud = chkRetentionCloud.Checked;
        JobConfig.LocalDestinationPath = txtLocalPath.Text.Trim();

        JobConfig.Frequency = (FrequencyType)(cboFrequency.SelectedValue ?? FrequencyType.Daily);
        JobConfig.ExecutionTime = dtpExecutionTime.Value.TimeOfDay;
        JobConfig.WeeklyDays = GetWeeklyDaysFromCheckboxes();
        JobConfig.DayOfMonth = Convert.ToInt32(numDayOfMonth.Value);

        JobConfig.EnableCloudUpload = chkEnableCloud.Checked;
        JobConfig.CloudProvider = chkEnableCloud.Checked ? (CloudProviderType)(cboCloudProvider.SelectedItem ?? CloudProviderType.None) : CloudProviderType.None;
        JobConfig.CloudFolderPath = txtCloudFolder.Text.Trim();
        JobConfig.CloudTokenEncrypted = chkEnableCloud.Checked ? CryptoService.Encrypt(txtCloudToken.Text) : null;

        JobConfig.WindowsDomainOrMachine = txtWindowsDomain.Text.Trim();
        JobConfig.WindowsUsername = txtWindowsUser.Text.Trim();
        JobConfig.WindowsPasswordEncrypted = CryptoService.Encrypt(txtWindowsPassword.Text);

        // Guardar configuración local en JSON cifrado con DPAPI
        await _repo.SaveAsync(JobConfig);

        // Registrar en Task Scheduler de Windows
        var (taskSuccess, taskMessage) = _taskSchedulerService.CreateOrUpdateTask(JobConfig);
        if (!taskSuccess)
        {
            MessageBox.Show($"Se guardó la configuración local, pero hubo un detalle al registrar en Windows Task Scheduler:\n\n{taskMessage}", "Advertencia de Task Scheduler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
