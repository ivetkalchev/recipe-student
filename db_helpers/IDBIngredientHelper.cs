using entity_classes;

namespace db_helpers
{
    public interface IDBIngredientHelper
    {
        void AddIngredient(Ingredient newIngredient);
        void DeleteIngredient(Ingredient ingredient);
        List<Ingredient> GetAllIngredients();
        List<Unit> GetAllUnits();
        bool IsIngredientExist(string name);
    }
}