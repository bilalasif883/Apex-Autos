using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ApexAutos
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string employeeId = txtEmployeeID.Text.Trim();
            string username = txtNewUsername.Text.Trim();
            string password = txtNewPassword.Text.Trim();

            if (string.IsNullOrEmpty(employeeId) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["ApexDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // Check if employee exists
                    string checkEmp = "SELECT COUNT(*) FROM Employees WHERE EmployeeID = @EmployeeID";
                    using (SqlCommand cmd = new SqlCommand(checkEmp, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                        int empExists = (int)cmd.ExecuteScalar();
                        if (empExists == 0)
                        {
                            MessageBox.Show("Employee ID does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Check if already registered
                    string checkUser = "SELECT COUNT(*) FROM Users WHERE EmployeeID = @EmployeeID";
                    using (SqlCommand cmd = new SqlCommand(checkUser, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                        int userExists = (int)cmd.ExecuteScalar();
                        if (userExists > 0)
                        {
                            MessageBox.Show("This employee is already registered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Insert into Users table
                    string insertQuery = "INSERT INTO Users (EmployeeID, Username, Password) VALUES (@EmployeeID, @Username, @Password)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
