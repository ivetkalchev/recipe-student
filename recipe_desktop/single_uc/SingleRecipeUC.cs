using entity_classes;
using manager_classes;

namespace recipe_desktop
{
    public partial class SingleRecipeUC : UserControl
    {
        private Recipe recipe;
        private IRecipeManager recipeManager;
        private IIngredientManager ingredientManager;

        public event EventHandler RecipeDeleted;

        public SingleRecipeUC(IRecipeManager recipeManager, IIngredientManager ingredientManager, Recipe recipe)
        {
            InitializeComponent();

            this.recipeManager = recipeManager;
            this.ingredientManager = ingredientManager;
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
            if (recipePic != null && !string.IsNullOrEmpty(recipePic.GetData()))
            {
                picRecipe.Image = ConvertBase64ToImage(recipePic.GetData());
            }
            else
            {
                string defaultImagePath = @"Resources\image-missing-icon-2048x2048-9it6buq7.png";
                string executablePath = AppDomain.CurrentDomain.BaseDirectory;
                string fullPath = Path.Combine(executablePath, defaultImagePath);

                if (File.Exists(fullPath))
                {
                    picRecipe.Image = Image.FromFile(fullPath);
                }
            }
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
            recipeManager.DeleteRecipe(recipe.GetIdRecipe());
            RecipeDeleted?.Invoke(this, EventArgs.Empty);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (recipe is MainCourse mainCourse)
            {
                EditMainCourseForm editForm = new EditMainCourseForm(mainCourse, recipeManager, ingredientManager);
                editForm.Show();
            }
            else if (recipe is Drink drink)
            {
                EditDrinkForm editForm = new EditDrinkForm(drink, recipeManager, ingredientManager);
                editForm.Show();
            }
            else if (recipe is Dessert dessert)
            {
                EditDessertForm editForm = new EditDessertForm(dessert, recipeManager, ingredientManager);
                editForm.Show();
            }
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