using System;
using System.Windows.Forms;
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
    }
}
