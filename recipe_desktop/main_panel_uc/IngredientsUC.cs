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
            
            LoadAllIngredients();
            LoadTypeIngredients();
        }

        private void LoadAllIngredients()
        {
            ingredients = ingredientManager.GetAllIngredients();
            UpdatePagination();
            DisplayIngredients();
        }

        private void LoadTypeIngredients()
        {
            var typeIngredients = ingredientManager.GetAllTypeIngredients();
            cbTypeIngredient.Items.Clear();

            foreach (var type in typeIngredients)
            {
                cbTypeIngredient.Items.Add(type.GetName());
            }
            if (cbTypeIngredient.Items.Count > 0)
            {
                cbTypeIngredient.SelectedIndex = 0;
            }
        }

        private void DisplayIngredients()
        {
            panelIngredients.Controls.Clear();
            lblNoResults.Visible = false;

            var flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                WrapContents = false,
                FlowDirection = FlowDirection.TopDown
            };

            List<Ingredient> ingredientsToDisplay = searchResults ?? ingredients;

            if (ingredientsToDisplay.Count == 0)
            {
                lblNoResults.Visible = true;
            }
            else
            {
                int startIndex = (currentPage - 1) * IngredientsPerPage;
                int endIndex = Math.Min(startIndex + IngredientsPerPage, ingredientsToDisplay.Count);

                for (int i = startIndex; i < endIndex; i++)
                {
                    var ingredientUC = new SingleIngredientUC(ingredientsToDisplay[i], ingredientManager);
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
                string name = tbName.Text.Trim();
                var type = ingredientManager.GetTypeIngredientByName(cbTypeIngredient.SelectedItem.ToString());

                var newIngredient = new Ingredient(0, name, type);

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

        private void ClearFields()
        {
            tbName.Clear();
            cbTypeIngredient.SelectedIndex = 0;
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
            string searchQuery = tbSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchQuery))
            {
                searchResults = null;
            }
            else
            {
                searchResults = new List<Ingredient>();
                foreach (var ingredient in ingredients)
                {
                    if (ingredient.GetName().ToLower().Contains(searchQuery))
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
