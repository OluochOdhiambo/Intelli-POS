using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCPos.Classes;
using CCPos.Modules;
using MetroFramework.Forms;

namespace CCPos.Forms
{
    public partial class frmSplitPaymentGrid : MetroForm
    {
        private CommonFunctions _commonFunctions;
        private DataTable _splitPaymentDetails;
        private int _orderID;

        private bool loadComplete = false;
        private string[] columnsToDisplay;
        private string[] columnsToHide;
        private string sql;
        private bool success;
        private DataTable members;
        private DataTable existingSplitPaymentDetails;
        private DataTable editedDetails;
        private long activeSplitItemID;
        private List<ItemSplitDetail> itemSplitDetails; // on initialize
        private List<ItemSplitDetail> adjustedItemSplitDetails; // during update

        public frmSplitPaymentGrid(DataTable splitPaymentDetails, int orderID)
        {
            InitializeComponent();
            _splitPaymentDetails = splitPaymentDetails;
            _orderID = orderID;
            _commonFunctions = new CommonFunctions();

            // initialize edited details
            editedDetails = new DataTable();

            LoadSplitPaymentDetails();
            LoadMembers();

            loadComplete = true;
        }

        public void CheckExistingSplits()
        {
            sql = $"select memberID MemberID, ps.itemID ItemID, s.Description_2 Item, price Price, qty Qty, isSplit Split from wiz_cc_order_payment_split ps inner join StkItem s on ps.itemID = s.StockLink where ps.orderID = {_orderID}";

            existingSplitPaymentDetails = _commonFunctions.LoadDatatable(sql);
        }

        public void LoadSplitPaymentDetails()
        {
            CheckExistingSplits();

            columnsToDisplay = new string[] { "MemberID", "ItemID", "Item", "Price", "Qty", "Split" };
            columnsToHide = new string[] { "MemberID", "ItemID" };

            if (existingSplitPaymentDetails.Rows.Count > 0)
            {
                _commonFunctions.LoadDataGridFromDataTable(existingSplitPaymentDetails, dgvSplitPayments, columnsToDisplay, columnsToHide);
            } else
            {
                _commonFunctions.LoadDataGridFromDataTable(_splitPaymentDetails, dgvSplitPayments, columnsToDisplay, columnsToHide);

                // load list of itemDetails
                itemSplitDetails = new List<ItemSplitDetail> { };

                foreach (DataRow row in _splitPaymentDetails.Rows)
                {
                    ItemSplitDetail itemSplitDetail = new ItemSplitDetail();
                    itemSplitDetail.MemberID = Convert.ToInt32(row["MemberID"]);
                    itemSplitDetail.Member = row["Member"].ToString();
                    itemSplitDetail.ItemID = Convert.ToInt64(row["ItemID"]);
                    itemSplitDetail.Item = row["Item"].ToString();
                    itemSplitDetail.Price = Convert.ToDecimal(row["Price"]);
                    itemSplitDetail.OriginalQty = Convert.ToInt32(row["Qty"]);

                    itemSplitDetails.Add(itemSplitDetail);
                }
            }

        }

        public void LoadMembers()
        {
            sql = $"select g.guestID MemberID, c.Name Member, g.wipOrderID OrderID, CAST(0 As INT) SplitQty from wiz_cc_table_guests g inner join Client c on c.DCLink = g.guestID where g.orderID = {_orderID}";
            members = _commonFunctions.LoadDatatable(sql);

            columnsToDisplay = new string[] { "MemberID", "Member", "SplitQty", };
            columnsToHide = new string[] { "MemberID" };

            _commonFunctions.LoadDataGridFromDataTable(members, dgvMembers, columnsToDisplay, columnsToHide);
        }

        public void ReloadSplitPayments()
        {
            editedDetails = new DataTable();
            editedDetails.Columns.Add("MemberID", typeof(int));
            editedDetails.Columns.Add("Member", typeof(string));
            editedDetails.Columns.Add("ItemID", typeof(long));
            editedDetails.Columns.Add("Item", typeof(string));
            editedDetails.Columns.Add("Price", typeof(decimal));
            editedDetails.Columns.Add("Qty", typeof(int));
            editedDetails.Columns.Add("Split", typeof(bool));

            // Loop through the itemSplitDetails list and populate the DataTable
            foreach (var itemSplitDetail in itemSplitDetails)
            {
                bool hasSharedItemID = itemSplitDetails.Count(x => x.ItemID == itemSplitDetail.ItemID) > 1;

                DataRow newRow = editedDetails.NewRow();

                newRow["MemberID"] = itemSplitDetail.MemberID;
                newRow["Member"] = itemSplitDetail.Member;
                newRow["ItemID"] = itemSplitDetail.ItemID;
                newRow["Item"] = itemSplitDetail.Item;
                newRow["Price"] = itemSplitDetail.Price;
                newRow["Split"] = hasSharedItemID;
                newRow["Qty"] = itemSplitDetail.SplitQty == 0 ? itemSplitDetail.OriginalQty : itemSplitDetail.SplitQty;

                editedDetails.Rows.Add(newRow);
            }

            columnsToDisplay = new string[] { "MemberID", "ItemID", "Item", "Price", "Qty", "Split" };
            columnsToHide = new string[] { "MemberID", "ItemID" };

            _commonFunctions.LoadDataGridFromDataTable(editedDetails, dgvSplitPayments, columnsToDisplay, columnsToHide);
        }

        public void PostSplitPayments()
        {
            if (editedDetails.Rows.Count == 0)
            {
                var result = MessageBox.Show("No splits specified.", "INFORMATION", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }
            }

            foreach (DataRow detail in editedDetails.Rows)
            {
                long productID = Convert.ToInt64(detail["ItemID"]);
                int memberID = Convert.ToInt32(detail["MemberID"]);
                int qty = Convert.ToInt32(detail["Qty"]);
                decimal price = Convert.ToDecimal(detail["Price"]);
                decimal itemTotal = price * qty;
                decimal taxSC = itemTotal * Convert.ToDecimal(0.1);
                decimal taxCL = itemTotal * Convert.ToDecimal(0.02);
                decimal taxVAT = itemTotal * Convert.ToDecimal(0.16);
                bool isSplit = Convert.ToBoolean(detail["Price"]);

                //TODO: Fix discount in payments table
                // Insert to split payments table
                sql = $"INSERT INTO wiz_cc_order_payment_split (orderID, itemID, memberID, price, qty, itemTotal, discount, taxVAT, taxSC, taxCL, taxTotal, isSplit) VALUES ({_orderID}, {productID}, {memberID}, {price}, {qty}, {itemTotal}, {0}, {taxVAT}, {taxSC}, {taxCL}, {taxVAT + taxSC + taxCL}, '{isSplit}');";
                success = _commonFunctions.ExecuteScalarAndReturnBool(sql);
            }
        }

        private void dgvSplitPayments_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (loadComplete == false) { return; }

            if (e.RowIndex >= 0)
            {
                // Get the DataGridView and the current row
                DataGridView dgv = sender as DataGridView;
                DataGridViewRow currentRow = dgv.Rows[e.RowIndex];

                // clear adjusted details
                adjustedItemSplitDetails = new List<ItemSplitDetail> { };

                activeSplitItemID = Convert.ToInt64(currentRow.Cells["ItemID"].Value);
                string item = currentRow.Cells["Item"].Value.ToString();
                decimal price = Convert.ToDecimal(currentRow.Cells["Price"].Value);
                int originalQty = Convert.ToInt32(currentRow.Cells["Qty"].Value);

                // create item detail for each member
                foreach (DataRow member in members.Rows)
                {
                    ItemSplitDetail newSplitDetail = new ItemSplitDetail();
                    newSplitDetail.MemberID = Convert.ToInt32(member["MemberID"]);
                    newSplitDetail.Member = member["Member"].ToString();
                    newSplitDetail.ItemID = activeSplitItemID;
                    newSplitDetail.Item = item;
                    newSplitDetail.Price = price;
                    newSplitDetail.OriginalQty = originalQty;

                    adjustedItemSplitDetails.Add(newSplitDetail);
                }
            }
        }

        private void dgvMembers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMembers.Columns[e.ColumnIndex].Name == "SplitQty")
            {
                // Get the current row
                DataGridViewRow row = dgvMembers.Rows[e.RowIndex];

                if (row.Cells["MemberID"].Value != null)
                {
                    int memberId = Convert.ToInt32(row.Cells["MemberID"].Value);
                    int quantity = Convert.ToInt32(row.Cells["SplitQty"].Value);

                    ItemSplitDetail currentDetail = adjustedItemSplitDetails.FirstOrDefault(detail => detail.ItemID == activeSplitItemID && detail.MemberID == memberId);

                    if (currentDetail != null) 
                    { 
                        currentDetail.SplitQty = quantity;
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (adjustedItemSplitDetails.Count > 0)
            {
                long itemID = Convert.ToInt64(adjustedItemSplitDetails[0].ItemID);

                itemSplitDetails.RemoveAll(item => item.ItemID == itemID);

                foreach (var adjustedDetail in adjustedItemSplitDetails)
                {
                    // Add the adjusted detail into the original list after removal
                    itemSplitDetails.Add(adjustedDetail);
                }

                ReloadSplitPayments();
            }
        }

        private void mtProceedToPay_Click(object sender, EventArgs e)
        {
            PostSplitPayments();

            this.DialogResult = DialogResult.OK;
            this.Close();

            // open split payment form
            frmSplitPayment frmSplitPayment = new frmSplitPayment(_orderID);
            frmSplitPayment.Show();
        }
    }
}
