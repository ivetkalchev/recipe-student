using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using entity_classes.Users;
using enum_classes.Users;

namespace recipe_desktop
{
    public partial class RegisterUC : UserControl
    {
        private string textUsername = " username";
        private string textPassword = " password";
        private string textEmail = " email";
        private string textBsn = " BSN";
        private string textFirstName = " First Name";
        private string textLastName = " Last Name";
        private string textSecurityAnswer = " answer";
        public RegisterUC()
        {
            InitializeComponent();

            textHolderUsername();
            textHolderPassword();
            textHolderEmail();
            textHolderBsn();
            textHolderFirstName();
            textHolderLastName();
            textHolderSecurityAnswer();

            LoadCbGender();
            cbGender.SelectedIndex = 0;
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
        private void picPassword_Click(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = !tbPassword.UseSystemPasswordChar;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            tbUsername.Clear();
            tbPassword.Clear();
            tbEmail.Clear();
            tbBsn.Clear();
            tbFirstName.Clear();
            tbLastName.Clear();
            cbGender.SelectedIndex = 0;
            dtpBirthdate.Value = DateTime.Now;
            tbSecurityAnswer.Clear();

            textHolderUsername();
            textHolderPassword();
            textHolderEmail();
            textHolderBsn();
            textHolderFirstName();
            textHolderLastName();
            textHolderSecurityAnswer();
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
        private void tbEmail_GotFocus(object sender, EventArgs e)
        {
            if (tbEmail.Text == textEmail)
            {
                tbEmail.Text = "";
                tbEmail.ForeColor = SystemColors.WindowText;
            }
        }
        private void tbEmail_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                tbEmail.Text = textEmail;
                tbEmail.ForeColor = SystemColors.GrayText;
            }
        }
        private void textHolderEmail()
        {
            tbEmail.Text = textEmail;
            tbEmail.ForeColor = SystemColors.GrayText;
            tbEmail.GotFocus += tbEmail_GotFocus;
            tbEmail.LostFocus += tbEmail_LostFocus;
        }
        private void tbBsn_GotFocus(object sender, EventArgs e)
        {
            if (tbBsn.Text == textBsn)
            {
                tbBsn.Text = "";
                tbBsn.ForeColor = SystemColors.WindowText;
            }
        }
        private void tbBsn_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbBsn.Text))
            {
                tbBsn.Text = textBsn;
                tbBsn.ForeColor = SystemColors.GrayText;
            }
        }
        private void textHolderBsn()
        {
            tbBsn.Text = textBsn;
            tbBsn.ForeColor = SystemColors.GrayText;
            tbBsn.GotFocus += tbBsn_GotFocus;
            tbBsn.LostFocus += tbBsn_LostFocus;
        }
        private void tbFirstName_GotFocus(object sender, EventArgs e)
        {
            if (tbFirstName.Text == textFirstName)
            {
                tbFirstName.Text = "";
                tbFirstName.ForeColor = SystemColors.WindowText;
            }
        }
        private void tbFirstName_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbFirstName.Text))
            {
                tbFirstName.Text = textFirstName;
                tbFirstName.ForeColor = SystemColors.GrayText;
            }
        }
        private void textHolderFirstName()
        {
            tbFirstName.Text = textFirstName;
            tbFirstName.ForeColor = SystemColors.GrayText;
            tbFirstName.GotFocus += tbFirstName_GotFocus;
            tbFirstName.LostFocus += tbFirstName_LostFocus;
        }
        private void tbLastName_GotFocus(object sender, EventArgs e)
        {
            if (tbLastName.Text == textLastName)
            {
                tbLastName.Text = "";
                tbLastName.ForeColor = SystemColors.WindowText;
            }
        }
        private void tbLastName_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLastName.Text))
            {
                tbLastName.Text = textLastName;
                tbLastName.ForeColor = SystemColors.GrayText;
            }
        }
        private void textHolderLastName()
        {
            tbLastName.Text = textLastName;
            tbLastName.ForeColor = SystemColors.GrayText;
            tbLastName.GotFocus += tbBsn_GotFocus;
            tbLastName.LostFocus += tbBsn_LostFocus;
        }
        private void LoadCbGender()
        {
            foreach (Gender gender in Enum.GetValues(typeof(Gender)))
            {
                cbGender.Items.Add(gender);
            }
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
        private void lblLogin_Click(object sender, EventArgs e)
        {
            AuthenticationForm parentForm = this.ParentForm as AuthenticationForm;
            parentForm.ClearPanel();
            parentForm.LoadLogin();
        }
        private void lblLogin_MouseHover(object sender, EventArgs e)
        {
            lblLogin.ForeColor = Color.FromArgb(255, 255, 255);
        }
        private void lblLogin_MouseLeave(object sender, EventArgs e)
        {
            lblLogin.ForeColor = Color.FromArgb(61, 83, 143);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //add logic

            HomePageForm homePage = new HomePageForm();
            homePage.Show();

            Form parentForm = this.ParentForm;
            parentForm.Hide();
        }
    }
}
