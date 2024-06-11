using entity_classes;
using manager_classes;
using System;
using System.Windows.Forms;

namespace recipe_desktop
{
    public partial class SingleIngredientRecipeUC : UserControl
    {
        private readonly Ingredient ingredient;
        private readonly IIngredientManager ingredientManager;

        public event EventHandler<IngredientRecipe> IngredientAdded;

        public SingleIngredientRecipeUC(Ingredient ingredient, IIngredientManager ingredientManager)
        {
            InitializeComponent();

            this.ingredient = ingredient;
            this.ingredientManager = ingredientManager;

            LoadUnits();
            LoadIngredientName();
        }

        private void LoadIngredientName()
        {
            lblName.Text = ingredient.NameIngredient;
        }

        private void LoadUnits()
        {
            var units = ingredientManager.GetAllUnits();
            cbUnit.Items.Clear();

            foreach (var unit in units)
            {
                cbUnit.Items.Add(unit.NameUnit);
            }

            if (cbUnit.Items.Count > 0)
            {
                cbUnit.SelectedIndex = 0;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var selectedUnitName = cbUnit.SelectedItem?.ToString();
            var quantity = nudPrice.Value;

            if (!string.IsNullOrEmpty(selectedUnitName) && quantity > 0)
            {
                var selectedUnit = GetSelectedUnit(selectedUnitName);

                if (selectedUnit != null)
                {
                    var ingredientRecipe = new IngredientRecipe(ingredient, quantity, selectedUnit);
                    OnIngredientAdded(ingredientRecipe);

                    ResetFormFields();

                    MessageBox.Show("Ingredient added successfully!");
                }
            }
            else
            {
                MessageBox.Show("Please select a unit and enter a quantity.");
            }
        }

        private Unit GetSelectedUnit(string unitName)
        {
            foreach (var unit in ingredientManager.GetAllUnits())
            {
                if (unit.NameUnit == unitName)
                {
                    return unit;
                }
            }
            return null;
        }

        private void ResetFormFields()
        {
            nudPrice.Value = 0;
            cbUnit.SelectedIndex = 0;
        }

        protected virtual void OnIngredientAdded(IngredientRecipe e)
        {
            IngredientAdded?.Invoke(this, e);
        }
    }
}
