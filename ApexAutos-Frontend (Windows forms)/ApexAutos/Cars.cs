using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace ApexAutos
{
    public partial class ShowroomForm : Form
    {
        private readonly string connectionString;

        public ShowroomForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["ApexDB"].ConnectionString;
        }

        private void ShowroomForm_Load(object sender, EventArgs e)
        {
            LoadBranches();
        }

        private void LoadBranches()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT BranchID, BranchName FROM Branches";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbBranch.DisplayMember = "BranchName";
                    cmbBranch.ValueMember = "BranchID";
                    cmbBranch.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load branches: " + ex.Message);
            }
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBranch.SelectedValue is int branchId)
            {
                LoadCarsForBranch(branchId);
            }
        }

        private void LoadCarsForBranch(int branchId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT CarID, Make, Model, Year, Price FROM Cars WHERE BranchID = @branchId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@branchId", branchId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewCars.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading cars: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (cmbBranch.SelectedValue is int branchId)
            {
                LoadCarsForBranch(branchId);
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (!(cmbBranch.SelectedValue is int branchId)) return;

            string make = Prompt.ShowDialog("Enter Make:", "Add Car");
            string model = Prompt.ShowDialog("Enter Model:", "Add Car");
            string yearStr = Prompt.ShowDialog("Enter Year:", "Add Car");
            string priceStr = Prompt.ShowDialog("Enter Price:", "Add Car");

            if (int.TryParse(yearStr, out int year) && decimal.TryParse(priceStr, out decimal price))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "INSERT INTO Cars (BranchID, Make, Model, Year, Price) VALUES (@BranchID, @Make, @Model, @Year, @Price)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@BranchID", branchId);
                        cmd.Parameters.AddWithValue("@Make", make);
                        cmd.Parameters.AddWithValue("@Model", model);
                        cmd.Parameters.AddWithValue("@Year", year);
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.ExecuteNonQuery();
                    }

                    LoadCarsForBranch(branchId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding car: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Invalid Year or Price");
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewCars.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a car to edit.");
                return;
            }

            DataGridViewRow row = dataGridViewCars.SelectedRows[0];
            int carId = (int)row.Cells["CarID"].Value;
            string make = Prompt.ShowDialog("Edit Make:", "Edit Car", row.Cells["Make"].Value.ToString());
            string model = Prompt.ShowDialog("Edit Model:", "Edit Car", row.Cells["Model"].Value.ToString());
            string yearStr = Prompt.ShowDialog("Edit Year:", "Edit Car", row.Cells["Year"].Value.ToString());
            string priceStr = Prompt.ShowDialog("Edit Price:", "Edit Car", row.Cells["Price"].Value.ToString());

            if (int.TryParse(yearStr, out int year) && decimal.TryParse(priceStr, out decimal price))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "UPDATE Cars SET Make=@Make, Model=@Model, Year=@Year, Price=@Price WHERE CarID=@CarID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@CarID", carId);
                        cmd.Parameters.AddWithValue("@Make", make);
                        cmd.Parameters.AddWithValue("@Model", model);
                        cmd.Parameters.AddWithValue("@Year", year);
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.ExecuteNonQuery();
                    }

                    LoadCarsForBranch((int)cmbBranch.SelectedValue);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating car: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Invalid Year or Price");
            }
        }

        private void btnRemove_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewCars.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a car to delete.");
                return;
            }

            int carId = (int)dataGridViewCars.SelectedRows[0].Cells["CarID"].Value;

            DialogResult result = MessageBox.Show("Are you sure you want to delete this car?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Cars WHERE CarID = @CarID", conn);
                        cmd.Parameters.AddWithValue("@CarID", carId);
                        cmd.ExecuteNonQuery();
                    }

                    LoadCarsForBranch((int)cmbBranch.SelectedValue);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting car: " + ex.Message);
                }
            }
        }
    }

    public static class Prompt
    {
        public static string ShowDialog(string text, string caption, string defaultValue = "")
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = text, Width = 340 };
            TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 340, Text = defaultValue };
            Button confirmation = new Button() { Text = "OK", Left = 270, Width = 90, Top = 90, DialogResult = DialogResult.OK };
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : "";
        }
    }
}
