using entity_classes;
using manager_classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recipe_desktop
{
    public partial class AddDessertUC : UserControl
    {
        private DesktopUser user;
        private IRecipeManager recipeManager;
        private IIngredientManager ingredientManager;
        public AddDessertUC(DesktopUser user, IRecipeManager recipeManager, IIngredientManager ingredientManager)
        {
            InitializeComponent();

            this.user = user;
            this.recipeManager = recipeManager;
            this.ingredientManager = ingredientManager;

            LoadDifficulty();
            LoadDietRestrictions();
            LoadIngredients();
        }

        private void LoadDifficulty()
        {
            var difficulties = recipeManager.GetAllDifficulties();
            cbDifficulty.Items.Clear();

            foreach (var difficulty in difficulties)
            {
                cbDifficulty.Items.Add(difficulty.GetName());
            }
            if (cbDifficulty.Items.Count > 0)
            {
                cbDifficulty.SelectedIndex = 0;
            }
        }

        private void LoadDietRestrictions()
        {
            var dietRestrictions = recipeManager.GetAllDietRestrictions();
            cbDietRestriction.Items.Clear();

            foreach (var dietRestriction in dietRestrictions)
            {
                cbDietRestriction.Items.Add(dietRestriction.GetName());
            }
            if (cbDietRestriction.Items.Count > 0)
            {
                cbDietRestriction.SelectedIndex = 0;
            }
        }

        private void LoadIngredients()
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbAddedIngredients.SelectedItem != null)
            {
                lbAddedIngredients.Items.Remove(lbAddedIngredients.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select an ingredient to delete.");
            }
        }
    }
}
