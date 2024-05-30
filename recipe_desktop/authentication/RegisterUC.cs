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
using entity_classes;
using manager_classes;
using Microsoft.VisualBasic.ApplicationServices;
using enum_classes;

namespace recipe_desktop
{
    public partial class RegisterUC : UserControl
    {
        private UserManager userManager;
        public RegisterUC(UserManager userManager)
        {
            InitializeComponent();

            LoadCbGender();
            cbGender.SelectedIndex = 0;
            dtpBirthdate.Value = DateTime.Now;

            this.userManager = userManager;
        }

        private void picPassword_Click(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = !tbPassword.UseSystemPasswordChar;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void LoadCbGender()
        {
            foreach (Gender gender in Enum.GetValues(typeof(Gender)))
            {
                cbGender.Items.Add(gender);
            }
        }

        private void LoadLogin()
        {
            AuthenticationForm parentForm = this.ParentForm as AuthenticationForm;
            parentForm?.ClearPanel();
            parentForm?.LoadLogin();
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
            int bsn;
            bool isBsnValid = int.TryParse(tbBsn.Text, out bsn);
            Gender gender = (Gender)Enum.Parse(typeof(Gender), cbGender.SelectedItem.ToString());
            DateTime birthdate = dtpBirthdate.Value.Date;
            string securityAnswer = tbSecurityAnswer.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(plainPassword) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                !isBsnValid ||
                string.IsNullOrWhiteSpace(securityAnswer))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Create the Role object (assuming role ID 2 is for Employee)
            Role employeeRole = new Role(2, "Employee", new List<Permission>());

            // Create a new DesktopUser
            DesktopUser newUser = new DesktopUser(
                0, // The ID will be set by the database
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

            // Attempt to register the user
            if (userManager.RegisterDesktopUser(newUser))
            {
                MessageBox.Show("User registered successfully!");
                ClearFields();
                LoadLogin();
            }
            else
            {
                MessageBox.Show("Registration failed. The email or BSN might already be taken.");
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
            cbGender.SelectedIndex = 0;
            dtpBirthdate.Value = DateTime.Now;
            tbSecurityAnswer.Clear();
        }
    }
}
