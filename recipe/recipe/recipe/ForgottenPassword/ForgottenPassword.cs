using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace recipe
{
    public partial class ForgottenPassword : Form
    {
        public ForgottenPassword()
        {
            InitializeComponent();
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
        }

        private void lblLogin_MouseHover(object sender, EventArgs e)
        {
            lblLogin.ForeColor = Color.FromArgb(255, 41, 107);
        }

        private void lblLogin_MouseLeave(object sender, EventArgs e)
        {
            lblLogin.ForeColor = Color.FromArgb(255, 130, 169);
        }

        private void lblRegister_MouseHover(object sender, EventArgs e)
        {
            lblRegister.ForeColor = Color.FromArgb(255, 130, 169);
        }

        private void lblRegister_MouseLeave(object sender, EventArgs e)
        {
            lblRegister.ForeColor = Color.FromArgb(255, 41, 107);
        }

        private void tbBSN_KeyPress(object sender, KeyPressEventArgs bsn)
        {
            if (!char.IsDigit(bsn.KeyChar) && bsn.KeyChar != '\b')
            {
                bsn.Handled = true;
                MessageBox.Show("Please enter only numbers.");
            }
            else if (tbBSN.Text.Length >= 9 && bsn.KeyChar != '\b')
            {
                bsn.Handled = true;
                MessageBox.Show("Maximum length reached (9 digits).");
            }
        }

        private void btnReveal_Click(object sender, EventArgs e)
        {
            string bsn = tbBSN.Text;

            if (string.IsNullOrEmpty(bsn))
            {
                MessageBox.Show("Please enter your BSN.");
                return;
            }

            try
            {
                // Open connection
                using (SqlConnection connection = new SqlConnection("Data Source=mssqlstud.fhict.local;Initial Catalog=dbi526066_recipe;User ID=dbi526066_recipe;Password=123123;Encrypt=False"))
                {
                    connection.Open();

                    // Check if BSN exists
                    string query = "SELECT Username, Password, FirstName, LastName FROM RegisterTbl WHERE BSN = @BSN";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BSN", bsn);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string username = reader["Username"].ToString();
                                string password = reader["Password"].ToString();
                                string firstName = reader["FirstName"].ToString();
                                string lastName = reader["LastName"].ToString();

                                MessageBox.Show($"The BSN matches {firstName} {lastName}.\n" +
                                                $"The password of {username} is {password}.");
                            }
                            else
                            {
                                MessageBox.Show("No user found with this BSN.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

    }
}
