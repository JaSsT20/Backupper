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
        pnlHeader = new Panel();
        lblHeaderSubtitle = new Label();
        lblHeaderTitle = new Label();
        tabControlMain = new TabControl();
        tabJobs = new TabPage();
        dgvJobs = new DataGridView();
        colName = new DataGridViewTextBoxColumn();
        colDatabase = new DataGridViewTextBoxColumn();
        colServer = new DataGridViewTextBoxColumn();
        colType = new DataGridViewTextBoxColumn();
        colFrequency = new DataGridViewTextBoxColumn();
        colTaskStatus = new DataGridViewTextBoxColumn();
        colLastRun = new DataGridViewTextBoxColumn();
        colNextRun = new DataGridViewTextBoxColumn();
        pnlToolbar = new FlowLayoutPanel();
        btnNewJob = new Button();
        btnEditJob = new Button();
        btnRunNow = new Button();
        btnDeleteJob = new Button();
        btnRefresh = new Button();
        btnViewLogs = new Button();
        tabExplorer = new TabPage();
        dgvBackupFiles = new DataGridView();
        colFileItemName = new DataGridViewTextBoxColumn();
        colFileJob = new DataGridViewTextBoxColumn();
        colFileLocation = new DataGridViewTextBoxColumn();
        colFileSizeFormatted = new DataGridViewTextBoxColumn();
        colFileDateFormatted = new DataGridViewTextBoxColumn();
        colFileFullPath = new DataGridViewTextBoxColumn();
        pnlFilesFilter = new FlowLayoutPanel();
        lblFilterLocation = new Label();
        cboFileLocationFilter = new ComboBox();
        btnRefreshFiles = new Button();
        lblFilesInfo = new Label();
        statusStrip = new StatusStrip();
        lblStatusCount = new ToolStripStatusLabel();
        lblStatusPath = new ToolStripStatusLabel();
        pnlHeader.SuspendLayout();
        tabControlMain.SuspendLayout();
        tabJobs.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvJobs).BeginInit();
        pnlToolbar.SuspendLayout();
        tabExplorer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvBackupFiles).BeginInit();
        pnlFilesFilter.SuspendLayout();
        statusStrip.SuspendLayout();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.FromArgb(20, 30, 55);
        pnlHeader.Controls.Add(lblHeaderSubtitle);
        pnlHeader.Controls.Add(lblHeaderTitle);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Size = new Size(1008, 75);
        pnlHeader.TabIndex = 0;
        // 
        // lblHeaderSubtitle
        // 
        lblHeaderSubtitle.AutoSize = true;
        lblHeaderSubtitle.Font = new Font("Segoe UI", 9.5F);
        lblHeaderSubtitle.ForeColor = Color.FromArgb(170, 190, 220);
        lblHeaderSubtitle.Location = new Point(23, 46);
        lblHeaderSubtitle.Name = "lblHeaderSubtitle";
        lblHeaderSubtitle.Size = new Size(593, 17);
        lblHeaderSubtitle.TabIndex = 1;
        lblHeaderSubtitle.Text = "Configuración y programación de respaldos desatendidos vía Programador de Tareas de Windows.";
        // 
        // lblHeaderTitle
        // 
        lblHeaderTitle.AutoSize = true;
        lblHeaderTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblHeaderTitle.ForeColor = Color.White;
        lblHeaderTitle.Location = new Point(20, 14);
        lblHeaderTitle.Name = "lblHeaderTitle";
        lblHeaderTitle.Size = new Size(504, 30);
        lblHeaderTitle.TabIndex = 0;
        lblHeaderTitle.Text = "Backuper — Respaldos Automáticos SQL Server";
        // 
        // tabControlMain
        // 
        tabControlMain.Controls.Add(tabJobs);
        tabControlMain.Controls.Add(tabExplorer);
        tabControlMain.Dock = DockStyle.Fill;
        tabControlMain.Font = new Font("Segoe UI", 9.5F);
        tabControlMain.Location = new Point(0, 75);
        tabControlMain.Name = "tabControlMain";
        tabControlMain.SelectedIndex = 0;
        tabControlMain.Size = new Size(1008, 456);
        tabControlMain.TabIndex = 1;
        tabControlMain.SelectedIndexChanged += tabControlMain_SelectedIndexChanged;
        // 
        // tabJobs
        // 
        tabJobs.Controls.Add(dgvJobs);
        tabJobs.Controls.Add(pnlToolbar);
        tabJobs.Location = new Point(4, 26);
        tabJobs.Name = "tabJobs";
        tabJobs.Padding = new Padding(8);
        tabJobs.Size = new Size(1000, 426);
        tabJobs.TabIndex = 0;
        tabJobs.Text = "  Tareas Programadas  ";
        tabJobs.UseVisualStyleBackColor = true;
        // 
        // dgvJobs
        // 
        dgvJobs.AllowUserToAddRows = false;
        dgvJobs.AllowUserToDeleteRows = false;
        dgvJobs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvJobs.BackgroundColor = Color.White;
        dgvJobs.BorderStyle = BorderStyle.Fixed3D;
        dgvJobs.ColumnHeadersHeight = 34;
        dgvJobs.Columns.AddRange(new DataGridViewColumn[] { colName, colDatabase, colServer, colType, colFrequency, colTaskStatus, colLastRun, colNextRun });
        dgvJobs.Dock = DockStyle.Fill;
        dgvJobs.Location = new Point(8, 64);
        dgvJobs.MultiSelect = false;
        dgvJobs.Name = "dgvJobs";
        dgvJobs.ReadOnly = true;
        dgvJobs.RowHeadersVisible = false;
        dgvJobs.RowTemplate.Height = 32;
        dgvJobs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvJobs.Size = new Size(984, 354);
        dgvJobs.TabIndex = 1;
        dgvJobs.CellDoubleClick += dgvJobs_CellDoubleClick;
        // 
        // colName
        // 
        colName.HeaderText = "Nombre de Tarea";
        colName.Name = "colName";
        colName.ReadOnly = true;
        // 
        // colDatabase
        // 
        colDatabase.HeaderText = "Base de Datos";
        colDatabase.Name = "colDatabase";
        colDatabase.ReadOnly = true;
        // 
        // colServer
        // 
        colServer.HeaderText = "Servidor SQL";
        colServer.Name = "colServer";
        colServer.ReadOnly = true;
        // 
        // colType
        // 
        colType.HeaderText = "Tipo Respaldo";
        colType.Name = "colType";
        colType.ReadOnly = true;
        // 
        // colFrequency
        // 
        colFrequency.HeaderText = "Frecuencia / Hora";
        colFrequency.Name = "colFrequency";
        colFrequency.ReadOnly = true;
        // 
        // colTaskStatus
        // 
        colTaskStatus.HeaderText = "Estado Windows";
        colTaskStatus.Name = "colTaskStatus";
        colTaskStatus.ReadOnly = true;
        // 
        // colLastRun
        // 
        colLastRun.HeaderText = "Última Ejecución";
        colLastRun.Name = "colLastRun";
        colLastRun.ReadOnly = true;
        // 
        // colNextRun
        // 
        colNextRun.HeaderText = "Próxima Ejecución";
        colNextRun.Name = "colNextRun";
        colNextRun.ReadOnly = true;
        // 
        // pnlToolbar
        // 
        pnlToolbar.BackColor = Color.FromArgb(240, 244, 250);
        pnlToolbar.Controls.Add(btnNewJob);
        pnlToolbar.Controls.Add(btnEditJob);
        pnlToolbar.Controls.Add(btnRunNow);
        pnlToolbar.Controls.Add(btnDeleteJob);
        pnlToolbar.Controls.Add(btnRefresh);
        pnlToolbar.Controls.Add(btnViewLogs);
        pnlToolbar.Dock = DockStyle.Top;
        pnlToolbar.Location = new Point(8, 8);
        pnlToolbar.Name = "pnlToolbar";
        pnlToolbar.Padding = new Padding(6);
        pnlToolbar.Size = new Size(984, 56);
        pnlToolbar.TabIndex = 0;
        // 
        // btnNewJob
        // 
        btnNewJob.BackColor = Color.FromArgb(24, 119, 242);
        btnNewJob.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnNewJob.ForeColor = Color.White;
        btnNewJob.Location = new Point(9, 9);
        btnNewJob.Margin = new Padding(3, 3, 10, 3);
        btnNewJob.Name = "btnNewJob";
        btnNewJob.Size = new Size(130, 32);
        btnNewJob.TabIndex = 0;
        btnNewJob.Text = "Nuevo Respaldo";
        btnNewJob.UseVisualStyleBackColor = false;
        btnNewJob.Click += btnNewJob_Click;
        // 
        // btnEditJob
        // 
        btnEditJob.BackColor = Color.White;
        btnEditJob.Font = new Font("Segoe UI", 9.5F);
        btnEditJob.Location = new Point(152, 9);
        btnEditJob.Margin = new Padding(3, 3, 10, 3);
        btnEditJob.Name = "btnEditJob";
        btnEditJob.Size = new Size(95, 32);
        btnEditJob.TabIndex = 1;
        btnEditJob.Text = "Editar";
        btnEditJob.UseVisualStyleBackColor = false;
        btnEditJob.Click += btnEditJob_Click;
        // 
        // btnRunNow
        // 
        btnRunNow.BackColor = Color.FromArgb(235, 247, 238);
        btnRunNow.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnRunNow.ForeColor = Color.FromArgb(25, 130, 60);
        btnRunNow.Location = new Point(260, 9);
        btnRunNow.Margin = new Padding(3, 3, 10, 3);
        btnRunNow.Name = "btnRunNow";
        btnRunNow.Size = new Size(125, 32);
        btnRunNow.TabIndex = 2;
        btnRunNow.Text = "Ejecutar Ahora";
        btnRunNow.UseVisualStyleBackColor = false;
        btnRunNow.Click += btnRunNow_Click;
        // 
        // btnDeleteJob
        // 
        btnDeleteJob.BackColor = Color.FromArgb(255, 240, 240);
        btnDeleteJob.Font = new Font("Segoe UI", 9.5F);
        btnDeleteJob.ForeColor = Color.FromArgb(200, 30, 30);
        btnDeleteJob.Location = new Point(398, 9);
        btnDeleteJob.Margin = new Padding(3, 3, 10, 3);
        btnDeleteJob.Name = "btnDeleteJob";
        btnDeleteJob.Size = new Size(95, 32);
        btnDeleteJob.TabIndex = 3;
        btnDeleteJob.Text = "Eliminar";
        btnDeleteJob.UseVisualStyleBackColor = false;
        btnDeleteJob.Click += btnDeleteJob_Click;
        // 
        // btnRefresh
        // 
        btnRefresh.BackColor = Color.White;
        btnRefresh.Font = new Font("Segoe UI", 9.5F);
        btnRefresh.Location = new Point(506, 9);
        btnRefresh.Margin = new Padding(3, 3, 10, 3);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new Size(100, 32);
        btnRefresh.TabIndex = 4;
        btnRefresh.Text = "Actualizar";
        btnRefresh.UseVisualStyleBackColor = false;
        btnRefresh.Click += btnRefresh_Click;
        // 
        // btnViewLogs
        // 
        btnViewLogs.BackColor = Color.White;
        btnViewLogs.Font = new Font("Segoe UI", 9.5F);
        btnViewLogs.Location = new Point(619, 9);
        btnViewLogs.Name = "btnViewLogs";
        btnViewLogs.Size = new Size(110, 32);
        btnViewLogs.TabIndex = 5;
        btnViewLogs.Text = "Ver Registro";
        btnViewLogs.UseVisualStyleBackColor = false;
        btnViewLogs.Click += btnViewLogs_Click;
        // 
        // tabExplorer
        // 
        tabExplorer.Controls.Add(dgvBackupFiles);
        tabExplorer.Controls.Add(pnlFilesFilter);
        tabExplorer.Location = new Point(4, 26);
        tabExplorer.Name = "tabExplorer";
        tabExplorer.Padding = new Padding(8);
        tabExplorer.Size = new Size(1000, 426);
        tabExplorer.TabIndex = 1;
        tabExplorer.Text = "  Explorador de Respaldos (Archivos)  ";
        tabExplorer.UseVisualStyleBackColor = true;
        // 
        // dgvBackupFiles
        // 
        dgvBackupFiles.AllowUserToAddRows = false;
        dgvBackupFiles.AllowUserToDeleteRows = false;
        dgvBackupFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvBackupFiles.BackgroundColor = Color.White;
        dgvBackupFiles.BorderStyle = BorderStyle.Fixed3D;
        dgvBackupFiles.ColumnHeadersHeight = 34;
        dgvBackupFiles.Columns.AddRange(new DataGridViewColumn[] { colFileItemName, colFileJob, colFileLocation, colFileSizeFormatted, colFileDateFormatted, colFileFullPath });
        dgvBackupFiles.Dock = DockStyle.Fill;
        dgvBackupFiles.Location = new Point(8, 64);
        dgvBackupFiles.MultiSelect = false;
        dgvBackupFiles.Name = "dgvBackupFiles";
        dgvBackupFiles.ReadOnly = true;
        dgvBackupFiles.RowHeadersVisible = false;
        dgvBackupFiles.RowTemplate.Height = 32;
        dgvBackupFiles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvBackupFiles.Size = new Size(984, 354);
        dgvBackupFiles.TabIndex = 1;
        dgvBackupFiles.CellDoubleClick += dgvBackupFiles_CellDoubleClick;
        // 
        // colFileItemName
        // 
        colFileItemName.FillWeight = 140F;
        colFileItemName.HeaderText = "Nombre de Archivo";
        colFileItemName.Name = "colFileItemName";
        colFileItemName.ReadOnly = true;
        // 
        // colFileJob
        // 
        colFileJob.FillWeight = 110F;
        colFileJob.HeaderText = "Tarea / Base de Datos";
        colFileJob.Name = "colFileJob";
        colFileJob.ReadOnly = true;
        // 
        // colFileLocation
        // 
        colFileLocation.FillWeight = 70F;
        colFileLocation.HeaderText = "Ubicación";
        colFileLocation.Name = "colFileLocation";
        colFileLocation.ReadOnly = true;
        // 
        // colFileSizeFormatted
        // 
        colFileSizeFormatted.FillWeight = 70F;
        colFileSizeFormatted.HeaderText = "Tamaño";
        colFileSizeFormatted.Name = "colFileSizeFormatted";
        colFileSizeFormatted.ReadOnly = true;
        // 
        // colFileDateFormatted
        // 
        colFileDateFormatted.HeaderText = "Fecha de Creación";
        colFileDateFormatted.Name = "colFileDateFormatted";
        colFileDateFormatted.ReadOnly = true;
        // 
        // colFileFullPath
        // 
        colFileFullPath.FillWeight = 180F;
        colFileFullPath.HeaderText = "Ruta Completa";
        colFileFullPath.Name = "colFileFullPath";
        colFileFullPath.ReadOnly = true;
        // 
        // pnlFilesFilter
        // 
        pnlFilesFilter.BackColor = Color.FromArgb(240, 244, 250);
        pnlFilesFilter.Controls.Add(lblFilterLocation);
        pnlFilesFilter.Controls.Add(cboFileLocationFilter);
        pnlFilesFilter.Controls.Add(btnRefreshFiles);
        pnlFilesFilter.Controls.Add(lblFilesInfo);
        pnlFilesFilter.Dock = DockStyle.Top;
        pnlFilesFilter.Location = new Point(8, 8);
        pnlFilesFilter.Name = "pnlFilesFilter";
        pnlFilesFilter.Padding = new Padding(10, 12, 10, 10);
        pnlFilesFilter.Size = new Size(984, 56);
        pnlFilesFilter.TabIndex = 0;
        // 
        // lblFilterLocation
        // 
        lblFilterLocation.AutoSize = true;
        lblFilterLocation.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblFilterLocation.Location = new Point(13, 17);
        lblFilterLocation.Margin = new Padding(3, 5, 3, 0);
        lblFilterLocation.Name = "lblFilterLocation";
        lblFilterLocation.Size = new Size(54, 17);
        lblFilterLocation.TabIndex = 0;
        lblFilterLocation.Text = "Origen:";
        // 
        // cboFileLocationFilter
        // 
        cboFileLocationFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        cboFileLocationFilter.FormattingEnabled = true;
        cboFileLocationFilter.Location = new Point(73, 14);
        cboFileLocationFilter.Margin = new Padding(3, 2, 15, 3);
        cboFileLocationFilter.Name = "cboFileLocationFilter";
        cboFileLocationFilter.Size = new Size(200, 25);
        cboFileLocationFilter.TabIndex = 1;
        cboFileLocationFilter.SelectedIndexChanged += cboFileLocationFilter_SelectedIndexChanged;
        // 
        // btnRefreshFiles
        // 
        btnRefreshFiles.BackColor = Color.White;
        btnRefreshFiles.Location = new Point(291, 12);
        btnRefreshFiles.Margin = new Padding(3, 0, 15, 3);
        btnRefreshFiles.Name = "btnRefreshFiles";
        btnRefreshFiles.Size = new Size(130, 30);
        btnRefreshFiles.TabIndex = 2;
        btnRefreshFiles.Text = "Actualizar Archivos";
        btnRefreshFiles.UseVisualStyleBackColor = false;
        btnRefreshFiles.Click += btnRefreshFiles_Click;
        // 
        // lblFilesInfo
        // 
        lblFilesInfo.AutoSize = true;
        lblFilesInfo.ForeColor = Color.DimGray;
        lblFilesInfo.Location = new Point(439, 18);
        lblFilesInfo.Margin = new Padding(3, 6, 3, 0);
        lblFilesInfo.Name = "lblFilesInfo";
        lblFilesInfo.Size = new Size(432, 17);
        lblFilesInfo.TabIndex = 3;
        lblFilesInfo.Text = "💡 Doble clic en un archivo local para abrir su carpeta en el Explorador.";
        // 
        // statusStrip
        // 
        statusStrip.Items.AddRange(new ToolStripItem[] { lblStatusCount, lblStatusPath });
        statusStrip.Location = new Point(0, 531);
        statusStrip.Name = "statusStrip";
        statusStrip.Size = new Size(1008, 22);
        statusStrip.TabIndex = 2;
        // 
        // lblStatusCount
        // 
        lblStatusCount.Name = "lblStatusCount";
        lblStatusCount.Size = new Size(112, 17);
        lblStatusCount.Text = "Tareas registradas: 0";
        // 
        // lblStatusPath
        // 
        lblStatusPath.Name = "lblStatusPath";
        lblStatusPath.RightToLeft = RightToLeft.No;
        lblStatusPath.Size = new Size(881, 17);
        lblStatusPath.Spring = true;
        lblStatusPath.Text = "Almacenamiento: ProgramData\\Backuper\\jobs";
        lblStatusPath.TextAlign = ContentAlignment.MiddleRight;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1008, 553);
        Controls.Add(tabControlMain);
        Controls.Add(statusStrip);
        Controls.Add(pnlHeader);
        Font = new Font("Segoe UI", 9.5F);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Gestor de Respaldos Automáticos SQL Server";
        Load += MainForm_Load;
        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        tabControlMain.ResumeLayout(false);
        tabJobs.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvJobs).EndInit();
        pnlToolbar.ResumeLayout(false);
        tabExplorer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvBackupFiles).EndInit();
        pnlFilesFilter.ResumeLayout(false);
        pnlFilesFilter.PerformLayout();
        statusStrip.ResumeLayout(false);
        statusStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Panel pnlHeader;
    private Label lblHeaderTitle;
    private Label lblHeaderSubtitle;
    private TabControl tabControlMain;
    private TabPage tabJobs;
    private FlowLayoutPanel pnlToolbar;
    private Button btnNewJob;
    private Button btnEditJob;
    private Button btnRunNow;
    private Button btnDeleteJob;
    private Button btnRefresh;
    private Button btnViewLogs;
    private DataGridView dgvJobs;
    private TabPage tabExplorer;
    private FlowLayoutPanel pnlFilesFilter;
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
    private StatusStrip statusStrip;
    private ToolStripStatusLabel lblStatusCount;
    private ToolStripStatusLabel lblStatusPath;
    private DataGridViewTextBoxColumn colName;
    private DataGridViewTextBoxColumn colDatabase;
    private DataGridViewTextBoxColumn colServer;
    private DataGridViewTextBoxColumn colType;
    private DataGridViewTextBoxColumn colFrequency;
    private DataGridViewTextBoxColumn colTaskStatus;
    private DataGridViewTextBoxColumn colLastRun;
    private DataGridViewTextBoxColumn colNextRun;
}
