namespace CCPos.Forms
{
    partial class frmConfig
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.mtAssign = new MetroFramework.Controls.MetroTile();
            this.mtCancel = new MetroFramework.Controls.MetroTile();
            this.mtAdd = new MetroFramework.Controls.MetroTile();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tcConfigs = new System.Windows.Forms.TabControl();
            this.tabPrinter = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dgvPrinters = new System.Windows.Forms.DataGridView();
            this.PrinterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrinterIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAssignedPrinters = new System.Windows.Forms.GroupBox();
            this.dgvAssigned = new System.Windows.Forms.DataGridView();
            this.Printer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboLocation = new System.Windows.Forms.ComboBox();
            this.cboName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.dgvTables = new System.Windows.Forms.DataGridView();
            this.TableLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.cboTableLocation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCapacity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTableName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tcConfigs.SuspendLayout();
            this.tabPrinter.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrinters)).BeginInit();
            this.dgvAssignedPrinters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssigned)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).BeginInit();
            this.panel4.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.mtAssign);
            this.groupBox5.Controls.Add(this.mtCancel);
            this.groupBox5.Controls.Add(this.mtAdd);
            this.groupBox5.Controls.Add(this.metroButton2);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(30, 513);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(935, 73);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ACTIONS";
            // 
            // mtAssign
            // 
            this.mtAssign.Location = new System.Drawing.Point(252, 17);
            this.mtAssign.Name = "mtAssign";
            this.mtAssign.Size = new System.Drawing.Size(110, 50);
            this.mtAssign.TabIndex = 29;
            this.mtAssign.Text = "ASSIGN";
            this.mtAssign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mtAssign.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mtAssign.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mtAssign.Click += new System.EventHandler(this.mtAssign_Click);
            // 
            // mtCancel
            // 
            this.mtCancel.Location = new System.Drawing.Point(402, 17);
            this.mtCancel.Name = "mtCancel";
            this.mtCancel.Size = new System.Drawing.Size(110, 50);
            this.mtCancel.TabIndex = 28;
            this.mtCancel.Text = "CANCEL";
            this.mtCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mtCancel.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mtCancel.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            // 
            // mtAdd
            // 
            this.mtAdd.Location = new System.Drawing.Point(106, 17);
            this.mtAdd.Name = "mtAdd";
            this.mtAdd.Size = new System.Drawing.Size(110, 50);
            this.mtAdd.TabIndex = 27;
            this.mtAdd.Text = "ADD";
            this.mtAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mtAdd.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mtAdd.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mtAdd.Click += new System.EventHandler(this.mtAdd_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(16, 111);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(0, 0);
            this.metroButton2.TabIndex = 12;
            this.metroButton2.Text = "metroButton2";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tcConfigs);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(33, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(929, 472);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SYSTEM CONFIGURATION";
            // 
            // tcConfigs
            // 
            this.tcConfigs.Controls.Add(this.tabPrinter);
            this.tcConfigs.Controls.Add(this.tabPage2);
            this.tcConfigs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcConfigs.Location = new System.Drawing.Point(3, 29);
            this.tcConfigs.Name = "tcConfigs";
            this.tcConfigs.SelectedIndex = 0;
            this.tcConfigs.Size = new System.Drawing.Size(923, 440);
            this.tcConfigs.TabIndex = 16;
            this.tcConfigs.SelectedIndexChanged += new System.EventHandler(this.tcConfigs_SelectedIndexChanged);
            // 
            // tabPrinter
            // 
            this.tabPrinter.Controls.Add(this.groupBox2);
            this.tabPrinter.Location = new System.Drawing.Point(4, 34);
            this.tabPrinter.Name = "tabPrinter";
            this.tabPrinter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrinter.Size = new System.Drawing.Size(915, 402);
            this.tabPrinter.TabIndex = 0;
            this.tabPrinter.Text = "Printers";
            this.tabPrinter.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(909, 396);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PRINTER SETTINGS";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.dgvAssignedPrinters);
            this.panel1.Location = new System.Drawing.Point(465, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 364);
            this.panel1.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.dgvPrinters);
            this.groupBox6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(15, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(413, 176);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Devices";
            // 
            // dgvPrinters
            // 
            this.dgvPrinters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrinters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrinters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PrinterName,
            this.PrinterIP});
            this.dgvPrinters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrinters.Location = new System.Drawing.Point(3, 25);
            this.dgvPrinters.Name = "dgvPrinters";
            this.dgvPrinters.RowHeadersWidth = 51;
            this.dgvPrinters.RowTemplate.Height = 35;
            this.dgvPrinters.RowTemplate.ReadOnly = true;
            this.dgvPrinters.Size = new System.Drawing.Size(407, 148);
            this.dgvPrinters.TabIndex = 2;
            // 
            // PrinterName
            // 
            this.PrinterName.HeaderText = "Printer";
            this.PrinterName.MinimumWidth = 6;
            this.PrinterName.Name = "PrinterName";
            this.PrinterName.ReadOnly = true;
            // 
            // PrinterIP
            // 
            this.PrinterIP.HeaderText = "IP Address";
            this.PrinterIP.MinimumWidth = 6;
            this.PrinterIP.Name = "PrinterIP";
            this.PrinterIP.ReadOnly = true;
            // 
            // dgvAssignedPrinters
            // 
            this.dgvAssignedPrinters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAssignedPrinters.Controls.Add(this.dgvAssigned);
            this.dgvAssignedPrinters.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAssignedPrinters.Location = new System.Drawing.Point(15, 204);
            this.dgvAssignedPrinters.Name = "dgvAssignedPrinters";
            this.dgvAssignedPrinters.Size = new System.Drawing.Size(413, 160);
            this.dgvAssignedPrinters.TabIndex = 6;
            this.dgvAssignedPrinters.TabStop = false;
            this.dgvAssignedPrinters.Text = "Assigned";
            // 
            // dgvAssigned
            // 
            this.dgvAssigned.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAssigned.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssigned.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Printer,
            this.Location});
            this.dgvAssigned.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAssigned.Location = new System.Drawing.Point(3, 25);
            this.dgvAssigned.Name = "dgvAssigned";
            this.dgvAssigned.RowHeadersWidth = 51;
            this.dgvAssigned.RowTemplate.Height = 35;
            this.dgvAssigned.RowTemplate.ReadOnly = true;
            this.dgvAssigned.Size = new System.Drawing.Size(407, 132);
            this.dgvAssigned.TabIndex = 2;
            // 
            // Printer
            // 
            this.Printer.HeaderText = "Printer";
            this.Printer.MinimumWidth = 6;
            this.Printer.Name = "Printer";
            this.Printer.ReadOnly = true;
            // 
            // Location
            // 
            this.Location.HeaderText = "Location";
            this.Location.MinimumWidth = 6;
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(3, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 364);
            this.panel2.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.cboLocation);
            this.groupBox4.Controls.Add(this.cboName);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(0, 204);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(415, 160);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Assign";
            // 
            // cboLocation
            // 
            this.cboLocation.FormattingEnabled = true;
            this.cboLocation.Location = new System.Drawing.Point(114, 97);
            this.cboLocation.Name = "cboLocation";
            this.cboLocation.Size = new System.Drawing.Size(165, 29);
            this.cboLocation.TabIndex = 4;
            // 
            // cboName
            // 
            this.cboName.FormattingEnabled = true;
            this.cboName.Location = new System.Drawing.Point(114, 41);
            this.cboName.Name = "cboName";
            this.cboName.Size = new System.Drawing.Size(165, 29);
            this.cboName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "Location:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Name:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tbIP);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.tbName);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(415, 176);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "New";
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(114, 98);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(165, 29);
            this.tbIP.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "IP:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(114, 39);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(165, 29);
            this.tbName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(915, 402);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tables";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.panel3);
            this.groupBox7.Controls.Add(this.panel4);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(3, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(909, 396);
            this.groupBox7.TabIndex = 17;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "TABLE SETTINGS";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.groupBox8);
            this.panel3.Location = new System.Drawing.Point(465, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(441, 364);
            this.panel3.TabIndex = 1;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.dgvTables);
            this.groupBox8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(15, 0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(413, 206);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Devices";
            // 
            // dgvTables
            // 
            this.dgvTables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TableLocation,
            this.TableName,
            this.Capacity});
            this.dgvTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTables.Location = new System.Drawing.Point(3, 25);
            this.dgvTables.Name = "dgvTables";
            this.dgvTables.RowHeadersWidth = 51;
            this.dgvTables.RowTemplate.Height = 35;
            this.dgvTables.RowTemplate.ReadOnly = true;
            this.dgvTables.Size = new System.Drawing.Size(407, 178);
            this.dgvTables.TabIndex = 2;
            // 
            // TableLocation
            // 
            this.TableLocation.HeaderText = "Location";
            this.TableLocation.MinimumWidth = 6;
            this.TableLocation.Name = "TableLocation";
            this.TableLocation.ReadOnly = true;
            // 
            // TableName
            // 
            this.TableName.HeaderText = "Table";
            this.TableName.MinimumWidth = 6;
            this.TableName.Name = "TableName";
            this.TableName.ReadOnly = true;
            // 
            // Capacity
            // 
            this.Capacity.HeaderText = "Capacity";
            this.Capacity.Name = "Capacity";
            this.Capacity.ReadOnly = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox11);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(3, 29);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(415, 364);
            this.panel4.TabIndex = 0;
            // 
            // groupBox11
            // 
            this.groupBox11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox11.Controls.Add(this.cboTableLocation);
            this.groupBox11.Controls.Add(this.label5);
            this.groupBox11.Controls.Add(this.tbCapacity);
            this.groupBox11.Controls.Add(this.label7);
            this.groupBox11.Controls.Add(this.tbTableName);
            this.groupBox11.Controls.Add(this.label8);
            this.groupBox11.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox11.Location = new System.Drawing.Point(0, 0);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(415, 206);
            this.groupBox11.TabIndex = 0;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "New";
            // 
            // cboTableLocation
            // 
            this.cboTableLocation.FormattingEnabled = true;
            this.cboTableLocation.Location = new System.Drawing.Point(114, 33);
            this.cboTableLocation.Name = "cboTableLocation";
            this.cboTableLocation.Size = new System.Drawing.Size(165, 29);
            this.cboTableLocation.TabIndex = 5;
            this.cboTableLocation.SelectedIndexChanged += new System.EventHandler(this.cboTableLocation_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Location:";
            // 
            // tbCapacity
            // 
            this.tbCapacity.Location = new System.Drawing.Point(114, 132);
            this.tbCapacity.Name = "tbCapacity";
            this.tbCapacity.Size = new System.Drawing.Size(165, 29);
            this.tbCapacity.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 21);
            this.label7.TabIndex = 2;
            this.label7.Text = "Capacity:";
            // 
            // tbTableName
            // 
            this.tbTableName.Location = new System.Drawing.Point(114, 79);
            this.tbTableName.Name = "tbTableName";
            this.tbTableName.Size = new System.Drawing.Size(165, 29);
            this.tbTableName.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 21);
            this.label8.TabIndex = 0;
            this.label8.Text = "Table name:";
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 618);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmConfig";
            this.Padding = new System.Windows.Forms.Padding(30, 97, 30, 32);
            this.groupBox5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tcConfigs.ResumeLayout(false);
            this.tabPrinter.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrinters)).EndInit();
            this.dgvAssignedPrinters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssigned)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).EndInit();
            this.panel4.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private MetroFramework.Controls.MetroTile mtAssign;
        private MetroFramework.Controls.MetroTile mtCancel;
        private MetroFramework.Controls.MetroTile mtAdd;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tcConfigs;
        private System.Windows.Forms.TabPage tabPrinter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dgvPrinters;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrinterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrinterIP;
        private System.Windows.Forms.GroupBox dgvAssignedPrinters;
        private System.Windows.Forms.DataGridView dgvAssigned;
        private System.Windows.Forms.DataGridViewTextBoxColumn Printer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboLocation;
        private System.Windows.Forms.ComboBox cboName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DataGridView dgvTables;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox tbCapacity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTableName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboTableLocation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Capacity;
    }
}