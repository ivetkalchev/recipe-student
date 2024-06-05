using entity_classes;
using exceptions;
using manager_classes;
using System.Collections.Generic;
using System.Windows.Forms;

namespace recipe_desktop
{
    public partial class AddRecipeForm : Form
    {
        List<MenuUC> menuButtons;

        public AddRecipeForm()
        {
            InitializeComponent();

            menuButtons = new List<MenuUC>() { AddDessert, AddMainCourse, AddDrink };
            ClickMenu(menuButtons);
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

            switch (menuButton.Name)
            {
                case "AddDessert": 
                    LoadAddDessert();
                    break;

                case "AddMainCourse":
                    LoadAddMainCourse();
                    break;

                case "AddDrink":
                    LoadAddDrink();
                    break;

                default:
                    MessageBox.Show("Unknown menu button clicked");
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadAddDrink()
        {
            this.Close();

            AddDrinkForm addDrink = new AddDrinkForm();
            addDrink.Show();
        }

        private void LoadAddDessert()
        {
            this.Close();

            AddDessertForm addDessert = new AddDessertForm();
            addDessert.Show();
        }

        private void LoadAddMainCourse()
        {
            this.Close();

            AddMainCourseForm addMainCourse = new AddMainCourseForm();
            addMainCourse.Show();
        }
    }
}
