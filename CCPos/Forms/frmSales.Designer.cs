namespace CCPos
{
    partial class frmSales
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
            this.mtDelete = new MetroFramework.Controls.MetroTile();
            this.mtCourse = new MetroFramework.Controls.MetroTile();
            this.mtTables = new MetroFramework.Controls.MetroTile();
            this.mtKitchen = new MetroFramework.Controls.MetroTile();
            this.mtVoid = new MetroFramework.Controls.MetroTile();
            this.mtPayment = new MetroFramework.Controls.MetroTile();
            this.mtBook = new MetroFramework.Controls.MetroTile();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbTotalPayable = new System.Windows.Forms.TextBox();
            this.tbMemberNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbCustomerName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbSubTotal = new System.Windows.Forms.TextBox();
            this.tbDiscount = new System.Windows.Forms.TextBox();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvOrdersItems = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.flpCategory = new System.Windows.Forms.FlowLayoutPanel();
            this.flpProduct = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersItems)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.mtDelete);
            this.groupBox5.Controls.Add(this.mtCourse);
            this.groupBox5.Controls.Add(this.mtTables);
            this.groupBox5.Controls.Add(this.mtKitchen);
            this.groupBox5.Controls.Add(this.mtVoid);
            this.groupBox5.Controls.Add(this.mtPayment);
            this.groupBox5.Controls.Add(this.mtBook);
            this.groupBox5.Controls.Add(this.metroButton2);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(20, 647);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1164, 73);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ACTIONS";
            // 
            // mtDelete
            // 
            this.mtDelete.Location = new System.Drawing.Point(224, 17);
            this.mtDelete.Name = "mtDelete";
            this.mtDelete.Size = new System.Drawing.Size(110, 50);
            this.mtDelete.TabIndex = 34;
            this.mtDelete.Text = "DELETE";
            this.mtDelete.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mtDelete.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mtDelete.Click += new System.EventHandler(this.mtDelete_Click);
            // 
            // mtCourse
            // 
            this.mtCourse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mtCourse.Location = new System.Drawing.Point(93, 17);
            this.mtCourse.Name = "mtCourse";
            this.mtCourse.Size = new System.Drawing.Size(110, 50);
            this.mtCourse.TabIndex = 33;
            this.mtCourse.Text = "COURSE";
            this.mtCourse.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mtCourse.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mtCourse.Click += new System.EventHandler(this.mtCourse_Click);
            // 
            // mtTables
            // 
            this.mtTables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mtTables.Location = new System.Drawing.Point(864, 17);
            this.mtTables.Name = "mtTables";
            this.mtTables.Size = new System.Drawing.Size(110, 50);
            this.mtTables.TabIndex = 31;
            this.mtTables.Text = "TABLES";
            this.mtTables.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mtTables.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            // 
            // mtKitchen
            // 
            this.mtKitchen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mtKitchen.Location = new System.Drawing.Point(1005, 17);
            this.mtKitchen.Name = "mtKitchen";
            this.mtKitchen.Size = new System.Drawing.Size(110, 50);
            this.mtKitchen.TabIndex = 30;
            this.mtKitchen.Text = "KITCHEN";
            this.mtKitchen.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mtKitchen.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            // 
            // mtVoid
            // 
            this.mtVoid.Location = new System.Drawing.Point(517, 17);
            this.mtVoid.Name = "mtVoid";
            this.mtVoid.Size = new System.Drawing.Size(110, 50);
            this.mtVoid.TabIndex = 29;
            this.mtVoid.Text = "VOID";
            this.mtVoid.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mtVoid.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mtVoid.Click += new System.EventHandler(this.mtVoid_Click);
            // 
            // mtPayment
            // 
            this.mtPayment.Location = new System.Drawing.Point(650, 17);
            this.mtPayment.Name = "mtPayment";
            this.mtPayment.Size = new System.Drawing.Size(110, 50);
            this.mtPayment.TabIndex = 28;
            this.mtPayment.Text = "PAYMENT";
            this.mtPayment.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mtPayment.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mtPayment.Click += new System.EventHandler(this.mtPayment_Click);
            // 
            // mtBook
            // 
            this.mtBook.Location = new System.Drawing.Point(385, 17);
            this.mtBook.Name = "mtBook";
            this.mtBook.Size = new System.Drawing.Size(110, 50);
            this.mtBook.TabIndex = 27;
            this.mtBook.Text = "ORDER";
            this.mtBook.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mtBook.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mtBook.Click += new System.EventHandler(this.mtBook_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(16, 111);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(0, 0);
            this.metroButton2.TabIndex = 12;
            this.metroButton2.Text = "metroButton2";
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Qty";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 125;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 125;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Item";
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 125;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(64, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1079, 565);
            this.panel1.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1079, 565);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ORDERS";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.dgvOrdersItems);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(2, 38);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(558, 521);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Details";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.panel2);
            this.groupBox6.Controls.Add(this.panel3);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(3, 347);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(552, 171);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Summary";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.tbTotalPayable);
            this.panel2.Controls.Add(this.tbMemberNo);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.tbCustomerName);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(247, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(302, 138);
            this.panel2.TabIndex = 11;
            // 
            // tbTotalPayable
            // 
            this.tbTotalPayable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotalPayable.Location = new System.Drawing.Point(150, 91);
            this.tbTotalPayable.Name = "tbTotalPayable";
            this.tbTotalPayable.ReadOnly = true;
            this.tbTotalPayable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbTotalPayable.Size = new System.Drawing.Size(137, 34);
            this.tbTotalPayable.TabIndex = 25;
            // 
            // tbMemberNo
            // 
            this.tbMemberNo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMemberNo.Location = new System.Drawing.Point(150, 52);
            this.tbMemberNo.Name = "tbMemberNo";
            this.tbMemberNo.ReadOnly = true;
            this.tbMemberNo.Size = new System.Drawing.Size(137, 30);
            this.tbMemberNo.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 23);
            this.label9.TabIndex = 23;
            this.label9.Text = "Member No.:";
            // 
            // tbCustomerName
            // 
            this.tbCustomerName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustomerName.Location = new System.Drawing.Point(150, 13);
            this.tbCustomerName.Name = "tbCustomerName";
            this.tbCustomerName.ReadOnly = true;
            this.tbCustomerName.Size = new System.Drawing.Size(137, 30);
            this.tbCustomerName.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 28);
            this.label5.TabIndex = 21;
            this.label5.Text = "Amt Due:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(33, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 23);
            this.label8.TabIndex = 20;
            this.label8.Text = "Customer:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.tbSubTotal);
            this.panel3.Controls.Add(this.tbDiscount);
            this.panel3.Controls.Add(this.tbTotal);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(6, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(235, 135);
            this.panel3.TabIndex = 10;
            // 
            // tbSubTotal
            // 
            this.tbSubTotal.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSubTotal.Location = new System.Drawing.Point(121, 93);
            this.tbSubTotal.Name = "tbSubTotal";
            this.tbSubTotal.ReadOnly = true;
            this.tbSubTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbSubTotal.Size = new System.Drawing.Size(97, 30);
            this.tbSubTotal.TabIndex = 23;
            // 
            // tbDiscount
            // 
            this.tbDiscount.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDiscount.Location = new System.Drawing.Point(121, 52);
            this.tbDiscount.Name = "tbDiscount";
            this.tbDiscount.ReadOnly = true;
            this.tbDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbDiscount.Size = new System.Drawing.Size(97, 30);
            this.tbDiscount.TabIndex = 22;
            // 
            // tbTotal
            // 
            this.tbTotal.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotal.Location = new System.Drawing.Point(122, 13);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.ReadOnly = true;
            this.tbTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbTotal.Size = new System.Drawing.Size(96, 30);
            this.tbTotal.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 23);
            this.label3.TabIndex = 20;
            this.label3.Text = "Sub Total:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 23);
            this.label2.TabIndex = 19;
            this.label2.Text = "Discount:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Total:";
            // 
            // dgvOrdersItems
            // 
            this.dgvOrdersItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrdersItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrdersItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdersItems.Location = new System.Drawing.Point(5, 28);
            this.dgvOrdersItems.Name = "dgvOrdersItems";
            this.dgvOrdersItems.RowHeadersWidth = 51;
            this.dgvOrdersItems.RowTemplate.Height = 35;
            this.dgvOrdersItems.Size = new System.Drawing.Size(548, 313);
            this.dgvOrdersItems.TabIndex = 3;
            this.dgvOrdersItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdersItems_CellContentClick);
            this.dgvOrdersItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdersItems_CellValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbSearch);
            this.groupBox2.Controls.Add(this.flpCategory);
            this.groupBox2.Controls.Add(this.flpProduct);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(566, 38);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(510, 518);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Items";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(249, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 28);
            this.label4.TabIndex = 4;
            this.label4.Text = "Search:";
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Location = new System.Drawing.Point(329, 28);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(175, 34);
            this.tbSearch.TabIndex = 3;
            // 
            // flpCategory
            // 
            this.flpCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpCategory.Location = new System.Drawing.Point(3, 28);
            this.flpCategory.Name = "flpCategory";
            this.flpCategory.Size = new System.Drawing.Size(225, 102);
            this.flpCategory.TabIndex = 2;
            this.flpCategory.WrapContents = false;
            // 
            // flpProduct
            // 
            this.flpProduct.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpProduct.Location = new System.Drawing.Point(3, 136);
            this.flpProduct.Name = "flpProduct";
            this.flpProduct.Size = new System.Drawing.Size(504, 378);
            this.flpProduct.TabIndex = 1;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(11, 237);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(47, 42);
            this.btnUp.TabIndex = 6;
            this.btnUp.Text = "UP";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(11, 302);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(47, 42);
            this.btnDown.TabIndex = 10;
            this.btnDown.Text = "DOWN";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // frmSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 740);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox5);
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSales";
            this.Padding = new System.Windows.Forms.Padding(20, 62, 20, 20);
            this.Load += new System.EventHandler(this.frmSales_Load);
            this.groupBox5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersItems)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox5;
        private MetroFramework.Controls.MetroTile mtTables;
        private MetroFramework.Controls.MetroTile mtKitchen;
        private MetroFramework.Controls.MetroTile mtVoid;
        private MetroFramework.Controls.MetroTile mtPayment;
        private MetroFramework.Controls.MetroTile mtBook;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbTotalPayable;
        private System.Windows.Forms.TextBox tbMemberNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbCustomerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbSubTotal;
        private System.Windows.Forms.TextBox tbDiscount;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvOrdersItems;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.FlowLayoutPanel flpCategory;
        private System.Windows.Forms.FlowLayoutPanel flpProduct;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private MetroFramework.Controls.MetroTile mtCourse;
        private MetroFramework.Controls.MetroTile mtDelete;
    }
}

