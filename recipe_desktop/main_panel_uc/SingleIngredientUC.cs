using entity_classes;
using manager_classes;
using System;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

namespace recipe_desktop
{
    public partial class SingleIngredientUC : UserControl
    {
        private Ingredient ingredient;
        private IIngredientManager ingredientManager;

        public event EventHandler IngredientDeleted;
        public SingleIngredientUC(IIngredientManager ingredientManager, Ingredient ingredient)
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
    }
}
