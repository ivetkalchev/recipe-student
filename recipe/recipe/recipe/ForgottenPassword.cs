using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace recipe
{
    public partial class ForgottenPassword : Form
    {
        public ForgottenPassword()
        {
            InitializeComponent();
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
            this.Close();
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            this.Close();
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
    }
}
