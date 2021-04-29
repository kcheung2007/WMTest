namespace WMTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(ie != null)
                ie.Close();

            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form1 ) );
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripbrnUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSimpleTest = new System.Windows.Forms.TabPage();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblDBName = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoOnline = new System.Windows.Forms.RadioButton();
            this.rdoOffline = new System.Windows.Forms.RadioButton();
            this.btnLegalHold = new System.Windows.Forms.Button();
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cboURL = new System.Windows.Forms.ComboBox();
            this.lnkURL = new System.Windows.Forms.LinkLabel();
            this.btnCount = new System.Windows.Forms.Button();
            this.btnAutoWeb = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblPST = new System.Windows.Forms.Label();
            this.lblFiles = new System.Windows.Forms.Label();
            this.lblExpectedResult = new System.Windows.Forms.Label();
            this.lblAcutualResult = new System.Windows.Forms.Label();
            this.txtExpectedSrc = new System.Windows.Forms.TextBox();
            this.txtExpectedPst = new System.Windows.Forms.TextBox();
            this.txtExpectedFile = new System.Windows.Forms.TextBox();
            this.txtActualSrc = new System.Windows.Forms.TextBox();
            this.txtActualPst = new System.Windows.Forms.TextBox();
            this.txtActualFile = new System.Windows.Forms.TextBox();
            this.txtExpectedProp = new System.Windows.Forms.TextBox();
            this.txtActualProp = new System.Windows.Forms.TextBox();
            this.lblProperties = new System.Windows.Forms.Label();
            this.cboOutput = new System.Windows.Forms.ComboBox();
            this.cboSource = new System.Windows.Forms.ComboBox();
            this.lnkOutput = new System.Windows.Forms.LinkLabel();
            this.lnkSource = new System.Windows.Forms.LinkLabel();
            this.tabAutoTest = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnAutoCount = new System.Windows.Forms.Button();
            this.lnkInput = new System.Windows.Forms.LinkLabel();
            this.cboInFile = new System.Windows.Forms.ComboBox();
            this.btnAutoTest = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList( this.components );
            this.toolTip = new System.Windows.Forms.ToolTip( this.components );
            this.folderBrowserDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.bgwDeleteFolders = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabSimpleTest.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabAutoTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.toolStripbrnUp,
            this.toolStripSeparator1,
            this.toolStripTextBox1} );
            this.toolStrip1.Location = new System.Drawing.Point( 0, 0 );
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size( 857, 25 );
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripbrnUp
            // 
            this.toolStripbrnUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripbrnUp.Image = ((System.Drawing.Image)(resources.GetObject( "toolStripbrnUp.Image" )));
            this.toolStripbrnUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbrnUp.Name = "toolStripbrnUp";
            this.toolStripbrnUp.Size = new System.Drawing.Size( 23, 22 );
            this.toolStripbrnUp.Text = "toolStripButton1";
            this.toolStripbrnUp.ToolTipText = "Up";
            this.toolStripbrnUp.Click += new System.EventHandler( this.toolStripbrnUp_Click );
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size( 6, 25 );
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.toolStripTextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.toolStripTextBox1.AutoToolTip = true;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size( 500, 25 );
            this.toolStripTextBox1.Text = "C:\\";
            this.toolStripTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler( this.toolStripTextBox1_KeyDown );
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point( 0, 25 );
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add( this.webBrowser1 );
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add( this.tabControl1 );
            this.splitContainer1.Size = new System.Drawing.Size( 857, 459 );
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.TabIndex = 1;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point( 0, 0 );
            this.webBrowser1.MinimumSize = new System.Drawing.Size( 20, 20 );
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size( 193, 459 );
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri( "c:\\", System.UriKind.Absolute );
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler( this.webBrowser1_Navigated );
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add( this.tabSimpleTest );
            this.tabControl1.Controls.Add( this.tabAutoTest );
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point( 0, 0 );
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size( 660, 459 );
            this.tabControl1.TabIndex = 0;
            // 
            // tabSimpleTest
            // 
            this.tabSimpleTest.Controls.Add( this.lblPassword );
            this.tabSimpleTest.Controls.Add( this.lblUserName );
            this.tabSimpleTest.Controls.Add( this.lblDBName );
            this.tabSimpleTest.Controls.Add( this.txtPassword );
            this.tabSimpleTest.Controls.Add( this.txtUserID );
            this.tabSimpleTest.Controls.Add( this.txtDatabase );
            this.tabSimpleTest.Controls.Add( this.groupBox1 );
            this.tabSimpleTest.Controls.Add( this.btnLegalHold );
            this.tabSimpleTest.Controls.Add( this.txtDisplay );
            this.tabSimpleTest.Controls.Add( this.btnDelete );
            this.tabSimpleTest.Controls.Add( this.cboURL );
            this.tabSimpleTest.Controls.Add( this.lnkURL );
            this.tabSimpleTest.Controls.Add( this.btnCount );
            this.tabSimpleTest.Controls.Add( this.btnAutoWeb );
            this.tabSimpleTest.Controls.Add( this.tableLayoutPanel1 );
            this.tabSimpleTest.Controls.Add( this.cboOutput );
            this.tabSimpleTest.Controls.Add( this.cboSource );
            this.tabSimpleTest.Controls.Add( this.lnkOutput );
            this.tabSimpleTest.Controls.Add( this.lnkSource );
            this.tabSimpleTest.Location = new System.Drawing.Point( 4, 22 );
            this.tabSimpleTest.Name = "tabSimpleTest";
            this.tabSimpleTest.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabSimpleTest.Size = new System.Drawing.Size( 652, 433 );
            this.tabSimpleTest.TabIndex = 0;
            this.tabSimpleTest.Text = "Simple Test";
            this.tabSimpleTest.UseVisualStyleBackColor = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point( 22, 212 );
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size( 53, 13 );
            this.lblPassword.TabIndex = 22;
            this.lblPassword.Text = "Password";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point( 32, 190 );
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size( 43, 13 );
            this.lblUserName.TabIndex = 21;
            this.lblUserName.Text = "User ID";
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.Location = new System.Drawing.Point( 22, 167 );
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size( 53, 13 );
            this.lblDBName.TabIndex = 20;
            this.lblDBName.Text = "DB Name";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point( 81, 207 );
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size( 100, 20 );
            this.txtPassword.TabIndex = 19;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point( 81, 186 );
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size( 100, 20 );
            this.txtUserID.TabIndex = 18;
            this.txtUserID.Text = "root";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point( 81, 165 );
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size( 100, 20 );
            this.txtDatabase.TabIndex = 17;
            this.txtDatabase.Text = "test";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.rdoOnline );
            this.groupBox1.Controls.Add( this.rdoOffline );
            this.groupBox1.Location = new System.Drawing.Point( 417, 100 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 74, 58 );
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // rdoOnline
            // 
            this.rdoOnline.AutoSize = true;
            this.rdoOnline.Checked = true;
            this.rdoOnline.Location = new System.Drawing.Point( 4, 29 );
            this.rdoOnline.Name = "rdoOnline";
            this.rdoOnline.Size = new System.Drawing.Size( 55, 17 );
            this.rdoOnline.TabIndex = 1;
            this.rdoOnline.TabStop = true;
            this.rdoOnline.Text = "Online";
            this.toolTip.SetToolTip( this.rdoOnline, "Online Processing" );
            this.rdoOnline.UseVisualStyleBackColor = true;
            // 
            // rdoOffline
            // 
            this.rdoOffline.AutoSize = true;
            this.rdoOffline.Location = new System.Drawing.Point( 4, 8 );
            this.rdoOffline.Name = "rdoOffline";
            this.rdoOffline.Size = new System.Drawing.Size( 55, 17 );
            this.rdoOffline.TabIndex = 0;
            this.rdoOffline.Text = "Offline";
            this.toolTip.SetToolTip( this.rdoOffline, "Offline Process" );
            this.rdoOffline.UseVisualStyleBackColor = true;
            // 
            // btnLegalHold
            // 
            this.btnLegalHold.Location = new System.Drawing.Point( 418, 25 );
            this.btnLegalHold.Name = "btnLegalHold";
            this.btnLegalHold.Size = new System.Drawing.Size( 75, 23 );
            this.btnLegalHold.TabIndex = 15;
            this.btnLegalHold.Text = "Legal Hold";
            this.toolTip.SetToolTip( this.btnLegalHold, "Check Legal Hold Status" );
            this.btnLegalHold.UseVisualStyleBackColor = true;
            this.btnLegalHold.Click += new System.EventHandler( this.btnLegalHold_Click );
            // 
            // txtDisplay
            // 
            this.txtDisplay.Location = new System.Drawing.Point( 11, 325 );
            this.txtDisplay.Multiline = true;
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.Size = new System.Drawing.Size( 472, 100 );
            this.txtDisplay.TabIndex = 14;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point( 418, 49 );
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size( 75, 23 );
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.toolTip.SetToolTip( this.btnDelete, "Count output files" );
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler( this.btnDelete_Click );
            // 
            // cboURL
            // 
            this.cboURL.FormattingEnabled = true;
            this.cboURL.Items.AddRange( new object[] {
            "Z:\\wamuTestData\\data\\dlh\\318993-DLH SOURCE",
            "Z:\\wamuTestData\\data\\dlh\\providian"} );
            this.cboURL.Location = new System.Drawing.Point( 55, 2 );
            this.cboURL.Name = "cboURL";
            this.cboURL.Size = new System.Drawing.Size( 359, 21 );
            this.cboURL.TabIndex = 0;
            this.cboURL.Text = "http://localhost:9999/aciserver4j";
            // 
            // lnkURL
            // 
            this.lnkURL.AutoSize = true;
            this.lnkURL.Location = new System.Drawing.Point( 23, 6 );
            this.lnkURL.Name = "lnkURL";
            this.lnkURL.Size = new System.Drawing.Size( 29, 13 );
            this.lnkURL.TabIndex = 7;
            this.lnkURL.TabStop = true;
            this.lnkURL.Text = "URL";
            this.toolTip.SetToolTip( this.lnkURL, "Point to aci server URL" );
            // 
            // btnCount
            // 
            this.btnCount.Location = new System.Drawing.Point( 418, 76 );
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size( 75, 23 );
            this.btnCount.TabIndex = 6;
            this.btnCount.Text = "Count";
            this.toolTip.SetToolTip( this.btnCount, "Count output files" );
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Click += new System.EventHandler( this.btnCount_Click );
            // 
            // btnAutoWeb
            // 
            this.btnAutoWeb.Location = new System.Drawing.Point( 418, 1 );
            this.btnAutoWeb.Name = "btnAutoWeb";
            this.btnAutoWeb.Size = new System.Drawing.Size( 75, 23 );
            this.btnAutoWeb.TabIndex = 4;
            this.btnAutoWeb.Text = "Auto Web";
            this.btnAutoWeb.UseVisualStyleBackColor = true;
            this.btnAutoWeb.Click += new System.EventHandler( this.btnAutoWeb_Click );
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 20F ) );
            this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 20F ) );
            this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 20F ) );
            this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 20F ) );
            this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 20F ) );
            this.tableLayoutPanel1.Controls.Add( this.lblCount, 0, 0 );
            this.tableLayoutPanel1.Controls.Add( this.lblSource, 1, 0 );
            this.tableLayoutPanel1.Controls.Add( this.lblPST, 2, 0 );
            this.tableLayoutPanel1.Controls.Add( this.lblFiles, 3, 0 );
            this.tableLayoutPanel1.Controls.Add( this.lblExpectedResult, 0, 1 );
            this.tableLayoutPanel1.Controls.Add( this.lblAcutualResult, 0, 2 );
            this.tableLayoutPanel1.Controls.Add( this.txtExpectedSrc, 1, 1 );
            this.tableLayoutPanel1.Controls.Add( this.txtExpectedPst, 2, 1 );
            this.tableLayoutPanel1.Controls.Add( this.txtExpectedFile, 3, 1 );
            this.tableLayoutPanel1.Controls.Add( this.txtActualSrc, 1, 2 );
            this.tableLayoutPanel1.Controls.Add( this.txtActualPst, 2, 2 );
            this.tableLayoutPanel1.Controls.Add( this.txtActualFile, 3, 2 );
            this.tableLayoutPanel1.Controls.Add( this.txtExpectedProp, 4, 1 );
            this.tableLayoutPanel1.Controls.Add( this.txtActualProp, 4, 2 );
            this.tableLayoutPanel1.Controls.Add( this.lblProperties, 4, 0 );
            this.tableLayoutPanel1.Location = new System.Drawing.Point( 16, 75 );
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 27.5F ) );
            this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 37.5F ) );
            this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 33.81295F ) );
            this.tableLayoutPanel1.Size = new System.Drawing.Size( 398, 83 );
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCount.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.lblCount.Location = new System.Drawing.Point( 36, 3 );
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size( 40, 19 );
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "Count";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSource.Location = new System.Drawing.Point( 85, 3 );
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size( 70, 19 );
            this.lblSource.TabIndex = 1;
            this.lblSource.Text = "Source";
            this.lblSource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPST
            // 
            this.lblPST.AutoSize = true;
            this.lblPST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPST.Location = new System.Drawing.Point( 164, 3 );
            this.lblPST.Name = "lblPST";
            this.lblPST.Size = new System.Drawing.Size( 70, 19 );
            this.lblPST.TabIndex = 2;
            this.lblPST.Text = "PST";
            this.lblPST.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFiles
            // 
            this.lblFiles.AutoSize = true;
            this.lblFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFiles.Location = new System.Drawing.Point( 243, 3 );
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size( 70, 19 );
            this.lblFiles.TabIndex = 3;
            this.lblFiles.Text = "Files";
            this.lblFiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExpectedResult
            // 
            this.lblExpectedResult.AutoSize = true;
            this.lblExpectedResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExpectedResult.Location = new System.Drawing.Point( 6, 25 );
            this.lblExpectedResult.Name = "lblExpectedResult";
            this.lblExpectedResult.Size = new System.Drawing.Size( 70, 26 );
            this.lblExpectedResult.TabIndex = 4;
            this.lblExpectedResult.Text = "Expected Result:";
            this.lblExpectedResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAcutualResult
            // 
            this.lblAcutualResult.AutoSize = true;
            this.lblAcutualResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAcutualResult.Location = new System.Drawing.Point( 6, 54 );
            this.lblAcutualResult.Name = "lblAcutualResult";
            this.lblAcutualResult.Size = new System.Drawing.Size( 70, 26 );
            this.lblAcutualResult.TabIndex = 5;
            this.lblAcutualResult.Text = "Actual Result:";
            this.lblAcutualResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtExpectedSrc
            // 
            this.txtExpectedSrc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtExpectedSrc.Location = new System.Drawing.Point( 85, 28 );
            this.txtExpectedSrc.Name = "txtExpectedSrc";
            this.txtExpectedSrc.ReadOnly = true;
            this.txtExpectedSrc.Size = new System.Drawing.Size( 70, 20 );
            this.txtExpectedSrc.TabIndex = 2;
            this.txtExpectedSrc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtExpectedPst
            // 
            this.txtExpectedPst.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtExpectedPst.Location = new System.Drawing.Point( 164, 28 );
            this.txtExpectedPst.Name = "txtExpectedPst";
            this.txtExpectedPst.ReadOnly = true;
            this.txtExpectedPst.Size = new System.Drawing.Size( 70, 20 );
            this.txtExpectedPst.TabIndex = 3;
            this.txtExpectedPst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtExpectedFile
            // 
            this.txtExpectedFile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtExpectedFile.Location = new System.Drawing.Point( 243, 28 );
            this.txtExpectedFile.Name = "txtExpectedFile";
            this.txtExpectedFile.ReadOnly = true;
            this.txtExpectedFile.Size = new System.Drawing.Size( 70, 20 );
            this.txtExpectedFile.TabIndex = 4;
            this.txtExpectedFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtActualSrc
            // 
            this.txtActualSrc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtActualSrc.Location = new System.Drawing.Point( 85, 57 );
            this.txtActualSrc.Name = "txtActualSrc";
            this.txtActualSrc.ReadOnly = true;
            this.txtActualSrc.Size = new System.Drawing.Size( 70, 20 );
            this.txtActualSrc.TabIndex = 6;
            this.txtActualSrc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtActualPst
            // 
            this.txtActualPst.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtActualPst.Location = new System.Drawing.Point( 164, 57 );
            this.txtActualPst.Name = "txtActualPst";
            this.txtActualPst.ReadOnly = true;
            this.txtActualPst.Size = new System.Drawing.Size( 70, 20 );
            this.txtActualPst.TabIndex = 7;
            this.txtActualPst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtActualFile
            // 
            this.txtActualFile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtActualFile.Location = new System.Drawing.Point( 243, 57 );
            this.txtActualFile.Name = "txtActualFile";
            this.txtActualFile.ReadOnly = true;
            this.txtActualFile.Size = new System.Drawing.Size( 70, 20 );
            this.txtActualFile.TabIndex = 8;
            this.txtActualFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtExpectedProp
            // 
            this.txtExpectedProp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtExpectedProp.Location = new System.Drawing.Point( 322, 28 );
            this.txtExpectedProp.Name = "txtExpectedProp";
            this.txtExpectedProp.ReadOnly = true;
            this.txtExpectedProp.Size = new System.Drawing.Size( 70, 20 );
            this.txtExpectedProp.TabIndex = 5;
            this.txtExpectedProp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtActualProp
            // 
            this.txtActualProp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtActualProp.Location = new System.Drawing.Point( 322, 57 );
            this.txtActualProp.Name = "txtActualProp";
            this.txtActualProp.ReadOnly = true;
            this.txtActualProp.Size = new System.Drawing.Size( 70, 20 );
            this.txtActualProp.TabIndex = 9;
            this.txtActualProp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblProperties
            // 
            this.lblProperties.AutoSize = true;
            this.lblProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProperties.Location = new System.Drawing.Point( 322, 3 );
            this.lblProperties.Name = "lblProperties";
            this.lblProperties.Size = new System.Drawing.Size( 70, 19 );
            this.lblProperties.TabIndex = 14;
            this.lblProperties.Text = "Properties";
            this.lblProperties.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboOutput
            // 
            this.cboOutput.FormattingEnabled = true;
            this.cboOutput.Items.AddRange( new object[] {
            "C:\\wamuOut\\C0",
            "C:\\wamuOut\\C1",
            "C:\\wamuOut\\C2",
            "C:\\wamuOut\\C3",
            "C:\\wamuOut\\C4",
            "C:\\wamuOut\\C5",
            "C:\\wamuOut\\C6",
            "C:\\wamuOut\\C7",
            "C:\\wamuOut\\C8",
            "C:\\wamuOut\\C9",
            "C:\\wamuOut\\C10"} );
            this.cboOutput.Location = new System.Drawing.Point( 55, 50 );
            this.cboOutput.Name = "cboOutput";
            this.cboOutput.Size = new System.Drawing.Size( 359, 21 );
            this.cboOutput.TabIndex = 2;
            this.cboOutput.Text = "C:\\wamuOut\\C0";
            // 
            // cboSource
            // 
            this.cboSource.FormattingEnabled = true;
            this.cboSource.Items.AddRange( new object[] {
            "C:\\wamuTestData\\data\\dlh\\C0",
            "C:\\wamuTestData\\data\\dlh\\C1",
            "C:\\wamuTestData\\data\\dlh\\C2",
            "C:\\wamuTestData\\data\\dlh\\C3",
            "C:\\wamuTestData\\data\\dlh\\C4",
            "C:\\wamuTestData\\data\\dlh\\C5",
            "C:\\wamuTestData\\data\\dlh\\C6",
            "C:\\wamuTestData\\data\\dlh\\C7",
            "C:\\wamuTestData\\data\\dlh\\C8",
            "C:\\wamuTestData\\data\\dlh\\C9",
            "C:\\wamuTestData\\data\\dlh\\C10",
            "C:\\wamuTestData\\data\\dlh\\providian"} );
            this.cboSource.Location = new System.Drawing.Point( 55, 26 );
            this.cboSource.Name = "cboSource";
            this.cboSource.Size = new System.Drawing.Size( 359, 21 );
            this.cboSource.TabIndex = 1;
            this.cboSource.Text = "C:\\wamuTestData\\data\\dlh\\C0";
            // 
            // lnkOutput
            // 
            this.lnkOutput.AutoSize = true;
            this.lnkOutput.Location = new System.Drawing.Point( 13, 53 );
            this.lnkOutput.Name = "lnkOutput";
            this.lnkOutput.Size = new System.Drawing.Size( 39, 13 );
            this.lnkOutput.TabIndex = 1;
            this.lnkOutput.TabStop = true;
            this.lnkOutput.Text = "Ouput:";
            this.toolTip.SetToolTip( this.lnkOutput, "Point to output folder" );
            this.lnkOutput.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.lnkOutput_LinkClicked );
            // 
            // lnkSource
            // 
            this.lnkSource.AutoSize = true;
            this.lnkSource.Location = new System.Drawing.Point( 8, 30 );
            this.lnkSource.Name = "lnkSource";
            this.lnkSource.Size = new System.Drawing.Size( 44, 13 );
            this.lnkSource.TabIndex = 0;
            this.lnkSource.TabStop = true;
            this.lnkSource.Text = "Source:";
            this.toolTip.SetToolTip( this.lnkSource, "Point to Input Folder" );
            this.lnkSource.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.lnkSource_LinkClicked );
            // 
            // tabAutoTest
            // 
            this.tabAutoTest.Controls.Add( this.dataGridView );
            this.tabAutoTest.Controls.Add( this.btnAutoCount );
            this.tabAutoTest.Controls.Add( this.lnkInput );
            this.tabAutoTest.Controls.Add( this.cboInFile );
            this.tabAutoTest.Controls.Add( this.btnAutoTest );
            this.tabAutoTest.Location = new System.Drawing.Point( 4, 22 );
            this.tabAutoTest.Name = "tabAutoTest";
            this.tabAutoTest.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabAutoTest.Size = new System.Drawing.Size( 652, 433 );
            this.tabAutoTest.TabIndex = 1;
            this.tabAutoTest.Text = "Auto Test";
            this.tabAutoTest.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point( 6, 31 );
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size( 639, 396 );
            this.dataGridView.TabIndex = 17;
            // 
            // btnAutoCount
            // 
            this.btnAutoCount.Location = new System.Drawing.Point( 405, 4 );
            this.btnAutoCount.Name = "btnAutoCount";
            this.btnAutoCount.Size = new System.Drawing.Size( 68, 23 );
            this.btnAutoCount.TabIndex = 16;
            this.btnAutoCount.Text = "Auto Count";
            this.btnAutoCount.UseVisualStyleBackColor = true;
            this.btnAutoCount.Click += new System.EventHandler( this.btnAutoCount_Click );
            // 
            // lnkInput
            // 
            this.lnkInput.AutoSize = true;
            this.lnkInput.Location = new System.Drawing.Point( 15, 10 );
            this.lnkInput.Name = "lnkInput";
            this.lnkInput.Size = new System.Drawing.Size( 38, 13 );
            this.lnkInput.TabIndex = 15;
            this.lnkInput.TabStop = true;
            this.lnkInput.Text = "In File:";
            this.toolTip.SetToolTip( this.lnkInput, "Point to output folder" );
            this.lnkInput.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.lnkInput_LinkClicked );
            // 
            // cboInFile
            // 
            this.cboInFile.FormattingEnabled = true;
            this.cboInFile.Items.AddRange( new object[] {
            "c:\\tmp\\Offline.csv",
            "c:\\tmp\\Online.csv"} );
            this.cboInFile.Location = new System.Drawing.Point( 56, 6 );
            this.cboInFile.Name = "cboInFile";
            this.cboInFile.Size = new System.Drawing.Size( 275, 21 );
            this.cboInFile.TabIndex = 14;
            this.cboInFile.Text = "c:\\tmp\\Offline.csv";
            // 
            // btnAutoTest
            // 
            this.btnAutoTest.Location = new System.Drawing.Point( 335, 4 );
            this.btnAutoTest.Name = "btnAutoTest";
            this.btnAutoTest.Size = new System.Drawing.Size( 68, 23 );
            this.btnAutoTest.TabIndex = 13;
            this.btnAutoTest.Text = "Auto Web";
            this.btnAutoTest.UseVisualStyleBackColor = true;
            this.btnAutoTest.Click += new System.EventHandler( this.btnAutoTest_Click );
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size( 16, 16 );
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // folderBrowserDlg
            // 
            this.folderBrowserDlg.SelectedPath = "C:\\";
            // 
            // openFileDlg
            // 
            this.openFileDlg.FileName = "DefFile.csv";
            this.openFileDlg.Filter = "CSV file (*.cvs)|*.csv|Text File (*.txt)|*.txt|All Files|*.*";
            this.openFileDlg.InitialDirectory = "C:\\";
            // 
            // bgwDeleteFolders
            // 
            this.bgwDeleteFolders.WorkerReportsProgress = true;
            this.bgwDeleteFolders.DoWork += new System.ComponentModel.DoWorkEventHandler( this.bgwDeleteFolders_DoWork );
            this.bgwDeleteFolders.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler( this.bgwDeleteFolders_RunWorkerCompleted );
            this.bgwDeleteFolders.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler( this.bgwDeleteFolders_ProgressChanged );
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 857, 484 );
            this.Controls.Add( this.splitContainer1 );
            this.Controls.Add( this.toolStrip1 );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout( false );
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout( false );
            this.splitContainer1.Panel2.ResumeLayout( false );
            this.splitContainer1.ResumeLayout( false );
            this.tabControl1.ResumeLayout( false );
            this.tabSimpleTest.ResumeLayout( false );
            this.tabSimpleTest.PerformLayout();
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout( false );
            this.tableLayoutPanel1.PerformLayout();
            this.tabAutoTest.ResumeLayout( false );
            this.tabAutoTest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripbrnUp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSimpleTest;
        private System.Windows.Forms.TabPage tabAutoTest;
        private System.Windows.Forms.LinkLabel lnkOutput;
        private System.Windows.Forms.LinkLabel lnkSource;
        private System.Windows.Forms.ComboBox cboOutput;
        private System.Windows.Forms.ComboBox cboSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblPST;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.Label lblExpectedResult;
        private System.Windows.Forms.Label lblAcutualResult;
        private System.Windows.Forms.TextBox txtExpectedSrc;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtExpectedPst;
        private System.Windows.Forms.TextBox txtExpectedFile;
        private System.Windows.Forms.TextBox txtActualSrc;
        private System.Windows.Forms.TextBox txtActualPst;
        private System.Windows.Forms.TextBox txtActualFile;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.Button btnAutoWeb;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TextBox txtExpectedProp;
        private System.Windows.Forms.TextBox txtActualProp;
        private System.Windows.Forms.Label lblProperties;
        private System.Windows.Forms.ComboBox cboURL;
        private System.Windows.Forms.LinkLabel lnkURL;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDlg;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnAutoCount;
        private System.Windows.Forms.LinkLabel lnkInput;
        private System.Windows.Forms.ComboBox cboInFile;
        private System.Windows.Forms.Button btnAutoTest;
        private System.Windows.Forms.Button btnDelete;
        private System.ComponentModel.BackgroundWorker bgwDeleteFolders;
        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.Button btnLegalHold;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoOffline;
        private System.Windows.Forms.RadioButton rdoOnline;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblDBName;

    }
}

