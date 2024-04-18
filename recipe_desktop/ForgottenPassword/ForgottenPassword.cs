using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using data_access;

namespace recipe_desktop
{
    public partial class ForgottenPassword : Form
    {
        private DataForgottenPassword dbFP;
        public ForgottenPassword()
        {
            InitializeComponent();
            dbFP = new DataForgottenPassword("Data Source=mssqlstud.fhict.local;Initial Catalog=dbi526066_recipe;User ID=dbi526066_recipe;Password=123123;Encrypt=False");
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
        }

        private void lblLogin_MouseHover(object sender, EventArgs e)
        {
            lblLogin.ForeColor = Color.FromArgb(255, 41, 107);
        }

        private void lblLogin_MouseLeave(object sender, EventArgs e)
        {
            lblLogin.ForeColor = Color.FromArgb(255, 130, 169);
        }

        private void lblRegister_MouseHover(object sender, EventArgs e)
        {
            lblRegister.ForeColor = Color.FromArgb(255, 130, 169);
        }

        private void lblRegister_MouseLeave(object sender, EventArgs e)
        {
            lblRegister.ForeColor = Color.FromArgb(255, 41, 107);
        }

        private void tbBSN_KeyPress(object sender, KeyPressEventArgs bsn)
        {
            if (!char.IsDigit(bsn.KeyChar) && bsn.KeyChar != '\b')
            {
                bsn.Handled = true;
                MessageBox.Show("Please enter only numbers.");
            }
            else if (tbBSN.Text.Length >= 9 && bsn.KeyChar != '\b')
            {
                bsn.Handled = true;
                MessageBox.Show("Maximum length reached (9 digits).");
            }
        }

        private void btnReveal_Click(object sender, EventArgs e)
        {
            string bsn = tbBSN.Text;

            if (string.IsNullOrEmpty(bsn))
            {
                MessageBox.Show("Please enter your BSN.");
                return;
            }

            try
            {
                var userData = dbFP.GetUserDataByBSN(bsn);

                if (userData.Item1 != null && userData.Item2 != null && userData.Item3 != null && userData.Item4 != null)
                {
                    string username = userData.Item1;
                    string password = userData.Item2;
                    string firstName = userData.Item3;
                    string lastName = userData.Item4;

                    MessageBox.Show($"The BSN matches {firstName} {lastName}.\n" +
                                    $"The password of {username} is {password}.");
                }
                else
                {
                    MessageBox.Show("No user found with this BSN.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
