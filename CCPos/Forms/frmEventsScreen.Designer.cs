namespace CCPos.Forms
{
    partial class frmEventsScreen
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
            this.mtTables = new MetroFramework.Controls.MetroTile();
            this.mtKitchen = new MetroFramework.Controls.MetroTile();
            this.mtPost = new MetroFramework.Controls.MetroTile();
            this.mtCancel = new MetroFramework.Controls.MetroTile();
            this.mtAdd = new MetroFramework.Controls.MetroTile();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.cboBookingRef = new System.Windows.Forms.ComboBox();
            this.eventLabel = new System.Windows.Forms.Label();
            this.mainFlpPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.SuspendLayout();
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
            this.groupBox5.Location = new System.Drawing.Point(20, 462);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1024, 73);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ACTIONS";
            // 
            // mtTables
            // 
            this.mtTables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mtTables.Location = new System.Drawing.Point(724, 17);
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
            this.mtKitchen.Location = new System.Drawing.Point(865, 17);
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
            this.groupBox1.Controls.Add(this.filterPanel);
            this.groupBox1.Controls.Add(this.mainFlpPanel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 402);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "EVENT BOOKING ORDERS";
            // 
            // filterPanel
            // 
            this.filterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterPanel.Controls.Add(this.cboBookingRef);
            this.filterPanel.Controls.Add(this.eventLabel);
            this.filterPanel.Location = new System.Drawing.Point(3, 32);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(1015, 51);
            this.filterPanel.TabIndex = 1;
            // 
            // cboBookingRef
            // 
            this.cboBookingRef.FormattingEnabled = true;
            this.cboBookingRef.Location = new System.Drawing.Point(135, 9);
            this.cboBookingRef.Name = "cboBookingRef";
            this.cboBookingRef.Size = new System.Drawing.Size(152, 33);
            this.cboBookingRef.TabIndex = 1;
            this.cboBookingRef.SelectedIndexChanged += new System.EventHandler(this.cboBookingRef_SelectedIndexChanged);
            // 
            // eventLabel
            // 
            this.eventLabel.AutoSize = true;
            this.eventLabel.Location = new System.Drawing.Point(8, 12);
            this.eventLabel.Name = "eventLabel";
            this.eventLabel.Size = new System.Drawing.Size(121, 25);
            this.eventLabel.TabIndex = 0;
            this.eventLabel.Text = "Select Event:";
            // 
            // mainFlpPanel
            // 
            this.mainFlpPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainFlpPanel.AutoScroll = true;
            this.mainFlpPanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainFlpPanel.Location = new System.Drawing.Point(3, 89);
            this.mainFlpPanel.Name = "mainFlpPanel";
            this.mainFlpPanel.Size = new System.Drawing.Size(1015, 310);
            this.mainFlpPanel.TabIndex = 0;
            // 
            // frmEventsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 555);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmEventsScreen";
            this.groupBox5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private MetroFramework.Controls.MetroTile mtTables;
        private MetroFramework.Controls.MetroTile mtKitchen;
        private MetroFramework.Controls.MetroTile mtPost;
        private MetroFramework.Controls.MetroTile mtCancel;
        private MetroFramework.Controls.MetroTile mtAdd;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel mainFlpPanel;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Label eventLabel;
        private System.Windows.Forms.ComboBox cboBookingRef;
    }
}