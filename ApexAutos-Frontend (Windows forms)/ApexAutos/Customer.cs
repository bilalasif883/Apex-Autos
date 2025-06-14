using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ApexAutos
{
    public partial class Customer : Form
    {
        string connectionString = @"Data Source=BEAST\SQLEXPRESS;Initial Catalog=ApexAutos_DB;Integrated Security=True;";

        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            LoadCustomerFeedback();
        }

        private void LoadCustomerFeedback()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        c.CustomerID,
                        c.Name,
                        c.Contact,
                        c.Email,
                        f.FeedbackID,
                        f.Message
                    FROM 
                        Customers c
                    LEFT JOIN 
                        Feedback f ON c.CustomerID = f.CustomerID";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewCustomers.DataSource = dt;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCustomerFeedback();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = Prompt.ShowDialog("Enter Customer Name:", "Add Customer");
            string contact = Prompt.ShowDialog("Enter Contact Number:", "Add Customer");
            string email = Prompt.ShowDialog("Enter Email:", "Add Customer");
            string message = Prompt.ShowDialog("Enter Feedback Message (optional):", "Add Feedback");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Insert Customer
                string insertCustomer = "INSERT INTO Customers (Name, Contact, Email) OUTPUT INSERTED.CustomerID VALUES (@Name, @Contact, @Email)";
                SqlCommand cmdCustomer = new SqlCommand(insertCustomer, conn);
                cmdCustomer.Parameters.AddWithValue("@Name", name);
                cmdCustomer.Parameters.AddWithValue("@Contact", contact);
                cmdCustomer.Parameters.AddWithValue("@Email", email);

                int newCustomerId = (int)cmdCustomer.ExecuteScalar();

                // Insert Feedback if message exists
                if (!string.IsNullOrEmpty(message))
                {
                    string insertFeedback = "INSERT INTO Feedback (CustomerID, Message) VALUES (@CustomerID, @Message)";
                    SqlCommand cmdFeedback = new SqlCommand(insertFeedback, conn);
                    cmdFeedback.Parameters.AddWithValue("@CustomerID", newCustomerId);
                    cmdFeedback.Parameters.AddWithValue("@Message", message);
                    cmdFeedback.ExecuteNonQuery();
                }
            }

            LoadCustomerFeedback();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a customer to edit.");
                return;
            }

            var row = dataGridViewCustomers.SelectedRows[0];

            int customerId = (int)row.Cells["CustomerID"].Value;
            int feedbackId = row.Cells["FeedbackID"].Value != DBNull.Value ? (int)row.Cells["FeedbackID"].Value : 0;

            string name = Prompt.ShowDialog("Edit Name:", "Edit Customer", row.Cells["Name"].Value.ToString());
            string contact = Prompt.ShowDialog("Edit Contact:", "Edit Customer", row.Cells["Contact"].Value.ToString());
            string email = Prompt.ShowDialog("Edit Email:", "Edit Customer", row.Cells["Email"].Value.ToString());

            string message = Prompt.ShowDialog("Edit Feedback Message:", "Edit Feedback", row.Cells["Message"].Value?.ToString());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Update customer
                string updateCustomer = "UPDATE Customers SET Name = @Name, Contact = @Contact, Email = @Email WHERE CustomerID = @CustomerID";
                SqlCommand cmdCustomer = new SqlCommand(updateCustomer, conn);
                cmdCustomer.Parameters.AddWithValue("@Name", name);
                cmdCustomer.Parameters.AddWithValue("@Contact", contact);
                cmdCustomer.Parameters.AddWithValue("@Email", email);
                cmdCustomer.Parameters.AddWithValue("@CustomerID", customerId);
                cmdCustomer.ExecuteNonQuery();

                // Update or insert feedback
                if (feedbackId > 0)
                {
                    string updateFeedback = "UPDATE Feedback SET Message = @Message WHERE FeedbackID = @FeedbackID";
                    SqlCommand cmdFeedback = new SqlCommand(updateFeedback, conn);
                    cmdFeedback.Parameters.AddWithValue("@Message", message);
                    cmdFeedback.Parameters.AddWithValue("@FeedbackID", feedbackId);
                    cmdFeedback.ExecuteNonQuery();
                }
                else if (!string.IsNullOrEmpty(message))
                {
                    string insertFeedback = "INSERT INTO Feedback (CustomerID, Message) VALUES (@CustomerID, @Message)";
                    SqlCommand cmdFeedback = new SqlCommand(insertFeedback, conn);
                    cmdFeedback.Parameters.AddWithValue("@CustomerID", customerId);
                    cmdFeedback.Parameters.AddWithValue("@Message", message);
                    cmdFeedback.ExecuteNonQuery();
                }
            }

            LoadCustomerFeedback();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a customer to remove.");
                return;
            }

            int customerId = (int)dataGridViewCustomers.SelectedRows[0].Cells["CustomerID"].Value;

            DialogResult result = MessageBox.Show("Are you sure you want to delete this customer and their feedback?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Delete feedback first
                    SqlCommand deleteFeedback = new SqlCommand("DELETE FROM Feedback WHERE CustomerID = @CustomerID", conn);
                    deleteFeedback.Parameters.AddWithValue("@CustomerID", customerId);
                    deleteFeedback.ExecuteNonQuery();

                    // Delete customer
                    SqlCommand deleteCustomer = new SqlCommand("DELETE FROM Customers WHERE CustomerID = @CustomerID", conn);
                    deleteCustomer.Parameters.AddWithValue("@CustomerID", customerId);
                    deleteCustomer.ExecuteNonQuery();
                }

                LoadCustomerFeedback();
            }
        }

        private void dataGridViewCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
