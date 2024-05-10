using DAOs;
using DTOs;
using manager_classes;
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

namespace recipe_desktop
{
    public partial class ForgottenPasswordUC : UserControl
    {
        private UserManager userManager;
        public ForgottenPasswordUC(UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
        }
        private void lblRegister_MouseHover(object sender, EventArgs e)
        {
            lblRegister.ForeColor = Color.FromArgb(255, 255, 255);
        }
        private void lblRegister_MouseLeave(object sender, EventArgs e)
        {
            lblRegister.ForeColor = Color.FromArgb(61, 83, 143);
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string securityAnswer = tbSecurityAnswer.Text;
            string newPassword = tbNewPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(securityAnswer) || string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string hashedNewPassword = PasswordHasher.HashPassword(newPassword);

            if (userManager.ValidateSecurityAnswer(username, securityAnswer))
            {
                if (userManager.UpdateDesktopPassword(username, hashedNewPassword))
                {
                    MessageBox.Show("Password updated successfully.");
                    HomePageForm homePage = new HomePageForm();
                    homePage.Show();
                    Form parentForm = this.ParentForm;
                    parentForm.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to update password.");
                }
            }
            else
            {
                MessageBox.Show("Incorrect security answer.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbUsername.Clear();
            tbSecurityAnswer.Clear();
        }
        private void lblRegister_Click(object sender, EventArgs e)
        {
            AuthenticationForm parentForm = this.ParentForm as AuthenticationForm;
            parentForm.ClearPanel();
            parentForm.LoadRegister();
        }
        private void lblLogin_MouseHover(object sender, EventArgs e)
        {
            lblLogin.ForeColor = Color.FromArgb(61, 83, 143);
        }
        private void lblLogin_MouseLeave(object sender, EventArgs e)
        {
            lblLogin.ForeColor = Color.FromArgb(255, 255, 255);
        }
        private void lblLogin_Click(object sender, EventArgs e)
        {
            AuthenticationForm parentForm = this.ParentForm as AuthenticationForm;
            parentForm.ClearPanel();
            parentForm.LoadLogin();
        }

        private void picPassword_Click(object sender, EventArgs e)
        {
            tbNewPassword.UseSystemPasswordChar = !tbNewPassword.UseSystemPasswordChar;
        }
    }
}
