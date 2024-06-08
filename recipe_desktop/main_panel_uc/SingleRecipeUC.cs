using entity_classes;
using manager_classes;
using System;
using System.Windows.Forms;

namespace recipe_desktop
{
    public partial class SingleRecipeUC : UserControl
    {
        private Recipe recipe;
        private IRecipeManager recipeManager;

        public event EventHandler RecipeDeleted;

        public SingleRecipeUC(IRecipeManager recipeManager, Recipe recipe)
        {
            InitializeComponent();

            this.recipeManager = recipeManager;
            this.recipe = recipe;

            LoadRecipeDetails();
        }

        private void LoadRecipeDetails()
        {
            SetPicture(recipe.GetRecipePic());
            SetTitle(recipe.GetTitle());
            SetUser(recipe.GetUser().GetUsername());
        }

        public void SetPicture(RecipePic recipePic)
        {
            picRecipe.Image = ConvertBase64ToImage(recipePic.GetData());
        }

        public void SetTitle(string title)
        {
            lblTitle.Text = title;
        }

        public void SetUser(string username)
        {
            lblUser.Text = username;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //recipeManager.DeleteRecipe(recipe.GetIdRecipe());
            //RecipeDeleted?.Invoke(this, EventArgs.Empty);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //EditRecipeForm editRecipe = new EditRecipeForm(recipe, recipeManager);
            //editRecipe.Show();
        }

        private Image ConvertBase64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                ms.Write(imageBytes, 0, imageBytes.Length);
                return Image.FromStream(ms, true);
            }
        }
    }
}
