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
        private string textSecurityAnswer = " your answer";
        public ForgottenPasswordUC()
        {
            InitializeComponent();
            textHolderSecAnswer();
        }
        private void tbSecAnswer_GotFocus(object sender, EventArgs e)
        {
            if (tbSecAnswer.Text == textSecurityAnswer)
            {
                tbSecAnswer.Text = "";
                tbSecAnswer.ForeColor = SystemColors.WindowText;
            }
        }
        private void tbSecAnswer_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSecAnswer.Text))
            {
                tbSecAnswer.Text = textSecurityAnswer;
                tbSecAnswer.ForeColor = SystemColors.GrayText;
            }
        }
        private void textHolderSecAnswer()
        {
            tbSecAnswer.Text = textSecurityAnswer;
            tbSecAnswer.ForeColor = SystemColors.GrayText;
            tbSecAnswer.GotFocus += tbSecAnswer_GotFocus;
            tbSecAnswer.LostFocus += tbSecAnswer_LostFocus;
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

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbSecAnswer.Clear();
            textHolderSecAnswer();
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            AuthenticationForm parentForm = this.ParentForm as AuthenticationForm;
            parentForm.ClearPanel();
            parentForm.LoadRegister();
        }
    }
}
