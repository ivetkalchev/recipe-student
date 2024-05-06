using DAOs;
using manager_classes;
using System;
using System.Windows.Forms;

namespace recipe_desktop
{
    public partial class AuthenticationForm : Form
    {
        private UserManager userManager;
        public AuthenticationForm()
        {
            InitializeComponent();
            //CheckConnection();

            userManager = new UserManager(new UserDAO());
        }

        public void CheckConnection()
        {
            if (!DatabaseConnection.CheckConnection())
            {
                MessageBox.Show("Failed to connect to the database.");
                return;
            }
            else
            {
                MessageBox.Show("Connected to the database.");
                return;
            }
        }

        private void AuthenticationForm_Load(object sender, EventArgs e)
        {           
            LoadBar();
            LoadLogin();
        }

        private void LoadBar()
        {
            BarUC barUC = new BarUC();
            barUC.Dock = DockStyle.Fill;
            panelBar.Controls.Add(barUC);
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

        public void LoadForgottenPassword()
        {
            ForgottenPasswordUC fpUC = new ForgottenPasswordUC();
            fpUC.Dock = DockStyle.Fill;
            panelInput.Controls.Add(fpUC);
        }

        public void LoadRegister()
        {
            RegisterUC registerUC = new RegisterUC();
            registerUC.Dock = DockStyle.Fill;
            panelInput.Controls.Add(registerUC);
        }
    }
}
