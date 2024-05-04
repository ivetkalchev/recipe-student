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
    public partial class LoginUC : UserControl
    {
        private string textUsername = " username";
        private string textPassword = " password";
        public LoginUC()
        {
            InitializeComponent();

            textHolderUsername();
            textHolderPassword();

            label1.TextAlign = ContentAlignment.MiddleCenter;
        }
        private void tbUsername_GotFocus(object sender, EventArgs e)
        {
            if (tbUsername.Text == textUsername)
            {
                tbUsername.Text = "";
                tbUsername.ForeColor = SystemColors.WindowText;
            }
        }
        private void tbUsername_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbUsername.Text))
            {
                tbUsername.Text = textUsername;
                tbUsername.ForeColor = SystemColors.GrayText;
            }
        }
        private void tbPassword_GotFocus(object sender, EventArgs e)
        {
            if (tbPassword.Text == textPassword)
            {
                tbPassword.Text = "";
                tbPassword.ForeColor = SystemColors.WindowText;
            }
        }
        private void tbPassword_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                tbPassword.Text = textPassword;
                tbPassword.ForeColor = SystemColors.GrayText;
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            tbUsername.Clear();
            tbPassword.Clear();

            textHolderUsername();
            textHolderPassword();
        }
        private void textHolderUsername()
        {
            tbUsername.Text = textUsername;
            tbUsername.ForeColor = SystemColors.GrayText;
            tbUsername.GotFocus += tbUsername_GotFocus;
            tbUsername.LostFocus += tbUsername_LostFocus;
        }
        private void textHolderPassword()
        {
            tbPassword.Text = textPassword;
            tbPassword.ForeColor = SystemColors.GrayText;
            tbPassword.GotFocus += tbPassword_GotFocus;
            tbPassword.LostFocus += tbPassword_LostFocus;
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

        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            AuthenticationForm parentForm = this.ParentForm as AuthenticationForm;
            parentForm.ClearPanel();
            parentForm.LoadRegister();
        }
    }
}
