using System;
using System.Windows.Forms;
using entity_classes;
using exceptions;
using manager_classes;

namespace recipe_desktop
{
    public partial class IngredientsUC : UserControl
    {
        private IIngredientManager ingredientManager;

        public IngredientsUC(IIngredientManager ingredientManager)
        {
            InitializeComponent();
            this.ingredientManager = ingredientManager;
            LoadUnits();
        }

        private void LoadUnits()
        {
            var units = ingredientManager.GetAllUnits();
            cbUnits.Items.Clear();

            foreach (var unit in units)
            {
                cbUnits.Items.Add(unit.GetName());
            }

            if (cbUnits.Items.Count > 0)
            {
                cbUnits.SelectedIndex = 0;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string name = tbName.Text.Trim();
            Unit selectedUnit = null;

            foreach (var unit in ingredientManager.GetAllUnits())
            {
                if (unit.GetName() == cbUnits.SelectedItem.ToString())
                {
                    selectedUnit = unit;
                    break;
                }
            }

            decimal price = nudPrice.Value;

            try
            {
                Ingredient newIngredient = new Ingredient(
                    0, 
                    name, 
                    selectedUnit, 
                    price
                );

                ingredientManager.AddIngredient(newIngredient);

                MessageBox.Show($"{name} was added successfully!");
                ClearFields();
            }
            catch (InvalidIngredientException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearFields()
        {
            tbName.Clear();
            nudPrice.Value = nudPrice.Minimum;
            if (cbUnits.Items.Count > 0)
            {
                cbUnits.SelectedIndex = 0;
            }
        }
    }
}
