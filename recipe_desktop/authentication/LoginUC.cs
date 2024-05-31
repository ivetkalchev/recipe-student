using System;
using System.Drawing;
using System.Windows.Forms;
using manager_classes;
using entity_classes;

namespace recipe_desktop
{
    public partial class LoginUC : UserControl
    {
        private IUserManager userManager;

        public LoginUC(IUserManager userManager)
        {
            InitializeComponent();
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text.Trim();
            string password = tbPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            var user = userManager.LoginDesktopUser(username, password);
            if (user != null)
            {
                MessageBox.Show($"Login successful! Welcome, {username}!");
                OpenHomePage(user);
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void OpenHomePage(DesktopUser user)
        {
            HomePageForm homePage = new HomePageForm(userManager, user);
            homePage.Show();
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
