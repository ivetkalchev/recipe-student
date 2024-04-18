using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using data_access;
using logic_layer;

namespace recipe_desktop
{
    public partial class Register : Form
    {
        private DataRegisterDesktop dbRegister;
        public Register()
        {
            InitializeComponent();
            LoadCbGender();
            dbRegister = new DataRegisterDesktop("Data Source=mssqlstud.fhict.local;Initial Catalog=dbi526066_recipe;User ID=dbi526066_recipe;Password=123123;Encrypt=False");
        }
        private void ClearInput()
        {
            tbUsername.Clear();
            tbPassword.Clear();
            tbBSN.Clear();
            cbGender.SelectedIndex = 0;
            tbEmail.Clear();
            tbFirstName.Clear();
            tbLastName.Clear();
            dtpBirthdate.Value = DateTime.Today;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }
        private void LoadCbGender()
        {
            foreach (Gender gender in Enum.GetValues(typeof(Gender)))
            {
                cbGender.Items.Add(gender);
            }
        }

        private void tbBSN_KeyPress(object sender, KeyPressEventArgs bsn)
        {
            if (!char.IsDigit(bsn.KeyChar) && bsn.KeyChar != '\b')
            {
                bsn.Handled = true;
                MessageBox.Show("Please enter only numbers");
            }
            else if (tbBSN.Text.Length >= 9 && bsn.KeyChar != '\b')
            {
                bsn.Handled = true;
                MessageBox.Show("Maximum length reached (9 digits)");
            }
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
        }

        private void lblLogin_MouseHover(object sender, EventArgs e)
        {
            lblLogin.ForeColor = Color.FromArgb(255, 130, 169);
        }

        private void lblLogin_MouseLeave(object sender, EventArgs e)
        {
            lblLogin.ForeColor = Color.FromArgb(255, 41, 107);
        }
        private bool CheckEmptySpaces()
        {
            DateTime today = DateTime.Today;
            DateTime minBirthdate = today.AddYears(-14);

            if (tbUsername.Text == "")
            {
                MessageBox.Show("Please enter your username.");
                return false;
            }
            else if (tbPassword.Text == "")
            {
                MessageBox.Show("Please enter your password.");
                return false;
            }
            else if (tbBSN.Text == "")
            {
                MessageBox.Show("Please enter your BSN.");
                return false;
            }
            else if (tbBSN.Text.Length < 7)
            {
                MessageBox.Show("BSN must be at least 8 characters long.");
                return false;
            }
            else if (cbGender.SelectedIndex == -1)
            {
                MessageBox.Show("Please select your gender.");
                return false;
            }
            else if (tbEmail.Text == "")
            {
                MessageBox.Show("Please enter your email.");
                return false;
            }
            else if (!tbEmail.Text.Contains("@"))
            {
                MessageBox.Show("Add @ to the email.");
                return false;
            }
            else if (tbFirstName.Text == "")
            {
                MessageBox.Show("Please enter your first name.");
                return false;
            }
            else if (ContainsDigitsOrSymbols(tbFirstName.Text))
            {
                MessageBox.Show("First name should not contain numbers.");
                return false;
            }
            else if (tbLastName.Text == "")
            {
                MessageBox.Show("Please enter your last name.");
                return false;
            }
            else if (ContainsDigitsOrSymbols(tbLastName.Text))
            {
                MessageBox.Show("Last name should not contain numbers.");
                return false;
            }
            else if (dtpBirthdate.Value.Date > minBirthdate)
            {
                MessageBox.Show("Please select a valid birthdate (at least 14 years).");
                return false;
            }
            return true;
        }
        bool ContainsDigitsOrSymbols(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c) || char.IsSymbol(c) || char.IsPunctuation(c))
                {
                    return true;
                }
            }
            return false;
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckEmptySpaces())
                {
                    string username = tbUsername.Text;
                    string password = tbPassword.Text;
                    string bsn = tbBSN.Text;
                    string gender = cbGender.SelectedItem.ToString();
                    string email = tbEmail.Text;
                    string firstName = tbFirstName.Text;
                    string lastName = tbLastName.Text;
                    DateTime birthdate = dtpBirthdate.Value;

                    CompanyUser companyUser = new CompanyUser(
                        username: username,
                        password: password,
                        email: email,
                        firstName: firstName,
                        lastName: lastName,
                        bsn: int.Parse(bsn),
                        gender: gender,
                        birthdate: birthdate
                    );

                    dbRegister.OpenConnection();

                    if (dbRegister.DoesBSNExist(bsn))
                    {
                        MessageBox.Show("BSN is already registered.");
                        return;
                    }

                    if (dbRegister.DoesUsernameExist(username))
                    {
                        MessageBox.Show("Username is already registered. Please choose a different one.");
                        return;
                    }

                    if (dbRegister.DoesEmailExist(email))
                    {
                        MessageBox.Show("Email is already registered. Please choose a different one.");
                        return;
                    }

                    dbRegister.InsertUser(username, password, bsn, gender, email, firstName, lastName, birthdate);

                    MessageBox.Show($"Registration successful!\n" +
                        $"Welcome to the company, {firstName} {lastName}!");

                    Homepage homepage = new Homepage();
                    homepage.Show();

                    ClearInput();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                dbRegister.CloseConnection();
            }
        }
    }
}