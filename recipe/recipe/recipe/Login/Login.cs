using System.Data.SqlClient;

namespace recipe
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void lblForgottenPassword_Click(object sender, EventArgs e)
        {
            ForgottenPassword forgottenPassword = new ForgottenPassword();
            forgottenPassword.ShowDialog();
            this.Close();
        }
        private void lblRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
            this.Close();
        }

        private void lblForgottenPassword_MouseHover(object sender, EventArgs e)
        {
            lblForgottenPassword.ForeColor = Color.FromArgb(255, 130, 169);
        }

        private void lblForgottenPassword_MouseLeave(object sender, EventArgs e)
        {
            lblForgottenPassword.ForeColor = Color.FromArgb(255, 41, 107);
        }

        private void lblRegister_MouseHover(object sender, EventArgs e)
        {
            lblRegister.ForeColor = Color.FromArgb(255, 130, 169);
        }

        private void lblRegister_MouseLeave(object sender, EventArgs e)
        {
            lblRegister.ForeColor = Color.FromArgb(255, 41, 107);
        }
        public void ClearInput()
        {
            tbUsername.Clear();
            tbPassword.Clear();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (CheckEmptySpaces())
            {
                string username = tbUsername.Text;
                string password = tbPassword.Text;

                try
                {
                    // Open connection
                    using (SqlConnection connection = new SqlConnection("Data Source=mssqlstud.fhict.local;Initial Catalog=dbi526066_recipe;User ID=dbi526066_recipe;Password=123123;Encrypt=False"))
                    {
                        connection.Open();

                        // Check if username and password match
                        string query = "SELECT COUNT(*) FROM RegisterTbl WHERE Username = @Username AND Password = @Password";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Username", username);
                            command.Parameters.AddWithValue("@Password", password);

                            int count = (int)command.ExecuteScalar();
                            if (count > 0)
                            {
                                MessageBox.Show($"Successfully logged in! Welcome {username}!");

                                Homepage homepage = new Homepage();
                                homepage.Show();

                                ClearInput();
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password. Please try again.");
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


        private bool CheckEmptySpaces()
        {
            if (tbUsername.Text == "" && tbPassword.Text == "")
            {
                MessageBox.Show("Please enter all credentials");
                return false;
            }
            else if (tbUsername.Text == "")
            {
                MessageBox.Show("Please enter your username");
                return false;
            }
            else if (tbPassword.Text == "")
            {
                MessageBox.Show("Please enter your password");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
