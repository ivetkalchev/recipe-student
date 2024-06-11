using entity_classes;
using exceptions;
using manager_classes;

namespace recipe_desktop
{
    public partial class SettingsUC : UserControl
    {
        private DesktopUser user;
        private IUserManager userManager;

        public SettingsUC(DesktopUser user, IUserManager userManager)
        {
            InitializeComponent();

            this.user = user;
            this.userManager = userManager;

            LoadUserDetails();
            LockTextBoxes();
            LoadGender();
        }

        private void LoadUserDetails()
        {
            tbFirstName.Text = user.FirstName;
            tbLastName.Text = user.LastName;
            tbUsername.Text = user.Username;
            tbEmail.Text = user.Email;
            dtpBirthdate.Value = user.Birthdate;
            cbGenders.SelectedItem = user.Gender.NameGender;
            tbBSN.Text = user.Bsn.ToString();
            tbRole.Text = user.Role.NameRole;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newFirstName = tbFirstName.Text.Trim();
            string newLastName = tbLastName.Text.Trim();
            string newEmail = tbEmail.Text.Trim();
            DateTime newBirthdate = dtpBirthdate.Value;
            Gender newGender = userManager.GetGenderByName(cbGenders.SelectedItem.ToString());
            int.TryParse(tbBSN.Text.Trim(), out int newBSN);

            if (string.IsNullOrWhiteSpace(newFirstName) || string.IsNullOrWhiteSpace(newLastName) || string.IsNullOrWhiteSpace(newEmail))
            {
                MessageBox.Show("All fields must be filled.");
                return;
            }

            try
            {
                userManager.UpdateDesktopUserDetails(user, newFirstName, newLastName, newEmail, newBirthdate, newGender, newBSN);
                MessageBox.Show("Changes saved successfully!");

                LockTextBoxes();
            }
            catch (InvalidUserException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LockTextBoxes()
        {
            tbFirstName.Enabled = false;
            tbLastName.Enabled = false;
            tbUsername.Enabled = false;
            tbEmail.Enabled = false;
            dtpBirthdate.Enabled = false;
            cbGenders.Enabled = false;
            tbBSN.Enabled = false;
            tbRole.Enabled = false;

            btnSave.Enabled = false;
        }

        private void UnlockTextBoxes()
        {
            tbFirstName.Enabled = true;
            tbLastName.Enabled = true;
            tbEmail.Enabled = true;
            dtpBirthdate.Enabled = true;
            cbGenders.Enabled = true;
            tbBSN.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            UnlockTextBoxes();
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

        private void LoadGender()
        {
            var genders = userManager.GetAllGenders();
            cbGenders.Items.Clear();
            foreach (var gender in genders)
            {
                cbGenders.Items.Add(gender.NameGender);
            }
            if (cbGenders.Items.Count > 0)
            {
                cbGenders.SelectedIndex = cbGenders.FindStringExact(user.Gender.NameGender);
            }
        }
    }
}
