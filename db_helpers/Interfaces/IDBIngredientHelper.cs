using entity_classes;

namespace db_helpers
{
    public interface IDBIngredientHelper
    {
        void AddIngredient(Ingredient ingredient);
        List<Unit> GetAllUnits();
        bool IsIngredientExist(string name);
    }
}