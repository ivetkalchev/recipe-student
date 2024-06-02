using entity_classes;

namespace manager_classes
{
    public interface IIngredientManager
    {
        void AddIngredient(string name, Unit unit, decimal price);
        List<Unit> GetAllUnits();
    }
}