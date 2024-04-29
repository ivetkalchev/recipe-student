using System.Data.SqlClient;
using data_access;

namespace recipe_desktop
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
        }
        private void lblRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
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
