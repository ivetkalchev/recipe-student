using entity_classes;
using manager_classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recipe_desktop
{
    public partial class EditEmployeeForm : Form
    {
        private DesktopUser currentUser;
        private IUserManager userManager;

        public EditEmployeeForm(IUserManager userManager, DesktopUser currentUser)
        {
            InitializeComponent();
            this.userManager = userManager;
            this.currentUser = currentUser;

            LoadUserDetails();
            LockTextBoxes();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadUserDetails()
        {
            tbFirstName.Text = currentUser.GetFirstName();
            tbLastName.Text = currentUser.GetLastName();
            tbUsername.Text = currentUser.GetUsername();
            tbEmail.Text = currentUser.GetEmail();
            tbBirthdate.Text = currentUser.GetBirthdate().ToString("dd-MM-yyyy");
            tbGender.Text = currentUser.GetGender().GetName();
            tbBSN.Text = currentUser.GetBsn().ToString();
            tbRole.Text = currentUser.GetRole().GetName();
        }

        private void LockTextBoxes()
        {
            tbFirstName.Enabled = false;
            tbLastName.Enabled = false;
            tbUsername.Enabled = false;
            tbEmail.Enabled = false;
            tbBirthdate.Enabled = false;
            tbGender.Enabled = false;
            tbBSN.Enabled = false;
            tbRole.Enabled = false;

            btnSave.Enabled = false;
        }

        private void UnlockTextBoxes()
        {
            tbLastName.Enabled = true;
            tbEmail.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newLastName = tbLastName.Text.Trim();
            string newEmail = tbEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(newLastName) || string.IsNullOrWhiteSpace(newEmail))
            {
                MessageBox.Show("All fields must be filled.");
                return;
            }

            userManager.UpdateUserDetails(currentUser, newLastName, newEmail);
            MessageBox.Show("Changes saved successfully!");

            btnSave.Enabled = false;
            LockTextBoxes();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            UnlockTextBoxes();
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
