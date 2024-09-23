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
    public partial class frmTextPopup : MetroForm
    {
        private CommonFunctions _commonFunctions;
        private string _columnName;
        private long _productID;
        private int _wipOrderID;

        private string sql;
        private bool success = false;

        public frmTextPopup(string columnName, long productID, int wipOrderID)
        {
            InitializeComponent();
            InitializeForm(columnName, productID, wipOrderID);
        }

        public void InitializeForm(string columnName, long productID, int wipOrderID)
        {
            // Set form border style to none
            this.FormBorderStyle = FormBorderStyle.None;

            // Remove maximized window state, set custom size instead
            //this.Size = new System.Drawing.Size(400, 300);  // Set form size to 400x300

            // Set start position to center screen
            this.StartPosition = FormStartPosition.CenterScreen;

            // Ensure the form is not shown in the taskbar and has no control box
            this.ShowInTaskbar = false;
            this.ControlBox = false;

            _commonFunctions = new CommonFunctions();
            _columnName = columnName;
            _productID = productID;
            _wipOrderID = wipOrderID;

            if (_columnName == "M")
            {
                tbDetailName.Text = "Modifier";
            }
            else if (_columnName == "A")
            {
                tbDetailName.Text = "Add-On";
            } 
            else if (_columnName == "I")
            {
                tbDetailName.Text = "Instruction";
            }
        }

        private void mtSave_Click(object sender, EventArgs e)
        {
            string column = "";
            string boolCol = "";

            if (_columnName == "M")
            {
                column = "modifier";
                boolCol = "hasModifier";

            } else if (_columnName == "A")
            {
                column = "addOn";
                boolCol = "hasAddOn";
            }
            else if (_columnName == "I")
            {
                column = "instruction";
                boolCol = "hasInstruction";
            }

            // update product row in cc_wip_order
            sql = $"update cc_wip_order_details set [{column}] = '{tbInput.Text}', [{boolCol}] = {1} where itemID = {_productID} and orderID = {_wipOrderID}";
            success = _commonFunctions.ExecuteScalarAndReturnBool(sql);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
