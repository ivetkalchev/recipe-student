using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recipe
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
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
            this.Close();
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
            if (tbUsername.Text == "")
            {
                MessageBox.Show("Please enter your username");
                return false;
            }
            else if (tbPassword.Text == "")
            {
                MessageBox.Show("Please enter your password");
                return false;
            }
            else if (tbBSN.Text == "")
            {
                MessageBox.Show("Please enter your BSN");
                return false;
            }
            else if (cbGender.SelectedIndex == 0)
            {
                MessageBox.Show("Please select your gender");
                return false;
            }
            else if (tbEmail.Text == "")
            {
                MessageBox.Show("Please enter your email");
                return false;
            }
            else if (tbFirstName.Text == "")
            {
                MessageBox.Show("Please enter your first name");
                return false;
            }
            else if (tbLastName.Text == "")
            {
                MessageBox.Show("Please enter your last name");
                return false;
            }
            else if (dtpBirthdate.Value == DateTime.Today)
            {
                MessageBox.Show("Please select your birthdate");
                return false;
            }

            return true;
        }

        private void btnRegister_Click(object sender, EventArgs e)
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

                //add logic

                MessageBox.Show("Registration successful!");
                ClearInput();
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }
        }
    }
}
