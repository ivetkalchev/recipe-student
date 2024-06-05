using manager_classes;

namespace recipe_desktop
{
    public partial class RecipesUC : UserControl
    {
        public RecipesUC()
        {
            InitializeComponent();
        }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            AddRecipeForm addRecipe = new AddRecipeForm();
            addRecipe.Show();
        }
    }
}
