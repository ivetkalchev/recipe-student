using entity_classes;
using exceptions;
using manager_classes;
using System;
using System.Drawing;
using System.Windows.Forms;

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
            LoadToday();
        }

        private void picPassword_Click(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = !tbPassword.UseSystemPasswordChar;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void LoadToday()
        {
            dtpBirthdate.Value = DateTime.Now;
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
            AuthenticationForm parentForm = this.ParentForm as AuthenticationForm;
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
            try
            {
                string username = tbUsername.Text.Trim();
                string plainPassword = tbPassword.Text.Trim();
                Role employeeRole = new Role(2, "Employee");
                string email = tbEmail.Text.Trim();
                int.TryParse(tbBsn.Text.Trim(), out int bsn);
                string firstName = tbFirstName.Text.Trim();
                string lastName = tbLastName.Text.Trim();
                Gender gender = userManager.GetGenderByName(cbGenders.SelectedItem.ToString());
                DateTime birthdate = dtpBirthdate.Value.Date;

                if (string.IsNullOrWhiteSpace(username) ||
                    string.IsNullOrWhiteSpace(plainPassword) ||
                    string.IsNullOrWhiteSpace(email) ||
                    string.IsNullOrWhiteSpace(firstName) ||
                    string.IsNullOrWhiteSpace(lastName) ||
                    string.IsNullOrWhiteSpace(tbBsn.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

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
                    birthdate
                );

                newUser.UserValidation();
                newUser.DesktopUserValidation();

                userManager.RegisterDesktopUser(newUser);

                MessageBox.Show($"{username} is registered successfully!");
                ClearFields();
                LoadLogin();
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