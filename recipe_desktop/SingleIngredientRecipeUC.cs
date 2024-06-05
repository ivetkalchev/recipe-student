using entity_classes;
using manager_classes;
using System;
using System.Windows.Forms;

namespace recipe_desktop
{
    public partial class SingleIngredientRecipeUC : UserControl
    {
        private Ingredient ingredient;
        private IIngredientManager ingredientManager;

        public event EventHandler<IngredientRecipe> IngredientAdded;

        public SingleIngredientRecipeUC(Ingredient ingredient, IIngredientManager ingredientManager)
        {
            InitializeComponent();

            this.ingredient = ingredient;
            this.ingredientManager = ingredientManager;

            lblName.Text = ingredient.GetName();
            LoadUnits();
        }

        private void LoadUnits()
        {
            var units = ingredientManager.GetAllUnits();
            cbUnit.Items.Clear();

            foreach (var unit in units)
            {
                cbUnit.Items.Add(unit.GetName());
            }
            if (cbUnit.Items.Count > 0)
            {
                cbUnit.SelectedIndex = 0;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string selectedUnitName = cbUnit.SelectedItem?.ToString();
            decimal quantity = nudQuantity.Value;

            if (!string.IsNullOrEmpty(selectedUnitName) && quantity > 0)
            {
                Unit selectedUnit = null;
                foreach (var unit in ingredientManager.GetAllUnits())
                {
                    if (unit.GetName() == selectedUnitName)
                    {
                        selectedUnit = unit;
                        break;
                    }
                }

                if (selectedUnit != null)
                {
                    var ingredientRecipe = new IngredientRecipe(ingredient, quantity, selectedUnit);
                    OnIngredientAdded(ingredientRecipe);

                    nudQuantity.Value = 0;
                    cbUnit.SelectedIndex = 0;

                    MessageBox.Show("Ingredient added successfully!");

                }
            }
            else
            {
                MessageBox.Show("Please select a unit and enter a quantity.");
            }
        }

        protected virtual void OnIngredientAdded(IngredientRecipe e)
        {
            IngredientAdded?.Invoke(this, e);
        }
    }
}
