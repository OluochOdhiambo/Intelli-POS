using CCPos.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace CCPos.Forms
{
    public partial class frmCustomerModal : MetroForm
    {
        public int SelectedMemberID { get; private set; }
        public string SelectedCustomerName { get; private set; }
        public string SelectedMemberNo { get; private set; }
        public int AssignedWIPOrderID { get; private set; }

        private int _tableID;
        private int _orderID;
        private int _wipOrderID;
        private int _memberID;
        private int _locationID;

        private string sql;
        private bool isLoaded = false;
        private bool isReservation;
        private bool success = false;
        private string[] columnsToDisplay;
        private string[] columnsToHide;
        private DataTable members;
        private DataTable guestMembers = new DataTable();
        private DataRow currentMember;

        private CommonFunctions _commonFunctions;

        public frmCustomerModal(int tableID, int locationID, int wipOrderID, int orderID, int memberID)
        {
            InitializeComponent();
            InitializeForm(tableID, locationID, wipOrderID, orderID, memberID);
        }

        public frmCustomerModal() : this(0, 0, 0, 0, 0)
        {

        }

        private void InitializeForm(int tableID, int locationID, int wipOrderID, int orderID, int memberID)
        {
            // Set form border style to none
            this.FormBorderStyle = FormBorderStyle.None;

            // Set window state to maximized
            this.WindowState = FormWindowState.Maximized;

            // Set start position to manual and adjust size
            this.StartPosition = FormStartPosition.Manual;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            _commonFunctions = new CommonFunctions();

            _tableID = tableID;
            _locationID = locationID;
            _wipOrderID = wipOrderID;
            _orderID = orderID;
            _memberID = memberID;

            // Add guest member cols
            guestMembers.Columns.Add("Name", typeof(string));
            guestMembers.Columns.Add("MemberNo", typeof(string));
            guestMembers.Columns.Add("MemberID", typeof(int));

            LoadCustomers();
            LoadCurrentMembers();

            isLoaded = true;
        }

        private void LoadCurrentMembers()
        {
            if (_memberID != 0)
            {
                if (_wipOrderID == 0)
                {
                    sql = $"select c.id MemberID, c.Name, c.memberNo MemberNo from cc_table_guests g inner join tbl_customer c on c.id = g.guestID where g.tableID = {_tableID} and g.orderID = {_orderID}";
                }
                else if (_orderID == 0)
                {
                    sql = $"select c.id MemberID, c.Name, c.memberNo MemberNo from cc_table_guests g inner join tbl_customer c on c.id = g.guestID where g.tableID = {_tableID} and g.wipOrderID = {_wipOrderID}";
                }

                guestMembers = _commonFunctions.LoadDatatable(sql);

                if (guestMembers != null && guestMembers.Rows.Count > 0) 
                {
                    currentMember = guestMembers.Rows[0];

                    columnsToDisplay = new string[] { "MemberID", "MemberNo", "Name" };
                    columnsToHide = new string[] { "MemberID" };

                    _commonFunctions.LoadDataGridFromDataTable(guestMembers, dgvCustomers, columnsToDisplay, columnsToHide);
                }

                dgvCustomers.Enabled = false;
            }
        }

        private void LoadCustomers()
        {
            sql = "select id MemberID, Name, memberNo MemberNo from tbl_customer c where c.peopletype = 'Customer';";
            members = _commonFunctions.LoadDatatable(sql);

            _commonFunctions.LoadComboBox(sql, cboMember, "MemberID", "Name");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboMember.SelectedIndex == -1) { return; }

            string customerName = cboMember.Text;
            int customerID = Convert.ToInt32(cboMember.SelectedValue);

            if (guestMembers.Rows.Count == 0)
            {
                _memberID = customerID;
            }

            // fetch memberNo
            DataRow[] foundRows = members.Select("MemberID = " + customerID);

            if (foundRows.Length > 0)
            {
                DataRow newRow = guestMembers.NewRow();
                newRow["Name"] = customerName;
                newRow["MemberNo"] = foundRows[0]["MemberNo"].ToString();
                newRow["MemberID"] = Convert.ToInt32(foundRows[0]["MemberID"]);
                guestMembers.Rows.Add(newRow);
            }

            columnsToDisplay = new string[] { "MemberID", "MemberNo", "Name" };
            columnsToHide = new string[] { "MemberID" };

            _commonFunctions.LoadDataGridFromDataTable(guestMembers, dgvCustomers, columnsToDisplay, columnsToHide);
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (_memberID == 0)
            {
                MessageBox.Show("Please assign atleast 1 member to the table.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isReservation)
            {
                // check permissions
                frmPermission frmPermission = new frmPermission();

                if (frmPermission.ShowDialog() == DialogResult.OK)
                {
                    // create order in wip with status "Reserved"
                    sql = $"INSERT INTO cc_wip_order (tableID, customerID, orderTotal, taxTotal, totalPayable, agentID, orderStatus) OUTPUT INSERTED.orderID VALUES ({_tableID},{_memberID}, 0, 0, 0, 456, 'Reserved');";

                    _wipOrderID = _commonFunctions.ExecuteScalarAndReturnId(sql);

                    // save guests to guest table
                    foreach (DataRow guest in guestMembers.Rows)
                    {
                        sql = $"insert into cc_table_guests (guestID, tableID, wipOrderID) VALUES ({Convert.ToInt32(guest["MemberID"])}, {_tableID}, {_wipOrderID})";
                        success = _commonFunctions.ExecuteScalarAndReturnBool(sql);
                    }

                    MessageBox.Show($"Table reserved successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Open table screen
                    frmTableZone frmTableZone = new frmTableZone();
                    frmTableZone.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Table reservation denied.", "PERMISSION DENIED", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                if (_orderID == 0 && _wipOrderID == 0)
                {
                    // create an order in order_wip
                    sql = $"INSERT INTO cc_wip_order (tableID, customerID, orderTotal, taxTotal, totalPayable, agentID) OUTPUT INSERTED.orderID VALUES ({_tableID},{_memberID}, 0, 0, 0, 456);";

                    _wipOrderID = _commonFunctions.ExecuteScalarAndReturnId(sql);

                    // save guests to guest table
                    foreach (DataRow guest in guestMembers.Rows)
                    {
                        sql = $"insert into cc_table_guests (guestID, tableID, wipOrderID) VALUES ({Convert.ToInt32(guest["MemberID"])}, {_tableID}, {_wipOrderID})";
                        success = _commonFunctions.ExecuteScalarAndReturnBool(sql);
                    }
                }

                frmSales frmSales = new frmSales(_tableID, _locationID, _memberID, _wipOrderID, _orderID);
                frmSales.Show();

                this.Close();
            }
        }

        private void cbReserve_CheckedChanged(object sender, EventArgs e)
        {
            if (cbReserve.Checked)
            {
                isReservation = true;
            }
            else
            {
                isReservation = false;
            }
        }
    }
}
