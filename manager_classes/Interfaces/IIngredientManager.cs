using entity_classes;

namespace manager_classes
{
    public interface IIngredientManager
    {
        void AddIngredient(Ingredient newIngredient);
        void DeleteIngredient(Ingredient ingredient);
        List<Ingredient> GetAllIngredients();
        List<TypeIngredient> GetAllTypeIngredients();
        List<Unit> GetAllUnits();
        TypeIngredient GetTypeIngredientByName(string name);
        void UpdateIngredientDetails(Ingredient ingredient, string newName, TypeIngredient newType, decimal newPrice);
    }
}