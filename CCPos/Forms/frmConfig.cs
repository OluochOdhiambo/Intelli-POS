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
    public partial class frmConfig : MetroForm
    {
        private CommonFunctions _commonFunctions;

        private int currentTab;
        private string sql;
        private bool success;
        private DataTable printers;
        private DataTable tables;
        private DataTable assignedPrinters;
        private string[] columnsToDisplay;
        private string[] columnsToHide;

        public frmConfig()
        {
            InitializeComponent();
            InitializeForm();
        }

        public void InitializeForm()
        {
            // Set form border style to none
            this.FormBorderStyle = FormBorderStyle.None;

            // Set window state to maximized
            this.WindowState = FormWindowState.Normal;

            // Set start position to manual and adjust size
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.Bounds = Screen.PrimaryScreen.Bounds;

            // Initialize common functions
            _commonFunctions = new CommonFunctions();

            // Load current tab
            LoadTab(currentTab);

        }

        private void LoadTab(int selectedIndex)
        {
            if (selectedIndex == 0) // Printers tab
            {
                //Load datagrids and combo boxes
                LoadLocations(cboLocation);
                LoadAllPrinters();
                LoadAssignedPrinters();
            }
            else if (selectedIndex == 1)
            {
                LoadLocations(cboTableLocation);
            }
        }

        private void LoadLocations(ComboBox cbo)
        {
            //sql = "select id LocationID, branchname Location from tbl_terminallocation;";
            sql = "select WhseLink LocationID, Code LocationCode, Name Location from WhseMst;";
            _commonFunctions.LoadComboBox(sql, cbo, "LocationID", "Location");
        }

        private void LoadAllPrinters()
        {
            sql = "SELECT printerID PrinterID, name PrinterName, ip PrinterIP FROM wiz_cc_printers";

            // Load combobox
            _commonFunctions.LoadComboBox(sql, cboName, "PrinterID", "PrinterName");

            // Load datagrid
            printers = _commonFunctions.LoadDatatable(sql);

            columnsToDisplay = new string[] { "PrinterID", "PrinterName", "PrinterIP" };
            columnsToHide = new string[] { "PrinterID" };
            _commonFunctions.LoadDataGridFromDataTable(printers, dgvPrinters, columnsToDisplay, columnsToHide);
        }

        private void LoadAllTables()
        {
            sql = "select t.tableID TableID, t.tableName TableName, w.Name TableLocation, t.capacity Capacity from wiz_cc_tablemst t inner join WhseMst w on t.locationID = w.WhseLink";

            // Load datagrid
            tables = _commonFunctions.LoadDatatable(sql);

            columnsToDisplay = new string[] { "TableID", "TableName", "TableLocation", "Capacity" };
            columnsToHide = new string[] { "TableID" };
            _commonFunctions.LoadDataGridFromDataTable(tables, dgvTables, columnsToDisplay, columnsToHide);
        }


        private void LoadAssignedPrinters()
        {
            sql = "SELECT ap.id ID, ap.printerID PrinterID, ap.locationID LocationID, w.Name Location, p.name Printer, p.ip IP FROM wiz_cc_assgnd_printers ap inner join wiz_cc_printers p on p.printerID = ap.printerID inner join WhseMst w on ap.locationID = w.WhseLink";
            assignedPrinters = _commonFunctions.LoadDatatable(sql);

            columnsToDisplay = new string[] { "PrinterID", "LocationID", "Location", "Printer", "IP" };
            columnsToHide = new string[] { "PrinterID", "LocationID", "IP" };
            _commonFunctions.LoadDataGridFromDataTable(assignedPrinters, dgvAssigned, columnsToDisplay, columnsToHide);
        }

        private void AddPrinter()
        {
            if (!string.IsNullOrEmpty(tbName.Text) && !string.IsNullOrEmpty(tbIP.Text))
            {
                string printerName = tbName.Text;
                string printerIP = tbIP.Text;

                sql = $"INSERT INTO wiz_cc_printers (name, ip) VALUES ('{printerName}', '{printerIP}')";
                success = _commonFunctions.ExecuteScalarAndReturnBool(sql);

                if (success)
                {
                    MessageBox.Show($"Printer: {printerName} added successfully.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("An error occurred.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Reload printers datagrid
                LoadAllPrinters();

                // clear text boxes
                tbIP.Text = "";
                tbName.Text = "";
            }
        }

        private void AddTable()
        {
            if (cboTableLocation.SelectedIndex != -1 && !string.IsNullOrEmpty(tbTableName.Text) && !string.IsNullOrEmpty(tbCapacity.Text))
            {
                int locationID = Convert.ToInt32(cboTableLocation.SelectedValue);
                string tableName = tbTableName.Text;
                int capacity = Convert.ToInt32(tbCapacity.Text);

                sql = $"insert into wiz_cc_tablemst (tableName, locationID, capacity) VALUES ('{tableName}', {locationID}, {capacity})";
                success = _commonFunctions.ExecuteScalarAndReturnBool(sql);

                if (success)
                {
                    MessageBox.Show($"Table: {tableName} added successfully.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("An error occurred.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Reload printers datagrid
                LoadAllTables();

                // clear text boxes
                tbIP.Text = "";
                tbName.Text = "";
            }
        }


        private void mtAdd_Click(object sender, EventArgs e)
        {
            if (currentTab == 0 )
            {
                AddPrinter();
            } 
            else if (currentTab == 1)
            {
                AddTable();
            }
        }

        private void mtAssign_Click(object sender, EventArgs e)
        {
            if (cboLocation.SelectedIndex == -1 || cboName.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a printer and location to assign.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int printerID = Convert.ToInt32(cboName.SelectedValue);
            int locationID = Convert.ToInt32(cboLocation.SelectedValue);

            sql = $"insert into wiz_cc_assgnd_printers (printerID, locationID) values ({printerID}, {locationID});";
            success = _commonFunctions.ExecuteScalarAndReturnBool(sql);

            if (success)
            {
                MessageBox.Show($"Printer assigned successfully.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("An error occurred.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Reload printers datagrid
            LoadAssignedPrinters();

            // Reset combo boxes
            cboName.SelectedIndex = -1; 
            cboLocation.SelectedIndex = -1;
        }

        private void cboTableLocation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tcConfigs_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTab = tcConfigs.SelectedIndex;

            LoadTab(currentTab);
        }
    }
}
