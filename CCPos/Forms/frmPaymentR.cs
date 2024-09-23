using CCPos.Modules;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCPos.Forms
{
    public partial class frmPaymentR : MetroForm
    {
        private CommonFunctions _commonFunctions;
        private int _orderID;
        private int _tableID;
        private bool success;
        private decimal amount;

        private string sql;
        private string[] columnsToDisplay;
        private string[] columnsToHide;
        private string buttonInfo;
        private DataTable paymentTypes;
        private DataTable payments;
        private DataTable orderDetails;
        private DataTable splitPaymentDetails;

        public frmPaymentR(int orderID, int tableID)
        {
            InitializeComponent();
            InitializeForm(orderID, tableID);
        }

        public frmPaymentR() : this(0, 0)
        {
        }

        private void InitializeForm(int orderID, int tableID)
        {
            // Set form border style to none
            this.FormBorderStyle = FormBorderStyle.None;

            // Set window state to maximized
            this.WindowState = FormWindowState.Normal;

            // Set start position to manual and adjust size
            this.StartPosition = FormStartPosition.Manual;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            // Initialize Common Functions
            _commonFunctions = new CommonFunctions();

            // initialize payments dt
            payments = new DataTable();
            payments.Columns.Add("Id");
            payments.Columns.Add("PaymentName");
            payments.Columns.Add("Amount");
            payments.Columns.Add("Ref");

            _orderID = orderID;
            _tableID = tableID;
        }

        private void FetchOrderDetails()
        {
            if (_orderID != 0)
            {
                sql = $"select o.customerID CustomerID, o.totalPayable Total, o.orderStatus Status, c.name CustomerName, t.tableName TableName, l.locName LocationName from cc_order o inner join tbl_customer c on c.id = o.customerID inner join cc_tablemst t on t.tableID = o.tableID inner join cc_locations l on l.locID = t.locationID where orderID = {_orderID};";
                orderDetails = _commonFunctions.LoadDatatable(sql);

                if (orderDetails != null & orderDetails.Rows.Count > 0)
                {
                    amount = Convert.ToDecimal(orderDetails.Rows[0]["Total"]);

                    tbAmountDue.Text = amount.ToString();
                    //tbLocationName.Text = orderDetails.Rows[0]["LocationName"].ToString();
                    tbTableName.Text = orderDetails.Rows[0]["TableName"].ToString();
                }
            }
        }

        private void CreateSplitPaymentTemplate()
        {
            sql = $"select o.orderID OrderID, o.customerID MemberID, c.name Member, o.tableID TableID, d.itemID ItemID, p.product_name Item, d.qty Qty, d.price Price, CAST(0 AS BIT) Split from cc_order o inner join cc_order_details d on o.orderID = d.orderID inner join purchase p on p.product_id = d.itemID inner join tbl_customer c on c.id = o.customerID where o.orderID = {_orderID}";
            splitPaymentDetails = _commonFunctions.LoadDatatable(sql);
        }

        private void CreateNumericKeyboard()
        {


            // Create an array for the keyboard buttons with a 4x4 layout
            string[] buttonLabels = { "1", "2", "3", "+10",
                              "4", "5", "6", "+20",
                              "7", "8", "9", "+50",
                              "+/-", "0", ".", "←" };

            // Set button dimensions and layout
            int buttonWidth = 130; // Adjusted width for 4 columns
            int buttonHeight = 80;
            int margin = 25;

            // Create and add buttons to the panel
            for (int i = 0; i < buttonLabels.Length; i++)
            {
                Button btn = new Button
                {
                    Text = buttonLabels[i],
                    Width = buttonWidth,
                    Height = buttonHeight,
                    Tag = buttonLabels[i], // Store the value in the tag for easier access
                    Left = (i % 4) * (buttonWidth + margin), // Set X position for 4 columns
                    Top = (i / 4) * (buttonHeight + margin)  // Set Y position for rows
                };

                // Attach event handler for button clicks
                btn.Click += NumericButton_Click;
                panelInput.Controls.Add(btn);
            }
        }

        private void NumericButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                // Handle backspace button
                if (clickedButton.Text == "←")
                {
                    if (tbPaymentAmt.Text.Length > 0)
                    {
                        tbPaymentAmt.Text = tbPaymentAmt.Text.Substring(0, tbPaymentAmt.Text.Length - 1);
                    }
                }
                // Handle special buttons like "+10", "+20", "+50", and "+/-"
                else if (clickedButton.Text.StartsWith("+"))
                {
                    int valueToAdd = int.Parse(clickedButton.Text.Substring(1));
                    if (int.TryParse(tbPaymentAmt.Text, out int currentValue))
                    {
                        tbPaymentAmt.Text = (currentValue + valueToAdd).ToString();
                    }
                }
                else if (clickedButton.Text == "+/-")
                {
                    if (tbPaymentAmt.Text.Length > 0 && double.TryParse(tbPaymentAmt.Text, out double currentAmount))
                    {
                        tbPaymentAmt.Text = (-currentAmount).ToString();
                    }
                }
                // Handle numeric and decimal point buttons
                else
                {
                    tbPaymentAmt.Text += clickedButton.Tag.ToString();
                }
            }
        }

        public void LoadPaymentTypes()
        {
            // Get the products from the database
            sql = "select ptypeID PaymentID, name PaymentName from cc_payment_type;";
            paymentTypes = _commonFunctions.LoadDatatable(sql);

            int width = (flpPaymentTypes.Size.Width) - 25;
            buttonInfo = $"PaymentName|PaymentID|{width}|50|false";

            // Load buttons
            _commonFunctions.LoadDynamicButtons(paymentTypes, flpPaymentTypes, PaymentTypeButton_Click, buttonInfo);
        }

        private void PaymentTypeButton_Click(object sender, EventArgs e)
        {
            // Cast the sender to a Button
            Button clickedButton = sender as Button;
            int payTypeId = Convert.ToInt32(clickedButton.Tag);

            if (payTypeId == 5)
            {
                // create split payments template;
                CreateSplitPaymentTemplate();

                if (splitPaymentDetails == null)
                {
                    MessageBox.Show("Error creating split payment details.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // open split payment grid to allocate splits
                frmSplitPaymentGrid frmSplitPaymentGrid = new frmSplitPaymentGrid(splitPaymentDetails, _orderID);
                frmSplitPaymentGrid.Show();

                // Open split payments
                //frmSplitPayment frmSplitPayment = new frmSplitPayment();
                //frmSplitPayment.Show();
            }
            else
            {
                DataRow[] selectedPayType = paymentTypes.Select($"PaymentID = {payTypeId}");

                tbPaymentMode.Text = selectedPayType[0]["PaymentName"].ToString();
            }
        }

        private void frmPaymentR_Load(object sender, EventArgs e)
        {
            CreateNumericKeyboard();
            LoadPaymentTypes();
            FetchOrderDetails();
        }

        private void mtAdd_Click(object sender, EventArgs e)
        {
            if (tbPaymentAmt.Text == "")
            {
                MessageBox.Show("Please enter the amount to pay.");
                return;
            }

            DataRow newRow = payments.NewRow();

            newRow["Id"] = tbPaymentMode.Text;
            newRow["PaymentName"] = tbPaymentMode.Text;
            newRow["Amount"] = tbPaymentAmt.Text;
            newRow["Ref"] = tbRef.Text;

            payments.Rows.Add(newRow);

            columnsToDisplay = new string[] { "PaymentName", "Amount", "Ref" };
            columnsToHide = new string[] { "" };
            _commonFunctions.LoadDataGridFromDataTable(payments, dgvPayment, columnsToDisplay, columnsToHide);
        }

        private void mtPost_Click(object sender, EventArgs e)
        {
            if (payments.Rows.Count == 0)
            {
                MessageBox.Show("No payments to process.", "PAYMENT ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal cashAmount = 0m;
            decimal mpesaAmount = 0m;
            string mpesaRef = "";
            decimal cardAmount = 0m;
            string cardRef = "";
            decimal walletAmount = 0m;
            string walletRef = "";
            decimal totalAmount = 0m;

            foreach (DataRow row in payments.Rows)
            {
                if (row["PaymentName"].ToString() == "CASH")
                {
                    cashAmount = Convert.ToDecimal(row["Amount"]);
                }
                else if (row["PaymentName"].ToString() == "MPESA")
                {
                    mpesaAmount = Convert.ToDecimal(row["Amount"]);
                    mpesaRef = row["Ref"].ToString();
                }
                else if (row["PaymentName"].ToString() == "CARD/ BANK")
                {
                    cardAmount = Convert.ToDecimal(row["Amount"]);
                    cardRef = row["Ref"].ToString();
                }
                else if (row["PaymentName"].ToString() == "WALLET")
                {
                    walletAmount = Convert.ToDecimal(row["Amount"]);
                    walletRef = row["Ref"].ToString();
                }
            }

            totalAmount = cashAmount + mpesaAmount + cardAmount + walletAmount;

            //TODO: replace agent id

            sql = $"INSERT INTO cc_payment (cashamount, mpesaAmount, mpesaRef, bankAmount, bankRef, walletAmount, walletRef, totalAmount, orderID, isSplit, agentID) VALUES ({cashAmount}, {mpesaAmount}, '{mpesaRef}', {cardAmount}, '{cardRef}', {walletAmount}, '{walletRef}', {totalAmount}, {_orderID}, 0, 456);";
            success = _commonFunctions.ExecuteScalarAndReturnBool(sql);

            MessageBox.Show("Payment processed successfully!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
