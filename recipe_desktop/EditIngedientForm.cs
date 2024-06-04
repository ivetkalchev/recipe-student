using entity_classes;
using exceptions;
using manager_classes;

namespace recipe_desktop
{
    public partial class EditIngredientForm : Form
    {
        private Ingredient currentIngredient;
        private IIngredientManager ingredientManager;

        public EditIngredientForm(IIngredientManager ingredientManager, Ingredient currentIngredient)
        {
            InitializeComponent();
            this.ingredientManager = ingredientManager;
            this.currentIngredient = currentIngredient;

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
            tbName.Text = currentIngredient.GetName();
            cbTypeIngredient.SelectedItem = currentIngredient.GetTypeIngredient().GetName();
            nudPrice.Value = currentIngredient.GetPrice();
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
            ingredientManager.UpdateIngredientDetails(currentIngredient, newName, newType, newPrice);
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
                cbTypeIngredient.SelectedIndex = 0;
            }
        }
    }
}