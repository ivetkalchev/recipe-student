using entity_classes;
using exceptions;
using manager_classes;

namespace recipe_desktop
{
    public partial class EditIngredientForm : Form
    {
        private Ingredient ingredient;
        private IIngredientManager ingredientManager;

        public EditIngredientForm(Ingredient ingredient, IIngredientManager ingredientManager)
        {
            InitializeComponent();
            this.ingredientManager = ingredientManager;
            this.ingredient = ingredient;
            LoadIngredientDetails();
            LoadTypeIngredients();
            LockTextBoxes();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadIngredientDetails()
        {
            tbName.Text = ingredient.GetName();
            cbTypeIngredient.SelectedItem = ingredient.GetTypeIngredient().GetName();
            nudPrice.Value = ingredient.GetPrice();
        }

        private void LockTextBoxes()
        {
            tbName.Enabled = false;
            cbTypeIngredient.Enabled = false;
            nudPrice.Enabled = false;
            btnSave.Enabled = false;
        }

        private void UnlockTextBoxes()
        {
            tbName.Enabled = true;
            cbTypeIngredient.Enabled = true;
            nudPrice.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newName = tbName.Text.Trim();
            TypeIngredient newType = ingredientManager.GetTypeIngredientByName(cbTypeIngredient.SelectedItem.ToString());
            decimal newPrice = nudPrice.Value;

            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("All fields must be filled.");
                return;
            }

            try
            {
                ingredientManager.UpdateIngredientDetails(ingredient, newName, newType, newPrice);
                MessageBox.Show("Changes saved successfully!");
                btnSave.Enabled = false;
                LockTextBoxes();
            }
            catch (InvalidIngredientException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            UnlockTextBoxes();
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
                cbTypeIngredient.SelectedIndex = cbTypeIngredient.FindStringExact(ingredient.GetTypeIngredient().GetName());
            }
        }
    }
}