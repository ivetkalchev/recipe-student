using System;
using System.Collections.Generic;
using System.Windows.Forms;
using entity_classes;
using manager_classes;

namespace recipe_desktop
{
    public partial class AddRecipeForm : Form
    {
        private DesktopUser user;
        private IRecipeManager recipeManager;
        private IIngredientManager ingredientManager;

        private List<MenuUC> menuButtons;

        public AddRecipeForm(DesktopUser user, IRecipeManager recipeManager, IIngredientManager ingredientManager)
        {
            InitializeComponent();

            this.user = user;
            this.recipeManager = recipeManager;
            this.ingredientManager = ingredientManager;

            this.menuButtons = new List<MenuUC> { MainCourse, Dessert, Drink };

            InitializeMenuButtons();
            LoadMainCourse();
        }

        private void InitializeMenuButtons()
        {
            foreach (var menu in menuButtons)
            {
                menu.MenuClick += MenuButton_Click;
            }
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            if (sender is MenuUC menuButton)
            {
                ClearPanel();
                switch (menuButton.Name)
                {
                    case nameof(MainCourse):
                        lblHeaderText.Text = "Add A Main Course Recipe";
                        LoadMainCourse();
                        break;
                    case nameof(Dessert):
                        lblHeaderText.Text = "Add A Dessert Recipe";
                        LoadDessert();
                        break;
                    case nameof(Drink):
                        lblHeaderText.Text = "Add A Drink Recipe";
                        LoadDrink();
                        break;
                }
            }
        }

        private void LoadMainCourse()
        {
            LoadRecipeUserControl(new AddMainCourseUC(user, recipeManager, ingredientManager));
        }

        private void LoadDessert()
        {
            LoadRecipeUserControl(new AddDessertUC(user, recipeManager, ingredientManager));
        }

        private void LoadDrink()
        {
            LoadRecipeUserControl(new AddDrinkUC(user, recipeManager, ingredientManager));
        }

        private void LoadRecipeUserControl(UserControl recipeUserControl)
        {
            recipeUserControl.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(recipeUserControl);
        }

        private void ClearPanel()
        {
            mainPanel.Controls.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
