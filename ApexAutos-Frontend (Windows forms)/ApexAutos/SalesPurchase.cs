using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ApexAutos
{
    public partial class Sales_Purchase : Form
    {
        string connectionString = @"Data Source=BEAST\SQLEXPRESS;Initial Catalog=ApexAutos_DB;Integrated Security=True;";

        public Sales_Purchase()
        {
            InitializeComponent();
            cmbViewType.Items.Add("Sales");
            cmbViewType.Items.Add("Purchases");
            cmbViewType.SelectedIndex = 0;

            cmbViewType.SelectedIndexChanged += (s, e) => LoadData();
            LoadData();
        }

        private void LoadData()
        {
            string selected = cmbViewType.SelectedItem.ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = selected == "Sales"
                    ? @"SELECT s.SaleID, c.Name AS CustomerName, car.Make + ' ' + car.Model AS Car, s.SaleDate, s.Price
                        FROM Sales s
                        INNER JOIN Customers c ON s.CustomerID = c.CustomerID
                        INNER JOIN Cars car ON s.CarID = car.CarID"
                    : @"SELECT p.PurchaseID, sup.Name AS SupplierName, car.Make + ' ' + car.Model AS Car, p.PurchaseDate, p.Cost
                        FROM Purchases p
                        INNER JOIN Suppliers sup ON p.SupplierID = sup.SupplierID
                        INNER JOIN Cars car ON p.CarID = car.CarID";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewSP.DataSource = dt;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadData();

        private void btnAddSale_Click(object sender, EventArgs e)
        {
            string customerId = Prompt.ShowDialog("Enter Customer ID:", "Add Sale");
            string carId = Prompt.ShowDialog("Enter Car ID:", "Add Sale");
            string date = Prompt.ShowDialog("Enter Sale Date (yyyy-mm-dd):", "Add Sale");
            string price = Prompt.ShowDialog("Enter Sale Price:", "Add Sale");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Sales (CustomerID, CarID, SaleDate, Price) VALUES (@cust, @car, @date, @price)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cust", customerId);
                cmd.Parameters.AddWithValue("@car", carId);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@price", price);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadData();
        }

        private void btnEditSale_Click(object sender, EventArgs e)
        {
            if (dataGridViewSP.SelectedRows.Count == 0) return;

            DataGridViewRow row = dataGridViewSP.SelectedRows[0];
            string saleId = row.Cells["SaleID"].Value.ToString();
            string oldCustomer = row.Cells["CustomerName"].Value.ToString();
            string oldCar = row.Cells["Car"].Value.ToString();
            string oldDate = Convert.ToDateTime(row.Cells["SaleDate"].Value).ToString("yyyy-MM-dd");
            string oldPrice = row.Cells["Price"].Value.ToString();

            string newCustomerId = Prompt.ShowDialog($"Enter new Customer ID (was {oldCustomer}):", "Edit Sale");
            string newCarId = Prompt.ShowDialog($"Enter new Car ID (was {oldCar}):", "Edit Sale");
            string newDate = Prompt.ShowDialog($"Enter new Sale Date (yyyy-mm-dd) (was {oldDate}):", "Edit Sale");
            string newPrice = Prompt.ShowDialog($"Enter new Price (was {oldPrice}):", "Edit Sale");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Sales 
                         SET CustomerID = @cust, CarID = @car, SaleDate = @date, Price = @price 
                         WHERE SaleID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cust", newCustomerId);
                cmd.Parameters.AddWithValue("@car", newCarId);
                cmd.Parameters.AddWithValue("@date", newDate);
                cmd.Parameters.AddWithValue("@price", newPrice);
                cmd.Parameters.AddWithValue("@id", saleId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadData();
        }


        private void btnRemoveSale_Click(object sender, EventArgs e)
        {
            if (dataGridViewSP.SelectedRows.Count == 0) return;
            string saleId = dataGridViewSP.SelectedRows[0].Cells["SaleID"].Value.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Sales WHERE SaleID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", saleId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadData();
        }

        private void btnAddPurchase_Click(object sender, EventArgs e)
        {
            string supplierId = Prompt.ShowDialog("Enter Supplier ID:", "Add Purchase");
            string carId = Prompt.ShowDialog("Enter Car ID:", "Add Purchase");
            string date = Prompt.ShowDialog("Enter Purchase Date (yyyy-mm-dd):", "Add Purchase");
            string cost = Prompt.ShowDialog("Enter Purchase Cost:", "Add Purchase");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Purchases (SupplierID, CarID, PurchaseDate, Cost) VALUES (@sup, @car, @date, @cost)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@sup", supplierId);
                cmd.Parameters.AddWithValue("@car", carId);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@cost", cost);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadData();
        }

        private void btnEditPurchase_Click(object sender, EventArgs e)
        {
            if (dataGridViewSP.SelectedRows.Count == 0) return;

            DataGridViewRow row = dataGridViewSP.SelectedRows[0];
            string purchaseId = row.Cells["PurchaseID"].Value.ToString();
            string oldSupplier = row.Cells["SupplierName"].Value.ToString();
            string oldCar = row.Cells["Car"].Value.ToString();
            string oldDate = Convert.ToDateTime(row.Cells["PurchaseDate"].Value).ToString("yyyy-MM-dd");
            string oldCost = row.Cells["Cost"].Value.ToString();

            string newSupplierId = Prompt.ShowDialog($"Enter new Supplier ID (was {oldSupplier}):", "Edit Purchase");
            string newCarId = Prompt.ShowDialog($"Enter new Car ID (was {oldCar}):", "Edit Purchase");
            string newDate = Prompt.ShowDialog($"Enter new Purchase Date (yyyy-mm-dd) (was {oldDate}):", "Edit Purchase");
            string newCost = Prompt.ShowDialog($"Enter new Cost (was {oldCost}):", "Edit Purchase");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Purchases 
                         SET SupplierID = @sup, CarID = @car, PurchaseDate = @date, Cost = @cost 
                         WHERE PurchaseID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@sup", newSupplierId);
                cmd.Parameters.AddWithValue("@car", newCarId);
                cmd.Parameters.AddWithValue("@date", newDate);
                cmd.Parameters.AddWithValue("@cost", newCost);
                cmd.Parameters.AddWithValue("@id", purchaseId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadData();
        }


        private void btnRemovePurchase_Click(object sender, EventArgs e)
        {
            if (dataGridViewSP.SelectedRows.Count == 0) return;
            string purchaseId = dataGridViewSP.SelectedRows[0].Cells["PurchaseID"].Value.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Purchases WHERE PurchaseID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", purchaseId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadData();
        }
    }
}
