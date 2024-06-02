using entity_classes;

namespace manager_classes
{
    public interface IIngredientManager
    {
        void AddIngredient(Ingredient newIngredient);
        List<Unit> GetAllUnits();
    }
}