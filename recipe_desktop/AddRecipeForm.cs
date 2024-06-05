using entity_classes;
using manager_classes;
using System;
using System.Collections.Generic;
using System.Drawing.Interop;
using System.Windows.Forms;

namespace recipe_desktop
{
    public partial class AddRecipeForm : Form
    {
        private DesktopUser user;
        private IRecipeManager recipeManager;
        private IIngredientManager ingredientManager;

        List<MenuUC> menuButtons;

        public AddRecipeForm(DesktopUser user, IRecipeManager recipeManager, IIngredientManager ingredientManager)
        {
            InitializeComponent();

            menuButtons = new List<MenuUC>() { MainCourse, Dessert, Drink };
            ClickMenu(menuButtons);

            this.user = user;
            this.recipeManager = recipeManager;
            this.ingredientManager = ingredientManager;

            LoadMainCourse(user, recipeManager, ingredientManager);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                case "MainCourse":
                    lblHeaderText.Text = "Add A Main Course Recipe";
                    LoadMainCourse(user, recipeManager, ingredientManager);
                    break;
                case "Dessert":
                    lblHeaderText.Text = "Add A Dessert Recipe";
                    LoadDessert(user, recipeManager, ingredientManager);
                    break;
                case "Drink":
                    lblHeaderText.Text = "Add A Drink Recipe";
                    LoadDrink(user, recipeManager, ingredientManager);
                    break;
            }
        }

        public void LoadMainCourse(DesktopUser user, IRecipeManager recipeManager, IIngredientManager ingredientManager)
        {
            AddMainCourseUC mainCourseUC = new AddMainCourseUC(user, recipeManager, ingredientManager);
            mainCourseUC.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(mainCourseUC);
        }

        public void LoadDessert(DesktopUser user, IRecipeManager recipeManager, IIngredientManager ingredientManager)
        {
            AddDessertUC dessertUC = new AddDessertUC(user, recipeManager, ingredientManager);
            dessertUC.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(dessertUC);
        }

        public void LoadDrink(DesktopUser user, IRecipeManager recipeManager, IIngredientManager ingredientManager)
        {
            AddDrinkUC drinkUC = new AddDrinkUC(user, recipeManager, ingredientManager);
            drinkUC.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(drinkUC);
        }

        public void ClearPanel()
        {
            mainPanel.Controls.Clear();
        }
    }
}
