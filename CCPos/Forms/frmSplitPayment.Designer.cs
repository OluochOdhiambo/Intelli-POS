namespace CCPos.Forms
{
    partial class frmSplitPayment
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
            this.label4 = new System.Windows.Forms.Label();
            this.tbTableName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvPayment = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSummary = new System.Windows.Forms.DataGridView();
            this.PaymentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ref = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbPaymentAmt = new System.Windows.Forms.TextBox();
            this.panelInput = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboSplitMembers = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbRef = new System.Windows.Forms.TextBox();
            this.tbPaymentMode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flpPaymentTypes = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.mtTables = new MetroFramework.Controls.MetroTile();
            this.mtKitchen = new MetroFramework.Controls.MetroTile();
            this.mtPost = new MetroFramework.Controls.MetroTile();
            this.mtCancel = new MetroFramework.Controls.MetroTile();
            this.mtAdd = new MetroFramework.Controls.MetroTile();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.Member = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Due = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(378, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 21);
            this.label4.TabIndex = 16;
            this.label4.Text = "Table:";
            // 
            // tbTableName
            // 
            this.tbTableName.Location = new System.Drawing.Point(448, 24);
            this.tbTableName.Name = "tbTableName";
            this.tbTableName.ReadOnly = true;
            this.tbTableName.Size = new System.Drawing.Size(137, 29);
            this.tbTableName.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(26, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1073, 439);
            this.panel1.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panelInput);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1073, 439);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SPLIT PAYMENT";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvPayment);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(746, 222);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(310, 205);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Payments";
            // 
            // dgvPayment
            // 
            this.dgvPayment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Member,
            this.Due,
            this.Paid});
            this.dgvPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPayment.Location = new System.Drawing.Point(3, 25);
            this.dgvPayment.Name = "dgvPayment";
            this.dgvPayment.RowHeadersWidth = 51;
            this.dgvPayment.RowTemplate.Height = 35;
            this.dgvPayment.RowTemplate.ReadOnly = true;
            this.dgvPayment.Size = new System.Drawing.Size(304, 177);
            this.dgvPayment.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvSummary);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(743, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(310, 197);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Summary";
            // 
            // dgvSummary
            // 
            this.dgvSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PaymentName,
            this.Amount,
            this.Ref});
            this.dgvSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSummary.Location = new System.Drawing.Point(3, 25);
            this.dgvSummary.Name = "dgvSummary";
            this.dgvSummary.RowHeadersWidth = 51;
            this.dgvSummary.RowTemplate.Height = 35;
            this.dgvSummary.RowTemplate.ReadOnly = true;
            this.dgvSummary.Size = new System.Drawing.Size(304, 169);
            this.dgvSummary.TabIndex = 2;
            // 
            // PaymentName
            // 
            this.PaymentName.HeaderText = "Mode";
            this.PaymentName.MinimumWidth = 6;
            this.PaymentName.Name = "PaymentName";
            this.PaymentName.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.MinimumWidth = 6;
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // Ref
            // 
            this.Ref.HeaderText = "Ref";
            this.Ref.MinimumWidth = 6;
            this.Ref.Name = "Ref";
            this.Ref.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel3.Controls.Add(this.tbPaymentAmt);
            this.panel3.Location = new System.Drawing.Point(356, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(363, 97);
            this.panel3.TabIndex = 3;
            // 
            // tbPaymentAmt
            // 
            this.tbPaymentAmt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPaymentAmt.Location = new System.Drawing.Point(0, 0);
            this.tbPaymentAmt.Multiline = true;
            this.tbPaymentAmt.Name = "tbPaymentAmt";
            this.tbPaymentAmt.Size = new System.Drawing.Size(363, 97);
            this.tbPaymentAmt.TabIndex = 0;
            // 
            // panelInput
            // 
            this.panelInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panelInput.Location = new System.Drawing.Point(356, 135);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(363, 298);
            this.panelInput.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.cboSplitMembers);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.flpPaymentTypes);
            this.panel2.Location = new System.Drawing.Point(13, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(321, 401);
            this.panel2.TabIndex = 0;
            // 
            // cboSplitMembers
            // 
            this.cboSplitMembers.FormattingEnabled = true;
            this.cboSplitMembers.Location = new System.Drawing.Point(127, 3);
            this.cboSplitMembers.Name = "cboSplitMembers";
            this.cboSplitMembers.Size = new System.Drawing.Size(171, 33);
            this.cboSplitMembers.TabIndex = 4;
            this.cboSplitMembers.SelectedIndexChanged += new System.EventHandler(this.cboSplitMembers_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 21);
            this.label6.TabIndex = 3;
            this.label6.Text = "Member:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tbRef);
            this.panel4.Controls.Add(this.tbPaymentMode);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 311);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(321, 90);
            this.panel4.TabIndex = 2;
            // 
            // tbRef
            // 
            this.tbRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbRef.Location = new System.Drawing.Point(175, 50);
            this.tbRef.Name = "tbRef";
            this.tbRef.Size = new System.Drawing.Size(117, 33);
            this.tbRef.TabIndex = 3;
            // 
            // tbPaymentMode
            // 
            this.tbPaymentMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbPaymentMode.Location = new System.Drawing.Point(175, 6);
            this.tbPaymentMode.Name = "tbPaymentMode";
            this.tbPaymentMode.ReadOnly = true;
            this.tbPaymentMode.Size = new System.Drawing.Size(117, 33);
            this.tbPaymentMode.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Reference:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Payment Mode:";
            // 
            // flpPaymentTypes
            // 
            this.flpPaymentTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flpPaymentTypes.Location = new System.Drawing.Point(6, 48);
            this.flpPaymentTypes.Name = "flpPaymentTypes";
            this.flpPaymentTypes.Size = new System.Drawing.Size(312, 257);
            this.flpPaymentTypes.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.mtTables);
            this.groupBox5.Controls.Add(this.mtKitchen);
            this.groupBox5.Controls.Add(this.mtPost);
            this.groupBox5.Controls.Add(this.mtCancel);
            this.groupBox5.Controls.Add(this.mtAdd);
            this.groupBox5.Controls.Add(this.metroButton2);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(20, 518);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1074, 73);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ACTIONS";
            // 
            // mtTables
            // 
            this.mtTables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mtTables.Location = new System.Drawing.Point(774, 17);
            this.mtTables.Name = "mtTables";
            this.mtTables.Size = new System.Drawing.Size(110, 50);
            this.mtTables.TabIndex = 31;
            this.mtTables.Text = "TABLES";
            this.mtTables.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mtTables.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mtTables.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            // 
            // mtKitchen
            // 
            this.mtKitchen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mtKitchen.Location = new System.Drawing.Point(915, 17);
            this.mtKitchen.Name = "mtKitchen";
            this.mtKitchen.Size = new System.Drawing.Size(110, 50);
            this.mtKitchen.TabIndex = 30;
            this.mtKitchen.Text = "KITCHEN";
            this.mtKitchen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mtKitchen.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mtKitchen.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            // 
            // mtPost
            // 
            this.mtPost.Location = new System.Drawing.Point(252, 17);
            this.mtPost.Name = "mtPost";
            this.mtPost.Size = new System.Drawing.Size(110, 50);
            this.mtPost.TabIndex = 29;
            this.mtPost.Text = "POST";
            this.mtPost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mtPost.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mtPost.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
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
            // Member
            // 
            this.Member.HeaderText = "Member";
            this.Member.MinimumWidth = 6;
            this.Member.Name = "Member";
            this.Member.ReadOnly = true;
            // 
            // Due
            // 
            this.Due.HeaderText = "Due";
            this.Due.MinimumWidth = 6;
            this.Due.Name = "Due";
            this.Due.ReadOnly = true;
            // 
            // Paid
            // 
            this.Paid.HeaderText = "Paid";
            this.Paid.MinimumWidth = 6;
            this.Paid.Name = "Paid";
            this.Paid.ReadOnly = true;
            // 
            // frmSplitPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 611);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbTableName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox5);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmSplitPayment";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTableName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ref;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbPaymentAmt;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbRef;
        private System.Windows.Forms.TextBox tbPaymentMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpPaymentTypes;
        private System.Windows.Forms.GroupBox groupBox5;
        private MetroFramework.Controls.MetroTile mtTables;
        private MetroFramework.Controls.MetroTile mtKitchen;
        private MetroFramework.Controls.MetroTile mtPost;
        private MetroFramework.Controls.MetroTile mtCancel;
        private MetroFramework.Controls.MetroTile mtAdd;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.ComboBox cboSplitMembers;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Member;
        private System.Windows.Forms.DataGridViewTextBoxColumn Due;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paid;
    }
}