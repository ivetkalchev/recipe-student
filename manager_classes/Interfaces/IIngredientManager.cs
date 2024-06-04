using entity_classes;

namespace manager_classes
{
    public interface IIngredientManager
    {
        void AddIngredient(Ingredient newIngredient);
        void DeleteIngredient(Ingredient ingredient);
        List<Ingredient> GetAllIngredients();
        List<TypeIngredient> GetAllTypeIngredients();
        TypeIngredient GetTypeIngredientByName(string name);
        void UpdateIngredientDetails(Ingredient currentIngredient, string newName, TypeIngredient newType, decimal newPrice);
    }
}