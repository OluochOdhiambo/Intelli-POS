using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Fonts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCPos.Modules
{
    public class CommonFunctions
    {
        private string connString = "Data Source=(local);Initial Catalog=********; User ID=sa;Password=***********";

        public void LoadDataGridFromDataTable(DataTable dt, DataGridView dgv, string[] cols, string[] hiddenCols)
        {
            // Clear the DataGridView columns and rows if necessary
            dgv.Columns.Clear();
            dgv.Rows.Clear();

            // Add the specified columns dynamically to the DataGridView
            foreach (string col in cols)
            {
                DataGridViewColumn dgvCol;

                // Check if the column should be a checkbox column
                DataColumn dataColumn = dt.Columns[col];

                // skip if datacolumn is null
                if (dataColumn == null) { continue; }

                //if (col == "M" || col == "A" || col == "I")
                if (dataColumn.DataType == typeof(bool))
                {
                    DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                    checkBoxColumn.Name = col;
                    checkBoxColumn.HeaderText = col;
                    checkBoxColumn.DataPropertyName = col; // Binding the column to the DataTable
                    checkBoxColumn.TrueValue = true;
                    checkBoxColumn.FalseValue = false;
                    dgvCol = checkBoxColumn;
                }
                else
                {
                    dgvCol = new DataGridViewTextBoxColumn();
                    dgvCol.HeaderText = col;
                    dgvCol.Name = col;
                    dgvCol.DataPropertyName = col;
                }

                // Check if the column should be hidden
                if (hiddenCols.Contains(col))
                {
                    dgvCol.Visible = false; // Hide the column
                }

                dgv.Columns.Add(dgvCol);
            }

            foreach (DataRow row in dt.Rows)
            {
                // Create an array to hold the values for each row
                object[] rowData = new object[cols.Length];

                // Populate rowData with the values from the specified columns in the DataRow
                for (int i = 0; i < cols.Length; i++)
                {
                    string columnName = cols[i];

                    if (dt.Columns.Contains(columnName)) // Check if the column exists
                    {
                        rowData[i] = row[columnName]; // Safely access the column value
                    }
                    else
                    {
                        // Handle the case where the column doesn't exist, e.g., set a default value
                        rowData[i] = DBNull.Value; // Or any default value like null, 0, etc.
                    }
                }

                // Add the rowData array to the DataGridView
                int rowIndex = dgv.Rows.Add(rowData);

                // Check if the "isVoid" column exists and highlight the row if its value is true
                if (dt.Columns.Contains("isVoid") && row["isVoid"] != DBNull.Value && Convert.ToBoolean(row["isVoid"]))
                {
                    dgv.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red; // Highlight the row in red
                }

                // For each row, set checkbox values based on the corresponding DataRow value
                if (dt.Columns.Contains("M"))
                {
                    dgv.Rows[rowIndex].Cells["M"].Value = row["M"] != DBNull.Value && Convert.ToBoolean(row["M"]);
                }
                if (dt.Columns.Contains("A"))
                {
                    dgv.Rows[rowIndex].Cells["A"].Value = row["A"] != DBNull.Value && Convert.ToBoolean(row["A"]);
                }
                if (dt.Columns.Contains("I"))
                {
                    dgv.Rows[rowIndex].Cells["I"].Value = row["I"] != DBNull.Value && Convert.ToBoolean(row["I"]);
                }
            }

            // Assign the DataTable to the DataGridView's Tag to keep a reference
            dgv.Tag = dt;
        }

        public DataTable LoadDatatable(String sql)
        {
            // Adjust the query and connection string as needed
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }

                return dt;
            }
        }

        public void LoadComboBox(string sql,ComboBox comboBox, string idField, string valueField)
        {
            try
            {
                DataTable dataTable = LoadDatatable(sql);

                // Set the data source of the combo box
                comboBox.DataSource = dataTable;

                comboBox.DisplayMember = valueField;
                comboBox.ValueMember = idField;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
                MessageBox.Show($"Error loading combo box: {ex.Message}");
            }

            comboBox.SelectedIndex = -1;
        }


        // Method to dynamically load buttons
        public void LoadDynamicButtons(DataTable dt, FlowLayoutPanel flp, EventHandler handler, string buttonInfo)
        {
            // parse string
            string[] values = buttonInfo.Split('|');

            bool hasImage = bool.Parse(values[4]);

            bool hasBookings = dt.Columns.Contains("HasBookings");

            // Clear existing controls (if reloading)
            flp.Controls.Clear();

            // Ensure the panel is scrollable
            flp.AutoScroll = true;

            foreach (DataRow row in dt.Rows)
            {
                MetroTile dynamicTile = new MetroTile
                {
                    Text = row[$"{values[0]}"].ToString(),  // Text (ProductName, etc.)
                    Tag = row[$"{values[1]}"],              // Store ProductID in Tag for later use
                    Width = int.Parse(values[2]),           // Tile Width
                    Height = int.Parse(values[3]),          // Tile Height


                    UseTileImage = hasImage  // Show image if present
                };

                dynamicTile.TileTextFontSize = MetroTileTextSize.Tall;
                dynamicTile.TileTextFontWeight = MetroTileTextWeight.Bold;

                if (hasImage)
                {
                    dynamicTile.TextAlign = ContentAlignment.BottomCenter;  // Align text
                    dynamicTile.TileImageAlign = ContentAlignment.TopCenter;  // Align image
                    //dynamicTile.wrap = 
                } else
                {
                    dynamicTile.TextAlign = ContentAlignment.MiddleCenter;
                }

                if (hasImage)
                {
                    byte[] imageData = (byte[])row["Image"];  // Retrieve image data

                    if (imageData != null && imageData.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            dynamicTile.TileImage = Image.FromStream(ms);  // Convert binary data to image
                            dynamicTile.TileImage = new Bitmap(dynamicTile.TileImage, new Size(64, 64));  // Resize image as needed
                        }
                    }
                }

                if (hasBookings && row["HasBookings"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(row["HasBookings"]))
                    {
                        dynamicTile.CustomBackground = true;
                        dynamicTile.CustomForeColor = true;

                        string orderStatus = row["OrderStatus"].ToString();

                        switch (orderStatus)
                        {
                            case "Initiated":
                                dynamicTile.BackColor = Color.LightGray;  // Color for 'Initiated'
                                dynamicTile.ForeColor = Color.White;
                                break;
                            case "Preparation":
                                dynamicTile.BackColor = Color.Orange;  // Color for 'Preparation'
                                dynamicTile.ForeColor = Color.White;
                                break;
                            case "Ready":
                                dynamicTile.BackColor = Color.Yellow;  // Color for 'Ready'
                                dynamicTile.ForeColor = Color.Black;
                                break;
                            case "Reserved":
                                dynamicTile.BackColor = Color.Beige;  // Color for 'Reserved'
                                dynamicTile.ForeColor = Color.Black;
                                break;
                            case "Paid":
                                dynamicTile.BackColor = Color.Green;  // Color for 'Paid'
                                dynamicTile.ForeColor = Color.White;
                                break;
                            default:
                                dynamicTile.BackColor = Color.Pink;  // Default color for unknown status
                                dynamicTile.ForeColor = Color.Black;
                                break;
                        }
                    }
                }

                // Add a click event handler
                dynamicTile.Click += handler;

                // Add the tile to the FlowLayoutPanel
                flp.Controls.Add(dynamicTile);
            }
        }

        public int ExecuteScalarAndReturnId(string sql)
        {
            // Adjust the connection string as needed
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();

                // ExecuteScalar returns the first column of the first row in the result set
                object result = cmd.ExecuteScalar();

                // Convert result to integer, handling null values
                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    return id;
                }
                else
                {
                    throw new Exception("Query did not return a valid ID.");
                }
            }
        }

        public bool ExecuteScalarAndReturnBool(string sql)
        {
            // Adjust the connection string as needed
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }
    }
}
