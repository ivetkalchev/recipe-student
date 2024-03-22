namespace recipe
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void lblForgottenPassword_Click(object sender, EventArgs e)
        {
            ForgottenPassword forgottenPassword = new ForgottenPassword();
            forgottenPassword.ShowDialog();
            this.Close();
        }
        private void lblRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
            this.Close();
        }

        private void lblForgottenPassword_MouseHover(object sender, EventArgs e)
        {
            lblForgottenPassword.ForeColor = Color.FromArgb(255, 130, 169);
        }

        private void lblForgottenPassword_MouseLeave(object sender, EventArgs e)
        {
            lblForgottenPassword.ForeColor = Color.FromArgb(255, 41, 107);
        }

        private void lblRegister_MouseHover(object sender, EventArgs e)
        {
            lblRegister.ForeColor = Color.FromArgb(255, 130, 169);
        }

        private void lblRegister_MouseLeave(object sender, EventArgs e)
        {
            lblRegister.ForeColor = Color.FromArgb(255, 41, 107);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbUsername.Clear();
            tbPassword.Clear();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
        }
    }
}
