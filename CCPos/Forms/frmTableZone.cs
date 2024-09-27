using CCPos.Modules;
using MetroFramework.Forms;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CCPos.Forms
{
    public partial class frmTableZone : MetroForm
    {
        private string sql;
        private string buttonInfo;
        private bool success;
        private string tableID;
        private int intTableID;
        private int locationID;
        private int memberID;
        private int orderID;
        private int wipOrderID;
        private DataTable locations;
        private DataTable tables;
        private DataTable statusTypes;
        private CommonFunctions _commonFunctions;

        public frmTableZone()
        {
            InitializeComponent();

            // Set form border style to none
            this.FormBorderStyle = FormBorderStyle.None;

            // Set window state to maximized
            this.WindowState = FormWindowState.Maximized;

            // Set start position to manual and adjust size
            this.StartPosition = FormStartPosition.Manual;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            // Initialize Common Functions
            _commonFunctions = new CommonFunctions();

            LoadLocationButtons();
            CreateStatusKey();
        }

        // dynamically load location buttons
        public void LoadLocationButtons()
        {
            // Get the products from the database
            //sql = "select locID LocationID, locName LocationName from cc_locations;";
            sql = "select WhseLink LocationID, Code LocationCode, Name LocationName from WhseMst;";
            locations = _commonFunctions.LoadDatatable(sql);

            buttonInfo = "LocationName|LocationID|150|100|false";

            // Load buttons
            _commonFunctions.LoadDynamicButtons(locations, flpLocations, LocationButton_Click, buttonInfo);
        }

        public void LoadTableButtons()
        {
            // clear flp panel
            flpTables.Controls.Clear();

            sql = $"SELECT t.tableID AS TableID, t.tableName AS TableName, t.capacity AS Capacity, w.bookedCapacity WIPBookedCapacity, o.bookedCapacity BookedCapacity, w.customerID WIPCustomerID, o.customerID CustomerID, w.orderID WIPOrderID, w.orderStatus AS WIPOrderStatus, o.orderID OrderID, o.orderStatus AS OrderStatus, CASE WHEN w.orderStatus IS NOT NULL OR o.orderStatus IS NOT NULL THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END AS HasBookings FROM wiz_cc_tablemst t INNER JOIN WhseMst m ON t.locationID = m.WhseLink LEFT JOIN wiz_cc_wip_order w ON w.tableID = t.tableID AND w.orderStatus <> 'Paid' LEFT JOIN wiz_cc_order o ON o.tableID = t.tableID AND o.orderStatus <> 'Paid' WHERE m.WhseLink = {locationID};";

            tables = _commonFunctions.LoadDatatable(sql);

            int numberOfColumns = 4;  // Number of columns
            int panelWidth = (flpTables.Width / numberOfColumns) - 5;

            foreach (DataRow row in tables.Rows)
            {
                int tableID = Convert.ToInt32(row["TableID"]);
                string tableName = row["TableName"].ToString();
                int quantity = Convert.ToInt32(row["Capacity"]);
                int bookedCapacity = row["BookedCapacity"] == DBNull.Value ? 0 : Convert.ToInt32(row["BookedCapacity"]);
                int wipBookedCapacity = row["WIPBookedCapacity"] == DBNull.Value ? 0 : Convert.ToInt32(row["WIPBookedCapacity"]);
                string orderStatus = row["OrderStatus"] == DBNull.Value ? null : row["OrderStatus"].ToString();
                string wipOrderStatus = row["WIPOrderStatus"] == DBNull.Value ? null : row["WIPOrderStatus"].ToString();

                string finalStatus = !string.IsNullOrEmpty(orderStatus) ? orderStatus : wipOrderStatus;
                int finalBookedCapacity = bookedCapacity != 0 ? bookedCapacity : wipBookedCapacity;

                string tableDetailInfo = $"{tableID}-{tableName}";

                Panel newOrderItemPanel = CreateTablePanel(tableDetailInfo, panelWidth, tableName, quantity, finalBookedCapacity, finalStatus);

                flpTables.Controls.Add(newOrderItemPanel);
            }
        }

        private void LocationButton_Click(object sender, EventArgs e)
        {
            // Cast the sender to a Button
            Button clickedButton = sender as Button;

            // Retrieve ProductID from the button's Tag
            locationID = Convert.ToInt32(clickedButton.Tag);

            LoadTableButtons();
        }

        private void TableButton_Click(object sender, EventArgs e)
        {
            // Cast the sender to a Button
            Button clickedButton = sender as Button;

            // Retrieve ProductID from the button's Tag
            tableID = Convert.ToString(clickedButton.Tag);
            intTableID = Convert.ToInt32(tableID.Split('-')[0]);

            // Fetch table details from datatable
            DataRow tableDetails = tables.Select($"TableID = {intTableID}").FirstOrDefault();

            if (tableDetails != null && !tableDetails.IsNull("WIPOrderID")) 
            {
                wipOrderID = Convert.ToInt32(tableDetails["WIPOrderID"]);
                memberID = Convert.ToInt32(tableDetails["WIPCustomerID"]);
            }
            else if (tableDetails != null && !tableDetails.IsNull("OrderID"))
            {
                orderID = Convert.ToInt32(tableDetails["OrderID"]);
                memberID = Convert.ToInt32(tableDetails["CustomerID"]);
            }

            frmCustomerModal frmCustomerModal = new frmCustomerModal(intTableID, locationID, wipOrderID, orderID, memberID);
            frmCustomerModal.Show();
        }

        private void CreateStatusKey()
        {
            // Ensure the FlowLayoutPanel is correctly set up
            FlowLayoutPanel flowPanel = flpOrderKey; // Assuming flpOrderKey is already created and defined elsewhere

            // Configure the FlowLayoutPanel
            flowPanel.Dock = DockStyle.Right; // Dock to the right side of the GroupBox
            flowPanel.AutoSize = true;
            flowPanel.FlowDirection = FlowDirection.TopDown; // Arrange items vertically
            flowPanel.Padding = new Padding(5);
            flowPanel.WrapContents = false; // Ensure the panel does not wrap items

            // Add status panels to the FlowLayoutPanel
            flowPanel.Controls.Clear(); // Clear existing controls (optional)
            flowPanel.Controls.Add(CreateStatusPanel("Initiated", Color.LightGray, Color.Black));
            flowPanel.Controls.Add(CreateStatusPanel("Preparation", Color.Orange, Color.Black));
            flowPanel.Controls.Add(CreateStatusPanel("Ready", Color.Yellow, Color.Black));
            flowPanel.Controls.Add(CreateStatusPanel("Paid", Color.Green, Color.Black));
            flowPanel.Controls.Add(CreateStatusPanel("Reserved", Color.Beige, Color.Black));
            //flowPanel.Controls.Add(CreateStatusPanel("Complete", Color.MintCream, Color.Black));

            // Find the GroupBox control and add the FlowLayoutPanel to it
            GroupBox statusGroupBox = this.Controls.OfType<GroupBox>().FirstOrDefault(gb => gb.Name == "grpBxTableStatus");

            if (statusGroupBox != null)
            {
                statusGroupBox.Controls.Clear(); // Optional: Clear existing controls
                statusGroupBox.Controls.Add(flowPanel);
            }
            else
            {
                MessageBox.Show("GroupBox not found.");
            }
        }

        // Helper method to create a Panel and Label pair
        private Control CreateStatusPanel(string description, Color backColor, Color foreColor)
        {
            // Create a Panel for the color box
            Panel colorBox = new Panel
            {
                Size = new Size(50, 50),  // Adjust size as needed
                BackColor = backColor,
                Margin = new Padding(0, 0, 5, 0)  // Add space between the panel and label
            };

            // Create a Label for the description
            Label statusLabel = new Label
            {
                Text = description,
                ForeColor = foreColor,
                AutoSize = true,
                Padding = new Padding(5, 2, 5, 2)
            };

            // Create a FlowLayoutPanel to hold the Panel and Label
            FlowLayoutPanel statusPanel = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown, // Arrange items horizontally within the status panel
                Margin = new Padding(5)
            };

            statusPanel.Controls.Add(colorBox);
            statusPanel.Controls.Add(statusLabel);

            return statusPanel;
        }

        private void mtDashboardMenu_Click(object sender, EventArgs e)
        {
            frmDashboard frmDashboard = new frmDashboard();
            frmDashboard.Show();
        }


        private Panel CreateTablePanel(string tableDetailInfo, int panelWidth, string tableName, int quantity, int bookedQuantity, string orderStatus)
        {
            Panel panelOrderItem = new Panel();
            panelOrderItem.Location = new Point(0, 0);
            panelOrderItem.Size = new Size(panelWidth, 280);  // Size of the panel
            panelOrderItem.BackColor = Color.LightSkyBlue;

            // Create the panel that holds the image
            Panel panelImage = new Panel();
            panelImage.Dock = DockStyle.Top;
            panelImage.Size = new Size(panelWidth, 100);  // Adjust the height to fit the image better
            panelImage.BackColor = Color.FloralWhite;

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
            label1.Text = "Seats:";
            panelOrderItem.Controls.Add(label1);

            // Create and add TextBox for the product name
            TextBox textBox1 = new TextBox();
            textBox1.Location = new Point(100, startingY + verticalSpacing - 3);
            textBox1.Size = new Size(textBoxWidth, 25);
            textBox1.Text = quantity.ToString();
            textBox1.ReadOnly = true;
            panelOrderItem.Controls.Add(textBox1);

            // Create and add label for the quantity
            Label label2 = new Label();
            label2.AutoSize = true;
            label2.Location = new Point(18, startingY + verticalSpacing * 2);
            label2.Text = "Booked:";
            panelOrderItem.Controls.Add(label2);

            // Create and add TextBox for the quantity
            TextBox textBox2 = new TextBox();
            textBox2.Location = new Point(100, startingY + verticalSpacing * 2 - 3);
            textBox2.Size = new Size(textBoxWidth, 25);
            textBox2.Text = bookedQuantity.ToString();
            textBox2.ReadOnly = true;
            panelOrderItem.Controls.Add(textBox2);


            // --- Add a regular Button at the bottom ---
            Button buttonComplete = new Button();
            buttonComplete.Tag = tableDetailInfo;
            buttonComplete.Text = "Book";
            buttonComplete.Dock = DockStyle.Bottom;
            buttonComplete.TextAlign = ContentAlignment.MiddleCenter;
            buttonComplete.BackColor = Color.Green;
            buttonComplete.Size = new Size(panelWidth, 60);

            // Add a click event for completing the order
            buttonComplete.Click += TableButton_Click;

            panelOrderItem.Controls.Add(buttonComplete);  // Add the button to the panel

            switch (orderStatus)
            {
                case "Initiated":
                    panelOrderItem.BackColor = Color.LightGray;  // Color for 'Initiated'
                    panelOrderItem.ForeColor = Color.White;
                    break;
                case "Preparation":
                    panelOrderItem.BackColor = Color.Orange;  // Color for 'Preparation'
                    panelOrderItem.ForeColor = Color.White;
                    break;
                case "Ready":
                    panelOrderItem.BackColor = Color.Yellow;  // Color for 'Ready'
                    panelOrderItem.ForeColor = Color.Black;
                    break;
                case "Reserved":
                    panelOrderItem.BackColor = Color.Beige;  // Color for 'Reserved'
                    panelOrderItem.ForeColor = Color.Black;
                    break;
                case "Paid":
                    panelOrderItem.BackColor = Color.Green;  // Color for 'Paid'
                    panelOrderItem.ForeColor = Color.White;
                    break;
                default:
                    panelOrderItem.BackColor = Color.Pink;  // Default color for unknown status
                    panelOrderItem.ForeColor = Color.Black;
                    break;
            }

            return panelOrderItem;
        }
    }
}
