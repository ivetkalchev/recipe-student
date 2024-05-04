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
        private string textUsername = " username";
        private string textSecurityAnswer = " answer";
        public ForgottenPasswordUC()
        {
            InitializeComponent();

            textHolderUsername();
            textHolderSecurityAnswer();
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
        private void textHolderUsername()
        {
            tbUsername.Text = textUsername;
            tbUsername.ForeColor = SystemColors.GrayText;
            tbUsername.GotFocus += tbUsername_GotFocus;
            tbUsername.LostFocus += tbUsername_LostFocus;
        }
        private void tbSecurityAnswer_GotFocus(object sender, EventArgs e)
        {
            if (tbSecurityAnswer.Text == textSecurityAnswer)
            {
                tbSecurityAnswer.Text = "";
                tbSecurityAnswer.ForeColor = SystemColors.WindowText;
            }
        }
        private void tbSecurityAnswer_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSecurityAnswer.Text))
            {
                tbSecurityAnswer.Text = textSecurityAnswer;
                tbSecurityAnswer.ForeColor = SystemColors.GrayText;
            }
        }
        private void textHolderSecurityAnswer()
        {
            tbSecurityAnswer.Text = textSecurityAnswer;
            tbSecurityAnswer.ForeColor = SystemColors.GrayText;
            tbSecurityAnswer.GotFocus += tbSecurityAnswer_GotFocus;
            tbSecurityAnswer.LostFocus += tbSecurityAnswer_LostFocus;
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

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            tbUsername.Clear();
            tbSecurityAnswer.Clear();

            textHolderUsername();
            textHolderSecurityAnswer();
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
    }
}
