using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using manager_classes;
using DTOs;

namespace recipe_desktop
{
    public partial class LoginUC : UserControl
    {
        private UserManager userManager;
        public LoginUC(UserManager userManager)
        {
            InitializeComponent();

            label1.TextAlign = ContentAlignment.MiddleCenter;
            this.userManager = userManager;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            tbUsername.Clear();
            tbPassword.Clear();
        }
        private void lblRegister_MouseHover(object sender, EventArgs e)
        {
            lblRegister.ForeColor = Color.FromArgb(255, 255, 255);
        }
        private void lblRegister_MouseLeave(object sender, EventArgs e)
        {
            lblRegister.ForeColor = Color.FromArgb(61, 83, 143);
        }
        private void lblForgottenPassword_MouseHover(object sender, EventArgs e)
        {
            lblForgottenPassword.ForeColor = Color.FromArgb(255, 255, 255);
        }
        private void lblForgottenPassword_MouseLeave(object sender, EventArgs e)
        {
            lblForgottenPassword.ForeColor = Color.FromArgb(61, 83, 143);
        }
        private void lblForgottenPassword_Click(object sender, EventArgs e)
        {
            AuthenticationForm parentForm = this.ParentForm as AuthenticationForm;
            parentForm.ClearPanel();
            parentForm.LoadForgottenPassword();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            if (userManager.AuthenticateUser(username, password, out DesktopUserDTO user))
            {
                if (user != null)
                {
                    MessageBox.Show($"Login successful! Welcome, {user.Username}.");

                    // Open home page or perform any other necessary actions
                    OpenHomePage();
                }
                else
                {
                    MessageBox.Show("Failed to retrieve user information. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");

                tbPassword.Clear();
                tbUsername.Focus();
            }
        }
        
        private void OpenHomePage()
        {
            HomePageForm homePage = new HomePageForm();
            homePage.Show();

            Form parentForm = this.ParentForm;
            parentForm.Close();
        }
        private void lblRegister_Click(object sender, EventArgs e)
        {
            AuthenticationForm parentForm = this.ParentForm as AuthenticationForm;
            parentForm.ClearPanel();
            parentForm.LoadRegister();
        }
        private void picPassword_Click(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = !tbPassword.UseSystemPasswordChar;
        }
    }
}
