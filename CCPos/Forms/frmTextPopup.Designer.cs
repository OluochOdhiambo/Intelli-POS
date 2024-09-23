namespace CCPos.Forms
{
    partial class frmTextPopup
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
            this.tbDetailName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.mtSave = new MetroFramework.Controls.MetroTile();
            this.mtCancel = new MetroFramework.Controls.MetroTile();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbDetailName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(63, 72);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(698, 366);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Extras";
            // 
            // tbDetailName
            // 
            this.tbDetailName.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDetailName.Location = new System.Drawing.Point(127, 60);
            this.tbDetailName.Name = "tbDetailName";
            this.tbDetailName.Size = new System.Drawing.Size(155, 38);
            this.tbDetailName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Detail:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbInput);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(6, 139);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 221);
            this.panel1.TabIndex = 0;
            // 
            // tbInput
            // 
            this.tbInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInput.Location = new System.Drawing.Point(0, 0);
            this.tbInput.Multiline = true;
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(686, 221);
            this.tbInput.TabIndex = 0;
            // 
            // mtSave
            // 
            this.mtSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mtSave.Location = new System.Drawing.Point(86, 474);
            this.mtSave.Name = "mtSave";
            this.mtSave.Size = new System.Drawing.Size(119, 61);
            this.mtSave.TabIndex = 1;
            this.mtSave.Text = "SAVE";
            this.mtSave.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mtSave.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mtSave.Click += new System.EventHandler(this.mtSave_Click);
            // 
            // mtCancel
            // 
            this.mtCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mtCancel.Location = new System.Drawing.Point(620, 474);
            this.mtCancel.Name = "mtCancel";
            this.mtCancel.Size = new System.Drawing.Size(119, 61);
            this.mtCancel.TabIndex = 2;
            this.mtCancel.Text = "CANCEL";
            this.mtCancel.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mtCancel.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            // 
            // frmTextPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 553);
            this.Controls.Add(this.mtCancel);
            this.Controls.Add(this.mtSave);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmTextPopup";
            this.Padding = new System.Windows.Forms.Padding(37, 129, 37, 43);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.TextBox tbDetailName;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTile mtSave;
        private MetroFramework.Controls.MetroTile mtCancel;
    }
}