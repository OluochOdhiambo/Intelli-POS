using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCPos.Classes;
using CCPos.Modules;
using MetroFramework.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CCPos.Forms
{
    public partial class frmEventsScreen : MetroForm
    {
        CommonFunctions _commonFunctions;

        private bool loadComplete = false;
        private int currentBookingID;
        private string sql;
        private bool success;
        private DataTable bookings;
        private DataTable kitchenOrders;
        private List<BookingDetail> bookingDetails;

        public frmEventsScreen()
        {
            loadComplete = false;

            InitializeComponent();
            InitializeForm();

            loadComplete = true;
        }

        private void InitializeForm()
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

            LoadBookings();
        }

        private void LoadBookings()
        {
            sql = "select DISTINCT m.BookingID, 'BR/' + FORMAT(m.BookingID, '00000') AS BookingRef from wiz_cc_Bookings b inner join wiz_cc_BookingMenu m on b.SNo = m.BookingID inner join StkItem s on s.StockLink = m.ItemID where b.BookingConfirmed = 1 and m.isComplete = 0;";
            _commonFunctions.LoadComboBox(sql, cboBookingRef, "BookingID", "BookingRef");
        }

        private Panel CreateOrderItemPanel(string orderDetailInfo, int panelWidth, string tableName, string productName, int quantity, int servedQty, DateTime orderTime, byte[] imageData)
        {
            Panel panelOrderItem = new Panel();
            panelOrderItem.Location = new Point(0, 0);
            panelOrderItem.Size = new Size(panelWidth, 340);  // Size of the panel
            panelOrderItem.BackColor = Color.LightSkyBlue;

            // Create the panel that holds the image
            Panel panelImage = new Panel();
            panelImage.Dock = DockStyle.Top;
            panelImage.Size = new Size(panelWidth, 100);  // Adjust the height to fit the image better
            panelImage.BackColor = Color.FloralWhite;

            // If image data is available, add a PictureBox to the image panel
            if (imageData != null && imageData.Length > 0)
            {
                PictureBox pictureBox = new PictureBox();
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    pictureBox.Image = Image.FromStream(ms);  // Convert binary data to image
                    pictureBox.Size = new Size(100, 100);  // Set size for the image
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;  // Adjust image scaling
                }

                // Center the PictureBox in the panel
                pictureBox.Location = new Point((panelImage.Width - pictureBox.Width) / 2, (panelImage.Height - pictureBox.Height) / 2);
                panelImage.Controls.Add(pictureBox);
            }
            panelOrderItem.Controls.Add(panelImage);

            // Adjust the labels and textboxes to fit below the image
            int labelWidth = 80;
            int textBoxWidth = 140;
            int verticalSpacing = 30;  // Vertical spacing between controls
            int startingY = panelImage.Height + 10;  // Start below the image panel

            // Create and add label for the table name
            Label label4 = new Label();
            label4.AutoSize = true;
            label4.Location = new Point(18, startingY);
            label4.Text = "REF:";
            panelOrderItem.Controls.Add(label4);

            // Create and add TextBox for the table name
            TextBox textBox4 = new TextBox();
            textBox4.Location = new Point(100, startingY - 3);
            textBox4.Size = new Size(textBoxWidth, 25);
            textBox4.Text = tableName;
            textBox4.ReadOnly = true;
            panelOrderItem.Controls.Add(textBox4);

            // Create and add label for the product name
            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new Point(18, startingY + verticalSpacing);
            label1.Text = "Item:";
            panelOrderItem.Controls.Add(label1);

            // Create and add TextBox for the product name
            TextBox textBox1 = new TextBox();
            textBox1.Location = new Point(100, startingY + verticalSpacing - 3);
            textBox1.Size = new Size(textBoxWidth, 25);
            textBox1.Text = productName;
            textBox1.ReadOnly = true;
            panelOrderItem.Controls.Add(textBox1);

            // Create and add label for the quantity
            Label label2 = new Label();
            label2.AutoSize = true;
            label2.Location = new Point(18, startingY + verticalSpacing * 2);
            label2.Text = "Ordered:";
            panelOrderItem.Controls.Add(label2);

            // Create and add TextBox for the quantity
            TextBox textBox2 = new TextBox();
            textBox2.Location = new Point(100, startingY + verticalSpacing * 2 - 3);
            textBox2.Size = new Size(textBoxWidth, 25);
            textBox2.Text = quantity.ToString();
            textBox2.Name = $"tbOrderedQty_{orderDetailInfo}";
            textBox2.ReadOnly = true;
            panelOrderItem.Controls.Add(textBox2);

            // Create and add label for the served quantity (correct variable name)
            Label label5 = new Label();
            label5.AutoSize = true;
            label5.Location = new Point(18, startingY + verticalSpacing * 3);
            label5.Text = "Served:";
            panelOrderItem.Controls.Add(label5);

            // Create and add TextBox for the served quantity (correct variable name and control)
            TextBox textBox5 = new TextBox();
            textBox5.Location = new Point(100, startingY + verticalSpacing * 3 - 3);
            textBox5.Size = new Size(textBoxWidth, 25);
            textBox5.Text = servedQty.ToString();
            textBox5.Name = $"tbServedQty_{orderDetailInfo}";
            textBox5.ReadOnly = true;
            panelOrderItem.Controls.Add(textBox5);

            // Create and add label for the order time
            Label label3 = new Label();
            label3.AutoSize = true;
            label3.Location = new Point(18, startingY + verticalSpacing * 4);
            label3.Text = "Time:";
            panelOrderItem.Controls.Add(label3);

            // Create and add TextBox for the order time
            TextBox textBox3 = new TextBox();
            textBox3.Location = new Point(100, startingY + verticalSpacing * 4 - 3);
            textBox3.Size = new Size(textBoxWidth, 25);
            textBox3.Text = orderTime.ToString("HH:mm:ss");
            textBox3.ReadOnly = true;
            panelOrderItem.Controls.Add(textBox3);

            // Create and add label for the order time
            Label label6 = new Label();
            label6.AutoSize = true;
            label6.Location = new Point(18, startingY + verticalSpacing * 5);
            label6.Text = "Serve:";
            panelOrderItem.Controls.Add(label6);

            // Create and add TextBox for the order time
            TextBox tbFireQty = new TextBox();
            tbFireQty.Location = new Point(100, startingY + verticalSpacing * 5 - 3);
            tbFireQty.Size = new Size(textBoxWidth, 25);
            tbFireQty.Name = $"tbFireQty_{orderDetailInfo}";
            tbFireQty.ReadOnly = false;
            panelOrderItem.Controls.Add(tbFireQty);

            // --- Add a regular Button at the bottom ---
            Button buttonUpdate = new Button();
            buttonUpdate.Tag = orderDetailInfo;
            buttonUpdate.Text = "Fire";
            buttonUpdate.TextAlign = ContentAlignment.MiddleCenter;
            buttonUpdate.BackColor = Color.Green;
            buttonUpdate.Dock = DockStyle.Bottom;
            buttonUpdate.Size = new Size(panelWidth, 50);

            // Add a click event for completing the order
            buttonUpdate.Click += KitchenOrderUpdate_Click;

            // Finally, add the FlowLayoutPanel to the main panel
            panelOrderItem.Controls.Add(buttonUpdate);


            return panelOrderItem;
        }

        private void KitchenOrderUpdate_Click(object sender, EventArgs e)
        {
            Button updateButton = sender as Button;
            if (updateButton != null && updateButton.Tag != null)
            {
                string bookingAndDetailId = updateButton.Tag.ToString();
                int bookingId = Convert.ToInt32(bookingAndDetailId.Split('-')[0]);
                int detailId = Convert.ToInt32(bookingAndDetailId.Split('-')[1]);

                DataRow selectedOrderDetail = kitchenOrders.Select($"DetailSNo = {detailId}").FirstOrDefault();

                // Find the parent panel that contains the TextBox for served quantity
                Panel parentPanel = updateButton.Parent.Parent as Panel;

                // Find the TextBox for served quantity using its unique name
                TextBox tbFireQty = parentPanel.Controls.Find("tbFireQty_" + bookingAndDetailId, true).FirstOrDefault() as TextBox;
                TextBox tbOrderedQty = parentPanel.Controls.Find("tbOrderedQty_" + bookingAndDetailId, true).FirstOrDefault() as TextBox;
                TextBox tbServedQty = parentPanel.Controls.Find("tbServedQty_" + bookingAndDetailId, true).FirstOrDefault() as TextBox;

                if (tbFireQty == null)
                {
                    MessageBox.Show("Served quantity TextBox not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Parse the served quantity from the TextBox
                int servedQty;
                int orderedQty;
                int firedQty;
                if (!int.TryParse(tbFireQty.Text, out firedQty))
                {
                    MessageBox.Show("Please enter current quantity being fired.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(tbOrderedQty.Text, out orderedQty))
                {
                    MessageBox.Show("Please enter current quantity being fired.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(tbServedQty.Text, out servedQty))
                {
                    MessageBox.Show("Please enter current quantity being fired.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ProcessOrdersWithTransaction(servedQty, orderedQty, firedQty, detailId);

                // refresh orders and combo box
                LoadBookings();
                LoadKitchenOrders();
            }
        }

        private void ProcessOrdersWithTransaction(int servedQty, int orderedQty, int firedQty, int detailId)
        {
            // Start a transaction
            using (SqlConnection conn = new SqlConnection(_commonFunctions.GetConnectionString()))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Clear orders from the kitchen screen
                    FireOrders(servedQty, orderedQty, firedQty, detailId, transaction);

                    // Request permission approval
                    frmPermission frmPermission = new frmPermission();

                    if (frmPermission.ShowDialog() != DialogResult.OK)
                    {
                        MessageBox.Show("Order approval failed.", "APPROVAL DENIED", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        throw new Exception("Permission denied.");
                    }

                    // Commit transaction if all succeeded
                    transaction.Commit();
                    MessageBox.Show("Order processed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Rollback transaction in case of an error
                    transaction.Rollback();
                    MessageBox.Show($"Transaction failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void FireOrders(int servedQty, int orderedQty, int firedQty, int detailId, SqlTransaction transaction)
        {
            // reset success to false;
            success = false;

            if (servedQty == orderedQty)
            {
                DialogResult result = MessageBox.Show("Limit reached for servings. Order will be automatically completed.", "INFORMATION", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    sql = $"UPDATE wiz_cc_BookingMenu SET isComplete = 1 WHERE SNo = {detailId}";
                    success = _commonFunctions.ExecuteScalarWithTransaction(sql, transaction);
                }
            }
            else if ((servedQty + firedQty) > orderedQty)
            {
                int allowedQty = orderedQty - servedQty;
                DialogResult result = MessageBox.Show($"Fired items exceed the pending item balance. Only {allowedQty} items allowed to fire.", "INFORMATION", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    sql = $"UPDATE wiz_cc_BookingMenu SET servedQty = {servedQty + allowedQty}, isComplete = 1 WHERE SNo = {detailId}";
                    success = _commonFunctions.ExecuteScalarWithTransaction(sql, transaction);
                }
            }
            else if ((servedQty + firedQty) == orderedQty)
            {
                sql = $"UPDATE wiz_cc_BookingMenu SET servedQty = {servedQty + firedQty}, isComplete = 1 WHERE SNo = {detailId}";
                success = _commonFunctions.ExecuteScalarWithTransaction(sql, transaction);
            }
            else if ((servedQty + firedQty) < orderedQty)
            {
                sql = $"UPDATE wiz_cc_BookingMenu SET servedQty = {servedQty + firedQty} WHERE SNo = {detailId}";
                success = _commonFunctions.ExecuteScalarWithTransaction(sql, transaction);
            }

            // inform user of post status
            if (success)
            {
                MessageBox.Show("Booking updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Booking failed to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void LoadKitchenOrders()
        {
            // TODO: Add filter for exact logged in location
            sql = $"select m.Sno DetailSNo, m.BookingID, 'BR/' + FORMAT(m.BookingID, '00000') AS BookingRef, m.ItemID, s.Description_2 Item, Qty, ServedQty, UnitPrice, TotalPrice, i.imagename Image, b.BookingDate, m.ServingTime from wiz_cc_Bookings b inner join wiz_cc_BookingMenu m on b.SNo = m.BookingID inner join StkItem s on s.StockLink = m.ItemID left join wiz_cc_stkitem_info i on i.stocklink = s.StockLink where b.BookingConfirmed = 1 and m.isComplete = 0 and m.BookingID = {currentBookingID};";
            kitchenOrders = _commonFunctions.LoadDatatable(sql);

            mainFlpPanel.Controls.Clear();

            int numberOfColumns = 5;  // Number of columns
            int panelWidth = (mainFlpPanel.Width / numberOfColumns) - 10;

            foreach (DataRow row in kitchenOrders.Rows)
            {
                int bookingID = Convert.ToInt32(row["BookingID"]);
                int detailId = Convert.ToInt32(row["DetailSNo"]);
                string bookingRef = row["BookingRef"].ToString();
                TimeSpan servingTime = (TimeSpan)row["ServingTime"];
                DateTime bookingDate = Convert.ToDateTime(row["BookingDate"]);
                long productId = Convert.ToInt64(row["ItemID"]);
                string productName = row["Item"].ToString();
                int quantity = Convert.ToInt32(row["Qty"]);
                int servedQty = Convert.ToInt32(row["ServedQty"]);
                byte[] imageData = row["Image"] as byte[];  // Get image data

                string orderDetailInfo = $"{bookingID}-{detailId}-{bookingRef}";

                // Create a new order item panel with the image and other details
                Panel newOrderItemPanel = CreateOrderItemPanel(orderDetailInfo, panelWidth, bookingRef, productName, quantity, servedQty, bookingDate, imageData);

                mainFlpPanel.Controls.Add(newOrderItemPanel);
            }
        }

        private void cboBookingRef_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBookingRef.SelectedIndex == -1 || loadComplete == false) 
            { 
                return; 
            }
            else 
            { 
               currentBookingID = Convert.ToInt32(cboBookingRef.SelectedValue);

                LoadKitchenOrders();
            }
        }
    }    
}
