using manager_classes;
using db_helpers;
using entity_classes;

namespace recipe_desktop
{
    public partial class HomePageForm : Form
    {
        private DesktopUser user;
        private IUserManager userManager;
        private IIngredientManager ingredientManager;
        private IRecipeManager recipeManager;
        
        List<MenuUC> menuButtons;

        public HomePageForm(DesktopUser user, IUserManager userManager)
        {
            InitializeComponent();
            
            menuButtons = new List<MenuUC>() { Dashboard, Recipes, Ingredients, Employees, Settings, Log_Out };
            ClickMenu(menuButtons);

            this.userManager = userManager;
            this.user = user;
            this.ingredientManager = new IngredientManager(new DBIngredientHelper());
            this.recipeManager = new RecipeManager(new DBRecipeHelper());

            if (user.GetRole().GetName() != "Admin")
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
            this.Close();
            AuthenticationForm authForm = new AuthenticationForm();
            authForm.Show();
        }

        private void HomePageForm_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        public void LoadSettings()
        {
            SettingsUC settingsUC = new SettingsUC(user, userManager);
            settingsUC.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(settingsUC);
        }

        public void LoadDashboard()
        {
            DashBoardUC dashboardUC = new DashBoardUC(user, userManager);
            dashboardUC.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(dashboardUC);
        }

        public void LoadRecipes()
        {
            RecipesUC recipesUC = new RecipesUC(user, recipeManager, ingredientManager);
            recipesUC.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(recipesUC);
        }

        public void LoadEmployees()
        {
            EmployeeUC employeesUC = new EmployeeUC(userManager);
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
