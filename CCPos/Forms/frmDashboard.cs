using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace CCPos.Forms
{
    public partial class frmDashboard : MetroForm
    {
        public frmDashboard()
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
        }

        private void metroTilePOS_Click(object sender, EventArgs e)
        {
            frmTableZone frmTableZone = new frmTableZone();
            frmTableZone.Show();

            //this.Close();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            // Set the number of columns to 3
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.RowCount = 3;

            // Clear any existing column styles
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            // Set each column to take 33.33% of the total width
            for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            }
        }

        private void mtPermissions_Click(object sender, EventArgs e)
        {
            frmPermission frmPermission = new frmPermission();
            frmPermission.Show();

            //this.Close();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            frmKitchen frmKitchen = new frmKitchen();
            frmKitchen.Show();

            //this.Close();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            frmEventsScreen frmEventsScreen = new frmEventsScreen();
            frmEventsScreen.Show();

            //this.Close();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            frmConfig frmPrinter = new frmConfig();
            frmPrinter.Show();

            //this.Close();
        }
    }
}
