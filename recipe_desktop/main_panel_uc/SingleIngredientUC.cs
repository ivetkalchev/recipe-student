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
            SetId(ingredient.GetIdIngredient());
            SetName(ingredient.GetName());
            SetType(ingredient.GetTypeIngredient().GetName());
            SetPrice(ingredient.GetPrice());
        }

        public void SetId(int id)
        {
            lblId.Text = id.ToString();
        }

        public void SetName(string name)
        {
            lblName.Text = name;
        }

        public void SetType(string type)
        {
            lblType.Text = type;
        }

        public void SetPrice(decimal price)
        {
            CultureInfo euroCulture = new CultureInfo("nl-NL");
            lblPrice.Text = price.ToString("C", euroCulture);
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
