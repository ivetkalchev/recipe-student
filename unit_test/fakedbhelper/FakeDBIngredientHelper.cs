using db_helpers;
using entity_classes;
using exceptions;

namespace unit_tests
{
    public class FakeDBIngredientHelper : IDBIngredientHelper
    {
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<TypeIngredient> types = new List<TypeIngredient>();
        private List<Unit> units = new List<Unit>();

        public void AddIngredient(Ingredient ingredient)
        {
            if (ingredients.Exists(i => i.GetName() == ingredient.GetName()))
            {
                throw new AlreadyExistIngredientException(ingredient.GetName());
            }
            ingredients.Add(ingredient);
        }

        public void DeleteIngredient(Ingredient ingredient)
        {
            ingredients.Remove(ingredient);
        }

        public List<Ingredient> GetAllIngredients()
        {
            return ingredients;
        }

        public List<TypeIngredient> GetAllTypes()
        {
            return types;
        }

        public List<Unit> GetAllUnits()
        {
            return units;
        }

        public List<IngredientRecipe> GetIngredientsForRecipe(int recipeId)
        {
            return new List<IngredientRecipe>();
        }

        public bool DoesIngredientExist(string ingredientName)
        {
            return ingredients.Exists(i => i.GetName() == ingredientName);
        }

        public void UpdateIngredientDetails(Ingredient ingredient, string newName, TypeIngredient newType)
        {
            var existingIngredient = ingredients.Find(i => i.GetId() == ingredient.GetId());
            if (existingIngredient != null)
            {
                existingIngredient = new Ingredient(ingredient.GetId(), newName, newType);
            }
        }

        public void AddType(TypeIngredient type)
        {
            types.Add(type);
        }

        public bool IsIngredientNameTakenByOtherIngredient(Ingredient ingredient, string name)
        {
            return ingredients.Exists(i => i.GetName() == name && i.GetId() != ingredient.GetId());
        }
    }
}
