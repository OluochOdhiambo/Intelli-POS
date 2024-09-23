using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCPos.Modules;
using MetroFramework.Forms;

namespace CCPos.Forms
{
    public partial class frmPermission : MetroForm
    {
        private CommonFunctions _commonFunctions;

        public frmPermission()
        {
            InitializeComponent();
            InitializeForm();
        }

        public void InitializeForm()
        {
            // Set form border style to none
            this.FormBorderStyle = FormBorderStyle.None;

            // Set window state to maximized
            this.WindowState = FormWindowState.Maximized;

            // Set start position to manual and adjust size
            this.StartPosition = FormStartPosition.Manual;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            // Initialize Common Functions
            _commonFunctions = new CommonFunctions();
        }

        private void btnAllow_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
            this.Close();
        }
    }
}
