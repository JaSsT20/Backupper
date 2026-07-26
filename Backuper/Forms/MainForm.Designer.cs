namespace Backuper.Forms;

partial class MainForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();

        pnlSidebar = new Panel();
        pnlSidebarLogo = new Panel();
        lblLogoSub = new Label();
        lblLogoTitle = new Label();
        lblNavHeader = new Label();
        btnNavDashboard = new Button();
        btnNavExplorer = new Button();
        btnNavLogs = new Button();
        btnNavSettings = new Button();
        pnlSidebarFooter = new Panel();
        lblSystemStatus = new Label();

        pnlTopNav = new Panel();
        lblPageTitle = new Label();
        lblPageSubtitle = new Label();
        btnGlobalRefresh = new Button();

        pnlMainContainer = new Panel();

        // View 1: Dashboard
        pnlViewDashboard = new Panel();
        pnlStatCards = new TableLayoutPanel();
        cardTotalJobs = new Panel();
        lblStatTotalValue = new Label();
        lblStatTotalTitle = new Label();
        cardActiveJobs = new Panel();
        lblStatActiveValue = new Label();
        lblStatActiveTitle = new Label();
        cardCloudJobs = new Panel();
        lblStatCloudValue = new Label();
        lblStatCloudTitle = new Label();
        cardNextRun = new Panel();
        lblStatNextValue = new Label();
        lblStatNextTitle = new Label();

        pnlTableSection = new Panel();
        pnlToolbar = new FlowLayoutPanel();
        btnNewJob = new Button();
        btnEditJob = new Button();
        btnDuplicateJob = new Button();
        btnRunNow = new Button();
        btnDeleteJob = new Button();
        btnViewLogs = new Button();

        dgvJobs = new DataGridView();
        colName = new DataGridViewTextBoxColumn();
        colDatabase = new DataGridViewTextBoxColumn();
        colServer = new DataGridViewTextBoxColumn();
        colType = new DataGridViewTextBoxColumn();
        colFrequency = new DataGridViewTextBoxColumn();
        colTaskStatus = new DataGridViewTextBoxColumn();
        colLastRun = new DataGridViewTextBoxColumn();
        colNextRun = new DataGridViewTextBoxColumn();

        // View 2: Explorer
        pnlViewExplorer = new Panel();
        pnlFilesFilter = new Panel();
        lblFilterLocation = new Label();
        cboFileLocationFilter = new ComboBox();
        btnRefreshFiles = new Button();
        lblFilesInfo = new Label();

        dgvBackupFiles = new DataGridView();
        colFileItemName = new DataGridViewTextBoxColumn();
        colFileJob = new DataGridViewTextBoxColumn();
        colFileLocation = new DataGridViewTextBoxColumn();
        colFileSizeFormatted = new DataGridViewTextBoxColumn();
        colFileDateFormatted = new DataGridViewTextBoxColumn();
        colFileFullPath = new DataGridViewTextBoxColumn();

        // View 3: General Settings
        pnlViewSettings = new Panel();
        pnlSettingsContent = new TableLayoutPanel();

        cardSetSql = new Panel();
        lblSetSqlTitle = new Label();
        lblSetSqlServer = new Label();
        txtSetSqlServer = new TextBox();
        lblSetSqlAuth = new Label();
        rdoSetAuthWindows = new RadioButton();
        rdoSetAuthSql = new RadioButton();
        lblSetSqlUser = new Label();
        txtSetSqlUser = new TextBox();
        lblSetSqlPassword = new Label();
        txtSetSqlPassword = new TextBox();
        lblSetSqlDatabase = new Label();
        txtSetSqlDatabase = new TextBox();

        cardSetBackup = new Panel();
        lblSetBackupTitle = new Label();
        lblSetLocalPath = new Label();
        txtSetLocalPath = new TextBox();
        btnSetBrowseFolder = new Button();
        lblSetBackupType = new Label();
        cboSetBackupType = new ComboBox();
        lblSetCompression = new Label();
        cboSetCompression = new ComboBox();

        cardSetCloud = new Panel();
        lblSetCloudTitle = new Label();
        chkSetEnableCloud = new CheckBox();
        lblSetCloudToken = new Label();
        txtSetCloudToken = new TextBox();
        lblSetCloudFolder = new Label();
        txtSetCloudFolder = new TextBox();

        cardSetWindows = new Panel();
        lblSetWindowsTitle = new Label();
        lblSetWinWarning = new Label();
        lblSetWindowsDomain = new Label();
        txtSetWindowsDomain = new TextBox();
        lblSetWindowsUser = new Label();
        txtSetWindowsUser = new TextBox();
        lblSetWindowsPassword = new Label();
        txtSetWindowsPassword = new TextBox();

        pnlSettingsBottom = new Panel();
        btnSaveSettings = new Button();

        statusStrip = new StatusStrip();
        lblStatusCount = new ToolStripStatusLabel();
        lblStatusPath = new ToolStripStatusLabel();

        pnlSidebar.SuspendLayout();
        pnlSidebarLogo.SuspendLayout();
        pnlSidebarFooter.SuspendLayout();
        pnlTopNav.SuspendLayout();
        pnlMainContainer.SuspendLayout();
        pnlViewDashboard.SuspendLayout();
        pnlStatCards.SuspendLayout();
        cardTotalJobs.SuspendLayout();
        cardActiveJobs.SuspendLayout();
        cardCloudJobs.SuspendLayout();
        cardNextRun.SuspendLayout();
        pnlTableSection.SuspendLayout();
        pnlToolbar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvJobs).BeginInit();
        pnlViewExplorer.SuspendLayout();
        pnlFilesFilter.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvBackupFiles).BeginInit();
        pnlViewSettings.SuspendLayout();
        pnlSettingsContent.SuspendLayout();
        cardSetSql.SuspendLayout();
        cardSetBackup.SuspendLayout();
        cardSetCloud.SuspendLayout();
        cardSetWindows.SuspendLayout();
        pnlSettingsBottom.SuspendLayout();
        statusStrip.SuspendLayout();
        SuspendLayout();

        // 
        // pnlSidebar (Navegación Lateral Estilo Web)
        // 
        pnlSidebar.BackColor = Color.FromArgb(15, 23, 42); // Slate 900
        pnlSidebar.Controls.Add(btnNavSettings);
        pnlSidebar.Controls.Add(btnNavLogs);
        pnlSidebar.Controls.Add(btnNavExplorer);
        pnlSidebar.Controls.Add(btnNavDashboard);
        pnlSidebar.Controls.Add(lblNavHeader);
        pnlSidebar.Controls.Add(pnlSidebarLogo);
        pnlSidebar.Controls.Add(pnlSidebarFooter);
        pnlSidebar.Dock = DockStyle.Left;
        pnlSidebar.Location = new Point(0, 0);
        pnlSidebar.Name = "pnlSidebar";
        pnlSidebar.Size = new Size(240, 720);
        pnlSidebar.TabIndex = 0;

        // 
        // pnlSidebarLogo
        // 
        pnlSidebarLogo.BackColor = Color.FromArgb(15, 23, 42);
        pnlSidebarLogo.Controls.Add(lblLogoSub);
        pnlSidebarLogo.Controls.Add(lblLogoTitle);
        pnlSidebarLogo.Dock = DockStyle.Top;
        pnlSidebarLogo.Location = new Point(0, 0);
        pnlSidebarLogo.Name = "pnlSidebarLogo";
        pnlSidebarLogo.Size = new Size(240, 75);
        pnlSidebarLogo.TabIndex = 0;

        // 
        // lblLogoTitle
        // 
        lblLogoTitle.AutoSize = true;
        lblLogoTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblLogoTitle.ForeColor = Color.White;
        lblLogoTitle.Location = new Point(20, 16);
        lblLogoTitle.Name = "lblLogoTitle";
        lblLogoTitle.Size = new Size(111, 30);
        lblLogoTitle.TabIndex = 0;
        lblLogoTitle.Text = "Backuper";

        // 
        // lblLogoSub
        // 
        lblLogoSub.AutoSize = true;
        lblLogoSub.Font = new Font("Segoe UI", 8.5F);
        lblLogoSub.ForeColor = Color.FromArgb(148, 163, 184); // Slate 400
        lblLogoSub.Location = new Point(22, 48);
        lblLogoSub.Name = "lblLogoSub";
        lblLogoSub.Size = new Size(130, 15);
        lblLogoSub.TabIndex = 1;
        lblLogoSub.Text = "v1.2 Enterprise (.NET 8)";

        // 
        // lblNavHeader
        // 
        lblNavHeader.AutoSize = true;
        lblNavHeader.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblNavHeader.ForeColor = Color.FromArgb(71, 85, 105); // Slate 600
        lblNavHeader.Location = new Point(20, 95);
        lblNavHeader.Name = "lblNavHeader";
        lblNavHeader.Size = new Size(76, 13);
        lblNavHeader.TabIndex = 1;
        lblNavHeader.Text = "NAVEGACIÓN";

        // 
        // btnNavDashboard
        // 
        btnNavDashboard.BackColor = Color.FromArgb(30, 41, 59); // Active Slate 800
        btnNavDashboard.Cursor = Cursors.Hand;
        btnNavDashboard.FlatAppearance.BorderSize = 0;
        btnNavDashboard.FlatStyle = FlatStyle.Flat;
        btnNavDashboard.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        btnNavDashboard.ForeColor = Color.FromArgb(56, 189, 248); // Sky Blue Accent
        btnNavDashboard.Location = new Point(12, 118);
        btnNavDashboard.Name = "btnNavDashboard";
        btnNavDashboard.Padding = new Padding(12, 0, 0, 0);
        btnNavDashboard.Size = new Size(216, 44);
        btnNavDashboard.TabIndex = 2;
        btnNavDashboard.Text = "Tareas & Dashboard";
        btnNavDashboard.TextAlign = ContentAlignment.MiddleLeft;
        btnNavDashboard.UseVisualStyleBackColor = false;
        btnNavDashboard.Click += btnNavDashboard_Click;

        // 
        // btnNavExplorer
        // 
        btnNavExplorer.BackColor = Color.FromArgb(15, 23, 42);
        btnNavExplorer.Cursor = Cursors.Hand;
        btnNavExplorer.FlatAppearance.BorderSize = 0;
        btnNavExplorer.FlatStyle = FlatStyle.Flat;
        btnNavExplorer.Font = new Font("Segoe UI", 10F);
        btnNavExplorer.ForeColor = Color.FromArgb(203, 213, 225);
        btnNavExplorer.Location = new Point(12, 168);
        btnNavExplorer.Name = "btnNavExplorer";
        btnNavExplorer.Padding = new Padding(12, 0, 0, 0);
        btnNavExplorer.Size = new Size(216, 44);
        btnNavExplorer.TabIndex = 3;
        btnNavExplorer.Text = "Explorador de Archivos";
        btnNavExplorer.TextAlign = ContentAlignment.MiddleLeft;
        btnNavExplorer.UseVisualStyleBackColor = false;
        btnNavExplorer.Click += btnNavExplorer_Click;

        // 
        // btnNavLogs
        // 
        btnNavLogs.BackColor = Color.FromArgb(15, 23, 42);
        btnNavLogs.Cursor = Cursors.Hand;
        btnNavLogs.FlatAppearance.BorderSize = 0;
        btnNavLogs.FlatStyle = FlatStyle.Flat;
        btnNavLogs.Font = new Font("Segoe UI", 10F);
        btnNavLogs.ForeColor = Color.FromArgb(203, 213, 225);
        btnNavLogs.Location = new Point(12, 218);
        btnNavLogs.Name = "btnNavLogs";
        btnNavLogs.Padding = new Padding(12, 0, 0, 0);
        btnNavLogs.Size = new Size(216, 44);
        btnNavLogs.TabIndex = 4;
        btnNavLogs.Text = "Registros de Auditoría";
        btnNavLogs.TextAlign = ContentAlignment.MiddleLeft;
        btnNavLogs.UseVisualStyleBackColor = false;
        btnNavLogs.Click += btnViewLogs_Click;

        // 
        // btnNavSettings
        // 
        btnNavSettings.BackColor = Color.FromArgb(15, 23, 42);
        btnNavSettings.Cursor = Cursors.Hand;
        btnNavSettings.FlatAppearance.BorderSize = 0;
        btnNavSettings.FlatStyle = FlatStyle.Flat;
        btnNavSettings.Font = new Font("Segoe UI", 10F);
        btnNavSettings.ForeColor = Color.FromArgb(203, 213, 225);
        btnNavSettings.Location = new Point(12, 268);
        btnNavSettings.Name = "btnNavSettings";
        btnNavSettings.Padding = new Padding(12, 0, 0, 0);
        btnNavSettings.Size = new Size(216, 44);
        btnNavSettings.TabIndex = 5;
        btnNavSettings.Text = "Configuración General";
        btnNavSettings.TextAlign = ContentAlignment.MiddleLeft;
        btnNavSettings.UseVisualStyleBackColor = false;
        btnNavSettings.Click += btnNavSettings_Click;

        // 
        // pnlSidebarFooter
        // 
        pnlSidebarFooter.Controls.Add(lblSystemStatus);
        pnlSidebarFooter.Dock = DockStyle.Bottom;
        pnlSidebarFooter.Location = new Point(0, 670);
        pnlSidebarFooter.Name = "pnlSidebarFooter";
        pnlSidebarFooter.Size = new Size(240, 50);
        pnlSidebarFooter.TabIndex = 6;

        // 
        // lblSystemStatus
        // 
        lblSystemStatus.AutoSize = true;
        lblSystemStatus.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
        lblSystemStatus.ForeColor = Color.FromArgb(74, 222, 128); // Green 400
        lblSystemStatus.Location = new Point(16, 16);
        lblSystemStatus.Name = "lblSystemStatus";
        lblSystemStatus.Size = new Size(168, 15);
        lblSystemStatus.TabIndex = 0;
        lblSystemStatus.Text = "Task Scheduler Activo";

        // 
        // pnlTopNav (Barra Superior)
        // 
        pnlTopNav.BackColor = Color.White;
        pnlTopNav.Controls.Add(btnGlobalRefresh);
        pnlTopNav.Controls.Add(lblPageSubtitle);
        pnlTopNav.Controls.Add(lblPageTitle);
        pnlTopNav.Dock = DockStyle.Top;
        pnlTopNav.Location = new Point(240, 0);
        pnlTopNav.Name = "pnlTopNav";
        pnlTopNav.Size = new Size(1040, 75);
        pnlTopNav.TabIndex = 1;

        // 
        // lblPageTitle
        // 
        lblPageTitle.AutoSize = true;
        lblPageTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        lblPageTitle.ForeColor = Color.FromArgb(15, 23, 42); // Slate 900
        lblPageTitle.Location = new Point(24, 14);
        lblPageTitle.Name = "lblPageTitle";
        lblPageTitle.Size = new Size(244, 28);
        lblPageTitle.TabIndex = 0;
        lblPageTitle.Text = "Dashboard de Respaldos";

        // 
        // lblPageSubtitle
        // 
        lblPageSubtitle.AutoSize = true;
        lblPageSubtitle.Font = new Font("Segoe UI", 9.5F);
        lblPageSubtitle.ForeColor = Color.FromArgb(100, 116, 139); // Slate 500
        lblPageSubtitle.Location = new Point(26, 44);
        lblPageSubtitle.Name = "lblPageSubtitle";
        lblPageSubtitle.Size = new Size(475, 17);
        lblPageSubtitle.TabIndex = 1;
        lblPageSubtitle.Text = "Gestión y programación desatendida de bases de datos Microsoft SQL Server.";

        // 
        // btnGlobalRefresh
        // 
        btnGlobalRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnGlobalRefresh.BackColor = Color.FromArgb(241, 245, 249);
        btnGlobalRefresh.Cursor = Cursors.Hand;
        btnGlobalRefresh.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnGlobalRefresh.FlatStyle = FlatStyle.Flat;
        btnGlobalRefresh.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        btnGlobalRefresh.ForeColor = Color.FromArgb(30, 41, 59);
        btnGlobalRefresh.Location = new Point(885, 18);
        btnGlobalRefresh.Name = "btnGlobalRefresh";
        btnGlobalRefresh.Size = new Size(130, 38);
        btnGlobalRefresh.TabIndex = 2;
        btnGlobalRefresh.Text = "Actualizar Datos";
        btnGlobalRefresh.UseVisualStyleBackColor = false;
        btnGlobalRefresh.Click += btnRefresh_Click;

        // 
        // pnlMainContainer (Contenedor Principal)
        // 
        pnlMainContainer.BackColor = Color.FromArgb(248, 250, 252);
        pnlMainContainer.Controls.Add(pnlViewDashboard);
        pnlMainContainer.Controls.Add(pnlViewExplorer);
        pnlMainContainer.Controls.Add(pnlViewSettings);
        pnlMainContainer.Dock = DockStyle.Fill;
        pnlMainContainer.Location = new Point(240, 75);
        pnlMainContainer.Name = "pnlMainContainer";
        pnlMainContainer.Padding = new Padding(24);
        pnlMainContainer.Size = new Size(1040, 623);
        pnlMainContainer.TabIndex = 2;

        // 
        // pnlViewDashboard (Vista 1: Dashboard)
        // 
        pnlViewDashboard.Controls.Add(pnlTableSection);
        pnlViewDashboard.Controls.Add(pnlStatCards);
        pnlViewDashboard.Dock = DockStyle.Fill;
        pnlViewDashboard.Location = new Point(24, 24);
        pnlViewDashboard.Name = "pnlViewDashboard";
        pnlViewDashboard.Size = new Size(992, 575);
        pnlViewDashboard.TabIndex = 0;

        // 
        // pnlStatCards (Tarjetas KPI)
        // 
        pnlStatCards.ColumnCount = 4;
        pnlStatCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        pnlStatCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        pnlStatCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        pnlStatCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        pnlStatCards.Controls.Add(cardTotalJobs, 0, 0);
        pnlStatCards.Controls.Add(cardActiveJobs, 1, 0);
        pnlStatCards.Controls.Add(cardCloudJobs, 2, 0);
        pnlStatCards.Controls.Add(cardNextRun, 3, 0);
        pnlStatCards.Dock = DockStyle.Top;
        pnlStatCards.Location = new Point(0, 0);
        pnlStatCards.Name = "pnlStatCards";
        pnlStatCards.RowCount = 1;
        pnlStatCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        pnlStatCards.Size = new Size(992, 90);
        pnlStatCards.TabIndex = 0;

        // 
        // cardTotalJobs
        // 
        cardTotalJobs.BackColor = Color.White;
        cardTotalJobs.BorderStyle = BorderStyle.FixedSingle;
        cardTotalJobs.Controls.Add(lblStatTotalValue);
        cardTotalJobs.Controls.Add(lblStatTotalTitle);
        cardTotalJobs.Dock = DockStyle.Fill;
        cardTotalJobs.Location = new Point(0, 0);
        cardTotalJobs.Margin = new Padding(0, 0, 12, 0);
        cardTotalJobs.Name = "cardTotalJobs";
        cardTotalJobs.Padding = new Padding(14);
        cardTotalJobs.Size = new Size(236, 90);
        cardTotalJobs.TabIndex = 0;

        lblStatTotalTitle.AutoSize = true;
        lblStatTotalTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblStatTotalTitle.ForeColor = Color.FromArgb(100, 116, 139);
        lblStatTotalTitle.Location = new Point(14, 12);
        lblStatTotalTitle.Name = "lblStatTotalTitle";
        lblStatTotalTitle.Size = new Size(86, 15);
        lblStatTotalTitle.Text = "TOTAL TAREAS";

        lblStatTotalValue.AutoSize = true;
        lblStatTotalValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblStatTotalValue.ForeColor = Color.FromArgb(15, 23, 42);
        lblStatTotalValue.Location = new Point(12, 36);
        lblStatTotalValue.Name = "lblStatTotalValue";
        lblStatTotalValue.Size = new Size(28, 32);
        lblStatTotalValue.Text = "0";

        // 
        // cardActiveJobs
        // 
        cardActiveJobs.BackColor = Color.White;
        cardActiveJobs.BorderStyle = BorderStyle.FixedSingle;
        cardActiveJobs.Controls.Add(lblStatActiveValue);
        cardActiveJobs.Controls.Add(lblStatActiveTitle);
        cardActiveJobs.Dock = DockStyle.Fill;
        cardActiveJobs.Location = new Point(248, 0);
        cardActiveJobs.Margin = new Padding(0, 0, 12, 0);
        cardActiveJobs.Name = "cardActiveJobs";
        cardActiveJobs.Padding = new Padding(14);
        cardActiveJobs.Size = new Size(236, 90);
        cardActiveJobs.TabIndex = 1;

        lblStatActiveTitle.AutoSize = true;
        lblStatActiveTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblStatActiveTitle.ForeColor = Color.FromArgb(100, 116, 139);
        lblStatActiveTitle.Location = new Point(14, 12);
        lblStatActiveTitle.Name = "lblStatActiveTitle";
        lblStatActiveTitle.Size = new Size(99, 15);
        lblStatActiveTitle.Text = "TAREAS ACTIVAS";

        lblStatActiveValue.AutoSize = true;
        lblStatActiveValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblStatActiveValue.ForeColor = Color.FromArgb(22, 163, 74);
        lblStatActiveValue.Location = new Point(12, 36);
        lblStatActiveValue.Name = "lblStatActiveValue";
        lblStatActiveValue.Size = new Size(28, 32);
        lblStatActiveValue.Text = "0";

        // 
        // cardCloudJobs
        // 
        cardCloudJobs.BackColor = Color.White;
        cardCloudJobs.BorderStyle = BorderStyle.FixedSingle;
        cardCloudJobs.Controls.Add(lblStatCloudValue);
        cardCloudJobs.Controls.Add(lblStatCloudTitle);
        cardCloudJobs.Dock = DockStyle.Fill;
        cardCloudJobs.Location = new Point(496, 0);
        cardCloudJobs.Margin = new Padding(0, 0, 12, 0);
        cardCloudJobs.Name = "cardCloudJobs";
        cardCloudJobs.Padding = new Padding(14);
        cardCloudJobs.Size = new Size(236, 90);
        cardCloudJobs.TabIndex = 2;

        lblStatCloudTitle.AutoSize = true;
        lblStatCloudTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblStatCloudTitle.ForeColor = Color.FromArgb(100, 116, 139);
        lblStatCloudTitle.Location = new Point(14, 12);
        lblStatCloudTitle.Name = "lblStatCloudTitle";
        lblStatCloudTitle.Size = new Size(125, 15);
        lblStatCloudTitle.Text = "SINCRONIZACIÓN NUBE";

        lblStatCloudValue.AutoSize = true;
        lblStatCloudValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblStatCloudValue.ForeColor = Color.FromArgb(37, 99, 235);
        lblStatCloudValue.Location = new Point(12, 38);
        lblStatCloudValue.Name = "lblStatCloudValue";
        lblStatCloudValue.Size = new Size(91, 25);
        lblStatCloudValue.Text = "Dropbox";

        // 
        // cardNextRun
        // 
        cardNextRun.BackColor = Color.White;
        cardNextRun.BorderStyle = BorderStyle.FixedSingle;
        cardNextRun.Controls.Add(lblStatNextValue);
        cardNextRun.Controls.Add(lblStatNextTitle);
        cardNextRun.Dock = DockStyle.Fill;
        cardNextRun.Location = new Point(744, 0);
        cardNextRun.Margin = new Padding(0);
        cardNextRun.Name = "cardNextRun";
        cardNextRun.Padding = new Padding(14);
        cardNextRun.Size = new Size(248, 90);
        cardNextRun.TabIndex = 3;

        lblStatNextTitle.AutoSize = true;
        lblStatNextTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblStatNextTitle.ForeColor = Color.FromArgb(100, 116, 139);
        lblStatNextTitle.Location = new Point(14, 12);
        lblStatNextTitle.Name = "lblStatNextTitle";
        lblStatNextTitle.Size = new Size(116, 15);
        lblStatNextTitle.Text = "PRÓXIMO RESPALDO";

        lblStatNextValue.AutoSize = true;
        lblStatNextValue.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
        lblStatNextValue.ForeColor = Color.FromArgb(15, 23, 42);
        lblStatNextValue.Location = new Point(12, 40);
        lblStatNextValue.Name = "lblStatNextValue";
        lblStatNextValue.Size = new Size(78, 20);
        lblStatNextValue.Text = "Pendiente";

        // 
        // pnlTableSection
        // 
        pnlTableSection.Controls.Add(dgvJobs);
        pnlTableSection.Controls.Add(pnlToolbar);
        pnlTableSection.Dock = DockStyle.Fill;
        pnlTableSection.Location = new Point(0, 90);
        pnlTableSection.Name = "pnlTableSection";
        pnlTableSection.Padding = new Padding(0, 15, 0, 0);
        pnlTableSection.Size = new Size(992, 485);
        pnlTableSection.TabIndex = 1;

        // 
        // pnlToolbar (Barra de Acciones)
        // 
        pnlToolbar.BackColor = Color.Transparent;
        pnlToolbar.Controls.Add(btnNewJob);
        pnlToolbar.Controls.Add(btnEditJob);
        pnlToolbar.Controls.Add(btnDuplicateJob);
        pnlToolbar.Controls.Add(btnRunNow);
        pnlToolbar.Controls.Add(btnDeleteJob);
        pnlToolbar.Controls.Add(btnViewLogs);
        pnlToolbar.Dock = DockStyle.Top;
        pnlToolbar.Location = new Point(0, 15);
        pnlToolbar.Name = "pnlToolbar";
        pnlToolbar.Padding = new Padding(0, 0, 0, 15);
        pnlToolbar.Size = new Size(992, 53);
        pnlToolbar.TabIndex = 0;

        // 
        // btnNewJob
        // 
        btnNewJob.BackColor = Color.FromArgb(37, 99, 235);
        btnNewJob.Cursor = Cursors.Hand;
        btnNewJob.FlatAppearance.BorderSize = 0;
        btnNewJob.FlatStyle = FlatStyle.Flat;
        btnNewJob.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        btnNewJob.ForeColor = Color.White;
        btnNewJob.Location = new Point(0, 0);
        btnNewJob.Margin = new Padding(0, 0, 12, 0);
        btnNewJob.Name = "btnNewJob";
        btnNewJob.Size = new Size(145, 38);
        btnNewJob.TabIndex = 0;
        btnNewJob.Text = "Nuevo Respaldo";
        btnNewJob.UseVisualStyleBackColor = false;
        btnNewJob.Click += btnNewJob_Click;

        // 
        // btnEditJob
        // 
        btnEditJob.BackColor = Color.White;
        btnEditJob.Cursor = Cursors.Hand;
        btnEditJob.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnEditJob.FlatStyle = FlatStyle.Flat;
        btnEditJob.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        btnEditJob.ForeColor = Color.FromArgb(51, 65, 85);
        btnEditJob.Location = new Point(157, 0);
        btnEditJob.Margin = new Padding(0, 0, 12, 0);
        btnEditJob.Name = "btnEditJob";
        btnEditJob.Size = new Size(95, 38);
        btnEditJob.TabIndex = 1;
        btnEditJob.Text = "Editar";
        btnEditJob.UseVisualStyleBackColor = false;
        btnEditJob.Click += btnEditJob_Click;

        // 
        // btnDuplicateJob (Nuevo Botón Duplicar Job)
        // 
        btnDuplicateJob.BackColor = Color.White;
        btnDuplicateJob.Cursor = Cursors.Hand;
        btnDuplicateJob.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnDuplicateJob.FlatStyle = FlatStyle.Flat;
        btnDuplicateJob.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        btnDuplicateJob.ForeColor = Color.FromArgb(79, 70, 229); // Texto Indigo Elegante
        btnDuplicateJob.Location = new Point(264, 0);
        btnDuplicateJob.Margin = new Padding(0, 0, 12, 0);
        btnDuplicateJob.Name = "btnDuplicateJob";
        btnDuplicateJob.Size = new Size(105, 38);
        btnDuplicateJob.TabIndex = 2;
        btnDuplicateJob.Text = "Duplicar";
        btnDuplicateJob.UseVisualStyleBackColor = false;
        btnDuplicateJob.Click += btnDuplicateJob_Click;

        // 
        // btnRunNow
        // 
        btnRunNow.BackColor = Color.White;
        btnRunNow.Cursor = Cursors.Hand;
        btnRunNow.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnRunNow.FlatStyle = FlatStyle.Flat;
        btnRunNow.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        btnRunNow.ForeColor = Color.FromArgb(22, 101, 52);
        btnRunNow.Location = new Point(381, 0);
        btnRunNow.Margin = new Padding(0, 0, 12, 0);
        btnRunNow.Name = "btnRunNow";
        btnRunNow.Size = new Size(135, 38);
        btnRunNow.TabIndex = 3;
        btnRunNow.Text = "Ejecutar Ahora";
        btnRunNow.UseVisualStyleBackColor = false;
        btnRunNow.Click += btnRunNow_Click;

        // 
        // btnDeleteJob
        // 
        btnDeleteJob.BackColor = Color.White;
        btnDeleteJob.Cursor = Cursors.Hand;
        btnDeleteJob.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnDeleteJob.FlatStyle = FlatStyle.Flat;
        btnDeleteJob.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        btnDeleteJob.ForeColor = Color.FromArgb(185, 28, 28);
        btnDeleteJob.Location = new Point(528, 0);
        btnDeleteJob.Margin = new Padding(0, 0, 12, 0);
        btnDeleteJob.Name = "btnDeleteJob";
        btnDeleteJob.Size = new Size(95, 38);
        btnDeleteJob.TabIndex = 4;
        btnDeleteJob.Text = "Eliminar";
        btnDeleteJob.UseVisualStyleBackColor = false;
        btnDeleteJob.Click += btnDeleteJob_Click;

        // 
        // btnViewLogs
        // 
        btnViewLogs.BackColor = Color.White;
        btnViewLogs.Cursor = Cursors.Hand;
        btnViewLogs.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnViewLogs.FlatStyle = FlatStyle.Flat;
        btnViewLogs.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        btnViewLogs.ForeColor = Color.FromArgb(51, 65, 85);
        btnViewLogs.Location = new Point(635, 0);
        btnViewLogs.Name = "btnViewLogs";
        btnViewLogs.Size = new Size(110, 38);
        btnViewLogs.TabIndex = 5;
        btnViewLogs.Text = "Ver Logs";
        btnViewLogs.UseVisualStyleBackColor = false;
        btnViewLogs.Click += btnViewLogs_Click;

        // 
        // dgvJobs
        // 
        dgvJobs.AllowUserToAddRows = false;
        dgvJobs.AllowUserToDeleteRows = false;
        dgvJobs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        dgvJobs.BackgroundColor = Color.White;
        dgvJobs.BorderStyle = BorderStyle.FixedSingle;
        dgvJobs.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        dgvJobs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(241, 245, 249);
        dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(30, 41, 59);
        dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(241, 245, 249);
        dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(30, 41, 59);
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvJobs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvJobs.ColumnHeadersHeight = 42;
        dgvJobs.Columns.AddRange(new DataGridViewColumn[] { colName, colDatabase, colServer, colType, colFrequency, colTaskStatus, colLastRun, colNextRun });

        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.White;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
        dataGridViewCellStyle2.ForeColor = Color.FromArgb(51, 65, 85);
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(238, 242, 255);
        dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(30, 41, 59);
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvJobs.DefaultCellStyle = dataGridViewCellStyle2;

        dgvJobs.Dock = DockStyle.Fill;
        dgvJobs.EnableHeadersVisualStyles = false;
        dgvJobs.GridColor = Color.FromArgb(226, 232, 240);
        dgvJobs.Location = new Point(0, 68);
        dgvJobs.MultiSelect = false;
        dgvJobs.Name = "dgvJobs";
        dgvJobs.ReadOnly = true;
        dgvJobs.RowHeadersVisible = false;
        dgvJobs.RowTemplate.Height = 40;
        dgvJobs.ScrollBars = ScrollBars.Both;
        dgvJobs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvJobs.Size = new Size(992, 417);
        dgvJobs.TabIndex = 1;
        dgvJobs.CellDoubleClick += dgvJobs_CellDoubleClick;
        dgvJobs.CellFormatting += dgvJobs_CellFormatting;

        // Columnas de dgvJobs
        colName.HeaderText = "Nombre de Tarea";
        colName.Name = "colName";
        colName.ReadOnly = true;
        colName.Width = 200;
        colName.MinimumWidth = 160;

        colDatabase.HeaderText = "Base de Datos";
        colDatabase.Name = "colDatabase";
        colDatabase.ReadOnly = true;
        colDatabase.Width = 150;
        colDatabase.MinimumWidth = 120;

        colServer.HeaderText = "Servidor SQL";
        colServer.Name = "colServer";
        colServer.ReadOnly = true;
        colServer.Width = 220;
        colServer.MinimumWidth = 170;

        colType.HeaderText = "Tipo Respaldo";
        colType.Name = "colType";
        colType.ReadOnly = true;
        colType.Width = 170;
        colType.MinimumWidth = 140;

        colFrequency.HeaderText = "Frecuencia / Hora";
        colFrequency.Name = "colFrequency";
        colFrequency.ReadOnly = true;
        colFrequency.Width = 180;
        colFrequency.MinimumWidth = 150;

        colTaskStatus.HeaderText = "Estado Windows";
        colTaskStatus.Name = "colTaskStatus";
        colTaskStatus.ReadOnly = true;
        colTaskStatus.Width = 150;
        colTaskStatus.MinimumWidth = 120;

        colLastRun.HeaderText = "Última Ejecución";
        colLastRun.Name = "colLastRun";
        colLastRun.ReadOnly = true;
        colLastRun.Width = 160;
        colLastRun.MinimumWidth = 130;

        colNextRun.HeaderText = "Próxima Ejecución";
        colNextRun.Name = "colNextRun";
        colNextRun.ReadOnly = true;
        colNextRun.Width = 160;
        colNextRun.MinimumWidth = 130;

        // 
        // pnlViewExplorer (Vista 2: Explorador)
        // 
        pnlViewExplorer.Controls.Add(dgvBackupFiles);
        pnlViewExplorer.Controls.Add(pnlFilesFilter);
        pnlViewExplorer.Dock = DockStyle.Fill;
        pnlViewExplorer.Location = new Point(24, 24);
        pnlViewExplorer.Name = "pnlViewExplorer";
        pnlViewExplorer.Size = new Size(992, 575);
        pnlViewExplorer.TabIndex = 1;
        pnlViewExplorer.Visible = false;

        // 
        // pnlFilesFilter
        // 
        pnlFilesFilter.BackColor = Color.White;
        pnlFilesFilter.BorderStyle = BorderStyle.FixedSingle;
        pnlFilesFilter.Controls.Add(lblFilesInfo);
        pnlFilesFilter.Controls.Add(btnRefreshFiles);
        pnlFilesFilter.Controls.Add(cboFileLocationFilter);
        pnlFilesFilter.Controls.Add(lblFilterLocation);
        pnlFilesFilter.Dock = DockStyle.Top;
        pnlFilesFilter.Location = new Point(0, 0);
        pnlFilesFilter.Name = "pnlFilesFilter";
        pnlFilesFilter.Padding = new Padding(12);
        pnlFilesFilter.Size = new Size(992, 58);
        pnlFilesFilter.TabIndex = 0;

        lblFilterLocation.AutoSize = true;
        lblFilterLocation.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblFilterLocation.ForeColor = Color.FromArgb(30, 41, 59);
        lblFilterLocation.Location = new Point(14, 18);
        lblFilterLocation.Name = "lblFilterLocation";
        lblFilterLocation.Size = new Size(54, 17);
        lblFilterLocation.TabIndex = 0;
        lblFilterLocation.Text = "Origen:";

        cboFileLocationFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        cboFileLocationFilter.FormattingEnabled = true;
        cboFileLocationFilter.Location = new Point(74, 15);
        cboFileLocationFilter.Name = "cboFileLocationFilter";
        cboFileLocationFilter.Size = new Size(220, 25);
        cboFileLocationFilter.TabIndex = 1;
        cboFileLocationFilter.SelectedIndexChanged += cboFileLocationFilter_SelectedIndexChanged;

        btnRefreshFiles.BackColor = Color.FromArgb(241, 245, 249);
        btnRefreshFiles.Cursor = Cursors.Hand;
        btnRefreshFiles.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnRefreshFiles.FlatStyle = FlatStyle.Flat;
        btnRefreshFiles.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        btnRefreshFiles.ForeColor = Color.FromArgb(30, 41, 59);
        btnRefreshFiles.Location = new Point(310, 12);
        btnRefreshFiles.Name = "btnRefreshFiles";
        btnRefreshFiles.Size = new Size(130, 32);
        btnRefreshFiles.TabIndex = 2;
        btnRefreshFiles.Text = "Refrescar Lista";
        btnRefreshFiles.UseVisualStyleBackColor = false;
        btnRefreshFiles.Click += btnRefreshFiles_Click;

        lblFilesInfo.AutoSize = true;
        lblFilesInfo.Font = new Font("Segoe UI", 9F);
        lblFilesInfo.ForeColor = Color.FromArgb(100, 116, 139);
        lblFilesInfo.Location = new Point(455, 20);
        lblFilesInfo.Name = "lblFilesInfo";
        lblFilesInfo.Size = new Size(396, 15);
        lblFilesInfo.TabIndex = 3;
        lblFilesInfo.Text = "Nota: Doble clic en un archivo local o de Dropbox para abrir su ubicación.";

        // 
        // dgvBackupFiles
        // 
        dgvBackupFiles.AllowUserToAddRows = false;
        dgvBackupFiles.AllowUserToDeleteRows = false;
        dgvBackupFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        dgvBackupFiles.BackgroundColor = Color.White;
        dgvBackupFiles.BorderStyle = BorderStyle.FixedSingle;
        dgvBackupFiles.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        dgvBackupFiles.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

        dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = Color.FromArgb(241, 245, 249);
        dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        dataGridViewCellStyle3.ForeColor = Color.FromArgb(30, 41, 59);
        dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(241, 245, 249);
        dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(30, 41, 59);
        dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
        dgvBackupFiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
        dgvBackupFiles.ColumnHeadersHeight = 42;
        dgvBackupFiles.Columns.AddRange(new DataGridViewColumn[] { colFileItemName, colFileJob, colFileLocation, colFileSizeFormatted, colFileDateFormatted, colFileFullPath });

        dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle4.BackColor = Color.White;
        dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.5F);
        dataGridViewCellStyle4.ForeColor = Color.FromArgb(51, 65, 85);
        dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(238, 242, 255);
        dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(30, 41, 59);
        dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
        dgvBackupFiles.DefaultCellStyle = dataGridViewCellStyle4;

        dgvBackupFiles.Dock = DockStyle.Fill;
        dgvBackupFiles.EnableHeadersVisualStyles = false;
        dgvBackupFiles.GridColor = Color.FromArgb(226, 232, 240);
        dgvBackupFiles.Location = new Point(0, 58);
        dgvBackupFiles.MultiSelect = false;
        dgvBackupFiles.Name = "dgvBackupFiles";
        dgvBackupFiles.ReadOnly = true;
        dgvBackupFiles.RowHeadersVisible = false;
        dgvBackupFiles.RowTemplate.Height = 40;
        dgvBackupFiles.ScrollBars = ScrollBars.Both;
        dgvBackupFiles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvBackupFiles.Size = new Size(992, 517);
        dgvBackupFiles.TabIndex = 1;
        dgvBackupFiles.CellDoubleClick += dgvBackupFiles_CellDoubleClick;
        dgvBackupFiles.CellFormatting += dgvBackupFiles_CellFormatting;

        colFileItemName.HeaderText = "Nombre de Archivo";
        colFileItemName.Name = "colFileItemName";
        colFileItemName.ReadOnly = true;
        colFileItemName.Width = 260;

        colFileJob.HeaderText = "Tarea / Base de Datos";
        colFileJob.Name = "colFileJob";
        colFileJob.ReadOnly = true;
        colFileJob.Width = 180;

        colFileLocation.HeaderText = "Ubicación";
        colFileLocation.Name = "colFileLocation";
        colFileLocation.ReadOnly = true;
        colFileLocation.Width = 140;

        colFileSizeFormatted.HeaderText = "Tamaño";
        colFileSizeFormatted.Name = "colFileSizeFormatted";
        colFileSizeFormatted.ReadOnly = true;
        colFileSizeFormatted.Width = 110;

        colFileDateFormatted.HeaderText = "Fecha de Creación";
        colFileDateFormatted.Name = "colFileDateFormatted";
        colFileDateFormatted.ReadOnly = true;
        colFileDateFormatted.Width = 160;

        colFileFullPath.HeaderText = "Ruta Completa";
        colFileFullPath.Name = "colFileFullPath";
        colFileFullPath.ReadOnly = true;
        colFileFullPath.Width = 320;

        // 
        // pnlViewSettings (Vista 3: Configuración General)
        // 
        pnlViewSettings.Controls.Add(pnlSettingsContent);
        pnlViewSettings.Controls.Add(pnlSettingsBottom);
        pnlViewSettings.Dock = DockStyle.Fill;
        pnlViewSettings.Location = new Point(24, 24);
        pnlViewSettings.Name = "pnlViewSettings";
        pnlViewSettings.Size = new Size(992, 575);
        pnlViewSettings.TabIndex = 2;
        pnlViewSettings.Visible = false;

        // 
        // pnlSettingsContent (Grid de 2x2 para Secciones de Ajustes)
        // 
        pnlSettingsContent.ColumnCount = 2;
        pnlSettingsContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        pnlSettingsContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        pnlSettingsContent.Controls.Add(cardSetSql, 0, 0);
        pnlSettingsContent.Controls.Add(cardSetBackup, 1, 0);
        pnlSettingsContent.Controls.Add(cardSetCloud, 0, 1);
        pnlSettingsContent.Controls.Add(cardSetWindows, 1, 1);
        pnlSettingsContent.Dock = DockStyle.Fill;
        pnlSettingsContent.Location = new Point(0, 0);
        pnlSettingsContent.Name = "pnlSettingsContent";
        pnlSettingsContent.RowCount = 2;
        pnlSettingsContent.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        pnlSettingsContent.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        pnlSettingsContent.Size = new Size(992, 520);
        pnlSettingsContent.TabIndex = 0;

        // 
        // cardSetSql (1. Conexión SQL por Defecto)
        // 
        cardSetSql.BackColor = Color.White;
        cardSetSql.BorderStyle = BorderStyle.FixedSingle;
        cardSetSql.Controls.Add(txtSetSqlDatabase);
        cardSetSql.Controls.Add(lblSetSqlDatabase);
        cardSetSql.Controls.Add(txtSetSqlPassword);
        cardSetSql.Controls.Add(lblSetSqlPassword);
        cardSetSql.Controls.Add(txtSetSqlUser);
        cardSetSql.Controls.Add(lblSetSqlUser);
        cardSetSql.Controls.Add(rdoSetAuthSql);
        cardSetSql.Controls.Add(rdoSetAuthWindows);
        cardSetSql.Controls.Add(lblSetSqlAuth);
        cardSetSql.Controls.Add(txtSetSqlServer);
        cardSetSql.Controls.Add(lblSetSqlServer);
        cardSetSql.Controls.Add(lblSetSqlTitle);
        cardSetSql.Dock = DockStyle.Fill;
        cardSetSql.Location = new Point(0, 0);
        cardSetSql.Margin = new Padding(0, 0, 12, 12);
        cardSetSql.Name = "cardSetSql";
        cardSetSql.Padding = new Padding(16);
        cardSetSql.Size = new Size(484, 248);
        cardSetSql.TabIndex = 0;

        lblSetSqlTitle.AutoSize = true;
        lblSetSqlTitle.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
        lblSetSqlTitle.ForeColor = Color.FromArgb(15, 23, 42);
        lblSetSqlTitle.Location = new Point(16, 12);
        lblSetSqlTitle.Name = "lblSetSqlTitle";
        lblSetSqlTitle.Size = new Size(204, 20);
        lblSetSqlTitle.TabIndex = 0;
        lblSetSqlTitle.Text = "Conexión SQL por Defecto";

        lblSetSqlServer.AutoSize = true;
        lblSetSqlServer.Location = new Point(16, 48);
        lblSetSqlServer.Name = "lblSetSqlServer";
        lblSetSqlServer.Size = new Size(92, 17);
        lblSetSqlServer.TabIndex = 1;
        lblSetSqlServer.Text = "Servidor SQL:";

        txtSetSqlServer.Location = new Point(140, 45);
        txtSetSqlServer.Name = "txtSetSqlServer";
        txtSetSqlServer.Size = new Size(310, 24);
        txtSetSqlServer.TabIndex = 2;
        txtSetSqlServer.Text = "localhost";

        lblSetSqlAuth.AutoSize = true;
        lblSetSqlAuth.Location = new Point(16, 85);
        lblSetSqlAuth.Name = "lblSetSqlAuth";
        lblSetSqlAuth.Size = new Size(95, 17);
        lblSetSqlAuth.TabIndex = 3;
        lblSetSqlAuth.Text = "Autenticación:";

        rdoSetAuthWindows.AutoSize = true;
        rdoSetAuthWindows.Checked = true;
        rdoSetAuthWindows.Location = new Point(140, 83);
        rdoSetAuthWindows.Name = "rdoSetAuthWindows";
        rdoSetAuthWindows.Size = new Size(80, 21);
        rdoSetAuthWindows.TabIndex = 4;
        rdoSetAuthWindows.TabStop = true;
        rdoSetAuthWindows.Text = "Windows";
        rdoSetAuthWindows.UseVisualStyleBackColor = true;
        rdoSetAuthWindows.CheckedChanged += rdoSetAuth_CheckedChanged;

        rdoSetAuthSql.AutoSize = true;
        rdoSetAuthSql.Location = new Point(230, 83);
        rdoSetAuthSql.Name = "rdoSetAuthSql";
        rdoSetAuthSql.Size = new Size(89, 21);
        rdoSetAuthSql.TabIndex = 5;
        rdoSetAuthSql.Text = "SQL Server";
        rdoSetAuthSql.UseVisualStyleBackColor = true;
        rdoSetAuthSql.CheckedChanged += rdoSetAuth_CheckedChanged;

        lblSetSqlUser.AutoSize = true;
        lblSetSqlUser.Location = new Point(16, 122);
        lblSetSqlUser.Name = "lblSetSqlUser";
        lblSetSqlUser.Size = new Size(56, 17);
        lblSetSqlUser.TabIndex = 6;
        lblSetSqlUser.Text = "Usuario:";

        txtSetSqlUser.Enabled = false;
        txtSetSqlUser.Location = new Point(140, 119);
        txtSetSqlUser.Name = "txtSetSqlUser";
        txtSetSqlUser.Size = new Size(130, 24);
        txtSetSqlUser.TabIndex = 7;

        lblSetSqlPassword.AutoSize = true;
        lblSetSqlPassword.Location = new Point(280, 122);
        lblSetSqlPassword.Name = "lblSetSqlPassword";
        lblSetSqlPassword.Size = new Size(41, 17);
        lblSetSqlPassword.TabIndex = 8;
        lblSetSqlPassword.Text = "Pass:";

        txtSetSqlPassword.Enabled = false;
        txtSetSqlPassword.Location = new Point(325, 119);
        txtSetSqlPassword.Name = "txtSetSqlPassword";
        txtSetSqlPassword.UseSystemPasswordChar = true;
        txtSetSqlPassword.Size = new Size(125, 24);
        txtSetSqlPassword.TabIndex = 9;

        lblSetSqlDatabase.AutoSize = true;
        lblSetSqlDatabase.Location = new Point(16, 160);
        lblSetSqlDatabase.Name = "lblSetSqlDatabase";
        lblSetSqlDatabase.Size = new Size(97, 17);
        lblSetSqlDatabase.TabIndex = 10;
        lblSetSqlDatabase.Text = "BD por Defecto:";

        txtSetSqlDatabase.Location = new Point(140, 157);
        txtSetSqlDatabase.Name = "txtSetSqlDatabase";
        txtSetSqlDatabase.Size = new Size(310, 24);
        txtSetSqlDatabase.TabIndex = 11;

        // 
        // cardSetBackup (2. Rutas & Destino por Defecto)
        // 
        cardSetBackup.BackColor = Color.White;
        cardSetBackup.BorderStyle = BorderStyle.FixedSingle;
        cardSetBackup.Controls.Add(cboSetCompression);
        cardSetBackup.Controls.Add(lblSetCompression);
        cardSetBackup.Controls.Add(cboSetBackupType);
        cardSetBackup.Controls.Add(lblSetBackupType);
        cardSetBackup.Controls.Add(btnSetBrowseFolder);
        cardSetBackup.Controls.Add(txtSetLocalPath);
        cardSetBackup.Controls.Add(lblSetLocalPath);
        cardSetBackup.Controls.Add(lblSetBackupTitle);
        cardSetBackup.Dock = DockStyle.Fill;
        cardSetBackup.Location = new Point(496, 0);
        cardSetBackup.Margin = new Padding(0, 0, 0, 12);
        cardSetBackup.Name = "cardSetBackup";
        cardSetBackup.Padding = new Padding(16);
        cardSetBackup.Size = new Size(496, 248);
        cardSetBackup.TabIndex = 1;

        lblSetBackupTitle.AutoSize = true;
        lblSetBackupTitle.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
        lblSetBackupTitle.ForeColor = Color.FromArgb(15, 23, 42);
        lblSetBackupTitle.Location = new Point(16, 12);
        lblSetBackupTitle.Name = "lblSetBackupTitle";
        lblSetBackupTitle.Size = new Size(207, 20);
        lblSetBackupTitle.TabIndex = 0;
        lblSetBackupTitle.Text = "Rutas y Destino por Defecto";

        lblSetLocalPath.AutoSize = true;
        lblSetLocalPath.Location = new Point(16, 48);
        lblSetLocalPath.Name = "lblSetLocalPath";
        lblSetLocalPath.Size = new Size(130, 17);
        lblSetLocalPath.TabIndex = 1;
        lblSetLocalPath.Text = "Carpeta Local Base:";

        txtSetLocalPath.Location = new Point(160, 45);
        txtSetLocalPath.Name = "txtSetLocalPath";
        txtSetLocalPath.Size = new Size(220, 24);
        txtSetLocalPath.TabIndex = 2;
        txtSetLocalPath.Text = @"C:\BackupsSQL";

        btnSetBrowseFolder.BackColor = Color.FromArgb(241, 245, 249);
        btnSetBrowseFolder.Cursor = Cursors.Hand;
        btnSetBrowseFolder.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnSetBrowseFolder.FlatStyle = FlatStyle.Flat;
        btnSetBrowseFolder.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
        btnSetBrowseFolder.Location = new Point(388, 44);
        btnSetBrowseFolder.Name = "btnSetBrowseFolder";
        btnSetBrowseFolder.Size = new Size(88, 27);
        btnSetBrowseFolder.TabIndex = 3;
        btnSetBrowseFolder.Text = "Examinar...";
        btnSetBrowseFolder.UseVisualStyleBackColor = false;
        btnSetBrowseFolder.Click += btnSetBrowseFolder_Click;

        lblSetBackupType.AutoSize = true;
        lblSetBackupType.Location = new Point(16, 95);
        lblSetBackupType.Name = "lblSetBackupType";
        lblSetBackupType.Size = new Size(115, 17);
        lblSetBackupType.TabIndex = 4;
        lblSetBackupType.Text = "Tipo de Respaldo:";

        cboSetBackupType.DropDownStyle = ComboBoxStyle.DropDownList;
        cboSetBackupType.FormattingEnabled = true;
        cboSetBackupType.Location = new Point(160, 92);
        cboSetBackupType.Name = "cboSetBackupType";
        cboSetBackupType.Size = new Size(316, 25);
        cboSetBackupType.TabIndex = 5;

        lblSetCompression.AutoSize = true;
        lblSetCompression.Location = new Point(16, 140);
        lblSetCompression.Name = "lblSetCompression";
        lblSetCompression.Size = new Size(83, 17);
        lblSetCompression.TabIndex = 6;
        lblSetCompression.Text = "Compresión:";

        cboSetCompression.DropDownStyle = ComboBoxStyle.DropDownList;
        cboSetCompression.FormattingEnabled = true;
        cboSetCompression.Location = new Point(160, 137);
        cboSetCompression.Name = "cboSetCompression";
        cboSetCompression.Size = new Size(316, 25);
        cboSetCompression.TabIndex = 7;

        // 
        // cardSetCloud (3. Dropbox / Nube por Defecto)
        // 
        cardSetCloud.BackColor = Color.White;
        cardSetCloud.BorderStyle = BorderStyle.FixedSingle;
        cardSetCloud.Controls.Add(txtSetCloudFolder);
        cardSetCloud.Controls.Add(lblSetCloudFolder);
        cardSetCloud.Controls.Add(txtSetCloudToken);
        cardSetCloud.Controls.Add(lblSetCloudToken);
        cardSetCloud.Controls.Add(chkSetEnableCloud);
        cardSetCloud.Controls.Add(lblSetCloudTitle);
        cardSetCloud.Dock = DockStyle.Fill;
        cardSetCloud.Location = new Point(0, 260);
        cardSetCloud.Margin = new Padding(0, 0, 12, 0);
        cardSetCloud.Name = "cardSetCloud";
        cardSetCloud.Padding = new Padding(16);
        cardSetCloud.Size = new Size(484, 260);
        cardSetCloud.TabIndex = 2;

        lblSetCloudTitle.AutoSize = true;
        lblSetCloudTitle.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
        lblSetCloudTitle.ForeColor = Color.FromArgb(15, 23, 42);
        lblSetCloudTitle.Location = new Point(16, 12);
        lblSetCloudTitle.Name = "lblSetCloudTitle";
        lblSetCloudTitle.Size = new Size(260, 20);
        lblSetCloudTitle.TabIndex = 0;
        lblSetCloudTitle.Text = "Sincronización Dropbox por Defecto";

        chkSetEnableCloud.AutoSize = true;
        chkSetEnableCloud.Location = new Point(16, 48);
        chkSetEnableCloud.Name = "chkSetEnableCloud";
        chkSetEnableCloud.Size = new Size(260, 21);
        chkSetEnableCloud.TabIndex = 1;
        chkSetEnableCloud.Text = "Habilitar sincronización nube por defecto";
        chkSetEnableCloud.UseVisualStyleBackColor = true;

        lblSetCloudToken.AutoSize = true;
        lblSetCloudToken.Location = new Point(16, 90);
        lblSetCloudToken.Name = "lblSetCloudToken";
        lblSetCloudToken.Size = new Size(144, 17);
        lblSetCloudToken.TabIndex = 2;
        lblSetCloudToken.Text = "Token/Refresh Token:";

        txtSetCloudToken.Location = new Point(165, 87);
        txtSetCloudToken.Name = "txtSetCloudToken";
        txtSetCloudToken.UseSystemPasswordChar = true;
        txtSetCloudToken.Size = new Size(285, 24);
        txtSetCloudToken.TabIndex = 3;

        lblSetCloudFolder.AutoSize = true;
        lblSetCloudFolder.Location = new Point(16, 132);
        lblSetCloudFolder.Name = "lblSetCloudFolder";
        lblSetCloudFolder.Size = new Size(106, 17);
        lblSetCloudFolder.TabIndex = 4;
        lblSetCloudFolder.Text = "Carpeta Remota:";

        txtSetCloudFolder.Location = new Point(165, 129);
        txtSetCloudFolder.Name = "txtSetCloudFolder";
        txtSetCloudFolder.Size = new Size(285, 24);
        txtSetCloudFolder.TabIndex = 5;
        txtSetCloudFolder.Text = "/Backups";

        // 
        // cardSetWindows (4. Credenciales Windows por Defecto)
        // 
        cardSetWindows.BackColor = Color.White;
        cardSetWindows.BorderStyle = BorderStyle.FixedSingle;
        cardSetWindows.Controls.Add(txtSetWindowsPassword);
        cardSetWindows.Controls.Add(lblSetWindowsPassword);
        cardSetWindows.Controls.Add(txtSetWindowsUser);
        cardSetWindows.Controls.Add(lblSetWindowsUser);
        cardSetWindows.Controls.Add(txtSetWindowsDomain);
        cardSetWindows.Controls.Add(lblSetWindowsDomain);
        cardSetWindows.Controls.Add(lblSetWinWarning);
        cardSetWindows.Controls.Add(lblSetWindowsTitle);
        cardSetWindows.Dock = DockStyle.Fill;
        cardSetWindows.Location = new Point(496, 260);
        cardSetWindows.Margin = new Padding(0);
        cardSetWindows.Name = "cardSetWindows";
        cardSetWindows.Padding = new Padding(16);
        cardSetWindows.Size = new Size(496, 260);
        cardSetWindows.TabIndex = 3;

        lblSetWindowsTitle.AutoSize = true;
        lblSetWindowsTitle.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
        lblSetWindowsTitle.ForeColor = Color.FromArgb(15, 23, 42);
        lblSetWindowsTitle.Location = new Point(16, 12);
        lblSetWindowsTitle.Name = "lblSetWindowsTitle";
        lblSetWindowsTitle.Size = new Size(248, 20);
        lblSetWindowsTitle.TabIndex = 0;
        lblSetWindowsTitle.Text = "Credenciales Windows por Defecto";

        lblSetWinWarning.AutoSize = true;
        lblSetWinWarning.Font = new Font("Segoe UI", 8F);
        lblSetWinWarning.ForeColor = Color.FromArgb(185, 28, 28);
        lblSetWinWarning.Location = new Point(16, 38);
        lblSetWinWarning.Name = "lblSetWinWarning";
        lblSetWinWarning.Size = new Size(403, 13);
        lblSetWinWarning.TabIndex = 1;
        lblSetWinWarning.Text = "Nota: El usuario requiere contraseña tradicional obligatoria para Task Scheduler.";

        lblSetWindowsDomain.AutoSize = true;
        lblSetWindowsDomain.Location = new Point(16, 72);
        lblSetWindowsDomain.Name = "lblSetWindowsDomain";
        lblSetWindowsDomain.Size = new Size(111, 17);
        lblSetWindowsDomain.TabIndex = 2;
        lblSetWindowsDomain.Text = "Dominio/Equipo:";

        txtSetWindowsDomain.Location = new Point(160, 69);
        txtSetWindowsDomain.Name = "txtSetWindowsDomain";
        txtSetWindowsDomain.Size = new Size(316, 24);
        txtSetWindowsDomain.TabIndex = 3;

        lblSetWindowsUser.AutoSize = true;
        lblSetWindowsUser.Location = new Point(16, 112);
        lblSetWindowsUser.Name = "lblSetWindowsUser";
        lblSetWindowsUser.Size = new Size(111, 17);
        lblSetWindowsUser.TabIndex = 4;
        lblSetWindowsUser.Text = "Usuario Windows:";

        txtSetWindowsUser.Location = new Point(160, 109);
        txtSetWindowsUser.Name = "txtSetWindowsUser";
        txtSetWindowsUser.Size = new Size(316, 24);
        txtSetWindowsUser.TabIndex = 5;

        lblSetWindowsPassword.AutoSize = true;
        lblSetWindowsPassword.Location = new Point(16, 152);
        lblSetWindowsPassword.Name = "lblSetWindowsPassword";
        lblSetWindowsPassword.Size = new Size(132, 17);
        lblSetWindowsPassword.TabIndex = 6;
        lblSetWindowsPassword.Text = "Contraseña Windows:";

        txtSetWindowsPassword.Location = new Point(160, 149);
        txtSetWindowsPassword.Name = "txtSetWindowsPassword";
        txtSetWindowsPassword.UseSystemPasswordChar = true;
        txtSetWindowsPassword.Size = new Size(316, 24);
        txtSetWindowsPassword.TabIndex = 7;

        // 
        // pnlSettingsBottom (Barra Inferior de Ajustes)
        // 
        pnlSettingsBottom.Controls.Add(btnSaveSettings);
        pnlSettingsBottom.Dock = DockStyle.Bottom;
        pnlSettingsBottom.Location = new Point(0, 520);
        pnlSettingsBottom.Name = "pnlSettingsBottom";
        pnlSettingsBottom.Size = new Size(992, 55);
        pnlSettingsBottom.TabIndex = 1;

        // 
        // btnSaveSettings
        // 
        btnSaveSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnSaveSettings.BackColor = Color.FromArgb(37, 99, 235); // Electric Blue
        btnSaveSettings.Cursor = Cursors.Hand;
        btnSaveSettings.FlatAppearance.BorderSize = 0;
        btnSaveSettings.FlatStyle = FlatStyle.Flat;
        btnSaveSettings.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        btnSaveSettings.ForeColor = Color.White;
        btnSaveSettings.Location = new Point(742, 10);
        btnSaveSettings.Name = "btnSaveSettings";
        btnSaveSettings.Size = new Size(250, 40);
        btnSaveSettings.TabIndex = 0;
        btnSaveSettings.Text = "Guardar Configuración General";
        btnSaveSettings.UseVisualStyleBackColor = false;
        btnSaveSettings.Click += btnSaveSettings_Click;

        // 
        // statusStrip
        // 
        statusStrip.BackColor = Color.FromArgb(15, 23, 42);
        statusStrip.ForeColor = Color.FromArgb(148, 163, 184);
        statusStrip.Items.AddRange(new ToolStripItem[] { lblStatusCount, lblStatusPath });
        statusStrip.Location = new Point(0, 698);
        statusStrip.Name = "statusStrip";
        statusStrip.Size = new Size(1280, 22);
        statusStrip.TabIndex = 3;

        lblStatusCount.Name = "lblStatusCount";
        lblStatusCount.Size = new Size(112, 17);
        lblStatusCount.Text = "Tareas registradas: 0";

        lblStatusPath.Name = "lblStatusPath";
        lblStatusPath.RightToLeft = RightToLeft.No;
        lblStatusPath.Size = new Size(1153, 17);
        lblStatusPath.Spring = true;
        lblStatusPath.Text = "Almacenamiento: ProgramData\\Backuper\\jobs";
        lblStatusPath.TextAlign = ContentAlignment.MiddleRight;

        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(248, 250, 252);
        ClientSize = new Size(1280, 720);
        Controls.Add(pnlMainContainer);
        Controls.Add(pnlTopNav);
        Controls.Add(pnlSidebar);
        Controls.Add(statusStrip);
        Font = new Font("Segoe UI", 9.5F);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MinimumSize = new Size(1100, 650);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Backuper — Gestor de Respaldos SQL Server";
        Load += MainForm_Load;
        pnlSidebar.ResumeLayout(false);
        pnlSidebar.PerformLayout();
        pnlSidebarLogo.ResumeLayout(false);
        pnlSidebarLogo.PerformLayout();
        pnlSidebarFooter.ResumeLayout(false);
        pnlSidebarFooter.PerformLayout();
        pnlTopNav.ResumeLayout(false);
        pnlTopNav.PerformLayout();
        pnlMainContainer.ResumeLayout(false);
        pnlViewDashboard.ResumeLayout(false);
        pnlStatCards.ResumeLayout(false);
        cardTotalJobs.ResumeLayout(false);
        cardTotalJobs.PerformLayout();
        cardActiveJobs.ResumeLayout(false);
        cardActiveJobs.PerformLayout();
        cardCloudJobs.ResumeLayout(false);
        cardCloudJobs.PerformLayout();
        cardNextRun.ResumeLayout(false);
        cardNextRun.PerformLayout();
        pnlTableSection.ResumeLayout(false);
        pnlToolbar.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvJobs).EndInit();
        pnlViewExplorer.ResumeLayout(false);
        pnlFilesFilter.ResumeLayout(false);
        pnlFilesFilter.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvBackupFiles).EndInit();
        pnlViewSettings.ResumeLayout(false);
        pnlSettingsContent.ResumeLayout(false);
        cardSetSql.ResumeLayout(false);
        cardSetSql.PerformLayout();
        cardSetBackup.ResumeLayout(false);
        cardSetBackup.PerformLayout();
        cardSetCloud.ResumeLayout(false);
        cardSetCloud.PerformLayout();
        cardSetWindows.ResumeLayout(false);
        cardSetWindows.PerformLayout();
        pnlSettingsBottom.ResumeLayout(false);
        statusStrip.ResumeLayout(false);
        statusStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Panel pnlSidebar;
    private Panel pnlSidebarLogo;
    private Label lblLogoTitle;
    private Label lblLogoSub;
    private Label lblNavHeader;
    private Button btnNavDashboard;
    private Button btnNavExplorer;
    private Button btnNavLogs;
    private Button btnNavSettings;
    private Panel pnlSidebarFooter;
    private Label lblSystemStatus;

    private Panel pnlTopNav;
    private Label lblPageTitle;
    private Label lblPageSubtitle;
    private Button btnGlobalRefresh;

    private Panel pnlMainContainer;

    // View 1: Dashboard
    private Panel pnlViewDashboard;
    private TableLayoutPanel pnlStatCards;
    private Panel cardTotalJobs;
    private Label lblStatTotalTitle;
    private Label lblStatTotalValue;
    private Panel cardActiveJobs;
    private Label lblStatActiveTitle;
    private Label lblStatActiveValue;
    private Panel cardCloudJobs;
    private Label lblStatCloudTitle;
    private Label lblStatCloudValue;
    private Panel cardNextRun;
    private Label lblStatNextTitle;
    private Label lblStatNextValue;

    private Panel pnlTableSection;
    private FlowLayoutPanel pnlToolbar;
    private Button btnNewJob;
    private Button btnEditJob;
    private Button btnDuplicateJob;
    private Button btnRunNow;
    private Button btnDeleteJob;
    private Button btnViewLogs;
    private DataGridView dgvJobs;
    private DataGridViewTextBoxColumn colName;
    private DataGridViewTextBoxColumn colDatabase;
    private DataGridViewTextBoxColumn colServer;
    private DataGridViewTextBoxColumn colType;
    private DataGridViewTextBoxColumn colFrequency;
    private DataGridViewTextBoxColumn colTaskStatus;
    private DataGridViewTextBoxColumn colLastRun;
    private DataGridViewTextBoxColumn colNextRun;

    // View 2: Explorer
    private Panel pnlViewExplorer;
    private Panel pnlFilesFilter;
    private Label lblFilterLocation;
    private ComboBox cboFileLocationFilter;
    private Button btnRefreshFiles;
    private Label lblFilesInfo;
    private DataGridView dgvBackupFiles;
    private DataGridViewTextBoxColumn colFileItemName;
    private DataGridViewTextBoxColumn colFileJob;
    private DataGridViewTextBoxColumn colFileLocation;
    private DataGridViewTextBoxColumn colFileSizeFormatted;
    private DataGridViewTextBoxColumn colFileDateFormatted;
    private DataGridViewTextBoxColumn colFileFullPath;

    // View 3: Settings
    private Panel pnlViewSettings;
    private TableLayoutPanel pnlSettingsContent;
    private Panel cardSetSql;
    private Label lblSetSqlTitle;
    private Label lblSetSqlServer;
    private TextBox txtSetSqlServer;
    private Label lblSetSqlAuth;
    private RadioButton rdoSetAuthWindows;
    private RadioButton rdoSetAuthSql;
    private Label lblSetSqlUser;
    private TextBox txtSetSqlUser;
    private Label lblSetSqlPassword;
    private TextBox txtSetSqlPassword;
    private Label lblSetSqlDatabase;
    private TextBox txtSetSqlDatabase;

    private Panel cardSetBackup;
    private Label lblSetBackupTitle;
    private Label lblSetLocalPath;
    private TextBox txtSetLocalPath;
    private Button btnSetBrowseFolder;
    private Label lblSetBackupType;
    private ComboBox cboSetBackupType;
    private Label lblSetCompression;
    private ComboBox cboSetCompression;

    private Panel cardSetCloud;
    private Label lblSetCloudTitle;
    private CheckBox chkSetEnableCloud;
    private Label lblSetCloudToken;
    private TextBox txtSetCloudToken;
    private Label lblSetCloudFolder;
    private TextBox txtSetCloudFolder;

    private Panel cardSetWindows;
    private Label lblSetWindowsTitle;
    private Label lblSetWinWarning;
    private Label lblSetWindowsDomain;
    private TextBox txtSetWindowsDomain;
    private Label lblSetWindowsUser;
    private TextBox txtSetWindowsUser;
    private Label lblSetWindowsPassword;
    private TextBox txtSetWindowsPassword;

    private Panel pnlSettingsBottom;
    private Button btnSaveSettings;

    private StatusStrip statusStrip;
    private ToolStripStatusLabel lblStatusCount;
    private ToolStripStatusLabel lblStatusPath;
}
