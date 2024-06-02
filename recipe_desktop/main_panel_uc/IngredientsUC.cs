using System;
using System.Collections.Generic;
using System.Windows.Forms;
using entity_classes;
using exceptions;
using manager_classes;

namespace recipe_desktop
{
    public partial class IngredientsUC : UserControl
    {
        private readonly IIngredientManager ingredientManager;
        private List<Ingredient> ingredients;
        private List<Ingredient> searchResults;
        private int currentPage;
        private const int IngredientsPerPage = 3;

        public IngredientsUC(IIngredientManager ingredientManager)
        {
            InitializeComponent();
            this.ingredientManager = ingredientManager;
            currentPage = 1;
            LoadUnits();
            LoadAllIngredients();
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

        private void LoadAllIngredients()
        {
            ingredients = ingredientManager.GetAllIngredients();
            UpdatePagination();
            DisplayIngredients();
        }

        private void DisplayIngredients()
        {
            panelIngredients.Controls.Clear();
            lblNoResults.Visible = false;

            FlowLayoutPanel flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                WrapContents = false,
                FlowDirection = FlowDirection.TopDown
            };

            List<Ingredient> ingredientsToDisplay = searchResults ?? ingredients;
            if (ingredientsToDisplay.Count == 0)
            {
                lblNoResults.Text = "No results found";
                lblNoResults.Visible = true;
            }
            else
            {
                int startIndex = (currentPage - 1) * IngredientsPerPage;
                int endIndex = Math.Min(startIndex + IngredientsPerPage, ingredientsToDisplay.Count);

                for (int i = startIndex; i < endIndex; i++)
                {
                    SingleIngredientUC ingredientUC = new SingleIngredientUC(ingredientManager, ingredientsToDisplay[i]);
                    ingredientUC.IngredientDeleted += IngredientUC_IngredientDeleted;
                    ingredientUC.Margin = new Padding(10);
                    flowPanel.Controls.Add(ingredientUC);
                }

                panelIngredients.Controls.Add(flowPanel);
            }
            UpdatePaginationButtons();
        }

        private void IngredientUC_IngredientDeleted(object sender, EventArgs e)
        {
            LoadAllIngredients();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedUnit = FindSelectedUnit();
                var newIngredient = new Ingredient(0, tbName.Text.Trim(), selectedUnit, nudPrice.Value);

                ingredientManager.AddIngredient(newIngredient);
                MessageBox.Show($"{newIngredient.GetName()} was added successfully!");
                ClearFields();
                LoadAllIngredients();
            }
            catch (InvalidIngredientException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Unit FindSelectedUnit()
        {
            var units = ingredientManager.GetAllUnits();
            foreach (var unit in units)
            {
                if (unit.GetName() == cbUnits.SelectedItem.ToString())
                {
                    return unit;
                }
            }
            return null;
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

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayIngredients();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < (searchResults?.Count ?? ingredients.Count + IngredientsPerPage - 1) / IngredientsPerPage)
            {
                currentPage++;
                DisplayIngredients();
            }
        }

        private void picSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text.Trim()))
            {
                searchResults = null;
            }
            else
            {
                searchResults = new List<Ingredient>();
                foreach (var ingredient in ingredients)
                {
                    if (ingredient.GetName().ToLower().Contains(tbSearch.Text.Trim().ToLower()))
                    {
                        searchResults.Add(ingredient);
                    }
                }
            }
            currentPage = 1;
            DisplayIngredients();
        }

        private void UpdatePagination()
        {
            currentPage = 1;
            UpdatePaginationButtons();
        }

        private void UpdatePaginationButtons()
        {
            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < (searchResults?.Count ?? ingredients.Count + IngredientsPerPage - 1) / IngredientsPerPage;
        }
    }
}
