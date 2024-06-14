using entity_classes;

namespace db_helpers
{
    public interface IDBIngredientHelper
    {
        void AddIngredient(Ingredient newIngredient);
        void DeleteIngredient(Ingredient ingredient);
        bool DoesIngredientExist(string name);
        List<Ingredient> GetAllIngredients();
        List<TypeIngredient> GetAllTypes();
        List<Unit> GetAllUnits();
        List<IngredientRecipe> GetIngredientsForRecipe(int recipeId);
        bool IsIngredientNameTakenByOtherIngredient(Ingredient ingredient, string name);
        void UpdateIngredientDetails(Ingredient ingredient, string newName, TypeIngredient newType);
    }
}