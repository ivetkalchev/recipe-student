﻿using System;
using System.Drawing;
using System.Windows.Forms;
using entity_classes;
using manager_classes;
using enum_classes;
using exceptions;

namespace recipe_desktop
{
    public partial class RegisterUC : UserControl
    {
        private IUserManager userManager;

        public RegisterUC(IUserManager userManager)
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

            Role employeeRole = new Role(2, "Employee", new List<Permission>());

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
                    MessageBox.Show("User registered successfully!");
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
            cbGender.SelectedIndex = 0;
            dtpBirthdate.Value = DateTime.Now;
            tbSecurityAnswer.Clear();
        }
    }
}
