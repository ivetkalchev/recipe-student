using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using entity_classes;
using manager_classes;
using exceptions;

namespace recipe_desktop
{
    public partial class RegisterUC : UserControl
    {
        private IUserManager userManager;
        public RegisterUC(IUserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
            LoadGender();
            dtpBirthdate.Value = DateTime.Now;
        }

        private void picPassword_Click(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = !tbPassword.UseSystemPasswordChar;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void LoadGender()
        {
            var genders = userManager.GetAllGenders();
            cbGenders.Items.Clear();
            foreach (var gender in genders)
            {
                cbGenders.Items.Add(gender.GetName());
            }
            if (cbGenders.Items.Count > 0)
            {
                cbGenders.SelectedIndex = 0;
            }
        }

        private void LoadLogin()
        {
            Authentication parentForm = this.ParentForm as Authentication;
            parentForm.ClearPanel();
            parentForm.LoadLogin();
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            LoadLogin();
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
            string username = tbUsername.Text;
            string plainPassword = tbPassword.Text;
            string email = tbEmail.Text;
            string firstName = tbFirstName.Text;
            string lastName = tbLastName.Text;
            string securityAnswer = tbSecurityAnswer.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(plainPassword) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(tbBsn.Text) ||
                string.IsNullOrWhiteSpace(securityAnswer))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!int.TryParse(tbBsn.Text, out int bsn))
            {
                MessageBox.Show("Please enter a valid numeric BSN.");
                return;
            }

            Gender gender = userManager.GetGenderByName(cbGenders.SelectedItem.ToString());
            DateTime birthdate = dtpBirthdate.Value.Date;
            Role employeeRole = new Role(2, "Employee");

            DesktopUser newUser = new DesktopUser(
                0,
                username,
                email,
                plainPassword,
                employeeRole,
                firstName,
                lastName,
                bsn,
                gender,
                birthdate,
                securityAnswer
            );

            try
            {
                if (userManager.RegisterDesktopUser(newUser))
                {
                    MessageBox.Show($"{username} is registered successfully!");
                    ClearFields();
                    LoadLogin();
                }
            }
            catch (InvalidUserException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearFields()
        {
            tbUsername.Clear();
            tbPassword.Clear();
            tbEmail.Clear();
            tbBsn.Clear();
            tbFirstName.Clear();
            tbLastName.Clear();
            cbGenders.SelectedIndex = 0;
            dtpBirthdate.Value = DateTime.Now;
            tbSecurityAnswer.Clear();
        }

        private void tbBsn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Please enter only numeric values for BSN.");
                e.Handled = true;
            }
        }

        private void tbFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("The first name is invalid. Your first name must contain only alphabetic characters.");
                e.Handled = true;
            }
        }

        private void tbLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("The last name is invalid. Your last name must contain only alphabetic characters.");
                e.Handled = true;
            }
        }
    }
}
