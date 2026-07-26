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
        pnlHeader = new Panel();
        lblSubHeader = new Label();
        lblHeader = new Label();

        pnlWizardSidebar = new Panel();
        lblWizardHeader = new Label();
        btnStepSql = new Button();
        btnStepSchedule = new Button();
        btnStepBackup = new Button();
        btnStepCloud = new Button();
        btnStepWindows = new Button();

        pnlWizardContentContainer = new Panel();

        // Step 1: SQL
        pnlStepSql = new Panel();
        lblJobName = new Label();
        txtJobName = new TextBox();
        lblSqlServer = new Label();
        cboSqlServer = new ComboBox();
        btnDiscoverInstances = new Button();
        lblAuth = new Label();
        rdoAuthWindows = new RadioButton();
        rdoAuthSql = new RadioButton();
        lblSqlUser = new Label();
        txtSqlUser = new TextBox();
        lblSqlPassword = new Label();
        txtSqlPassword = new TextBox();
        lblDatabase = new Label();
        cboDatabase = new ComboBox();
        btnTestSqlConnection = new Button();

        // Step 2: Schedule
        pnlStepSchedule = new Panel();
        lblFrequency = new Label();
        cboFrequency = new ComboBox();
        lblExecutionTime = new Label();
        dtpExecutionTime = new DateTimePicker();
        lblDayOfMonth = new Label();
        numDayOfMonth = new NumericUpDown();
        pnlWeeklyDays = new Panel();
        lblWeeklyDays = new Label();
        chkMon = new CheckBox();
        chkTue = new CheckBox();
        chkWed = new CheckBox();
        chkThu = new CheckBox();
        chkFri = new CheckBox();
        chkSat = new CheckBox();
        chkSun = new CheckBox();

        // Step 3: Backup & Retention
        pnlStepBackup = new Panel();
        lblBackupType = new Label();
        cboBackupType = new ComboBox();
        lblCompression = new Label();
        cboCompression = new ComboBox();
        lblLocalPath = new Label();
        txtLocalPath = new TextBox();
        btnBrowseFolder = new Button();
        lblRetentionMode = new Label();
        cboRetentionMode = new ComboBox();
        lblRetentionCount = new Label();
        numRetentionCount = new NumericUpDown();
        lblRetentionDays = new Label();
        numRetentionDays = new NumericUpDown();
        chkRetentionLocal = new CheckBox();
        chkRetentionCloud = new CheckBox();

        // Step 4: Cloud
        pnlStepCloud = new Panel();
        chkEnableCloud = new CheckBox();
        lblCloudProvider = new Label();
        cboCloudProvider = new ComboBox();
        lblCloudToken = new Label();
        txtCloudToken = new TextBox();
        lblCloudFolder = new Label();
        txtCloudFolder = new TextBox();
        pnlCloudHelp = new Panel();
        lblCloudHelpText = new Label();

        // Step 5: Windows
        pnlStepWindows = new Panel();
        pnlWindowsHelp = new Panel();
        lblWindowsHelpText = new Label();
        lblWindowsDomain = new Label();
        txtWindowsDomain = new TextBox();
        lblWindowsUser = new Label();
        txtWindowsUser = new TextBox();
        lblWindowsPassword = new Label();
        txtWindowsPassword = new TextBox();

        pnlBottom = new Panel();
        btnCancel = new Button();
        btnSave = new Button();

        pnlHeader.SuspendLayout();
        pnlWizardSidebar.SuspendLayout();
        pnlWizardContentContainer.SuspendLayout();
        pnlStepSql.SuspendLayout();
        pnlStepSchedule.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numDayOfMonth).BeginInit();
        pnlWeeklyDays.SuspendLayout();
        pnlStepBackup.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numRetentionCount).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numRetentionDays).BeginInit();
        pnlStepCloud.SuspendLayout();
        pnlCloudHelp.SuspendLayout();
        pnlStepWindows.SuspendLayout();
        pnlWindowsHelp.SuspendLayout();
        pnlBottom.SuspendLayout();
        SuspendLayout();

        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.FromArgb(15, 23, 42); // Slate 900
        pnlHeader.Controls.Add(lblSubHeader);
        pnlHeader.Controls.Add(lblHeader);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Size = new Size(840, 75);
        pnlHeader.TabIndex = 0;

        // 
        // lblHeader
        // 
        lblHeader.AutoSize = true;
        lblHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblHeader.ForeColor = Color.White;
        lblHeader.Location = new Point(24, 16);
        lblHeader.Name = "lblHeader";
        lblHeader.Size = new Size(328, 25);
        lblHeader.TabIndex = 0;
        lblHeader.Text = "Configurar Tarea de Respaldo SQL";

        // 
        // lblSubHeader
        // 
        lblSubHeader.AutoSize = true;
        lblSubHeader.Font = new Font("Segoe UI", 9F);
        lblSubHeader.ForeColor = Color.FromArgb(148, 163, 184);
        lblSubHeader.Location = new Point(26, 44);
        lblSubHeader.Name = "lblSubHeader";
        lblSubHeader.Size = new Size(495, 15);
        lblSubHeader.TabIndex = 1;
        lblSubHeader.Text = "Asistente de configuración paso a paso para respaldos automáticos de SQL Server.";

        // 
        // pnlWizardSidebar (Panel Lateral de Pasos)
        // 
        pnlWizardSidebar.BackColor = Color.FromArgb(15, 23, 42);
        pnlWizardSidebar.Controls.Add(btnStepWindows);
        pnlWizardSidebar.Controls.Add(btnStepCloud);
        pnlWizardSidebar.Controls.Add(btnStepBackup);
        pnlWizardSidebar.Controls.Add(btnStepSchedule);
        pnlWizardSidebar.Controls.Add(btnStepSql);
        pnlWizardSidebar.Controls.Add(lblWizardHeader);
        pnlWizardSidebar.Dock = DockStyle.Left;
        pnlWizardSidebar.Location = new Point(0, 75);
        pnlWizardSidebar.Name = "pnlWizardSidebar";
        pnlWizardSidebar.Size = new Size(220, 450);
        pnlWizardSidebar.TabIndex = 1;

        // 
        // lblWizardHeader
        // 
        lblWizardHeader.AutoSize = true;
        lblWizardHeader.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblWizardHeader.ForeColor = Color.FromArgb(71, 85, 105);
        lblWizardHeader.Location = new Point(18, 16);
        lblWizardHeader.Name = "lblWizardHeader";
        lblWizardHeader.Size = new Size(130, 13);
        lblWizardHeader.TabIndex = 0;
        lblWizardHeader.Text = "PASOS DE CONFIGURACIÓN";

        // 
        // btnStepSql
        // 
        btnStepSql.BackColor = Color.FromArgb(30, 41, 59);
        btnStepSql.Cursor = Cursors.Hand;
        btnStepSql.FlatAppearance.BorderSize = 0;
        btnStepSql.FlatStyle = FlatStyle.Flat;
        btnStepSql.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        btnStepSql.ForeColor = Color.FromArgb(56, 189, 248);
        btnStepSql.Location = new Point(12, 38);
        btnStepSql.Name = "btnStepSql";
        btnStepSql.Padding = new Padding(12, 0, 0, 0);
        btnStepSql.Size = new Size(196, 42);
        btnStepSql.TabIndex = 1;
        btnStepSql.Text = "1. Conexión SQL";
        btnStepSql.TextAlign = ContentAlignment.MiddleLeft;
        btnStepSql.UseVisualStyleBackColor = false;
        btnStepSql.Click += btnStep_Click;

        // 
        // btnStepSchedule
        // 
        btnStepSchedule.BackColor = Color.FromArgb(15, 23, 42);
        btnStepSchedule.Cursor = Cursors.Hand;
        btnStepSchedule.FlatAppearance.BorderSize = 0;
        btnStepSchedule.FlatStyle = FlatStyle.Flat;
        btnStepSchedule.Font = new Font("Segoe UI", 9.5F);
        btnStepSchedule.ForeColor = Color.FromArgb(203, 213, 225);
        btnStepSchedule.Location = new Point(12, 86);
        btnStepSchedule.Name = "btnStepSchedule";
        btnStepSchedule.Padding = new Padding(12, 0, 0, 0);
        btnStepSchedule.Size = new Size(196, 42);
        btnStepSchedule.TabIndex = 2;
        btnStepSchedule.Text = "2. Programación";
        btnStepSchedule.TextAlign = ContentAlignment.MiddleLeft;
        btnStepSchedule.UseVisualStyleBackColor = false;
        btnStepSchedule.Click += btnStep_Click;

        // 
        // btnStepBackup
        // 
        btnStepBackup.BackColor = Color.FromArgb(15, 23, 42);
        btnStepBackup.Cursor = Cursors.Hand;
        btnStepBackup.FlatAppearance.BorderSize = 0;
        btnStepBackup.FlatStyle = FlatStyle.Flat;
        btnStepBackup.Font = new Font("Segoe UI", 9.5F);
        btnStepBackup.ForeColor = Color.FromArgb(203, 213, 225);
        btnStepBackup.Location = new Point(12, 134);
        btnStepBackup.Name = "btnStepBackup";
        btnStepBackup.Padding = new Padding(12, 0, 0, 0);
        btnStepBackup.Size = new Size(196, 42);
        btnStepBackup.TabIndex = 3;
        btnStepBackup.Text = "3. Destino & Purga";
        btnStepBackup.TextAlign = ContentAlignment.MiddleLeft;
        btnStepBackup.UseVisualStyleBackColor = false;
        btnStepBackup.Click += btnStep_Click;

        // 
        // btnStepCloud
        // 
        btnStepCloud.BackColor = Color.FromArgb(15, 23, 42);
        btnStepCloud.Cursor = Cursors.Hand;
        btnStepCloud.FlatAppearance.BorderSize = 0;
        btnStepCloud.FlatStyle = FlatStyle.Flat;
        btnStepCloud.Font = new Font("Segoe UI", 9.5F);
        btnStepCloud.ForeColor = Color.FromArgb(203, 213, 225);
        btnStepCloud.Location = new Point(12, 182);
        btnStepCloud.Name = "btnStepCloud";
        btnStepCloud.Padding = new Padding(12, 0, 0, 0);
        btnStepCloud.Size = new Size(196, 42);
        btnStepCloud.TabIndex = 4;
        btnStepCloud.Text = "4. Sincronización Nube";
        btnStepCloud.TextAlign = ContentAlignment.MiddleLeft;
        btnStepCloud.UseVisualStyleBackColor = false;
        btnStepCloud.Click += btnStep_Click;

        // 
        // btnStepWindows
        // 
        btnStepWindows.BackColor = Color.FromArgb(15, 23, 42);
        btnStepWindows.Cursor = Cursors.Hand;
        btnStepWindows.FlatAppearance.BorderSize = 0;
        btnStepWindows.FlatStyle = FlatStyle.Flat;
        btnStepWindows.Font = new Font("Segoe UI", 9.5F);
        btnStepWindows.ForeColor = Color.FromArgb(203, 213, 225);
        btnStepWindows.Location = new Point(12, 230);
        btnStepWindows.Name = "btnStepWindows";
        btnStepWindows.Padding = new Padding(12, 0, 0, 0);
        btnStepWindows.Size = new Size(196, 42);
        btnStepWindows.TabIndex = 5;
        btnStepWindows.Text = "5. Credenciales Windows";
        btnStepWindows.TextAlign = ContentAlignment.MiddleLeft;
        btnStepWindows.UseVisualStyleBackColor = false;
        btnStepWindows.Click += btnStep_Click;

        // 
        // pnlWizardContentContainer (Contenedor Central)
        // 
        pnlWizardContentContainer.BackColor = Color.FromArgb(248, 250, 252);
        pnlWizardContentContainer.Controls.Add(pnlStepSql);
        pnlWizardContentContainer.Controls.Add(pnlStepSchedule);
        pnlWizardContentContainer.Controls.Add(pnlStepBackup);
        pnlWizardContentContainer.Controls.Add(pnlStepCloud);
        pnlWizardContentContainer.Controls.Add(pnlStepWindows);
        pnlWizardContentContainer.Dock = DockStyle.Fill;
        pnlWizardContentContainer.Location = new Point(220, 75);
        pnlWizardContentContainer.Name = "pnlWizardContentContainer";
        pnlWizardContentContainer.Padding = new Padding(24);
        pnlWizardContentContainer.Size = new Size(620, 450);
        pnlWizardContentContainer.TabIndex = 2;

        // 
        // pnlStepSql (Paso 1: Conexión SQL)
        // 
        pnlStepSql.BackColor = Color.White;
        pnlStepSql.BorderStyle = BorderStyle.FixedSingle;
        pnlStepSql.Controls.Add(btnTestSqlConnection);
        pnlStepSql.Controls.Add(cboDatabase);
        pnlStepSql.Controls.Add(lblDatabase);
        pnlStepSql.Controls.Add(txtSqlPassword);
        pnlStepSql.Controls.Add(lblSqlPassword);
        pnlStepSql.Controls.Add(txtSqlUser);
        pnlStepSql.Controls.Add(lblSqlUser);
        pnlStepSql.Controls.Add(rdoAuthSql);
        pnlStepSql.Controls.Add(rdoAuthWindows);
        pnlStepSql.Controls.Add(lblAuth);
        pnlStepSql.Controls.Add(btnDiscoverInstances);
        pnlStepSql.Controls.Add(cboSqlServer);
        pnlStepSql.Controls.Add(lblSqlServer);
        pnlStepSql.Controls.Add(txtJobName);
        pnlStepSql.Controls.Add(lblJobName);
        pnlStepSql.Dock = DockStyle.Fill;
        pnlStepSql.Location = new Point(24, 24);
        pnlStepSql.Name = "pnlStepSql";
        pnlStepSql.Size = new Size(572, 402);
        pnlStepSql.TabIndex = 0;

        lblJobName.AutoSize = true;
        lblJobName.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblJobName.ForeColor = Color.FromArgb(30, 41, 59);
        lblJobName.Location = new Point(24, 24);
        lblJobName.Name = "lblJobName";
        lblJobName.Size = new Size(134, 17);
        lblJobName.TabIndex = 0;
        lblJobName.Text = "Nombre de la Tarea:";

        txtJobName.Location = new Point(180, 21);
        txtJobName.Name = "txtJobName";
        txtJobName.Size = new Size(360, 24);
        txtJobName.TabIndex = 1;

        lblSqlServer.AutoSize = true;
        lblSqlServer.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblSqlServer.ForeColor = Color.FromArgb(30, 41, 59);
        lblSqlServer.Location = new Point(24, 68);
        lblSqlServer.Name = "lblSqlServer";
        lblSqlServer.Size = new Size(134, 17);
        lblSqlServer.TabIndex = 2;
        lblSqlServer.Text = "Servidor SQL Server:";

        cboSqlServer.FormattingEnabled = true;
        cboSqlServer.Location = new Point(180, 65);
        cboSqlServer.Name = "cboSqlServer";
        cboSqlServer.Size = new Size(220, 25);
        cboSqlServer.TabIndex = 3;

        btnDiscoverInstances.BackColor = Color.FromArgb(241, 245, 249);
        btnDiscoverInstances.Cursor = Cursors.Hand;
        btnDiscoverInstances.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnDiscoverInstances.FlatStyle = FlatStyle.Flat;
        btnDiscoverInstances.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
        btnDiscoverInstances.ForeColor = Color.FromArgb(30, 41, 59);
        btnDiscoverInstances.Location = new Point(410, 64);
        btnDiscoverInstances.Name = "btnDiscoverInstances";
        btnDiscoverInstances.Size = new Size(130, 28);
        btnDiscoverInstances.TabIndex = 4;
        btnDiscoverInstances.Text = "Buscar Instancias";
        btnDiscoverInstances.UseVisualStyleBackColor = false;
        btnDiscoverInstances.Click += btnDiscoverInstances_Click;

        lblAuth.AutoSize = true;
        lblAuth.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblAuth.ForeColor = Color.FromArgb(30, 41, 59);
        lblAuth.Location = new Point(24, 115);
        lblAuth.Name = "lblAuth";
        lblAuth.Size = new Size(95, 17);
        lblAuth.TabIndex = 5;
        lblAuth.Text = "Autenticación:";

        rdoAuthWindows.AutoSize = true;
        rdoAuthWindows.Checked = true;
        rdoAuthWindows.Location = new Point(180, 113);
        rdoAuthWindows.Name = "rdoAuthWindows";
        rdoAuthWindows.Size = new Size(178, 21);
        rdoAuthWindows.TabIndex = 6;
        rdoAuthWindows.TabStop = true;
        rdoAuthWindows.Text = "Autenticación de Windows";
        rdoAuthWindows.UseVisualStyleBackColor = true;
        rdoAuthWindows.CheckedChanged += rdoAuth_CheckedChanged;

        rdoAuthSql.AutoSize = true;
        rdoAuthSql.Location = new Point(180, 138);
        rdoAuthSql.Name = "rdoAuthSql";
        rdoAuthSql.Size = new Size(187, 21);
        rdoAuthSql.TabIndex = 7;
        rdoAuthSql.Text = "Autenticación de SQL Server";
        rdoAuthSql.UseVisualStyleBackColor = true;
        rdoAuthSql.CheckedChanged += rdoAuth_CheckedChanged;

        lblSqlUser.AutoSize = true;
        lblSqlUser.Location = new Point(45, 175);
        lblSqlUser.Name = "lblSqlUser";
        lblSqlUser.Size = new Size(56, 17);
        lblSqlUser.TabIndex = 8;
        lblSqlUser.Text = "Usuario:";

        txtSqlUser.Enabled = false;
        txtSqlUser.Location = new Point(180, 172);
        txtSqlUser.Name = "txtSqlUser";
        txtSqlUser.Size = new Size(160, 24);
        txtSqlUser.TabIndex = 9;

        lblSqlPassword.AutoSize = true;
        lblSqlPassword.Location = new Point(350, 175);
        lblSqlPassword.Name = "lblSqlPassword";
        lblSqlPassword.Size = new Size(41, 17);
        lblSqlPassword.TabIndex = 10;
        lblSqlPassword.Text = "Pass:";

        txtSqlPassword.Enabled = false;
        txtSqlPassword.Location = new Point(400, 172);
        txtSqlPassword.Name = "txtSqlPassword";
        txtSqlPassword.UseSystemPasswordChar = true;
        txtSqlPassword.Size = new Size(140, 24);
        txtSqlPassword.TabIndex = 11;

        lblDatabase.AutoSize = true;
        lblDatabase.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblDatabase.ForeColor = Color.FromArgb(30, 41, 59);
        lblDatabase.Location = new Point(24, 222);
        lblDatabase.Name = "lblDatabase";
        lblDatabase.Size = new Size(96, 17);
        lblDatabase.TabIndex = 12;
        lblDatabase.Text = "Base de Datos:";

        cboDatabase.FormattingEnabled = true;
        cboDatabase.Location = new Point(180, 219);
        cboDatabase.Name = "cboDatabase";
        cboDatabase.Size = new Size(360, 25);
        cboDatabase.TabIndex = 13;

        btnTestSqlConnection.BackColor = Color.FromArgb(238, 242, 255);
        btnTestSqlConnection.Cursor = Cursors.Hand;
        btnTestSqlConnection.FlatAppearance.BorderColor = Color.FromArgb(199, 210, 254);
        btnTestSqlConnection.FlatStyle = FlatStyle.Flat;
        btnTestSqlConnection.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        btnTestSqlConnection.ForeColor = Color.FromArgb(67, 56, 202);
        btnTestSqlConnection.Location = new Point(180, 260);
        btnTestSqlConnection.Name = "btnTestSqlConnection";
        btnTestSqlConnection.Size = new Size(360, 36);
        btnTestSqlConnection.TabIndex = 14;
        btnTestSqlConnection.Text = "Probar Conexión y Cargar BDs";
        btnTestSqlConnection.UseVisualStyleBackColor = false;
        btnTestSqlConnection.Click += btnTestSqlConnection_Click;

        // 
        // pnlStepSchedule (Paso 2: Programación)
        // 
        pnlStepSchedule.BackColor = Color.White;
        pnlStepSchedule.BorderStyle = BorderStyle.FixedSingle;
        pnlStepSchedule.Controls.Add(pnlWeeklyDays);
        pnlStepSchedule.Controls.Add(numDayOfMonth);
        pnlStepSchedule.Controls.Add(lblDayOfMonth);
        pnlStepSchedule.Controls.Add(dtpExecutionTime);
        pnlStepSchedule.Controls.Add(lblExecutionTime);
        pnlStepSchedule.Controls.Add(cboFrequency);
        pnlStepSchedule.Controls.Add(lblFrequency);
        pnlStepSchedule.Dock = DockStyle.Fill;
        pnlStepSchedule.Location = new Point(24, 24);
        pnlStepSchedule.Name = "pnlStepSchedule";
        pnlStepSchedule.Size = new Size(572, 402);
        pnlStepSchedule.TabIndex = 1;
        pnlStepSchedule.Visible = false;

        lblFrequency.AutoSize = true;
        lblFrequency.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblFrequency.ForeColor = Color.FromArgb(30, 41, 59);
        lblFrequency.Location = new Point(24, 28);
        lblFrequency.Name = "lblFrequency";
        lblFrequency.Size = new Size(157, 17);
        lblFrequency.TabIndex = 0;
        lblFrequency.Text = "Frecuencia de Ejecución:";

        cboFrequency.DropDownStyle = ComboBoxStyle.DropDownList;
        cboFrequency.FormattingEnabled = true;
        cboFrequency.Location = new Point(210, 25);
        cboFrequency.Name = "cboFrequency";
        cboFrequency.Size = new Size(300, 25);
        cboFrequency.TabIndex = 1;
        cboFrequency.SelectedIndexChanged += cboFrequency_SelectedIndexChanged;

        lblExecutionTime.AutoSize = true;
        lblExecutionTime.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblExecutionTime.ForeColor = Color.FromArgb(30, 41, 59);
        lblExecutionTime.Location = new Point(24, 75);
        lblExecutionTime.Name = "lblExecutionTime";
        lblExecutionTime.Size = new Size(122, 17);
        lblExecutionTime.TabIndex = 2;
        lblExecutionTime.Text = "Hora de Ejecución:";

        dtpExecutionTime.CustomFormat = "hh:mm tt";
        dtpExecutionTime.Format = DateTimePickerFormat.Custom;
        dtpExecutionTime.ShowUpDown = true;
        dtpExecutionTime.Location = new Point(210, 72);
        dtpExecutionTime.Name = "dtpExecutionTime";
        dtpExecutionTime.Size = new Size(140, 24);
        dtpExecutionTime.TabIndex = 3;

        lblDayOfMonth.AutoSize = true;
        lblDayOfMonth.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblDayOfMonth.ForeColor = Color.FromArgb(30, 41, 59);
        lblDayOfMonth.Location = new Point(24, 122);
        lblDayOfMonth.Name = "lblDayOfMonth";
        lblDayOfMonth.Size = new Size(84, 17);
        lblDayOfMonth.TabIndex = 4;
        lblDayOfMonth.Text = "Día del Mes:";
        lblDayOfMonth.Visible = false;

        numDayOfMonth.Location = new Point(210, 119);
        numDayOfMonth.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        numDayOfMonth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numDayOfMonth.Name = "numDayOfMonth";
        numDayOfMonth.Size = new Size(90, 24);
        numDayOfMonth.TabIndex = 5;
        numDayOfMonth.Value = new decimal(new int[] { 1, 0, 0, 0 });
        numDayOfMonth.Visible = false;

        pnlWeeklyDays.Controls.Add(chkSun);
        pnlWeeklyDays.Controls.Add(chkSat);
        pnlWeeklyDays.Controls.Add(chkFri);
        pnlWeeklyDays.Controls.Add(chkThu);
        pnlWeeklyDays.Controls.Add(chkWed);
        pnlWeeklyDays.Controls.Add(chkTue);
        pnlWeeklyDays.Controls.Add(chkMon);
        pnlWeeklyDays.Controls.Add(lblWeeklyDays);
        pnlWeeklyDays.Location = new Point(18, 160);
        pnlWeeklyDays.Name = "pnlWeeklyDays";
        pnlWeeklyDays.Size = new Size(530, 120);
        pnlWeeklyDays.TabIndex = 6;
        pnlWeeklyDays.Visible = false;

        lblWeeklyDays.AutoSize = true;
        lblWeeklyDays.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblWeeklyDays.ForeColor = Color.FromArgb(30, 41, 59);
        lblWeeklyDays.Location = new Point(6, 6);
        lblWeeklyDays.Name = "lblWeeklyDays";
        lblWeeklyDays.Size = new Size(122, 17);
        lblWeeklyDays.TabIndex = 0;
        lblWeeklyDays.Text = "Días de la Semana:";

        chkMon.AutoSize = true;
        chkMon.Location = new Point(192, 6);
        chkMon.Name = "chkMon";
        chkMon.Size = new Size(61, 21);
        chkMon.TabIndex = 1;
        chkMon.Text = "Lunes";
        chkMon.UseVisualStyleBackColor = true;

        chkTue.AutoSize = true;
        chkTue.Location = new Point(280, 6);
        chkTue.Name = "chkTue";
        chkTue.Size = new Size(66, 21);
        chkTue.TabIndex = 2;
        chkTue.Text = "Martes";
        chkTue.UseVisualStyleBackColor = true;

        chkWed.AutoSize = true;
        chkWed.Location = new Point(370, 6);
        chkWed.Name = "chkWed";
        chkWed.Size = new Size(82, 21);
        chkWed.TabIndex = 3;
        chkWed.Text = "Miércoles";
        chkWed.UseVisualStyleBackColor = true;

        chkThu.AutoSize = true;
        chkThu.Location = new Point(192, 42);
        chkThu.Name = "chkThu";
        chkThu.Size = new Size(66, 21);
        chkThu.TabIndex = 4;
        chkThu.Text = "Jueves";
        chkThu.UseVisualStyleBackColor = true;

        chkFri.AutoSize = true;
        chkFri.Location = new Point(280, 42);
        chkFri.Name = "chkFri";
        chkFri.Size = new Size(69, 21);
        chkFri.TabIndex = 5;
        chkFri.Text = "Viernes";
        chkFri.UseVisualStyleBackColor = true;

        chkSat.AutoSize = true;
        chkSat.Location = new Point(370, 42);
        chkSat.Name = "chkSat";
        chkSat.Size = new Size(72, 21);
        chkSat.TabIndex = 6;
        chkSat.Text = "Sábado";
        chkSat.UseVisualStyleBackColor = true;

        chkSun.AutoSize = true;
        chkSun.Location = new Point(192, 78);
        chkSun.Name = "chkSun";
        chkSun.Size = new Size(80, 21);
        chkSun.TabIndex = 7;
        chkSun.Text = "Domingo";
        chkSun.UseVisualStyleBackColor = true;

        // 
        // pnlStepBackup (Paso 3: Destino & Purga)
        // 
        pnlStepBackup.BackColor = Color.White;
        pnlStepBackup.BorderStyle = BorderStyle.FixedSingle;
        pnlStepBackup.Controls.Add(chkRetentionCloud);
        pnlStepBackup.Controls.Add(chkRetentionLocal);
        pnlStepBackup.Controls.Add(numRetentionDays);
        pnlStepBackup.Controls.Add(lblRetentionDays);
        pnlStepBackup.Controls.Add(numRetentionCount);
        pnlStepBackup.Controls.Add(lblRetentionCount);
        pnlStepBackup.Controls.Add(cboRetentionMode);
        pnlStepBackup.Controls.Add(lblRetentionMode);
        pnlStepBackup.Controls.Add(btnBrowseFolder);
        pnlStepBackup.Controls.Add(txtLocalPath);
        pnlStepBackup.Controls.Add(lblLocalPath);
        pnlStepBackup.Controls.Add(cboCompression);
        pnlStepBackup.Controls.Add(lblCompression);
        pnlStepBackup.Controls.Add(cboBackupType);
        pnlStepBackup.Controls.Add(lblBackupType);
        pnlStepBackup.Dock = DockStyle.Fill;
        pnlStepBackup.Location = new Point(24, 24);
        pnlStepBackup.Name = "pnlStepBackup";
        pnlStepBackup.Size = new Size(572, 402);
        pnlStepBackup.TabIndex = 2;
        pnlStepBackup.Visible = false;

        lblBackupType.AutoSize = true;
        lblBackupType.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblBackupType.ForeColor = Color.FromArgb(30, 41, 59);
        lblBackupType.Location = new Point(24, 24);
        lblBackupType.Name = "lblBackupType";
        lblBackupType.Size = new Size(116, 17);
        lblBackupType.TabIndex = 0;
        lblBackupType.Text = "Tipo de Respaldo:";

        cboBackupType.DropDownStyle = ComboBoxStyle.DropDownList;
        cboBackupType.FormattingEnabled = true;
        cboBackupType.Location = new Point(200, 21);
        cboBackupType.Name = "cboBackupType";
        cboBackupType.Size = new Size(340, 25);
        cboBackupType.TabIndex = 1;

        lblCompression.AutoSize = true;
        lblCompression.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblCompression.ForeColor = Color.FromArgb(30, 41, 59);
        lblCompression.Location = new Point(24, 66);
        lblCompression.Name = "lblCompression";
        lblCompression.Size = new Size(84, 17);
        lblCompression.TabIndex = 2;
        lblCompression.Text = "Compresión:";

        cboCompression.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCompression.FormattingEnabled = true;
        cboCompression.Location = new Point(200, 63);
        cboCompression.Name = "cboCompression";
        cboCompression.Size = new Size(340, 25);
        cboCompression.TabIndex = 3;

        lblLocalPath.AutoSize = true;
        lblLocalPath.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblLocalPath.ForeColor = Color.FromArgb(30, 41, 59);
        lblLocalPath.Location = new Point(24, 108);
        lblLocalPath.Name = "lblLocalPath";
        lblLocalPath.Size = new Size(150, 17);
        lblLocalPath.TabIndex = 4;
        lblLocalPath.Text = "Carpeta Destino Local:";

        txtLocalPath.Location = new Point(200, 105);
        txtLocalPath.Name = "txtLocalPath";
        txtLocalPath.Size = new Size(235, 24);
        txtLocalPath.TabIndex = 5;

        btnBrowseFolder.BackColor = Color.FromArgb(241, 245, 249);
        btnBrowseFolder.Cursor = Cursors.Hand;
        btnBrowseFolder.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnBrowseFolder.FlatStyle = FlatStyle.Flat;
        btnBrowseFolder.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
        btnBrowseFolder.ForeColor = Color.FromArgb(30, 41, 59);
        btnBrowseFolder.Location = new Point(442, 104);
        btnBrowseFolder.Name = "btnBrowseFolder";
        btnBrowseFolder.Size = new Size(98, 27);
        btnBrowseFolder.TabIndex = 6;
        btnBrowseFolder.Text = "Examinar...";
        btnBrowseFolder.UseVisualStyleBackColor = false;
        btnBrowseFolder.Click += btnBrowseFolder_Click;

        lblRetentionMode.AutoSize = true;
        lblRetentionMode.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblRetentionMode.ForeColor = Color.FromArgb(30, 41, 59);
        lblRetentionMode.Location = new Point(24, 155);
        lblRetentionMode.Name = "lblRetentionMode";
        lblRetentionMode.Size = new Size(157, 17);
        lblRetentionMode.TabIndex = 7;
        lblRetentionMode.Text = "Regla de Limpieza / Purga:";

        cboRetentionMode.DropDownStyle = ComboBoxStyle.DropDownList;
        cboRetentionMode.FormattingEnabled = true;
        cboRetentionMode.Location = new Point(200, 152);
        cboRetentionMode.Name = "cboRetentionMode";
        cboRetentionMode.Size = new Size(340, 25);
        cboRetentionMode.TabIndex = 8;
        cboRetentionMode.SelectedIndexChanged += cboRetentionMode_SelectedIndexChanged;

        lblRetentionCount.AutoSize = true;
        lblRetentionCount.Location = new Point(40, 192);
        lblRetentionCount.Name = "lblRetentionCount";
        lblRetentionCount.Size = new Size(138, 17);
        lblRetentionCount.TabIndex = 9;
        lblRetentionCount.Text = "Máximo de Respaldos:";

        numRetentionCount.Location = new Point(200, 189);
        numRetentionCount.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
        numRetentionCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numRetentionCount.Name = "numRetentionCount";
        numRetentionCount.Size = new Size(80, 24);
        numRetentionCount.TabIndex = 10;
        numRetentionCount.Value = new decimal(new int[] { 10, 0, 0, 0 });

        lblRetentionDays.AutoSize = true;
        lblRetentionDays.Location = new Point(300, 192);
        lblRetentionDays.Name = "lblRetentionDays";
        lblRetentionDays.Size = new Size(119, 17);
        lblRetentionDays.TabIndex = 11;
        lblRetentionDays.Text = "Máx. Días Antigüedad:";

        numRetentionDays.Location = new Point(440, 189);
        numRetentionDays.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
        numRetentionDays.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numRetentionDays.Name = "numRetentionDays";
        numRetentionDays.Size = new Size(85, 24);
        numRetentionDays.TabIndex = 12;
        numRetentionDays.Value = new decimal(new int[] { 30, 0, 0, 0 });

        chkRetentionLocal.AutoSize = true;
        chkRetentionLocal.Checked = true;
        chkRetentionLocal.CheckState = CheckState.Checked;
        chkRetentionLocal.Location = new Point(200, 226);
        chkRetentionLocal.Name = "chkRetentionLocal";
        chkRetentionLocal.Size = new Size(198, 21);
        chkRetentionLocal.TabIndex = 13;
        chkRetentionLocal.Text = "Aplicar limpieza en disco local";
        chkRetentionLocal.UseVisualStyleBackColor = true;

        chkRetentionCloud.AutoSize = true;
        chkRetentionCloud.Checked = true;
        chkRetentionCloud.CheckState = CheckState.Checked;
        chkRetentionCloud.Location = new Point(200, 252);
        chkRetentionCloud.Name = "chkRetentionCloud";
        chkRetentionCloud.Size = new Size(207, 21);
        chkRetentionCloud.TabIndex = 14;
        chkRetentionCloud.Text = "Aplicar limpieza en Dropbox";
        chkRetentionCloud.UseVisualStyleBackColor = true;

        // 
        // pnlStepCloud (Paso 4: Sincronización Nube)
        // 
        pnlStepCloud.BackColor = Color.White;
        pnlStepCloud.BorderStyle = BorderStyle.FixedSingle;
        pnlStepCloud.Controls.Add(pnlCloudHelp);
        pnlStepCloud.Controls.Add(txtCloudFolder);
        pnlStepCloud.Controls.Add(lblCloudFolder);
        pnlStepCloud.Controls.Add(txtCloudToken);
        pnlStepCloud.Controls.Add(lblCloudToken);
        pnlStepCloud.Controls.Add(cboCloudProvider);
        pnlStepCloud.Controls.Add(lblCloudProvider);
        pnlStepCloud.Controls.Add(chkEnableCloud);
        pnlStepCloud.Dock = DockStyle.Fill;
        pnlStepCloud.Location = new Point(24, 24);
        pnlStepCloud.Name = "pnlStepCloud";
        pnlStepCloud.Size = new Size(572, 402);
        pnlStepCloud.TabIndex = 3;
        pnlStepCloud.Visible = false;

        chkEnableCloud.AutoSize = true;
        chkEnableCloud.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        chkEnableCloud.ForeColor = Color.FromArgb(30, 41, 59);
        chkEnableCloud.Location = new Point(24, 24);
        chkEnableCloud.Name = "chkEnableCloud";
        chkEnableCloud.Size = new Size(313, 21);
        chkEnableCloud.TabIndex = 0;
        chkEnableCloud.Text = "Subir copia de seguridad automáticamente a la nube";
        chkEnableCloud.UseVisualStyleBackColor = true;
        chkEnableCloud.CheckedChanged += chkEnableCloud_CheckedChanged;

        lblCloudProvider.AutoSize = true;
        lblCloudProvider.Location = new Point(40, 68);
        lblCloudProvider.Name = "lblCloudProvider";
        lblCloudProvider.Size = new Size(130, 17);
        lblCloudProvider.TabIndex = 1;
        lblCloudProvider.Text = "Proveedor de Nube:";

        cboCloudProvider.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCloudProvider.Enabled = false;
        cboCloudProvider.FormattingEnabled = true;
        cboCloudProvider.Location = new Point(200, 65);
        cboCloudProvider.Name = "cboCloudProvider";
        cboCloudProvider.Size = new Size(340, 25);
        cboCloudProvider.TabIndex = 2;

        lblCloudToken.AutoSize = true;
        lblCloudToken.Location = new Point(40, 112);
        lblCloudToken.Name = "lblCloudToken";
        lblCloudToken.Size = new Size(133, 17);
        lblCloudToken.TabIndex = 3;
        lblCloudToken.Text = "Token / Refresh Token:";

        txtCloudToken.Enabled = false;
        txtCloudToken.Location = new Point(200, 109);
        txtCloudToken.Name = "txtCloudToken";
        txtCloudToken.UseSystemPasswordChar = true;
        txtCloudToken.Size = new Size(340, 24);
        txtCloudToken.TabIndex = 4;

        lblCloudFolder.AutoSize = true;
        lblCloudFolder.Location = new Point(40, 156);
        lblCloudFolder.Name = "lblCloudFolder";
        lblCloudFolder.Size = new Size(106, 17);
        lblCloudFolder.TabIndex = 5;
        lblCloudFolder.Text = "Carpeta Remota:";

        txtCloudFolder.Enabled = false;
        txtCloudFolder.Location = new Point(200, 153);
        txtCloudFolder.Name = "txtCloudFolder";
        txtCloudFolder.Size = new Size(340, 24);
        txtCloudFolder.TabIndex = 6;
        txtCloudFolder.Text = "/Backups";

        pnlCloudHelp.BackColor = Color.FromArgb(239, 246, 255); // Blue 50
        pnlCloudHelp.BorderStyle = BorderStyle.FixedSingle;
        pnlCloudHelp.Controls.Add(lblCloudHelpText);
        pnlCloudHelp.Location = new Point(24, 200);
        pnlCloudHelp.Name = "pnlCloudHelp";
        pnlCloudHelp.Padding = new Padding(14);
        pnlCloudHelp.Size = new Size(516, 95);
        pnlCloudHelp.TabIndex = 7;

        lblCloudHelpText.AutoSize = false;
        lblCloudHelpText.Dock = DockStyle.Fill;
        lblCloudHelpText.Font = new Font("Segoe UI", 8.5F);
        lblCloudHelpText.ForeColor = Color.FromArgb(30, 64, 175); // Blue 800
        lblCloudHelpText.Location = new Point(14, 14);
        lblCloudHelpText.Name = "lblCloudHelpText";
        lblCloudHelpText.Size = new Size(486, 65);
        lblCloudHelpText.TabIndex = 0;
        lblCloudHelpText.Text = "CONFIGURACIÓN REQUERIDA EN DROPBOX:\r\nAsegúrese de crear su App en Dropbox Developers Console y marcar los permisos files.content.write, files.content.read y files.metadata.read antes de presionar Submit y pegar su Token.";

        // 
        // pnlStepWindows (Paso 5: Credenciales de Windows)
        // 
        pnlStepWindows.BackColor = Color.White;
        pnlStepWindows.BorderStyle = BorderStyle.FixedSingle;
        pnlStepWindows.Controls.Add(pnlWindowsHelp);
        pnlStepWindows.Controls.Add(txtWindowsPassword);
        pnlStepWindows.Controls.Add(lblWindowsPassword);
        pnlStepWindows.Controls.Add(txtWindowsUser);
        pnlStepWindows.Controls.Add(lblWindowsUser);
        pnlStepWindows.Controls.Add(txtWindowsDomain);
        pnlStepWindows.Controls.Add(lblWindowsDomain);
        pnlStepWindows.Dock = DockStyle.Fill;
        pnlStepWindows.Location = new Point(24, 24);
        pnlStepWindows.Name = "pnlStepWindows";
        pnlStepWindows.Size = new Size(572, 402);
        pnlStepWindows.TabIndex = 4;
        pnlStepWindows.Visible = false;

        pnlWindowsHelp.BackColor = Color.FromArgb(254, 242, 242); // Rose/Red 50
        pnlWindowsHelp.BorderStyle = BorderStyle.FixedSingle;
        pnlWindowsHelp.Controls.Add(lblWindowsHelpText);
        pnlWindowsHelp.Location = new Point(24, 20);
        pnlWindowsHelp.Name = "pnlWindowsHelp";
        pnlWindowsHelp.Padding = new Padding(14);
        pnlWindowsHelp.Size = new Size(516, 110);
        pnlWindowsHelp.TabIndex = 0;

        lblWindowsHelpText.AutoSize = false;
        lblWindowsHelpText.Dock = DockStyle.Fill;
        lblWindowsHelpText.Font = new Font("Segoe UI", 8.5F);
        lblWindowsHelpText.ForeColor = Color.FromArgb(153, 27, 27); // Red 800
        lblWindowsHelpText.Location = new Point(14, 14);
        lblWindowsHelpText.Name = "lblWindowsHelpText";
        lblWindowsHelpText.Size = new Size(486, 80);
        lblWindowsHelpText.TabIndex = 0;
        lblWindowsHelpText.Text = "REQUISITO OBLIGATORIO DE CONTRASEÑA EN WINDOWS:\r\nEl usuario de Windows configurado DEBE tener una contraseña tradicional establecida. Métodos de inicio de sesión con PIN de Windows Hello, reconocimiento facial, huella dactilar o cuentas sin contraseña NO son compatibles con el Programador de Tareas y causarán que el respaldo automático falle.";

        lblWindowsDomain.AutoSize = true;
        lblWindowsDomain.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblWindowsDomain.ForeColor = Color.FromArgb(30, 41, 59);
        lblWindowsDomain.Location = new Point(24, 152);
        lblWindowsDomain.Name = "lblWindowsDomain";
        lblWindowsDomain.Size = new Size(157, 17);
        lblWindowsDomain.TabIndex = 1;
        lblWindowsDomain.Text = "Dominio o Nombre Equipo:";

        txtWindowsDomain.Location = new Point(200, 149);
        txtWindowsDomain.Name = "txtWindowsDomain";
        txtWindowsDomain.Size = new Size(340, 24);
        txtWindowsDomain.TabIndex = 2;

        lblWindowsUser.AutoSize = true;
        lblWindowsUser.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblWindowsUser.ForeColor = Color.FromArgb(30, 41, 59);
        lblWindowsUser.Location = new Point(24, 195);
        lblWindowsUser.Name = "lblWindowsUser";
        lblWindowsUser.Size = new Size(134, 17);
        lblWindowsUser.TabIndex = 3;
        lblWindowsUser.Text = "Usuario de Windows:";

        txtWindowsUser.Location = new Point(200, 192);
        txtWindowsUser.Name = "txtWindowsUser";
        txtWindowsUser.Size = new Size(340, 24);
        txtWindowsUser.TabIndex = 4;

        lblWindowsPassword.AutoSize = true;
        lblWindowsPassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblWindowsPassword.ForeColor = Color.FromArgb(30, 41, 59);
        lblWindowsPassword.Location = new Point(24, 238);
        lblWindowsPassword.Name = "lblWindowsPassword";
        lblWindowsPassword.Size = new Size(155, 17);
        lblWindowsPassword.TabIndex = 5;
        lblWindowsPassword.Text = "Contraseña de Windows:";

        txtWindowsPassword.Location = new Point(200, 235);
        txtWindowsPassword.Name = "txtWindowsPassword";
        txtWindowsPassword.UseSystemPasswordChar = true;
        txtWindowsPassword.Size = new Size(340, 24);
        txtWindowsPassword.TabIndex = 6;

        // 
        // pnlBottom
        // 
        pnlBottom.BackColor = Color.FromArgb(248, 250, 252);
        pnlBottom.Controls.Add(btnSave);
        pnlBottom.Controls.Add(btnCancel);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Location = new Point(0, 525);
        pnlBottom.Name = "pnlBottom";
        pnlBottom.Size = new Size(840, 55);
        pnlBottom.TabIndex = 3;

        // 
        // btnCancel
        // 
        btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnCancel.BackColor = Color.White;
        btnCancel.Cursor = Cursors.Hand;
        btnCancel.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnCancel.FlatStyle = FlatStyle.Flat;
        btnCancel.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        btnCancel.ForeColor = Color.FromArgb(51, 65, 85);
        btnCancel.Location = new Point(555, 10);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(110, 36);
        btnCancel.TabIndex = 0;
        btnCancel.Text = "Cancelar";
        btnCancel.UseVisualStyleBackColor = false;
        btnCancel.Click += btnCancel_Click;

        // 
        // btnSave
        // 
        btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnSave.BackColor = Color.FromArgb(37, 99, 235); // Electric Blue
        btnSave.Cursor = Cursors.Hand;
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.FlatStyle = FlatStyle.Flat;
        btnSave.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        btnSave.ForeColor = Color.White;
        btnSave.Location = new Point(678, 10);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(150, 36);
        btnSave.TabIndex = 1;
        btnSave.Text = "Guardar y Programar";
        btnSave.UseVisualStyleBackColor = false;
        btnSave.Click += btnSave_Click;

        // 
        // JobEditForm
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(248, 250, 252);
        ClientSize = new Size(840, 580);
        Controls.Add(pnlWizardContentContainer);
        Controls.Add(pnlWizardSidebar);
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
        pnlWizardSidebar.ResumeLayout(false);
        pnlWizardSidebar.PerformLayout();
        pnlWizardContentContainer.ResumeLayout(false);
        pnlStepSql.ResumeLayout(false);
        pnlStepSql.PerformLayout();
        pnlStepSchedule.ResumeLayout(false);
        pnlStepSchedule.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numDayOfMonth).EndInit();
        pnlWeeklyDays.ResumeLayout(false);
        pnlWeeklyDays.PerformLayout();
        pnlStepBackup.ResumeLayout(false);
        pnlStepBackup.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numRetentionCount).EndInit();
        ((System.ComponentModel.ISupportInitialize)numRetentionDays).EndInit();
        pnlStepCloud.ResumeLayout(false);
        pnlStepCloud.PerformLayout();
        pnlCloudHelp.ResumeLayout(false);
        pnlStepWindows.ResumeLayout(false);
        pnlStepWindows.PerformLayout();
        pnlWindowsHelp.ResumeLayout(false);
        pnlBottom.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlHeader;
    private Label lblHeader;
    private Label lblSubHeader;

    private Panel pnlWizardSidebar;
    private Label lblWizardHeader;
    private Button btnStepSql;
    private Button btnStepSchedule;
    private Button btnStepBackup;
    private Button btnStepCloud;
    private Button btnStepWindows;

    private Panel pnlWizardContentContainer;

    private Panel pnlStepSql;
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

    private Panel pnlStepSchedule;
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

    private Panel pnlStepBackup;
    private Label lblBackupType;
    private ComboBox cboBackupType;
    private Label lblCompression;
    private ComboBox cboCompression;
    private Label lblLocalPath;
    private TextBox txtLocalPath;
    private Button btnBrowseFolder;
    private Label lblRetentionMode;
    private ComboBox cboRetentionMode;
    private Label lblRetentionCount;
    private NumericUpDown numRetentionCount;
    private Label lblRetentionDays;
    private NumericUpDown numRetentionDays;
    private CheckBox chkRetentionLocal;
    private CheckBox chkRetentionCloud;

    private Panel pnlStepCloud;
    private CheckBox chkEnableCloud;
    private Label lblCloudProvider;
    private ComboBox cboCloudProvider;
    private Label lblCloudToken;
    private TextBox txtCloudToken;
    private Label lblCloudFolder;
    private TextBox txtCloudFolder;
    private Panel pnlCloudHelp;
    private Label lblCloudHelpText;

    private Panel pnlStepWindows;
    private Panel pnlWindowsHelp;
    private Label lblWindowsHelpText;
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
