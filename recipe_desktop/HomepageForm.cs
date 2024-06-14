using manager_classes;
using db_helpers;
using entity_classes;

namespace recipe_desktop
{
    public partial class HomePageForm : Form
    {
        private readonly DesktopUser user;
        private readonly IUserManager userManager;
        private readonly IIngredientManager ingredientManager;
        private readonly IRecipeManager recipeManager;

        private readonly List<MenuUC> menuButtons;

        public HomePageForm(DesktopUser user, IUserManager userManager)
        {
            InitializeComponent();

            this.user = user;
            this.userManager = userManager;
            
            this.ingredientManager = new IngredientManager(new DBIngredientHelper());
            this.recipeManager = new RecipeManager(new DBRecipeHelper(new DBUserHelper()));

            this.menuButtons = new List<MenuUC> { Dashboard, Recipes, Ingredients, Employees, Settings, Log_Out };
            AttachMenuClickEvents(menuButtons);

            DenyEmployeeAccess();
        }

        private void DenyEmployeeAccess()
        {
            if (user.GetRole().GetName() != "Admin")
            {
                Employees.Enabled = false;
            }
        }

        private void AttachMenuClickEvents(List<MenuUC> menus)
        {
            foreach (var menu in menus)
            {
                menu.MenuClick += MenuClickHandler;
            }
        }

        private void MenuClickHandler(object sender, EventArgs e)
        {
            var menuButton = sender as MenuUC;
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
            var authForm = new AuthenticationForm();
            authForm.Show();
        }

        private void HomePageForm_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void LoadSettings()
        {
            var settingsUC = new SettingsUC(user, userManager);
            settingsUC.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(settingsUC);
        }

        private void LoadDashboard()
        {
            var dashboardUC = new DashBoardUC(user, userManager);
            dashboardUC.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(dashboardUC);
        }

        private void LoadRecipes()
        {
            var recipesUC = new RecipesUC(user, recipeManager, ingredientManager);
            recipesUC.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(recipesUC);
        }

        private void LoadEmployees()
        {
            var employeesUC = new EmployeeUC(userManager);
            employeesUC.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(employeesUC);
        }

        private void LoadIngredients()
        {
            var ingredientsUC = new IngredientsUC(ingredientManager);
            ingredientsUC.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(ingredientsUC);
        }

        private void ClearPanel()
        {
            mainPanel.Controls.Clear();
        }
    }
}
