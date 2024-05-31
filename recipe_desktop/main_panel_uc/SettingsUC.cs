using System;
using System.Windows.Forms;
using entity_classes;
using manager_classes;

namespace recipe_desktop
{
    public partial class SettingsUC : UserControl
    {
        private IUserManager userManager;
        private DesktopUser currentUser;

        public SettingsUC(IUserManager userManager, DesktopUser user)
        {
            InitializeComponent();

            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.currentUser = user ?? throw new ArgumentNullException(nameof(user));

            btnSave.Enabled = false;

            LoadUserDetails();
            LockTextBoxes();
        }

        private void LoadUserDetails()
        {
            tbFirstName.Text = currentUser.GetFirstName();
            tbLastName.Text = currentUser.GetLastName();
            tbUsername.Text = currentUser.GetUsername();
            tbEmail.Text = currentUser.GetEmail();
            tbBirthdate.Text = currentUser.GetBirthdate().ToString("yyyy-MM-dd");
            tbBSN.Text = currentUser.GetBsn().ToString();
            tbRole.Text = currentUser.GetRole().GetName();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newLastName = tbLastName.Text;
            string newUsername = tbUsername.Text;
            string newEmail = tbEmail.Text;

            if (string.IsNullOrWhiteSpace(newLastName) || string.IsNullOrWhiteSpace(newUsername) || string.IsNullOrWhiteSpace(newEmail))
            {
                MessageBox.Show("All fields must be filled.");
                return;
            }

            userManager.UpdateUserDetails(currentUser, newLastName, newUsername, newEmail);
            MessageBox.Show("Changes saved successfully! Reset the application to see the changes.");

            btnSave.Enabled = false;
            LockTextBoxes();
        }

        private void LockTextBoxes()
        {
            tbFirstName.Enabled = false;
            tbLastName.Enabled = false;
            tbUsername.Enabled = false;
            tbEmail.Enabled = false;
            tbBirthdate.Enabled = false;
            tbBSN.Enabled = false;
            tbRole.Enabled = false;
        }

        private void UnlockTextBoxes()
        {
            tbLastName.Enabled = true;
            tbUsername.Enabled = true;
            tbEmail.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            UnlockTextBoxes();
        }
    }
}
