namespace Backuper.Forms;

partial class JobEditForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        lblHeader = new Label();
        lblSubHeader = new Label();
        pnlHeader = new Panel();
        tabControl = new TabControl();
        tabSql = new TabPage();
        btnTestSqlConnection = new Button();
        btnDiscoverInstances = new Button();
        cboDatabase = new ComboBox();
        lblDatabase = new Label();
        txtSqlPassword = new TextBox();
        lblSqlPassword = new Label();
        txtSqlUser = new TextBox();
        lblSqlUser = new Label();
        rdoAuthSql = new RadioButton();
        rdoAuthWindows = new RadioButton();
        lblAuth = new Label();
        cboSqlServer = new ComboBox();
        lblSqlServer = new Label();
        txtJobName = new TextBox();
        lblJobName = new Label();
        tabBackup = new TabPage();
        lblCompression = new Label();
        cboCompression = new ComboBox();
        lblRetentionMode = new Label();
        cboRetentionMode = new ComboBox();
        lblRetentionCount = new Label();
        numRetentionCount = new NumericUpDown();
        lblRetentionDays = new Label();
        numRetentionDays = new NumericUpDown();
        chkRetentionLocal = new CheckBox();
        chkRetentionCloud = new CheckBox();
        btnBrowseFolder = new Button();
        txtLocalPath = new TextBox();
        lblLocalPath = new Label();
        cboBackupType = new ComboBox();
        lblBackupType = new Label();
        tabSchedule = new TabPage();
        pnlWeeklyDays = new Panel();
        chkSun = new CheckBox();
        chkSat = new CheckBox();
        chkFri = new CheckBox();
        chkThu = new CheckBox();
        chkWed = new CheckBox();
        chkTue = new CheckBox();
        chkMon = new CheckBox();
        lblWeeklyDays = new Label();
        numDayOfMonth = new NumericUpDown();
        lblDayOfMonth = new Label();
        dtpExecutionTime = new DateTimePicker();
        lblExecutionTime = new Label();
        cboFrequency = new ComboBox();
        lblFrequency = new Label();
        tabCloud = new TabPage();
        txtCloudFolder = new TextBox();
        lblCloudFolder = new Label();
        txtCloudToken = new TextBox();
        lblCloudToken = new Label();
        cboCloudProvider = new ComboBox();
        lblCloudProvider = new Label();
        chkEnableCloud = new CheckBox();
        tabWindows = new TabPage();
        lblWindowsHelp = new Label();
        txtWindowsPassword = new TextBox();
        lblWindowsPassword = new Label();
        txtWindowsUser = new TextBox();
        lblWindowsUser = new Label();
        txtWindowsDomain = new TextBox();
        lblWindowsDomain = new Label();
        pnlBottom = new Panel();
        btnCancel = new Button();
        btnSave = new Button();
        pnlHeader.SuspendLayout();
        tabControl.SuspendLayout();
        tabSql.SuspendLayout();
        tabBackup.SuspendLayout();
        tabSchedule.SuspendLayout();
        pnlWeeklyDays.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numDayOfMonth).BeginInit();
        tabCloud.SuspendLayout();
        tabWindows.SuspendLayout();
        pnlBottom.SuspendLayout();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.FromArgb(24, 119, 242);
        pnlHeader.Controls.Add(lblSubHeader);
        pnlHeader.Controls.Add(lblHeader);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Size = new Size(684, 70);
        pnlHeader.TabIndex = 0;
        // 
        // lblHeader
        // 
        lblHeader.AutoSize = true;
        lblHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblHeader.ForeColor = Color.White;
        lblHeader.Location = new Point(20, 12);
        lblHeader.Name = "lblHeader";
        lblHeader.Size = new Size(328, 25);
        lblHeader.TabIndex = 0;
        lblHeader.Text = "Configurar Tarea de Respaldo SQL";
        // 
        // lblSubHeader
        // 
        lblSubHeader.AutoSize = true;
        lblSubHeader.Font = new Font("Segoe UI", 9.5F);
        lblSubHeader.ForeColor = Color.FromArgb(225, 235, 255);
        lblSubHeader.Location = new Point(22, 40);
        lblSubHeader.Name = "lblSubHeader";
        lblSubHeader.Size = new Size(495, 17);
        lblSubHeader.TabIndex = 1;
        lblSubHeader.Text = "Defina la conexión, horario de ejecución y credenciales para el respaldo automático.";
        // 
        // tabControl
        // 
        tabControl.Controls.Add(tabSql);
        tabControl.Controls.Add(tabBackup);
        tabControl.Controls.Add(tabSchedule);
        tabControl.Controls.Add(tabCloud);
        tabControl.Controls.Add(tabWindows);
        tabControl.Dock = DockStyle.Fill;
        tabControl.Font = new Font("Segoe UI", 9.5F);
        tabControl.Location = new Point(0, 70);
        tabControl.Name = "tabControl";
        tabControl.SelectedIndex = 0;
        tabControl.Size = new Size(684, 410);
        tabControl.TabIndex = 1;
        // 
        // tabSql
        // 
        tabSql.Controls.Add(btnTestSqlConnection);
        tabSql.Controls.Add(btnDiscoverInstances);
        tabSql.Controls.Add(cboDatabase);
        tabSql.Controls.Add(lblDatabase);
        tabSql.Controls.Add(txtSqlPassword);
        tabSql.Controls.Add(lblSqlPassword);
        tabSql.Controls.Add(txtSqlUser);
        tabSql.Controls.Add(lblSqlUser);
        tabSql.Controls.Add(rdoAuthSql);
        tabSql.Controls.Add(rdoAuthWindows);
        tabSql.Controls.Add(lblAuth);
        tabSql.Controls.Add(cboSqlServer);
        tabSql.Controls.Add(lblSqlServer);
        tabSql.Controls.Add(txtJobName);
        tabSql.Controls.Add(lblJobName);
        tabSql.Location = new Point(4, 26);
        tabSql.Name = "tabSql";
        tabSql.Padding = new Padding(20);
        tabSql.Size = new Size(676, 380);
        tabSql.TabIndex = 0;
        tabSql.Text = "1. Servidor SQL y BD";
        tabSql.UseVisualStyleBackColor = true;
        // 
        // lblJobName
        // 
        lblJobName.AutoSize = true;
        lblJobName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblJobName.Location = new Point(23, 20);
        lblJobName.Name = "lblJobName";
        lblJobName.Size = new Size(137, 17);
        lblJobName.TabIndex = 0;
        lblJobName.Text = "Nombre de la Tarea:";
        // 
        // txtJobName
        // 
        txtJobName.Location = new Point(170, 17);
        txtJobName.Name = "txtJobName";
        txtJobName.Size = new Size(470, 24);
        txtJobName.TabIndex = 1;
        // 
        // lblSqlServer
        // 
        lblSqlServer.AutoSize = true;
        lblSqlServer.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblSqlServer.Location = new Point(23, 60);
        lblSqlServer.Name = "lblSqlServer";
        lblSqlServer.Size = new Size(131, 17);
        lblSqlServer.TabIndex = 2;
        lblSqlServer.Text = "Servidor SQL Server:";
        // 
        // cboSqlServer
        // 
        cboSqlServer.FormattingEnabled = true;
        cboSqlServer.Location = new Point(170, 57);
        cboSqlServer.Name = "cboSqlServer";
        cboSqlServer.Size = new Size(330, 25);
        cboSqlServer.TabIndex = 3;
        // 
        // btnDiscoverInstances
        // 
        btnDiscoverInstances.Location = new Point(510, 56);
        btnDiscoverInstances.Name = "btnDiscoverInstances";
        btnDiscoverInstances.Size = new Size(130, 27);
        btnDiscoverInstances.TabIndex = 4;
        btnDiscoverInstances.Text = "Buscar Instancias";
        btnDiscoverInstances.UseVisualStyleBackColor = true;
        btnDiscoverInstances.Click += btnDiscoverInstances_Click;
        // 
        // lblAuth
        // 
        lblAuth.AutoSize = true;
        lblAuth.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblAuth.Location = new Point(23, 105);
        lblAuth.Name = "lblAuth";
        lblAuth.Size = new Size(97, 17);
        lblAuth.TabIndex = 5;
        lblAuth.Text = "Autenticación:";
        // 
        // rdoAuthWindows
        // 
        rdoAuthWindows.AutoSize = true;
        rdoAuthWindows.Checked = true;
        rdoAuthWindows.Location = new Point(170, 103);
        rdoAuthWindows.Name = "rdoAuthWindows";
        rdoAuthWindows.Size = new Size(183, 21);
        rdoAuthWindows.TabIndex = 6;
        rdoAuthWindows.TabStop = true;
        rdoAuthWindows.Text = "Autenticación de Windows";
        rdoAuthWindows.UseVisualStyleBackColor = true;
        rdoAuthWindows.CheckedChanged += rdoAuth_CheckedChanged;
        // 
        // rdoAuthSql
        // 
        rdoAuthSql.AutoSize = true;
        rdoAuthSql.Location = new Point(370, 103);
        rdoAuthSql.Name = "rdoAuthSql";
        rdoAuthSql.Size = new Size(191, 21);
        rdoAuthSql.TabIndex = 7;
        rdoAuthSql.Text = "Autenticación de SQL Server";
        rdoAuthSql.UseVisualStyleBackColor = true;
        rdoAuthSql.CheckedChanged += rdoAuth_CheckedChanged;
        // 
        // lblSqlUser
        // 
        lblSqlUser.AutoSize = true;
        lblSqlUser.Location = new Point(40, 145);
        lblSqlUser.Name = "lblSqlUser";
        lblSqlUser.Size = new Size(56, 17);
        lblSqlUser.TabIndex = 8;
        lblSqlUser.Text = "Usuario:";
        // 
        // txtSqlUser
        // 
        txtSqlUser.Enabled = false;
        txtSqlUser.Location = new Point(170, 142);
        txtSqlUser.Name = "txtSqlUser";
        txtSqlUser.Size = new Size(200, 24);
        txtSqlUser.TabIndex = 9;
        // 
        // lblSqlPassword
        // 
        lblSqlPassword.AutoSize = true;
        lblSqlPassword.Location = new Point(385, 145);
        lblSqlPassword.Name = "lblSqlPassword";
        lblSqlPassword.Size = new Size(77, 17);
        lblSqlPassword.TabIndex = 10;
        lblSqlPassword.Text = "Contraseña:";
        // 
        // txtSqlPassword
        // 
        txtSqlPassword.Enabled = false;
        txtSqlPassword.Location = new Point(470, 142);
        txtSqlPassword.Name = "txtSqlPassword";
        txtSqlPassword.UseSystemPasswordChar = true;
        txtSqlPassword.Size = new Size(170, 24);
        txtSqlPassword.TabIndex = 11;
        // 
        // lblDatabase
        // 
        lblDatabase.AutoSize = true;
        lblDatabase.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblDatabase.Location = new Point(23, 195);
        lblDatabase.Name = "lblDatabase";
        lblDatabase.Size = new Size(100, 17);
        lblDatabase.TabIndex = 12;
        lblDatabase.Text = "Base de Datos:";
        // 
        // cboDatabase
        // 
        cboDatabase.FormattingEnabled = true;
        cboDatabase.Location = new Point(170, 192);
        cboDatabase.Name = "cboDatabase";
        cboDatabase.Size = new Size(330, 25);
        cboDatabase.TabIndex = 13;
        // 
        // btnTestSqlConnection
        // 
        btnTestSqlConnection.BackColor = Color.FromArgb(235, 242, 255);
        btnTestSqlConnection.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnTestSqlConnection.ForeColor = Color.FromArgb(24, 119, 242);
        btnTestSqlConnection.Location = new Point(170, 235);
        btnTestSqlConnection.Name = "btnTestSqlConnection";
        btnTestSqlConnection.Size = new Size(220, 32);
        btnTestSqlConnection.TabIndex = 14;
        btnTestSqlConnection.Text = "Probar Conexión y Cargar BDs";
        btnTestSqlConnection.UseVisualStyleBackColor = false;
        btnTestSqlConnection.Click += btnTestSqlConnection_Click;
        // 
        // tabBackup
        // 
        tabBackup.Controls.Add(chkRetentionCloud);
        tabBackup.Controls.Add(chkRetentionLocal);
        tabBackup.Controls.Add(numRetentionDays);
        tabBackup.Controls.Add(lblRetentionDays);
        tabBackup.Controls.Add(numRetentionCount);
        tabBackup.Controls.Add(lblRetentionCount);
        tabBackup.Controls.Add(cboRetentionMode);
        tabBackup.Controls.Add(lblRetentionMode);
        tabBackup.Controls.Add(cboCompression);
        tabBackup.Controls.Add(lblCompression);
        tabBackup.Controls.Add(btnBrowseFolder);
        tabBackup.Controls.Add(txtLocalPath);
        tabBackup.Controls.Add(lblLocalPath);
        tabBackup.Controls.Add(cboBackupType);
        tabBackup.Controls.Add(lblBackupType);
        tabBackup.Location = new Point(4, 26);
        tabBackup.Name = "tabBackup";
        tabBackup.Padding = new Padding(20);
        tabBackup.Size = new Size(676, 380);
        tabBackup.TabIndex = 1;
        tabBackup.Text = "2. Tipo, Destino y Limpieza";
        tabBackup.UseVisualStyleBackColor = true;
        // 
        // lblBackupType
        // 
        lblBackupType.AutoSize = true;
        lblBackupType.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblBackupType.Location = new Point(23, 20);
        lblBackupType.Name = "lblBackupType";
        lblBackupType.Size = new Size(116, 17);
        lblBackupType.TabIndex = 0;
        lblBackupType.Text = "Tipo de Respaldo:";
        // 
        // cboBackupType
        // 
        cboBackupType.DropDownStyle = ComboBoxStyle.DropDownList;
        cboBackupType.FormattingEnabled = true;
        cboBackupType.Location = new Point(190, 17);
        cboBackupType.Name = "cboBackupType";
        cboBackupType.Size = new Size(320, 25);
        cboBackupType.TabIndex = 1;
        // 
        // lblCompression
        // 
        lblCompression.AutoSize = true;
        lblCompression.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblCompression.Location = new Point(23, 58);
        lblCompression.Name = "lblCompression";
        lblCompression.Size = new Size(84, 17);
        lblCompression.TabIndex = 2;
        lblCompression.Text = "Compresión:";
        // 
        // cboCompression
        // 
        cboCompression.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCompression.FormattingEnabled = true;
        cboCompression.Location = new Point(190, 55);
        cboCompression.Name = "cboCompression";
        cboCompression.Size = new Size(320, 25);
        cboCompression.TabIndex = 3;
        // 
        // lblRetentionMode
        // 
        lblRetentionMode.AutoSize = true;
        lblRetentionMode.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblRetentionMode.Location = new Point(23, 96);
        lblRetentionMode.Name = "lblRetentionMode";
        lblRetentionMode.Size = new Size(157, 17);
        lblRetentionMode.TabIndex = 4;
        lblRetentionMode.Text = "Regla de Limpieza / Retención:";
        // 
        // cboRetentionMode
        // 
        cboRetentionMode.DropDownStyle = ComboBoxStyle.DropDownList;
        cboRetentionMode.FormattingEnabled = true;
        cboRetentionMode.Location = new Point(190, 93);
        cboRetentionMode.Name = "cboRetentionMode";
        cboRetentionMode.Size = new Size(320, 25);
        cboRetentionMode.TabIndex = 5;
        cboRetentionMode.SelectedIndexChanged += cboRetentionMode_SelectedIndexChanged;
        // 
        // lblRetentionCount
        // 
        lblRetentionCount.AutoSize = true;
        lblRetentionCount.Location = new Point(40, 133);
        lblRetentionCount.Name = "lblRetentionCount";
        lblRetentionCount.Size = new Size(138, 17);
        lblRetentionCount.TabIndex = 6;
        lblRetentionCount.Text = "Máximo de Respaldos:";
        // 
        // numRetentionCount
        // 
        numRetentionCount.Location = new Point(190, 130);
        numRetentionCount.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
        numRetentionCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numRetentionCount.Name = "numRetentionCount";
        numRetentionCount.Size = new Size(80, 24);
        numRetentionCount.TabIndex = 7;
        numRetentionCount.Value = new decimal(new int[] { 10, 0, 0, 0 });
        // 
        // lblRetentionDays
        // 
        lblRetentionDays.AutoSize = true;
        lblRetentionDays.Location = new Point(290, 133);
        lblRetentionDays.Name = "lblRetentionDays";
        lblRetentionDays.Size = new Size(129, 17);
        lblRetentionDays.TabIndex = 8;
        lblRetentionDays.Text = "Máx. Antigüedad (Días):";
        // 
        // numRetentionDays
        // 
        numRetentionDays.Location = new Point(430, 130);
        numRetentionDays.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
        numRetentionDays.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numRetentionDays.Name = "numRetentionDays";
        numRetentionDays.Size = new Size(80, 24);
        numRetentionDays.TabIndex = 9;
        numRetentionDays.Value = new decimal(new int[] { 30, 0, 0, 0 });
        // 
        // chkRetentionLocal
        // 
        chkRetentionLocal.AutoSize = true;
        chkRetentionLocal.Checked = true;
        chkRetentionLocal.CheckState = CheckState.Checked;
        chkRetentionLocal.Location = new Point(190, 165);
        chkRetentionLocal.Name = "chkRetentionLocal";
        chkRetentionLocal.Size = new Size(198, 21);
        chkRetentionLocal.TabIndex = 10;
        chkRetentionLocal.Text = "Aplicar limpieza en disco local";
        chkRetentionLocal.UseVisualStyleBackColor = true;
        // 
        // chkRetentionCloud
        // 
        chkRetentionCloud.AutoSize = true;
        chkRetentionCloud.Checked = true;
        chkRetentionCloud.CheckState = CheckState.Checked;
        chkRetentionCloud.Location = new Point(400, 165);
        chkRetentionCloud.Name = "chkRetentionCloud";
        chkRetentionCloud.Size = new Size(207, 21);
        chkRetentionCloud.TabIndex = 11;
        chkRetentionCloud.Text = "Aplicar limpieza en Dropbox";
        chkRetentionCloud.UseVisualStyleBackColor = true;
        // 
        // lblLocalPath
        // 
        lblLocalPath.AutoSize = true;
        lblLocalPath.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblLocalPath.Location = new Point(23, 205);
        lblLocalPath.Name = "lblLocalPath";
        lblLocalPath.Size = new Size(150, 17);
        lblLocalPath.TabIndex = 12;
        lblLocalPath.Text = "Carpeta Destino Local:";
        // 
        // txtLocalPath
        // 
        txtLocalPath.Location = new Point(190, 202);
        txtLocalPath.Name = "txtLocalPath";
        txtLocalPath.Size = new Size(350, 24);
        txtLocalPath.TabIndex = 13;
        // 
        // btnBrowseFolder
        // 
        btnBrowseFolder.Location = new Point(550, 201);
        btnBrowseFolder.Name = "btnBrowseFolder";
        btnBrowseFolder.Size = new Size(95, 27);
        btnBrowseFolder.TabIndex = 14;
        btnBrowseFolder.Text = "Examinar...";
        btnBrowseFolder.UseVisualStyleBackColor = true;
        btnBrowseFolder.Click += btnBrowseFolder_Click;
        // 
        // tabSchedule
        // 
        tabSchedule.Controls.Add(pnlWeeklyDays);
        tabSchedule.Controls.Add(numDayOfMonth);
        tabSchedule.Controls.Add(lblDayOfMonth);
        tabSchedule.Controls.Add(dtpExecutionTime);
        tabSchedule.Controls.Add(lblExecutionTime);
        tabSchedule.Controls.Add(cboFrequency);
        tabSchedule.Controls.Add(lblFrequency);
        tabSchedule.Location = new Point(4, 26);
        tabSchedule.Name = "tabSchedule";
        tabSchedule.Padding = new Padding(20);
        tabSchedule.Size = new Size(676, 380);
        tabSchedule.TabIndex = 2;
        tabSchedule.Text = "3. Frecuencia y Hora";
        tabSchedule.UseVisualStyleBackColor = true;
        // 
        // lblFrequency
        // 
        lblFrequency.AutoSize = true;
        lblFrequency.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblFrequency.Location = new Point(23, 30);
        lblFrequency.Name = "lblFrequency";
        lblFrequency.Size = new Size(157, 17);
        lblFrequency.TabIndex = 0;
        lblFrequency.Text = "Frecuencia de Ejecución:";
        // 
        // cboFrequency
        // 
        cboFrequency.DropDownStyle = ComboBoxStyle.DropDownList;
        cboFrequency.FormattingEnabled = true;
        cboFrequency.Location = new Point(200, 27);
        cboFrequency.Name = "cboFrequency";
        cboFrequency.Size = new Size(250, 25);
        cboFrequency.TabIndex = 1;
        cboFrequency.SelectedIndexChanged += cboFrequency_SelectedIndexChanged;
        // 
        // lblExecutionTime
        // 
        lblExecutionTime.AutoSize = true;
        lblExecutionTime.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblExecutionTime.Location = new Point(23, 75);
        lblExecutionTime.Name = "lblExecutionTime";
        lblExecutionTime.Size = new Size(122, 17);
        lblExecutionTime.TabIndex = 2;
        lblExecutionTime.Text = "Hora de Ejecución:";
        // 
        // dtpExecutionTime
        // 
        dtpExecutionTime.CustomFormat = "hh:mm tt";
        dtpExecutionTime.Format = DateTimePickerFormat.Custom;
        dtpExecutionTime.ShowUpDown = true;
        dtpExecutionTime.Location = new Point(200, 72);
        dtpExecutionTime.Name = "dtpExecutionTime";
        dtpExecutionTime.Size = new Size(130, 24);
        dtpExecutionTime.TabIndex = 3;
        // 
        // lblDayOfMonth
        // 
        lblDayOfMonth.AutoSize = true;
        lblDayOfMonth.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblDayOfMonth.Location = new Point(23, 120);
        lblDayOfMonth.Name = "lblDayOfMonth";
        lblDayOfMonth.Size = new Size(95, 17);
        lblDayOfMonth.TabIndex = 4;
        lblDayOfMonth.Text = "Día del Mes:";
        lblDayOfMonth.Visible = false;
        // 
        // numDayOfMonth
        // 
        numDayOfMonth.Location = new Point(200, 118);
        numDayOfMonth.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        numDayOfMonth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numDayOfMonth.Name = "numDayOfMonth";
        numDayOfMonth.Size = new Size(80, 24);
        numDayOfMonth.TabIndex = 5;
        numDayOfMonth.Value = new decimal(new int[] { 1, 0, 0, 0 });
        numDayOfMonth.Visible = false;
        // 
        // pnlWeeklyDays
        // 
        pnlWeeklyDays.Controls.Add(chkSun);
        pnlWeeklyDays.Controls.Add(chkSat);
        pnlWeeklyDays.Controls.Add(chkFri);
        pnlWeeklyDays.Controls.Add(chkThu);
        pnlWeeklyDays.Controls.Add(chkWed);
        pnlWeeklyDays.Controls.Add(chkTue);
        pnlWeeklyDays.Controls.Add(chkMon);
        pnlWeeklyDays.Controls.Add(lblWeeklyDays);
        pnlWeeklyDays.Location = new Point(20, 160);
        pnlWeeklyDays.Name = "pnlWeeklyDays";
        pnlWeeklyDays.Size = new Size(620, 120);
        pnlWeeklyDays.TabIndex = 6;
        pnlWeeklyDays.Visible = false;
        // 
        // lblWeeklyDays
        // 
        lblWeeklyDays.AutoSize = true;
        lblWeeklyDays.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblWeeklyDays.Location = new Point(3, 10);
        lblWeeklyDays.Name = "lblWeeklyDays";
        lblWeeklyDays.Size = new Size(130, 17);
        lblWeeklyDays.TabIndex = 0;
        lblWeeklyDays.Text = "Días de la semana:";
        // 
        // chkMon
        // 
        chkMon.AutoSize = true;
        chkMon.Location = new Point(180, 10);
        chkMon.Name = "chkMon";
        chkMon.Size = new Size(61, 21);
        chkMon.TabIndex = 1;
        chkMon.Text = "Lunes";
        chkMon.UseVisualStyleBackColor = true;
        // 
        // chkTue
        // 
        chkTue.AutoSize = true;
        chkTue.Location = new Point(270, 10);
        chkTue.Name = "chkTue";
        chkTue.Size = new Size(66, 21);
        chkTue.TabIndex = 2;
        chkTue.Text = "Martes";
        chkTue.UseVisualStyleBackColor = true;
        // 
        // chkWed
        // 
        chkWed.AutoSize = true;
        chkWed.Location = new Point(360, 10);
        chkWed.Name = "chkWed";
        chkWed.Size = new Size(82, 21);
        chkWed.TabIndex = 3;
        chkWed.Text = "Miércoles";
        chkWed.UseVisualStyleBackColor = true;
        // 
        // chkThu
        // 
        chkThu.AutoSize = true;
        chkThu.Location = new Point(470, 10);
        chkThu.Name = "chkThu";
        chkThu.Size = new Size(66, 21);
        chkThu.TabIndex = 4;
        chkThu.Text = "Jueves";
        chkThu.UseVisualStyleBackColor = true;
        // 
        // chkFri
        // 
        chkFri.AutoSize = true;
        chkFri.Location = new Point(180, 45);
        chkFri.Name = "chkFri";
        chkFri.Size = new Size(69, 21);
        chkFri.TabIndex = 5;
        chkFri.Text = "Viernes";
        chkFri.UseVisualStyleBackColor = true;
        // 
        // chkSat
        // 
        chkSat.AutoSize = true;
        chkSat.Location = new Point(270, 45);
        chkSat.Name = "chkSat";
        chkSat.Size = new Size(72, 21);
        chkSat.TabIndex = 6;
        chkSat.Text = "Sábado";
        chkSat.UseVisualStyleBackColor = true;
        // 
        // chkSun
        // 
        chkSun.AutoSize = true;
        chkSun.Location = new Point(360, 45);
        chkSun.Name = "chkSun";
        chkSun.Size = new Size(80, 21);
        chkSun.TabIndex = 7;
        chkSun.Text = "Domingo";
        chkSun.UseVisualStyleBackColor = true;
        // 
        // tabCloud
        // 
        tabCloud.Controls.Add(txtCloudFolder);
        tabCloud.Controls.Add(lblCloudFolder);
        tabCloud.Controls.Add(txtCloudToken);
        tabCloud.Controls.Add(lblCloudToken);
        tabCloud.Controls.Add(cboCloudProvider);
        tabCloud.Controls.Add(lblCloudProvider);
        tabCloud.Controls.Add(chkEnableCloud);
        tabCloud.Location = new Point(4, 26);
        tabCloud.Name = "tabCloud";
        tabCloud.Padding = new Padding(20);
        tabCloud.Size = new Size(676, 380);
        tabCloud.TabIndex = 3;
        tabCloud.Text = "4. Nube (Opcional)";
        tabCloud.UseVisualStyleBackColor = true;
        // 
        // chkEnableCloud
        // 
        chkEnableCloud.AutoSize = true;
        chkEnableCloud.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        chkEnableCloud.Location = new Point(23, 25);
        chkEnableCloud.Name = "chkEnableCloud";
        chkEnableCloud.Size = new Size(313, 21);
        chkEnableCloud.TabIndex = 0;
        chkEnableCloud.Text = "Subir copia de seguridad automáticamente a la nube";
        chkEnableCloud.UseVisualStyleBackColor = true;
        chkEnableCloud.CheckedChanged += chkEnableCloud_CheckedChanged;
        // 
        // lblCloudProvider
        // 
        lblCloudProvider.AutoSize = true;
        lblCloudProvider.Location = new Point(40, 70);
        lblCloudProvider.Name = "lblCloudProvider";
        lblCloudProvider.Size = new Size(130, 17);
        lblCloudProvider.TabIndex = 1;
        lblCloudProvider.Text = "Proveedor de Nube:";
        // 
        // cboCloudProvider
        // 
        cboCloudProvider.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCloudProvider.Enabled = false;
        cboCloudProvider.FormattingEnabled = true;
        cboCloudProvider.Location = new Point(200, 67);
        cboCloudProvider.Name = "cboCloudProvider";
        cboCloudProvider.Size = new Size(250, 25);
        cboCloudProvider.TabIndex = 2;
        // 
        // lblCloudToken
        // 
        lblCloudToken.AutoSize = true;
        lblCloudToken.Location = new Point(40, 115);
        lblCloudToken.Name = "lblCloudToken";
        lblCloudToken.Size = new Size(133, 17);
        lblCloudToken.TabIndex = 3;
        lblCloudToken.Text = "Token / Refresh Token:";
        // 
        // txtCloudToken
        // 
        txtCloudToken.Enabled = false;
        txtCloudToken.Location = new Point(200, 112);
        txtCloudToken.Name = "txtCloudToken";
        txtCloudToken.UseSystemPasswordChar = true;
        txtCloudToken.Size = new Size(420, 24);
        txtCloudToken.TabIndex = 4;
        // 
        // lblCloudFolder
        // 
        lblCloudFolder.AutoSize = true;
        lblCloudFolder.Location = new Point(40, 160);
        lblCloudFolder.Name = "lblCloudFolder";
        lblCloudFolder.Size = new Size(106, 17);
        lblCloudFolder.TabIndex = 5;
        lblCloudFolder.Text = "Carpeta Remota:";
        // 
        // txtCloudFolder
        // 
        txtCloudFolder.Enabled = false;
        txtCloudFolder.Location = new Point(200, 157);
        txtCloudFolder.Name = "txtCloudFolder";
        txtCloudFolder.Size = new Size(420, 24);
        txtCloudFolder.TabIndex = 6;
        txtCloudFolder.Text = "/Backups";
        // 
        // tabWindows
        // 
        tabWindows.Controls.Add(lblWindowsHelp);
        tabWindows.Controls.Add(txtWindowsPassword);
        tabWindows.Controls.Add(lblWindowsPassword);
        tabWindows.Controls.Add(txtWindowsUser);
        tabWindows.Controls.Add(lblWindowsUser);
        tabWindows.Controls.Add(txtWindowsDomain);
        tabWindows.Controls.Add(lblWindowsDomain);
        tabWindows.Location = new Point(4, 26);
        tabWindows.Name = "tabWindows";
        tabWindows.Padding = new Padding(20);
        tabWindows.Size = new Size(676, 380);
        tabWindows.TabIndex = 4;
        tabWindows.Text = "5. Credenciales Windows";
        tabWindows.UseVisualStyleBackColor = true;
        // 
        // lblWindowsHelp
        // 
        lblWindowsHelp.BackColor = Color.FromArgb(240, 245, 255);
        lblWindowsHelp.BorderStyle = BorderStyle.FixedSingle;
        lblWindowsHelp.Font = new Font("Segoe UI", 9F);
        lblWindowsHelp.ForeColor = Color.FromArgb(40, 60, 100);
        lblWindowsHelp.Location = new Point(20, 15);
        lblWindowsHelp.Name = "lblWindowsHelp";
        lblWindowsHelp.Padding = new Padding(10);
        lblWindowsHelp.Size = new Size(630, 75);
        lblWindowsHelp.TabIndex = 0;
        lblWindowsHelp.Text = "Las credenciales de Windows son requeridas por el Programador de Tareas de Windows (Task Scheduler) para ejecutar los respaldos de forma automática a la hora programada, incluso si el equipo está bloqueado o no hay una sesión abierta.";
        // 
        // lblWindowsDomain
        // 
        lblWindowsDomain.AutoSize = true;
        lblWindowsDomain.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblWindowsDomain.Location = new Point(23, 115);
        lblWindowsDomain.Name = "lblWindowsDomain";
        lblWindowsDomain.Size = new Size(157, 17);
        lblWindowsDomain.TabIndex = 1;
        lblWindowsDomain.Text = "Dominio o Nombre Equipo:";
        // 
        // txtWindowsDomain
        // 
        txtWindowsDomain.Location = new Point(200, 112);
        txtWindowsDomain.Name = "txtWindowsDomain";
        txtWindowsDomain.Size = new Size(300, 24);
        txtWindowsDomain.TabIndex = 2;
        // 
        // lblWindowsUser
        // 
        lblWindowsUser.AutoSize = true;
        lblWindowsUser.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblWindowsUser.Location = new Point(23, 160);
        lblWindowsUser.Name = "lblWindowsUser";
        lblWindowsUser.Size = new Size(134, 17);
        lblWindowsUser.TabIndex = 3;
        lblWindowsUser.Text = "Usuario de Windows:";
        // 
        // txtWindowsUser
        // 
        txtWindowsUser.Location = new Point(200, 157);
        txtWindowsUser.Name = "txtWindowsUser";
        txtWindowsUser.Size = new Size(300, 24);
        txtWindowsUser.TabIndex = 4;
        // 
        // lblWindowsPassword
        // 
        lblWindowsPassword.AutoSize = true;
        lblWindowsPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblWindowsPassword.Location = new Point(23, 205);
        lblWindowsPassword.Name = "lblWindowsPassword";
        lblWindowsPassword.Size = new Size(155, 17);
        lblWindowsPassword.TabIndex = 5;
        lblWindowsPassword.Text = "Contraseña de Windows:";
        // 
        // txtWindowsPassword
        // 
        txtWindowsPassword.Location = new Point(200, 202);
        txtWindowsPassword.Name = "txtWindowsPassword";
        txtWindowsPassword.UseSystemPasswordChar = true;
        txtWindowsPassword.Size = new Size(300, 24);
        txtWindowsPassword.TabIndex = 6;
        // 
        // pnlBottom
        // 
        pnlBottom.Controls.Add(btnSave);
        pnlBottom.Controls.Add(btnCancel);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Location = new Point(0, 480);
        pnlBottom.Name = "pnlBottom";
        pnlBottom.Size = new Size(684, 55);
        pnlBottom.TabIndex = 2;
        // 
        // btnCancel
        // 
        btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnCancel.Location = new Point(440, 12);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(100, 32);
        btnCancel.TabIndex = 0;
        btnCancel.Text = "Cancelar";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // btnSave
        // 
        btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnSave.BackColor = Color.FromArgb(24, 119, 242);
        btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnSave.ForeColor = Color.White;
        btnSave.Location = new Point(550, 12);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(120, 32);
        btnSave.TabIndex = 1;
        btnSave.Text = "Guardar y Programar";
        btnSave.UseVisualStyleBackColor = false;
        btnSave.Click += btnSave_Click;
        // 
        // JobEditForm
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(684, 535);
        Controls.Add(tabControl);
        Controls.Add(pnlBottom);
        Controls.Add(pnlHeader);
        Font = new Font("Segoe UI", 9.5F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "JobEditForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Configuración de Respaldo";
        Load += JobEditForm_Load;
        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        tabControl.ResumeLayout(false);
        tabSql.ResumeLayout(false);
        tabSql.PerformLayout();
        tabBackup.ResumeLayout(false);
        tabBackup.PerformLayout();
        tabSchedule.ResumeLayout(false);
        tabSchedule.PerformLayout();
        pnlWeeklyDays.ResumeLayout(false);
        pnlWeeklyDays.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numDayOfMonth).EndInit();
        tabCloud.ResumeLayout(false);
        tabCloud.PerformLayout();
        tabWindows.ResumeLayout(false);
        tabWindows.PerformLayout();
        pnlBottom.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlHeader;
    private Label lblHeader;
    private Label lblSubHeader;
    private TabControl tabControl;
    private TabPage tabSql;
    private Label lblJobName;
    private TextBox txtJobName;
    private Label lblSqlServer;
    private ComboBox cboSqlServer;
    private Button btnDiscoverInstances;
    private Label lblAuth;
    private RadioButton rdoAuthWindows;
    private RadioButton rdoAuthSql;
    private Label lblSqlUser;
    private TextBox txtSqlUser;
    private Label lblSqlPassword;
    private TextBox txtSqlPassword;
    private Label lblDatabase;
    private ComboBox cboDatabase;
    private Button btnTestSqlConnection;
    private TabPage tabBackup;
    private Label lblBackupType;
    private ComboBox cboBackupType;
    private Label lblCompression;
    private ComboBox cboCompression;
    private Label lblRetentionMode;
    private ComboBox cboRetentionMode;
    private Label lblRetentionCount;
    private NumericUpDown numRetentionCount;
    private Label lblRetentionDays;
    private NumericUpDown numRetentionDays;
    private CheckBox chkRetentionLocal;
    private CheckBox chkRetentionCloud;
    private Label lblLocalPath;
    private TextBox txtLocalPath;
    private Button btnBrowseFolder;
    private TabPage tabSchedule;
    private Label lblFrequency;
    private ComboBox cboFrequency;
    private Label lblExecutionTime;
    private DateTimePicker dtpExecutionTime;
    private Label lblDayOfMonth;
    private NumericUpDown numDayOfMonth;
    private Panel pnlWeeklyDays;
    private Label lblWeeklyDays;
    private CheckBox chkMon;
    private CheckBox chkTue;
    private CheckBox chkWed;
    private CheckBox chkThu;
    private CheckBox chkFri;
    private CheckBox chkSat;
    private CheckBox chkSun;
    private TabPage tabCloud;
    private CheckBox chkEnableCloud;
    private Label lblCloudProvider;
    private ComboBox cboCloudProvider;
    private Label lblCloudToken;
    private TextBox txtCloudToken;
    private Label lblCloudFolder;
    private TextBox txtCloudFolder;
    private TabPage tabWindows;
    private Label lblWindowsHelp;
    private Label lblWindowsDomain;
    private TextBox txtWindowsDomain;
    private Label lblWindowsUser;
    private TextBox txtWindowsUser;
    private Label lblWindowsPassword;
    private TextBox txtWindowsPassword;
    private Panel pnlBottom;
    private Button btnCancel;
    private Button btnSave;
}
