using System;
using System.Collections.Generic;
using System.Windows.Forms;
using manager_classes;
using db_helpers;
using entity_classes;

namespace recipe_desktop
{
    public partial class HomePage : Form
    {
        private DesktopUser currentUser;
        private IUserManager userManager;
        private IIngredientManager ingredientManager;

        List<MenuUC> menuButtons;

        public HomePage(IUserManager userManager, DesktopUser user)
        {
            InitializeComponent();

            menuButtons = new List<MenuUC>() { Dashboard, Recipes, Ingredients, Employees, Settings, Log_Out };
            ClickMenu(menuButtons);

            this.userManager = userManager;
            this.currentUser = user;
            //this.ingredientManager = new IngredientManager(new DBIngredientHelper());

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

                case "Ingredients":
                    lblHeaderText.Text = "Ingredients";
                    LoadIngredients();
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
            Authentication authForm = new Authentication();
            authForm.Show();
            this.Close();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            LoadDashboard();
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

        public void LoadIngredients()
        {
            IngredientsUC ingredientsUC = new IngredientsUC(ingredientManager);
            ingredientsUC.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(ingredientsUC);
        }

        public void ClearPanel()
        {
            mainPanel.Controls.Clear();
        }
    }
}
