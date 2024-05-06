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

namespace recipe_desktop
{
    public partial class ForgottenPasswordUC : UserControl
    {

        public ForgottenPasswordUC()
        {
            InitializeComponent();
        }
        private void lblRegister_MouseHover(object sender, EventArgs e)
        {
            lblRegister.ForeColor = Color.FromArgb(255, 255, 255);
        }
        private void lblRegister_MouseLeave(object sender, EventArgs e)
        {
            lblRegister.ForeColor = Color.FromArgb(61, 83, 143);
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //add logic

            HomePageForm homePage = new HomePageForm();
            homePage.Show();

            Form parentForm = this.ParentForm;
            parentForm.Hide();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            tbUsername.Clear();
            tbSecurityAnswer.Clear();
        }
        private void lblRegister_Click(object sender, EventArgs e)
        {
            AuthenticationForm parentForm = this.ParentForm as AuthenticationForm;
            parentForm.ClearPanel();
            parentForm.LoadRegister();
        }
        private void lblLogin_MouseHover(object sender, EventArgs e)
        {
            lblLogin.ForeColor = Color.FromArgb(61, 83, 143);
        }
        private void lblLogin_MouseLeave(object sender, EventArgs e)
        {
            lblLogin.ForeColor = Color.FromArgb(255, 255, 255);
        }
        private void lblLogin_Click(object sender, EventArgs e)
        {
            AuthenticationForm parentForm = this.ParentForm as AuthenticationForm;
            parentForm.ClearPanel();
            parentForm.LoadLogin();
        }
    }
}
