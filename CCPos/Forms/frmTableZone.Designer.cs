namespace CCPos.Forms
{
    partial class frmTableZone
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flpTables = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flpLocations = new System.Windows.Forms.FlowLayoutPanel();
            this.flpOrderKey = new System.Windows.Forms.FlowLayoutPanel();
            this.grpBxTableStatus = new System.Windows.Forms.GroupBox();
            this.mtDashboardMenu = new MetroFramework.Controls.MetroTile();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpBxTableStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(88, 75);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(908, 501);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Table Arrangement";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.flpTables);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(4, 180);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(899, 317);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tables";
            // 
            // flpTables
            // 
            this.flpTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTables.Location = new System.Drawing.Point(2, 27);
            this.flpTables.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flpTables.Name = "flpTables";
            this.flpTables.Size = new System.Drawing.Size(895, 288);
            this.flpTables.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.flpLocations);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(4, 30);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(899, 145);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Locations";
            // 
            // flpLocations
            // 
            this.flpLocations.AutoScroll = true;
            this.flpLocations.AutoScrollMinSize = new System.Drawing.Size(4000, 0);
            this.flpLocations.AutoSize = true;
            this.flpLocations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpLocations.Location = new System.Drawing.Point(2, 27);
            this.flpLocations.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flpLocations.Name = "flpLocations";
            this.flpLocations.Size = new System.Drawing.Size(895, 116);
            this.flpLocations.TabIndex = 2;
            this.flpLocations.WrapContents = false;
            // 
            // flpOrderKey
            // 
            this.flpOrderKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpOrderKey.Location = new System.Drawing.Point(2, 24);
            this.flpOrderKey.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flpOrderKey.Name = "flpOrderKey";
            this.flpOrderKey.Size = new System.Drawing.Size(163, 532);
            this.flpOrderKey.TabIndex = 1;
            // 
            // grpBxTableStatus
            // 
            this.grpBxTableStatus.Controls.Add(this.flpOrderKey);
            this.grpBxTableStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpBxTableStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBxTableStatus.Location = new System.Drawing.Point(1004, 49);
            this.grpBxTableStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpBxTableStatus.Name = "grpBxTableStatus";
            this.grpBxTableStatus.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpBxTableStatus.Size = new System.Drawing.Size(167, 558);
            this.grpBxTableStatus.TabIndex = 2;
            this.grpBxTableStatus.TabStop = false;
            this.grpBxTableStatus.Text = "Table Order Status";
            // 
            // mtDashboardMenu
            // 
            this.mtDashboardMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mtDashboardMenu.Location = new System.Drawing.Point(801, 13);
            this.mtDashboardMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mtDashboardMenu.Name = "mtDashboardMenu";
            this.mtDashboardMenu.Size = new System.Drawing.Size(172, 58);
            this.mtDashboardMenu.TabIndex = 22;
            this.mtDashboardMenu.Text = "DASHBOARD";
            this.mtDashboardMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mtDashboardMenu.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mtDashboardMenu.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mtDashboardMenu.Click += new System.EventHandler(this.mtDashboardMenu_Click);
            // 
            // frmTableZone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 623);
            this.Controls.Add(this.mtDashboardMenu);
            this.Controls.Add(this.grpBxTableStatus);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmTableZone";
            this.Padding = new System.Windows.Forms.Padding(15, 49, 15, 16);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpBxTableStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FlowLayoutPanel flpTables;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flpOrderKey;
        private System.Windows.Forms.GroupBox grpBxTableStatus;
        private System.Windows.Forms.FlowLayoutPanel flpLocations;
        private MetroFramework.Controls.MetroTile mtDashboardMenu;
    }
}