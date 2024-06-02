using db_helpers;
using manager_classes;
using System;
using System.Windows.Forms;

namespace recipe_desktop
{
    public partial class Authentication : Form
    {
        private UserManager userManager;
        public Authentication()
        {
            InitializeComponent();
            userManager = new UserManager(new DBUserHelper());
        }

        private void AuthenticationForm_Load(object sender, EventArgs e)
        {
            LoadLogin();
        }

        public void ClearPanel()
        {
            panelInput.Controls.Clear();
        }

        public void LoadLogin()
        {
            LoginUC loginUC = new LoginUC(userManager);
            loginUC.Dock = DockStyle.Fill;
            panelInput.Controls.Add(loginUC);
        }

        public void LoadRegister()
        {
            RegisterUC registerUC = new RegisterUC(userManager);
            registerUC.Dock = DockStyle.Fill;
            panelInput.Controls.Add(registerUC);
        }
    }
}
