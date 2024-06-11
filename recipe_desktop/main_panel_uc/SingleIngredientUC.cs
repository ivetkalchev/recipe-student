using entity_classes;
using manager_classes;
using System.Globalization;

namespace recipe_desktop
{
    public partial class SingleIngredientUC : UserControl
    {
        private Ingredient ingredient;
        private IIngredientManager ingredientManager;

        public event EventHandler IngredientDeleted;
        public SingleIngredientUC(Ingredient ingredient, IIngredientManager ingredientManager)
        {
            InitializeComponent();

            this.ingredientManager = ingredientManager;
            this.ingredient = ingredient;

            LoadIngredientDetails();
        }

        private void LoadIngredientDetails()
        {
            SetName(ingredient.NameIngredient);
            SetType(ingredient.TypeIngredient.NameTypeIngredient);
        }

        public void SetName(string name)
        {
            lblName.Text = name;
        }

        public void SetType(string type)
        {
            lblType.Text = type;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ingredientManager.DeleteIngredient(ingredient);
            IngredientDeleted?.Invoke(this, EventArgs.Empty);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditIngredientForm editIngredient = new EditIngredientForm(ingredient, ingredientManager);
            editIngredient.Show();
        }
    }
}
