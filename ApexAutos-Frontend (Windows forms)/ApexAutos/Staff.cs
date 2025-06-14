using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ApexAutos
{
    public partial class Staff : Form
    {
        string connectionString = @"Data Source=BEAST\SQLEXPRESS;Initial Catalog=ApexAutos_DB;Integrated Security=True;";

        public Staff()
        {
            InitializeComponent();
        }

        private void Staff_Load(object sender, EventArgs e)
        {
            LoadBranches();
        }

        private void LoadBranches()
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

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBranch.SelectedValue is int branchId)
            {
                LoadEmployeesForBranch(branchId);
            }
        }

        private void LoadEmployeesForBranch(int branchId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT EmployeeID, Name, Contact, Position FROM Employees WHERE BranchID = @branchId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@branchId", branchId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewStaff.DataSource = dt;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (cmbBranch.SelectedValue != null)
            {
                LoadEmployeesForBranch((int)cmbBranch.SelectedValue);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbBranch.SelectedValue == null) return;

            int branchId = (int)cmbBranch.SelectedValue;
            string name = Prompt.ShowDialog("Enter Name:", "Add Employee");
            string contact = Prompt.ShowDialog("Enter Contact:", "Add Employee");
            string position = Prompt.ShowDialog("Enter Position:", "Add Employee");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Employees (BranchID, Name, Contact, Position) VALUES (@BranchID, @Name, @Contact, @Position)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BranchID", branchId);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@Position", position);
                cmd.ExecuteNonQuery();
            }

            LoadEmployeesForBranch(branchId);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewStaff.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an employee to edit.");
                return;
            }

            DataGridViewRow row = dataGridViewStaff.SelectedRows[0];
            int employeeId = (int)row.Cells["EmployeeID"].Value;

            string name = Prompt.ShowDialog("Edit Name:", "Edit Employee", row.Cells["Name"].Value.ToString());
            string contact = Prompt.ShowDialog("Edit Contact:", "Edit Employee", row.Cells["Contact"].Value.ToString());
            string position = Prompt.ShowDialog("Edit Position:", "Edit Employee", row.Cells["Position"].Value.ToString());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Employees SET Name = @Name, Contact = @Contact, Position = @Position WHERE EmployeeID = @EmployeeID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@Position", position);
                cmd.ExecuteNonQuery();
            }

            LoadEmployeesForBranch((int)cmbBranch.SelectedValue);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridViewStaff.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an employee to delete.");
                return;
            }

            int employeeId = (int)dataGridViewStaff.SelectedRows[0].Cells["EmployeeID"].Value;

            DialogResult result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE EmployeeID = @EmployeeID", conn);
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                    cmd.ExecuteNonQuery();
                }

                LoadEmployeesForBranch((int)cmbBranch.SelectedValue);
            }
        }
    }
}
