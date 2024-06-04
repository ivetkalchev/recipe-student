using entity_classes;
using exceptions;
using manager_classes;

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
            LoadGender();
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
            dtpBirthdate.Value = currentUser.GetBirthdate();
            cbGenders.SelectedItem = currentUser.GetGender().GetName();
            tbBSN.Text = currentUser.GetBsn().ToString();
            tbRole.Text = currentUser.GetRole().GetName();
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
                userManager.UpdateUserDetails(currentUser, newFirstName, newLastName, newEmail, newBirthdate, newGender, newBSN);
                MessageBox.Show("Changes saved successfully!");

                btnSave.Enabled = false;
                LockTextBoxes();
            }
            catch (InvalidUserException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            UnlockTextBoxes();
        }

        private void tbFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("The last name is invalid. Your last name must contain only alphabetic characters.");
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

        private void tbBSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Please enter only numeric values for BSN.");
                e.Handled = true;
            }
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
                cbGenders.SelectedIndex = cbGenders.FindStringExact(currentUser.GetGender().GetName());
            }
        }
    }
}
