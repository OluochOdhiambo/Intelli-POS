using CCPos.Classes;
using CCPos.Modules;
using MetroFramework.Forms;
using Pastel.Evolution;
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
    public partial class frmSplitPayment : MetroForm
    {
        private int _orderID;
        private CommonFunctions _commonFunctions;

        private bool isLoaded = false;
        private string sql;
        private string buttonInfo;
        private string[] columnsToDisplay;
        private string[] columnsToHide;
        private DataTable paymentTypes;
        private DataTable memberDues;
        private DataTable memberSummary;
        private Payment currentPayment;
        private Wallet currentMemberWallet;
        private List<Payment> allPayments;
        private List<Wallet> memberWallets;

        public frmSplitPayment(int orderID)
        {
            InitializeComponent();
            InitializeForm(orderID);
        }

        public void InitializeForm(int orderID)
        {
            isLoaded = false;

            // Set form border style to none
            this.FormBorderStyle = FormBorderStyle.None;

            // Set window state to maximized
            this.WindowState = FormWindowState.Normal;

            // Set start position to manual and adjust size
            this.StartPosition = FormStartPosition.Manual;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            _orderID = orderID;
            _commonFunctions = new CommonFunctions();
            currentMemberWallet = new Wallet();
            allPayments = new List<Payment>();
            memberWallets = new List<Wallet>();

            // hide wallet combo box
            cboWallet.Visible = false;
            cboWallet.Enabled = false;
            tbWalletBalance.Visible = false;
            tbWalletBalance.Enabled = false;

            // add memberSummary columns
            memberSummary = new DataTable();
            memberSummary.Columns.Add("PaymentName");
            memberSummary.Columns.Add("Amount");
            memberSummary.Columns.Add("Ref");
            memberSummary.Columns.Add("Id");

            // Load members allocated payments
            LoadSplitMembers();
            LoadMemberDues();
            LoadPaymentTypes();
            LoadMemberWallets();

            // Load onscreen keyboard
            CreateNumericKeyboard();

            isLoaded = true;
        }

        private void LoadMemberWallets()
        {
            if (memberDues == null || memberDues.Rows.Count == 0)
            {
                MessageBox.Show($"An error encountered loading member dues for order: {_orderID}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataRow row in memberDues.Rows)
            {
                int memberID = Convert.ToInt32(row["MemberID"]);

                Wallet memberWallet = LoadSingleWallet(memberID);
                memberWallets.Add(memberWallet);
            }
        }

        private Wallet LoadSingleWallet(int memberID)
        {
            sql = $"select memberID MemberID, personal Personal, prepayment Prepayment, discretionary Discretionary, rollover Rollover from wiz_cc_wallets where memberID in ({memberID});";
            DataTable result = _commonFunctions.LoadDatatable(sql);

            decimal personal = Convert.ToDecimal(result.Rows[0]["Personal"]);
            decimal prepayment = Convert.ToDecimal(result.Rows[0]["Prepayment"]);
            decimal discretionary = Convert.ToDecimal(result.Rows[0]["Discretionary"]);
            decimal rollover = Convert.ToDecimal(result.Rows[0]["Rollover"]);

            Wallet memberWallet = new Wallet();

            memberWallet.MemberID = memberID;
            memberWallet.Discretionary = discretionary;
            memberWallet.DiscretionaryBal = discretionary;
            memberWallet.Personal = personal;
            memberWallet.PersonalBal = personal;
            memberWallet.Prepayment = prepayment;
            memberWallet.PrepaymentBal = prepayment;
            memberWallet.Rollover = rollover;
            memberWallet.RolloverBal = rollover;

            return memberWallet;
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

        public void LoadSplitMembers()
        {
            sql = "select DISTINCT ps.memberID MemberID, c.Name MemberName from wiz_cc_order_payment_split ps inner join Client c on c.DCLink = ps.memberID";
            _commonFunctions.LoadComboBox(sql, cboSplitMembers, "MemberID", "MemberName");

        }

        public void LoadMemberDues()
        {
            sql = $"select MAX(ps.orderID) OrderID, MAX(o.tableID) TableID, MAX(t.tableName) TableName, ps.memberID MemberID, MAX(c.Name) Member, SUM(ps.itemTotal) TotalExcl, SUM(ps.discount) Discount, SUM(ps.taxCL) TaxCL, SUM(ps.taxSC) TaxSC, SUM(ps.taxVAT) TaxVAT, SUM(ps.taxTotal) TaxTotal from wiz_cc_order_payment_split ps inner join wiz_cc_order o on ps.orderID = o.orderID inner join wiz_cc_tablemst t on t.tableID = o.tableID inner join Client c on c.DCLink = ps.memberID where ps.orderID = {_orderID} group by ps.memberID;";
            memberDues = _commonFunctions.LoadDatatable(sql);

            // add column to member dues for amount paid by member
            memberDues.Columns.Add("Paid", typeof(decimal));
            memberDues.Columns.Add("Due", typeof(decimal));

            //// Fill the column with 0 for all existing rows
            foreach (DataRow row in memberDues.Rows)
            {
                row["Paid"] = 0;
                row["Due"] = Convert.ToDecimal(row["TotalExcl"]) + Convert.ToDecimal(row["TaxTotal"]);
            }

            columnsToDisplay = new string[] { "MemberID", "Member", "Due", "Paid" };
            columnsToHide = new string[] { "MemberID" };

            _commonFunctions.LoadDataGridFromDataTable(memberDues, dgvPayment, columnsToDisplay, columnsToHide);
        }

        public void LoadPaymentsSummary(int targetMemberID)
        {
            if (allPayments.Count == 0) { return; }

            memberSummary.Rows.Clear();

            List<Payment> filteredPayments = allPayments.Where(payment => payment.MemberID == targetMemberID).ToList();

            for (int i = 0; i < filteredPayments.Count; i++)
            {
                Payment payment = filteredPayments[i];

                DataRow newRow = memberSummary.NewRow();
                newRow["PaymentName"] = payment.PaymentType;
                newRow["Amount"] = payment.Amount;
                newRow["Ref"] = payment.Ref;
                newRow["Id"] = i + 1;

                memberSummary.Rows.Add(newRow);
            }


            columnsToDisplay = new string[] { "PaymentName", "Amount", "Ref" };
            columnsToHide = new string[] {  };

            _commonFunctions.LoadDataGridFromDataTable(memberSummary, dgvSummary, columnsToDisplay, columnsToHide);
        }

        public void LoadPaymentTypes()
        {
            // Get the products from the database
            sql = "select ptypeID PaymentID, name PaymentName from wiz_cc_payment_type;";
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

            //DataRow[] selectedPayType = paymentTypes.Select($"PaymentID = {payTypeId}");
            //tbPaymentMode.Text = selectedPayType[0]["PaymentName"].ToString();

            if (payTypeId == 5)
            {
                // Ignore
            }
            else if (payTypeId == 4)
            {
                // show wallet combo box
                cboWallet.Visible = true;
                cboWallet.Enabled = true;
                tbWalletBalance.Visible = true;
                tbWalletBalance.Enabled = true;

                cboWallet.Items.Clear();
                cboWallet.Items.AddRange(new object[] { "Discretionary", "Personal", "Prepayment", "Rollover" });
            }
            else
            {
                cboWallet.Visible = false;
                cboWallet.Enabled = false;
                tbWalletBalance.Visible = false;
                tbWalletBalance.Enabled = false;

                DataRow[] selectedPayType = paymentTypes.Select($"PaymentID = {payTypeId}");

                tbPaymentMode.Text = selectedPayType[0]["PaymentName"].ToString();
            }
        }

        private void mtAdd_Click(object sender, EventArgs e)
        {
            if (cboSplitMembers.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the member making the payment!");
                return;
            }

            if (string.IsNullOrEmpty(tbPaymentAmt.Text))
            {
                MessageBox.Show("Please enter the amount to pay.");
                return;
            }

            if (string.IsNullOrEmpty(tbPaymentMode.Text) && cboWallet.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a payment mode or wallet.");
                return;
            }

            decimal amount = Convert.ToDecimal(tbPaymentAmt.Text);
            string reference = string.IsNullOrWhiteSpace(tbRef.Text) ? null : tbRef.Text;
            int memberId = Convert.ToInt32(cboSplitMembers.SelectedValue);

            string paymentType = "";
            if (cboWallet.SelectedIndex != -1)
            {
                // Wallet payment logic
                paymentType = cboWallet.Text;
                if (paymentType == "Discretionary")
                {
                    currentMemberWallet.DiscretionaryBal -= amount;
                }
                else if (paymentType == "Personal")
                {
                    currentMemberWallet.PersonalBal -= amount;
                }
                else if (paymentType == "Prepayment")
                {
                    currentMemberWallet.PrepaymentBal -= amount;
                }
                else if (paymentType == "Rollover")
                {
                    currentMemberWallet.RolloverBal -= amount;
                }
            }
            else
            {
                // Regular payment mode
                paymentType = tbPaymentMode.Text;
            }

            // Define the valid payment types
            string[] validPaymentTypes = { "CASH", "Discretionary", "Personal", "Prepayment", "Rollover" };

            // Check if the payment type is in the validPaymentTypes list
            if (validPaymentTypes.Contains(paymentType))
            {
                // Check if a payment with the same type already exists for this member
                Payment existingPayment = allPayments.FirstOrDefault(p => p.MemberID == memberId && p.PaymentType == paymentType);

                if (existingPayment != null)
                {
                    // If the payment exists, sum the amount
                    existingPayment.Amount += amount;
                }
                else
                {
                    // Create a new payment and add it to the list
                    Payment newPayment = new Payment
                    {
                        MemberID = memberId,
                        OrderID = _orderID,
                        PaymentType = paymentType,
                        Amount = amount,
                        Ref = reference,
                        AgentID = 464 // TODO: remove hardcoded agent ID
                    };

                    // Add the payment to allPayments list
                    allPayments.Add(newPayment);
                }
            }
            else
            {
                // For other payment types, always add a new payment
                Payment newPayment = new Payment
                {
                    MemberID = memberId,
                    OrderID = _orderID,
                    PaymentType = paymentType,
                    Amount = amount,
                    Ref = reference,
                    AgentID = 464 // TODO: remove hardcoded agent ID
                };

                // Add the payment to allPayments list
                allPayments.Add(newPayment);
            }

            // Reload DataGridView or update UI accordingly
            int targetMemberID = Convert.ToInt32(cboSplitMembers.SelectedValue);
            LoadPaymentsSummary(targetMemberID);

            // Reset wallet combo box
            cboWallet.SelectedIndex = -1;
        }



        private void cboSplitMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded == false) { return; }

            int targetMemberID = Convert.ToInt32(cboSplitMembers.SelectedValue);

            currentMemberWallet = memberWallets.FirstOrDefault(x => x.MemberID == targetMemberID);

            LoadPaymentsSummary(targetMemberID);
        }

        private void cboWallet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentMemberWallet == new Wallet()) { return; }

            if (cboWallet.Text == "Discretionary")
            {
                tbWalletBalance.Text = currentMemberWallet.DiscretionaryBal.ToString();
            }
            else if (cboWallet.Text == "Personal")
            {
                tbWalletBalance.Text = currentMemberWallet.PersonalBal.ToString();
            }
            else if (cboWallet.Text == "Prepayment")
            {
                tbWalletBalance.Text = currentMemberWallet.PrepaymentBal.ToString();
            }
            else if (cboWallet.Text == "Rollover")
            {
                tbWalletBalance.Text = currentMemberWallet.RolloverBal.ToString();
            }
        }
    }
}
