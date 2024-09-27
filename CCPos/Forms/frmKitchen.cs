using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCPos.Modules;
using MetroFramework.Forms;
using MetroFramework.Controls;

namespace CCPos.Forms
{
    public partial class frmKitchen : MetroForm
    {
        private CommonFunctions _commonFunctions;

        private string sql;
        private bool success;

        private DataTable kitchenOrders;

        public frmKitchen()
        {
            InitializeComponent();
            InitializeForm();
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

            LoadKitchenOrders();
        }

        private Panel CreateOrderItemPanel(string orderDetailInfo, int panelWidth, string tableName,string productName, int quantity, DateTime orderTime, byte[] imageData)
        {
            Panel panelOrderItem = new Panel();
            panelOrderItem.Location = new Point(0,0);
            panelOrderItem.Size = new Size(panelWidth, 340);  // Size of the panel
            panelOrderItem.BackColor = Color.LightSkyBlue;

            // Create the panel that holds the image
            Panel panelImage = new Panel();
            panelImage.Dock = DockStyle.Top;
            panelImage.Size = new Size(panelWidth, 120);  // Adjust the height to fit the image better
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
            int verticalSpacing = 40;  // Vertical spacing between controls
            int startingY = panelImage.Height + 10;  // Start below the image panel

            // Create and add label for the table name
            Label label4 = new Label();
            label4.AutoSize = true;
            label4.Location = new Point(18, startingY);
            label4.Text = "Table:";
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
            label2.Text = "Qty.:";
            panelOrderItem.Controls.Add(label2);

            // Create and add TextBox for the quantity
            TextBox textBox2 = new TextBox();
            textBox2.Location = new Point(100, startingY + verticalSpacing * 2 - 3);
            textBox2.Size = new Size(textBoxWidth, 25);
            textBox2.Text = quantity.ToString();
            textBox2.ReadOnly = true;
            panelOrderItem.Controls.Add(textBox2);

            // Create and add label for the order time
            Label label3 = new Label();
            label3.AutoSize = true;
            label3.Location = new Point(18, startingY + verticalSpacing * 3);
            label3.Text = "Time:";
            panelOrderItem.Controls.Add(label3);

            // Create and add TextBox for the order time
            TextBox textBox3 = new TextBox();
            textBox3.Location = new Point(100, startingY + verticalSpacing * 3 - 3);
            textBox3.Size = new Size(textBoxWidth, 25);
            textBox3.Text = orderTime.ToString("HH:mm:ss");
            textBox3.ReadOnly = true;
            panelOrderItem.Controls.Add(textBox3);

            // --- Add a regular Button at the bottom ---
            Button buttonComplete = new Button();
            buttonComplete.Tag = orderDetailInfo;
            buttonComplete.Text = "Complete";
            buttonComplete.Dock = DockStyle.Bottom;
            buttonComplete.TextAlign = ContentAlignment.MiddleCenter;
            buttonComplete.BackColor = Color.Green;
            buttonComplete.Size = new Size(panelWidth, 60);

            // Add a click event for completing the order
            buttonComplete.Click += KitchenOrder_Click;

            panelOrderItem.Controls.Add(buttonComplete);  // Add the button to the panel

            return panelOrderItem;
        }

        // Complete kitchen order
        private void KitchenOrder_Click(object sender, EventArgs e)
        {
            // Retrieve the product name from the button's Tag property
            Button clickedButton = sender as Button;
            if (clickedButton != null && clickedButton.Tag != null)
            {
                string orderAndDetailId = clickedButton.Tag.ToString();
                int orderId = Convert.ToInt32(orderAndDetailId.Split('-')[0]);
                int detailId = Convert.ToInt32(orderAndDetailId.Split('-')[1]);

                DataRow selectedOrderDetail = kitchenOrders.Select($"DetailID = {detailId}").FirstOrDefault();

                // request permission approval
                frmPermission frmPermission = new frmPermission();
                
                if (frmPermission.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show($"Order approval failed.", "APPROVAL DENIED", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                // update item ready status
                sql = $"UPDATE wiz_cc_order_details SET isReady = 1 WHERE odID = {detailId}";
                success = _commonFunctions.ExecuteScalarAndReturnBool(sql);

                if (success) {
                    MessageBox.Show($"Order for {selectedOrderDetail["ProductName"]} is ready.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show($"An error occurred.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow[] allOrderDetails = kitchenOrders.Select($"OrderID = {orderId}");

                // check all order items in order are ready
                bool allReady = allOrderDetails.All(row => Convert.ToBoolean(row["IsReady"]));

                if (allReady)
                {
                    sql = $"UPDATE wiz_cc_order SET orderStatus = 'Ready' WHERE orderID = {orderId};";
                    success = _commonFunctions.ExecuteScalarAndReturnBool(sql);

                    if (success)
                    {
                        MessageBox.Show($"Order for {selectedOrderDetail["TableName"]} is complete.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"An error occurred.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // reload kitchen orders
                LoadKitchenOrders();
            }
        }

        // Load order items
        private void LoadKitchenOrders()
        {
            // TODO: Add filter for exact logged in location
            sql = $"select o.orderID OrderID, d.odID DetailID, o.orderTime OrderTime, d.itemID ProductID, s.Description_1 ProductName, d.qty Quantity, d.isReady IsReady, t.tableName TableName, w.Name LocationName, i.imagename Image from wiz_cc_order o inner join wiz_cc_order_details d on o.orderID = d.orderID inner join StkItem s on s.StockLink = d.itemID inner join wiz_cc_tablemst t on t.tableID = o.tableID inner join WhseMst w on w.WhseLink = t.locationID left join wiz_cc_stkitem_info i on i.stocklink = s.StockLink where o.orderStatus = 'Preparation' and w.WhseLink in (3,4,5,6,7,8) and d.isReady = 0 order by o.orderTime asc;";
            kitchenOrders = _commonFunctions.LoadDatatable(sql);

            mainFlpPanel.Controls.Clear();

            int numberOfColumns = 5;  // Number of columns
            int panelWidth = (mainFlpPanel.Width / numberOfColumns) - 10;

            foreach (DataRow row in kitchenOrders.Rows)
            {
                int orderId = Convert.ToInt32(row["OrderID"]);
                int detailId = Convert.ToInt32(row["DetailID"]);
                string tableName = row["TableName"].ToString();
                DateTime orderTime = Convert.ToDateTime(row["OrderTime"]);
                long productId = Convert.ToInt64(row["ProductID"]);
                string productName = row["ProductName"].ToString();
                int quantity = Convert.ToInt32(row["Quantity"]);
                byte[] imageData = row["Image"] as byte[];  // Get image data

                string orderDetailInfo = $"{orderId}-{detailId}-{tableName}";

                // Create a new order item panel with the image and other details
                Panel newOrderItemPanel = CreateOrderItemPanel(orderDetailInfo, panelWidth, tableName, productName, quantity, orderTime, imageData);

                mainFlpPanel.Controls.Add(newOrderItemPanel);
            }
        }

        private void mtKitchen_Click(object sender, EventArgs e)
        {
            frmKitchen frmKitchen = new frmKitchen();
            frmKitchen.Show();

            // Close current form
            this.Close();
        }

        private void mtTables_Click(object sender, EventArgs e)
        {
            frmTableZone frmTableZone = new frmTableZone();
            frmTableZone.Show();

            // Close current form
            this.Close();
        }

        private void mtDashboardMenu_Click(object sender, EventArgs e)
        {
            frmDashboard frmDashboard = new frmDashboard();
            frmDashboard.Show();
        }
    }
}
