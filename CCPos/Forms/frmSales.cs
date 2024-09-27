using CCPos.Forms;
using CCPos.Modules;
using MetroFramework.Forms;
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

namespace CCPos
{
    public partial class frmSales : MetroForm
    {
        private int _wipOrderID;
        private int _branchTableID;
        private int _locationID;
        private int _customerID;
        private int _orderID;

        private string sql;
        private string buttonInfo;
        private bool success;
        private int mainorderID;
        private string[] columnsToDisplay;
        private string[] columnsToHide;

        private DataTable products;
        private DataTable filteredProducts;
        private DataTable tables;
        private DataTable categories;
        private DataTable orderDetails;
        private DataTable selectedCustomer;
        private CommonFunctions _commonFunctions;

        private int course = 0;
        private decimal total = 0m;
        private decimal subtotal = 0m;
        private decimal discount = 0m;
        private decimal vat = 0m;
        private decimal serviceCharge = 0m;
        private decimal cateringLevy = 0m;
        private decimal totalPayable = 0m;

        // Constructor with parameters
        public frmSales(int branchTableID, int locationID, int customerID, int wipOrderID, int orderID)
        {
            InitializeComponent();
            InitializeForm(branchTableID, locationID, customerID, wipOrderID, orderID);

            StyleButtons();
        }

        // Constructor without parameters
        public frmSales() : this(0, 0, 0, 0, 0)
        {
        }

        private void InitializeForm(int tableID, int locationID, int customerID, int wipOrderID, int orderID)
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

            // Initialize the orderdetails DataTable with columns
            orderDetails = new DataTable();
            orderDetails.Columns.Add("ProductID", typeof(long));
            orderDetails.Columns.Add("Item", typeof(string));
            orderDetails.Columns.Add("CategoryID", typeof(int));
            orderDetails.Columns.Add("CategoryName", typeof(string));
            orderDetails.Columns.Add("Price", typeof(decimal));
            orderDetails.Columns.Add("Qty", typeof(int));
            orderDetails.Columns.Add("Discount", typeof(decimal));
            orderDetails.Columns.Add("Taxable", typeof(bool));
            orderDetails.Columns.Add("VAT", typeof(decimal));
            orderDetails.Columns.Add("ServiceCharge", typeof(decimal));
            orderDetails.Columns.Add("CateringLevy", typeof(decimal));
            orderDetails.Columns.Add("ItemTotal", typeof(decimal));
            orderDetails.Columns.Add("TaxTotal", typeof(decimal));
            orderDetails.Columns.Add("isVoid", typeof(bool));
            orderDetails.Columns.Add("Course", typeof(bool));

            filteredProducts = new DataTable();
            filteredProducts.Columns.Add("ProductID", typeof(long));
            filteredProducts.Columns.Add("Item", typeof(string));
            filteredProducts.Columns.Add("CategoryID", typeof(string));
            filteredProducts.Columns.Add("CategoryName", typeof(string));
            filteredProducts.Columns.Add("Price", typeof(decimal));
            filteredProducts.Columns.Add("Qty", typeof(int));
            filteredProducts.Columns.Add("Discount", typeof(decimal));
            filteredProducts.Columns.Add("Taxable", typeof(bool));
            filteredProducts.Columns.Add("Image", typeof(byte[]));

            // Store the tableID and locationID for use in the form
            _branchTableID = tableID;
            _locationID = locationID;
            _customerID = customerID;
            _wipOrderID = wipOrderID;
            _orderID = orderID;

            // Set customer, agent name, and table
            FetchTableDetails();
            FetchCustomerDetails();

            LoadProductButtons();
            LoadCategoryButtons();

            LoadExistingOrderDetails();

        }

        private void StyleButtons()
        {
            mtBook.CustomBackground = true;
            mtPayment.CustomBackground = true;
            mtVoid.CustomBackground = true;
            mtBook.CustomForeColor = true;
            mtPayment.CustomForeColor = true;
            mtVoid.CustomForeColor = true;

            mtBook.BackColor = Color.Green;
            mtPayment.BackColor = Color.Blue;
            mtVoid.BackColor = Color.OrangeRed;
            mtBook.ForeColor = Color.White;
            mtPayment.ForeColor = Color.White;
            mtVoid.ForeColor = Color.White;
        }

        public void LoadExistingOrderDetails()
        {
            if (_orderID != 0)
            {
                sql = $"select o.orderID OrderID, o.customerID CustomerID, o.tableID TableID, d.itemID ProductID, p.Description_2 Item, d.price Price, d.qty Qty, d.discount Discount, CAST(1 AS INT) Taxable, d.taxVAT VAT, d.taxSC ServiceCharge, d.taxCL CateringLevy, d.itemTotal ItemTotal, d.taxTotal TaxTotal, d.isVoid, ISNULL(d.course, 0) Course, d.hasModifier M, d.hasAddOn A, d.hasInstruction I from wiz_cc_order o inner join wiz_cc_order_details d on o.orderID = d.orderID inner join StkItem p on p.StockLink = d.itemID where o.orderID = {_orderID} order by d.course;";
            }
            else if (_wipOrderID != 0)
            {
                sql = $"select o.orderID OrderID, o.customerID CustomerID, o.tableID TableID, d.itemID ProductID, p.Description_2 Item, d.price Price, d.qty Qty, d.discount Discount, CAST(1 AS INT) Taxable, d.taxVAT VAT, d.taxSC ServiceCharge, d.taxCL CateringLevy, d.itemTotal ItemTotal, d.taxTotal TaxTotal, d.isVoid, ISNULL(d.course, 0) Course, d.hasModifier M, d.hasAddOn A, d.hasInstruction I from wiz_cc_wip_order o inner join wiz_cc_wip_order_details d on o.orderID = d.orderID inner join StkItem p on p.StockLink = d.itemID where o.orderID = {_wipOrderID} order by d.course;";
            }

            orderDetails = _commonFunctions.LoadDatatable(sql);

            // check if details have courses
            DataRow[] foundRows = orderDetails.Select("Course > 0");

            // Ensure there are multiple rows to process
            if (foundRows.Length > 1)
            {
                int lastCourse = -1;

                for (int i = 0; i < foundRows.Length; i++)
                {
                    // Get the current course value
                    int currentCourse = Convert.ToInt16(foundRows[i]["Course"]);

                    // Check if it's a new course (different from the last one)
                    if (currentCourse != lastCourse)
                    {
                        lastCourse = currentCourse;

                        // Create a new row for the course header
                        DataRow newCourseRow = orderDetails.NewRow();
                        newCourseRow["Item"] = $"Course {currentCourse}";
                        newCourseRow["Course"] = currentCourse;

                        // Insert the new row at the correct index
                        int rowIndexToInsert;

                        if (i == 0)
                        {
                            rowIndexToInsert = 0;
                        }
                        else
                        {
                            rowIndexToInsert = orderDetails.Rows.IndexOf(foundRows[i]);
                        }

                        orderDetails.Rows.InsertAt(newCourseRow, rowIndexToInsert);
                    }
                }
            }
            /////////////////////////////

            columnsToDisplay = new string[] { "ProductID", "Item", "Price", "Qty", "M", "A", "I" };
            columnsToHide = new string[] { "ProductID" };

            _commonFunctions.LoadDataGridFromDataTable(orderDetails, dgvOrdersItems, columnsToDisplay, columnsToHide);

            dgvOrdersItems.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOrdersItems.Columns["Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            decimal tax = 0m;

            if (orderDetails.Rows.Count == 0 ) { return; }

            // load text box fields
            total = Convert.ToDecimal(orderDetails.Compute("SUM(ItemTotal)", string.Empty));
            discount = Convert.ToDecimal(orderDetails.Compute("SUM(Discount)", string.Empty));
            subtotal = total - discount;
            vat = Convert.ToDecimal(orderDetails.Compute("SUM(VAT)", string.Empty));
            serviceCharge = Convert.ToDecimal(orderDetails.Compute("SUM(ServiceCharge)", string.Empty));
            cateringLevy = Convert.ToDecimal(orderDetails.Compute("SUM(CateringLevy)", string.Empty));
            tax = vat + cateringLevy + serviceCharge;
            totalPayable = (Math.Ceiling(subtotal * 100) / 100) + (Math.Ceiling(tax * 100) / 100);

            tbTotal.Text = (Math.Ceiling(total * 100) / 100).ToString();
            tbDiscount.Text = (Math.Ceiling(discount * 100) / 100).ToString();
            tbSubTotal.Text = (Math.Ceiling(total * 100) / 100).ToString();
        }

        public void FetchTableDetails()
        {
            //sql = $"SELECT CONCAT(t.id, '-', ta.id) UniqueTableID, t.id TableID, t.tablename TableName, t.seatqty Capacity, ta.id LocationID, ta.branchname LocationName , ta.imagename Image FROM tbl_tablezone t CROSS JOIN tbl_terminallocation ta where ta.id = {_locationID} and t.id = {_branchTableID};";
            if (_wipOrderID == 0)
            {
                sql = $"select t.tableID TableID, t.tableName TableName, w.Name LocationName, o.bookedCapacity, t.imageName Image from wiz_cc_tablemst t inner join wiz_cc_order o on o.tableID = t.tableID inner join WhseMst w on w.WhseLink = t.locationID where o.orderID = {_orderID}";
            }
            else if (_orderID == 0)
            {
                sql = $"select t.tableID TableID, t.tableName TableName, w.Name LocationName, o.bookedCapacity, t.imageName Image from wiz_cc_tablemst t inner join wiz_cc_wip_order o on o.tableID = t.tableID inner join WhseMst w on w.WhseLink = t.locationID where o.orderID = {_wipOrderID}";
            }
            tables = _commonFunctions.LoadDatatable(sql);

            if (tables != null & _locationID != 0)
            {
                string tableName = tables.Rows[0]["TableName"].ToString();
                string locationName = tables.Rows[0]["LocationName"].ToString();

                //tbTableName.Text = tableName;
            }
        }

        public void FetchCustomerDetails()
        {
            if (_customerID != 0)
            {
                //sql = $"select id MemberID, Name, memberNo MemberNo from tbl_customer c where c.id = {_customerID};";
                sql = $"select c.DCLink MemberID, c.Name Name, c.Account MemberNo from Client c where c.DCLink = {_customerID};";
                selectedCustomer = _commonFunctions.LoadDatatable(sql);

                if (selectedCustomer != null)
                {
                    string customerName = selectedCustomer.Rows[0]["Name"].ToString();
                    string memberNo = selectedCustomer.Rows[0]["MemberNo"].ToString();

                    tbCustomerName.Text = customerName;
                    tbMemberNo.Text = memberNo;
                }
            }
        }


        // Method to dynamically load buttons
        public void LoadProductButtons()
        {
            // Get the products from the database
            //sql = "select CAST(p.product_id AS BIGINT) AS ProductID, p.product_name Item, c.id CategoryID, c.category_name CategoryName, p.retail_price Price, 1 Qty, p.discount Discount, p.taxapply Taxable, p.imagename Image from purchase p inner join tbl_category c on c.category_name = p.category";
            sql = "select s.StockLink ProductID, s.Code ItemCode, s.Description_2 Item, sd.ItemCategoryID CategoryID, c.cCategoryDescription CategoryName, s.ServiceItem, p.fInclPrice Price, CAST(1 AS INT) Qty, CAST(0 AS INT) Discount, i.imagename Image, p.iWarehouseID, w.Code, W.Name Location from stkItem s inner join _etblStockDetails sd on sd.StockID = s.StockLink inner join _etblStockCategories c on c.idStockCategories = sd.ItemCategoryID inner join _etblPriceListPrices p on s.StockLink = p.iStockID left join wiz_cc_stkitem_info i on i.stocklink = s.StockLink inner join WhseMst w on w.WhseLink = p.iWarehouseID";
            products = _commonFunctions.LoadDatatable(sql);

            int width = (flpProduct.Size.Width / 5) - 10;
            //TODO: make image presence dynamic from settings
            buttonInfo = $"Item|ProductID|{width}|100|false";

            // Load buttons
            _commonFunctions.LoadDynamicButtons(products, flpProduct, ProductButton_Click, buttonInfo);
        }

        public void LoadFilteredProductButtons()
        {
            int width = (flpProduct.Size.Width / 5) - 10;
            //TODO: make image dynamic
            buttonInfo = $"Item|ProductID|{width}|100|false";
            // Load buttons
            _commonFunctions.LoadDynamicButtons(filteredProducts, flpProduct, ProductButton_Click, buttonInfo);

        }

        public void LoadCategoryButtons()
        {
            // Get the products from the database
            //sql = "select id CategoryID, category_name CategoryName from tbl_category;";
            sql = "select idStockCategories CategoryID, cCategoryDescription CategoryName from _etblStockCategories";
            categories = _commonFunctions.LoadDatatable(sql);

            int width = (flpCategory.Size.Width / 5) - 5;
            buttonInfo = $"CategoryName|CategoryID|{width}|50|false";

            // Load buttons
            _commonFunctions.LoadDynamicButtons(categories, flpCategory, CategoryButton_Click, buttonInfo);

        }

        // Disable product button
        private bool DisableButton()
        {
            if (_orderID != 0)
            {
                return true;
            }

            return false;
        }

        // Event handler for product buttons
        private void ProductButton_Click(object sender, EventArgs e)
        {
            // Test disable button
            if (DisableButton()) { return; }

            // Cast the sender to a Button
            Button clickedButton = sender as Button;

            // Retrieve ProductID from the button's Tag
            long productId = Convert.ToInt64(clickedButton.Tag);

            // Find the row in the products DataTable that matches the ProductID
            DataRow[] selectedProduct = products.Select($"ProductID = {productId}");

            // Check if a matching product was found
            if (selectedProduct.Length > 0)
            {
                // Get product details
                DataRow product = selectedProduct[0];

                // Check if the product already exists in the orderdetails DataTable
                DataRow[] existingOrderItem = orderDetails.Select($"ProductID = {productId}");

                if (existingOrderItem.Length == 0)  // If the product is not found in orderdetails
                {
                    // Add the product to the orderdetails DataTable
                    DataRow orderRow = orderDetails.NewRow();
                    orderRow["ProductID"] = product["ProductID"];
                    orderRow["Item"] = product["Item"];
                    orderRow["Price"] = product["Price"];
                    orderRow["Qty"] = 1;  // Default quantity
                    orderRow["Discount"] = 0;  // Default discount
                    orderRow["Taxable"] = true;  // Default taxable status
                    orderRow["M"] = false;
                    orderRow["A"] = false;
                    orderRow["I"] = false;
                    orderRow["ItemTotal"] = Convert.ToInt32(orderRow["Qty"]) * Convert.ToDecimal(orderRow["Price"]);
                    orderRow["VAT"] = Convert.ToDecimal(orderRow["Price"]) * Convert.ToDecimal(0.16);
                    orderRow["ServiceCharge"] = Convert.ToDecimal(orderRow["Price"]) * Convert.ToDecimal(0.1);
                    orderRow["CateringLevy"] = Convert.ToDecimal(orderRow["Price"]) * Convert.ToDecimal(0.02);
                    orderRow["TaxTotal"] = Convert.ToInt32(orderRow["VAT"]) + Convert.ToInt32(orderRow["ServiceCharge"]) + Convert.ToInt32(orderRow["CateringLevy"]);

                    // Insert row to cc_wip_table
                    sql = $"INSERT INTO wiz_cc_wip_order_details (orderID, itemID, qty, course, price, itemTotal, discount, taxVAT, taxSC, taxCL, taxTotal) VALUES ({_wipOrderID}, '{Convert.ToInt64(orderRow["ProductID"])}', {Convert.ToInt32(orderRow["Qty"])}, {course}, {Convert.ToDecimal(orderRow["Price"])}, {Convert.ToDecimal(orderRow["ItemTotal"])}, {Convert.ToDecimal(orderRow["Discount"])}, {Convert.ToDecimal(orderRow["VAT"])}, {Convert.ToDecimal(orderRow["ServiceCharge"])}, {Convert.ToDecimal(orderRow["CateringLevy"])}, {Convert.ToDecimal(orderRow["TaxTotal"])});";

                    success = _commonFunctions.ExecuteScalarAndReturnBool(sql);

                    // Add the row to the orderdetails DataTable
                    orderDetails.Rows.Add(orderRow);

                    columnsToDisplay = new string[] { "ProductID", "Item", "Price", "Qty", "M", "A", "I" };
                    columnsToHide = new string[] { "ProductID" };

                    _commonFunctions.LoadDataGridFromDataTable(orderDetails, dgvOrdersItems, columnsToDisplay, columnsToHide);

                    dgvOrdersItems.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvOrdersItems.Columns["Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    decimal tax;

                    total = Convert.ToDecimal(orderDetails.Compute("SUM(ItemTotal)", string.Empty));
                    discount = Convert.ToDecimal(orderDetails.Compute("SUM(Discount)", string.Empty));
                    subtotal = total - discount;
                    vat = Convert.ToDecimal(orderDetails.Compute("SUM(VAT)", string.Empty));
                    serviceCharge = Convert.ToDecimal(orderDetails.Compute("SUM(ServiceCharge)", string.Empty));
                    cateringLevy = Convert.ToDecimal(orderDetails.Compute("SUM(CateringLevy)", string.Empty));
                    tax = vat + cateringLevy + serviceCharge;
                    totalPayable = (Math.Ceiling(subtotal * 100) / 100) + (Math.Ceiling(tax * 100) / 100);

                    tbTotal.Text = (Math.Ceiling(total * 100) / 100).ToString();
                    tbDiscount.Text = (Math.Ceiling(discount * 100) / 100).ToString();
                    tbSubTotal.Text = (Math.Ceiling(total * 100) / 100).ToString();
                    //tbVat.Text = vat.ToString();
                    //tbServiceCharge.Text = serviceCharge.ToString();
                    //tbCateringLevy.Text = cateringLevy.ToString();
                    tbTotalPayable.Text = totalPayable.ToString();

                    // Update wip_order table
                    sql = $"UPDATE wiz_cc_wip_order SET orderTotal = {total}, taxTotal = {tax}, totalPayable = {totalPayable} WHERE orderID = {_wipOrderID};";

                    success = _commonFunctions.ExecuteScalarAndReturnBool(sql);

                    // TODO: Implement Error handling and logging

                    // Reset success to false
                    success = false;
                }
                else
                {
                    // Product already exists, do nothing or notify
                    MessageBox.Show($"Product {product["Item"]} is already in the order.");
                }
            }
            else
            {
                MessageBox.Show("Product not found!");
            }
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            if (DisableButton()) { return; }

            // Cast the sender to a Button
            Button clickedButton = sender as Button;

            // Retrieve ProductID from the button's Tag
            int categoryId = Convert.ToInt32(clickedButton.Tag);

            // Filter rows based on the categoryId
            DataRow[] filteredRows = products.Select("CategoryID = " + categoryId);

            // Add filtered rows to the new DataTable
            foreach (DataRow row in filteredRows)
            {
                filteredProducts.ImportRow(row);
            }

            LoadFilteredProductButtons();

            filteredProducts = new DataTable();
            filteredProducts.Columns.Add("ProductID", typeof(long));
            filteredProducts.Columns.Add("Item", typeof(string));
            filteredProducts.Columns.Add("CategoryID", typeof(string));
            filteredProducts.Columns.Add("CategoryName", typeof(string));
            filteredProducts.Columns.Add("Price", typeof(decimal));
            filteredProducts.Columns.Add("Qty", typeof(int));
            filteredProducts.Columns.Add("Discount", typeof(decimal));
            filteredProducts.Columns.Add("Taxable", typeof(bool));
            filteredProducts.Columns.Add("Image", typeof(byte[]));
        }


        private void ProcessOrdersWithTransaction()
        {
            // Start a transaction
            using (SqlConnection conn = new SqlConnection(_commonFunctions.GetConnectionString()))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Clear orders from the kitchen screen
                    ProcessOrder(transaction);

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


        private void ProcessOrder(SqlTransaction transaction)
        {
            sql = $"INSERT INTO wiz_cc_order (customerID, tableID, bookedCapacity, orderTotal, taxTotal, totalPayable, orderTime, orderStatus, agentID) OUTPUT INSERTED.orderID SELECT customerID, tableID, bookedCapacity, orderTotal, taxTotal, totalPayable, orderTime, 'Preparation' orderStatus, agentID FROM wiz_cc_wip_order WHERE orderID = {_wipOrderID};";
            //mainorderID = _commonFunctions.ExecuteScalarAndReturnId(sql);
            mainorderID = _commonFunctions.ExecuteScalarWithTransactionReturnID(sql, transaction);

            if (mainorderID != 0)
            {

                // Move Details to main
                foreach (DataRow orderRow in orderDetails.Rows)
                {
                    if (orderRow["Item"].ToString().StartsWith("Course ")) { continue; };

                    sql = $"INSERT INTO wiz_cc_order_details (orderID, itemID, qty, course, price, itemTotal, discount, taxVAT, taxSC, taxCL, taxTotal, isVoid, hasModifier, modifier, hasAddOn, addOn, hasInstruction, instruction) SELECT orderID, itemID, qty, course, price, itemTotal, discount, taxVAT, taxSC, taxCL, taxTotal, isVoid, hasModifier, modifier, hasAddOn, addOn, hasInstruction, instruction FROM wiz_cc_wip_order_details WHERE orderID = {_wipOrderID} and itemID = {Convert.ToInt64(orderRow["ProductID"])};";

                    //success = _commonFunctions.ExecuteScalarAndReturnBool(sql);
                    success = _commonFunctions.ExecuteScalarWithTransaction(sql, transaction);
                }

                // Delete Details and Master from wip tables
                string itemIDs = string.Join(",", orderDetails.AsEnumerable().Where(row => row.Field<long?>("ProductID") != null).Select(row => row.Field<long>("ProductID").ToString()));

                sql = $"DELETE FROM wiz_cc_wip_order_details WHERE orderID = {_wipOrderID} AND itemID IN ({itemIDs});";
                //success = _commonFunctions.ExecuteScalarAndReturnBool(sql);
                success = _commonFunctions.ExecuteScalarWithTransaction(sql, transaction);

                sql = $"DELETE FROM wiz_cc_wip_order WHERE orderID = {_wipOrderID};";
                //success = _commonFunctions.ExecuteScalarAndReturnBool(sql);
                success = _commonFunctions.ExecuteScalarWithTransaction(sql, transaction);

                //Update guests table 
                sql = $"update wiz_cc_table_guests set orderID = {mainorderID} where wipOrderID = {_wipOrderID}";
                success = _commonFunctions.ExecuteScalarWithTransaction(sql, transaction);

                MessageBox.Show("Order posted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Operation failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSales_Load(object sender, EventArgs e)
        {

        }

        private void mtTables_Click(object sender, EventArgs e)
        {
            frmTableZone frmTableZone = new frmTableZone();
            frmTableZone.Show();

            // Close current form
            this.Close();
        }

        private void mtKitchen_Click(object sender, EventArgs e)
        {
            frmKitchen frmKitchen = new frmKitchen();
            frmKitchen.Show();

            // Close current form
            this.Close();
        }

        private void mtDashboardMenu_Click(object sender, EventArgs e)
        {
            frmDashboard frmDashboard = new frmDashboard();
            frmDashboard.Show();
        }

        private void mtPayment_Click(object sender, EventArgs e)
        {
            int oid = mainorderID != 0 ? mainorderID : _orderID != 0 ? _orderID : 0;

            if (oid == 0)
            {
                if (_wipOrderID != 0)
                {
                    MessageBox.Show("Please book the order before proceeding to payment.");
                    return;
                }
            }

            frmPaymentR frmPaymentR = new frmPaymentR(oid, _branchTableID);
            frmPaymentR.Show();
        }

        private void mtCourse_Click(object sender, EventArgs e)
        {
            if (_orderID != 0) { return; }

            course += 1;

            DataRow blankRow = orderDetails.NewRow();

            blankRow["Item"] = $"Course {course}";

            if (course == 1)
            {
                orderDetails.Rows.InsertAt(blankRow, 0);

                sql = $"update wiz_cc_wip_order_details set course = 1 where orderID = {_wipOrderID};";
                success = _commonFunctions.ExecuteScalarAndReturnBool(sql);
            }
            else
            {
                orderDetails.Rows.Add(blankRow);
            }

            columnsToDisplay = new string[] { "ProductID", "Item", "Price", "Qty", "M", "A", "I" };
            columnsToHide = new string[] { "ProductID" };

            _commonFunctions.LoadDataGridFromDataTable(orderDetails, dgvOrdersItems, columnsToDisplay, columnsToHide);
        }

        private void SwapRows(int sourceIndex, int targetIndex)
        {
            DataRow row = orderDetails.Rows[sourceIndex];
            DataRow targetRow = orderDetails.NewRow();
            targetRow.ItemArray = orderDetails.Rows[targetIndex].ItemArray.Clone() as object[]; // Copy data from the target row

            // Swap the rows
            orderDetails.Rows[targetIndex].ItemArray = row.ItemArray.Clone() as object[]; // Move selected row to the target index
            orderDetails.Rows[sourceIndex].ItemArray = targetRow.ItemArray; // Move target row to the source index

            // Refresh the grid and maintain selection
            columnsToDisplay = new string[] { "ProductID", "Item", "Price", "Qty", "M", "A", "I" };
            columnsToHide = new string[] { "ProductID" };

            _commonFunctions.LoadDataGridFromDataTable(orderDetails, dgvOrdersItems, columnsToDisplay, columnsToHide);

            dgvOrdersItems.ClearSelection();

            // Select the target row
            dgvOrdersItems.Rows[targetIndex].Selected = true;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            // Ensure that a row is selected
            if (dgvOrdersItems.SelectedRows.Count > 0)
            {
                int rowIndex = dgvOrdersItems.SelectedRows[0].Index; // Get the index of the selected row

                // Check if the selected row is not the first row (to prevent moving out of bounds)
                if (rowIndex > 0)
                {
                    // Check if the row above is not a course row
                    if (!orderDetails.Rows[rowIndex - 1]["Item"].ToString().StartsWith("Course"))
                    {
                        // Swap the selected row with the row above
                        SwapRows(rowIndex, rowIndex - 1);
                    }
                    else if (orderDetails.Rows[rowIndex - 1]["Item"].ToString().StartsWith("Course 1"))
                    {

                    }
                    else if (orderDetails.Rows[rowIndex - 1]["Item"].ToString().StartsWith("Course"))
                    {
                        int currentCourse = Convert.ToInt32(orderDetails.Rows[rowIndex - 1]["Item"].ToString().Split(' ')[1]);
                        long productID = Convert.ToInt64(orderDetails.Rows[rowIndex]["ProductID"]);

                        sql = $"update wiz_cc_wip_order_details set course = {currentCourse - 1} where orderID = {_wipOrderID} and itemID = {productID}";
                        success = _commonFunctions.ExecuteScalarAndReturnBool(sql);

                        // Swap the selected row with the row above
                        SwapRows(rowIndex, rowIndex - 1);
                    }
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            // Ensure that a row is selected
            if (dgvOrdersItems.SelectedRows.Count > 0)
            {
                int rowIndex = dgvOrdersItems.SelectedRows[0].Index; // Get the index of the selected row
                int lastRowIndex = orderDetails.Rows.Count - 1; // Get the index of the last row

                // Check if the selected row is not the last row
                if (rowIndex < lastRowIndex)
                {
                    // Check if the row below is a course row
                    if (orderDetails.Rows[rowIndex + 1]["Item"].ToString().StartsWith("Course"))
                    {
                        int currentCourse = Convert.ToInt32(orderDetails.Rows[rowIndex + 1]["Item"].ToString().Split(' ')[1]);
                        long productID = Convert.ToInt64(orderDetails.Rows[rowIndex]["ProductID"]);

                        sql = $"update wiz_cc_wip_order_details set course = {currentCourse} where orderID = {_wipOrderID} and itemID = {productID}";
                        success = _commonFunctions.ExecuteScalarAndReturnBool(sql);

                        SwapRows(rowIndex, rowIndex + 1);
                    }
                    else
                    {
                        // Normal move down if next row is not a Course row
                        SwapRows(rowIndex, rowIndex + 1);
                    }
                }
            }
        }

        private void mtDelete_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvOrdersItems.SelectedRows[0].Index;

            orderDetails.Rows.RemoveAt(rowIndex);

            // Refresh the grid and maintain selection
            columnsToDisplay = new string[] { "ProductID", "Item", "Price", "Qty", "M", "A", "I" };
            columnsToHide = new string[] { "ProductID" };

            _commonFunctions.LoadDataGridFromDataTable(orderDetails, dgvOrdersItems, columnsToDisplay, columnsToHide);

            dgvOrdersItems.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOrdersItems.Columns["Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void mtVoid_Click(object sender, EventArgs e)
        {
            if (_orderID == 0) { return; }

            frmPermission frmPermission = new frmPermission();
            if (dgvOrdersItems.SelectedRows.Count > 0)
            {
                // Get the index of the selected row
                int rowIndex = dgvOrdersItems.SelectedRows[0].Index;

                DataRow selectedRow = orderDetails.Rows[rowIndex];

                if (frmPermission.ShowDialog() == DialogResult.OK)
                {
                    selectedRow["isVoid"] = true;

                    sql = $"UPDATE wiz_cc_order_details SET isVoid = 1 WHERE orderID = {_orderID} and itemID = {selectedRow["productID"].ToString()}";
                    success = _commonFunctions.ExecuteScalarAndReturnBool(sql);

                    MessageBox.Show("Order voided successfully.");

                    // Refresh the grid and maintain selection
                    columnsToDisplay = new string[] { "ProductID", "Item", "Price", "Qty", "M", "A", "I" };
                    columnsToHide = new string[] { "ProductID" };

                    _commonFunctions.LoadDataGridFromDataTable(orderDetails, dgvOrdersItems, columnsToDisplay, columnsToHide);

                    dgvOrdersItems.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvOrdersItems.Columns["Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }

            // Refresh the grid and maintain selection
            columnsToDisplay = new string[] { "ProductID", "Item", "Price", "Qty", "M", "A", "I" };
            columnsToHide = new string[] { "ProductID" };

            _commonFunctions.LoadDataGridFromDataTable(orderDetails, dgvOrdersItems, columnsToDisplay, columnsToHide);

            dgvOrdersItems.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOrdersItems.Columns["Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void mtBook_Click(object sender, EventArgs e)
        {
            ProcessOrdersWithTransaction();
        }

        private void dgvOrdersItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            // Check if the column being edited is the Qty, C, A, M column
            if (dgv.Columns[e.ColumnIndex].Name == "Qty")
            {
                string columnName = dgv.Columns[e.ColumnIndex].Name;

                // Get the corresponding DataTable
                DataTable dt = dgv.Tag as DataTable;

                // Get the edited row in DataGridView
                DataGridViewRow editedRow = dgv.Rows[e.RowIndex];

                string prodID = editedRow.Cells["ProductID"].Value.ToString();

                // Find the matching row in the DataTable using the ProductID
                long productId = Convert.ToInt64(prodID);
                int editedQty = Convert.ToInt32(editedRow.Cells["Qty"].Value);
                
                DataRow[] rows = dt.Select($"ProductID = {productId}");


                if (rows.Length == 1)
                {
                    decimal price = Convert.ToDecimal(rows[0]["Price"]);
                    decimal itemTotal = price * editedQty;
                    decimal taxSC = itemTotal * Convert.ToDecimal(0.1);
                    decimal taxCL = itemTotal * Convert.ToDecimal(0.02);
                    decimal taxVAT = itemTotal * Convert.ToDecimal(0.16);

                    // Update wip_details tbl
                    sql = $"UPDATE wiz_cc_wip_order_details SET qty = {editedQty}, itemTotal = {price * editedQty}, taxVAT = {taxVAT}, taxSC = {taxSC}, taxCL = {taxCL}, taxTotal = {taxSC + taxCL + taxVAT} WHERE orderID = {_wipOrderID} and itemID = {productId}";

                    success = _commonFunctions.ExecuteScalarAndReturnBool(sql);

                    // Update the Qty in the DataTable
                    rows[0]["Qty"] = editedRow.Cells["Qty"].Value;
                    rows[0]["ItemTotal"] = price * editedQty;
                    rows[0]["VAT"] = taxVAT;
                    rows[0]["ServiceCharge"] = taxSC;
                    rows[0]["CateringLevy"] = taxCL;
                    rows[0]["TaxTotal"] =taxCL + taxSC + taxVAT;
                }

                columnsToDisplay = new string[] { "ProductID", "Item", "Price", "Qty", "M", "A", "I" };
                columnsToHide = new string[] { "ProductID" };

                _commonFunctions.LoadDataGridFromDataTable(orderDetails, dgvOrdersItems, columnsToDisplay, columnsToHide);

                dgvOrdersItems.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvOrdersItems.Columns["Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                decimal tax;

                total = Convert.ToDecimal(orderDetails.Compute("SUM(ItemTotal)", string.Empty));
                discount = Convert.ToDecimal(orderDetails.Compute("SUM(Discount)", string.Empty));
                subtotal = total - discount;
                vat = Convert.ToDecimal(orderDetails.Compute("SUM(VAT)", string.Empty));
                serviceCharge = Convert.ToDecimal(orderDetails.Compute("SUM(ServiceCharge)", string.Empty));
                cateringLevy = Convert.ToDecimal(orderDetails.Compute("SUM(CateringLevy)", string.Empty));
                tax = vat + cateringLevy + serviceCharge;
                totalPayable = (Math.Ceiling(subtotal * 100) / 100) + (Math.Ceiling(tax * 100) / 100);

                tbTotal.Text = (Math.Ceiling(total * 100) / 100).ToString();
                tbDiscount.Text = (Math.Ceiling(discount * 100) / 100).ToString();
                tbSubTotal.Text = (Math.Ceiling(total * 100) / 100).ToString();
                //tbVat.Text = vat.ToString();
                //tbServiceCharge.Text = serviceCharge.ToString();
                //tbCateringLevy.Text = cateringLevy.ToString();
                tbTotalPayable.Text = totalPayable.ToString();

                // Update wip_order table
                sql = $"UPDATE wiz_cc_wip_order SET orderTotal = {total}, taxTotal = {tax}, totalPayable = {totalPayable} WHERE orderID = {_wipOrderID};";

                success = _commonFunctions.ExecuteScalarAndReturnBool(sql);

                // TODO: Implement Error handling and logging

                // Reset success to false
                success = false;
            }
        }

        private void dgvOrdersItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            // Check if the column being edited is the C, A, M column
            if (dgv.Columns[e.ColumnIndex].Name == "M" || dgv.Columns[e.ColumnIndex].Name == "A" || dgv.Columns[e.ColumnIndex].Name == "I")
            {
                string columnName = dgv.Columns[e.ColumnIndex].Name;

                // Get the corresponding DataTable
                DataTable dt = dgv.Tag as DataTable;

                // Get the edited row in DataGridView
                DataGridViewRow editedRow = dgv.Rows[e.RowIndex];

                string prodID = editedRow.Cells["ProductID"].Value.ToString();

                // Find the matching row in the DataTable using the ProductID
                long productId = Convert.ToInt64(prodID);
                DataRow[] rows = dt.Select($"ProductID = {productId}");

                // check if column is either Condiment/modifier, Add-on, Instruction for dialogue box
                if (columnName == "M" || columnName == "A" || columnName == "I")
                {
                    frmTextPopup frmTextPopup = new frmTextPopup(columnName, productId, _wipOrderID);

                    if (frmTextPopup.ShowDialog() == DialogResult.OK)
                    {
                        if (rows.Length == 1)
                        {
                            // update datatable
                            rows[0][columnName] = editedRow.Cells[columnName].EditedFormattedValue;

                            columnsToDisplay = new string[] { "ProductID", "Item", "Price", "Qty", "M", "A", "I" };
                            columnsToHide = new string[] { "ProductID" };

                            _commonFunctions.LoadDataGridFromDataTable(orderDetails, dgvOrdersItems, columnsToDisplay, columnsToHide);

                            dgvOrdersItems.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgvOrdersItems.Columns["Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                    }
                }
            }
        }
    }
}
