using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using manager_classes;
using entity_classes;
using db_helpers;

namespace recipe_desktop
{
    public partial class HomePageForm : Form
    {
        private DesktopUser currentUser;
        private IUserManager userManager;

        List<MenuUC> menuButtons;

        public HomePageForm(IUserManager userManager, DesktopUser user)
        {
            InitializeComponent();
            menuButtons = new List<MenuUC>() { Dashboard, Recipes, Employees, Settings, Log_Out };
            ClickMenu(menuButtons);
            this.userManager = userManager;
            this.currentUser = user;

            if (currentUser.GetRole().GetName() != "Admin")
            {
                Employees.Enabled = false;
            }
        }

        private void ClickMenu(List<MenuUC> menus)
        {
            foreach (var menu in menus)
            {
                menu.MenuClick += Menu_menuClick;
            }
        }

        private void Menu_menuClick(object sender, EventArgs e)
        {
            MenuUC menuButton = (MenuUC)sender;
            ClearPanel();

            switch (menuButton.Name)
            {
                case "Dashboard":
                    lblHeaderText.Text = "Dashboard";
                    LoadDashboard();
                    break;

                case "Recipes":
                    lblHeaderText.Text = "Recipes";
                    LoadRecipes();
                    break;

                case "Employees":
                    if (Employees.Enabled)
                    {
                        lblHeaderText.Text = "Employees";
                        LoadEmployees();
                    }
                    break;

                case "Settings":
                    lblHeaderText.Text = "Settings";
                    LoadSettings();
                    break;

                case "Log_Out":
                    LogOut();
                    break;
            }
        }

        private void LogOut()
        {
            AuthenticationForm authForm = new AuthenticationForm();
            authForm.Show();
            this.Close();
        }

        private void HomePageForm_Load(object sender, EventArgs e)
        {
            LoadBar();
            LoadDashboard();
        }

        private void LoadBar()
        {
            BarUC barUC = new BarUC();
            barUC.Dock = DockStyle.Fill;
            panelBar.Controls.Add(barUC);
        }

        public void LoadSettings()
        {
            SettingsUC settingsUC = new SettingsUC(userManager, currentUser);
            settingsUC.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(settingsUC);
        }

        public void LoadDashboard()
        {
            DashBoardUC dashboardUC = new DashBoardUC(userManager, currentUser);
            dashboardUC.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(dashboardUC);
        }

        public void LoadRecipes()
        {
            RecipesUC recipesUC = new RecipesUC();
            recipesUC.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(recipesUC);
        }

        public void LoadEmployees()
        {
            EmployeesUC employeesUC = new EmployeesUC(userManager);
            employeesUC.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(employeesUC);
        }

        public void ClearPanel()
        {
            mainPanel.Controls.Clear();
        }
    }
}
