using entity_classes;
using exceptions;
using db_helpers;

namespace manager_classes
{
    public class IngredientManager : IIngredientManager
    {
        private IDBIngredientHelper dbHelper;

        public IngredientManager(IDBIngredientHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        public List<TypeIngredient> GetAllTypeIngredients()
        {
            return dbHelper.GetAllTypes();
        }

        public List<Unit> GetAllUnits()
        {
            return dbHelper.GetAllUnits();
        }

        public TypeIngredient GetTypeIngredientByName(string name)
        {
            var types = dbHelper.GetAllTypes();
            foreach (var type in types)
            {
                if (type.GetName().Equals(name, System.StringComparison.OrdinalIgnoreCase))
                {
                    return type;
                }
            }
            return null;
        }

        public void AddIngredient(Ingredient newIngredient)
        {
            newIngredient.IsIngredientNameValid(newIngredient.GetName());
            CheckIfIngredientExists(newIngredient.GetName());

            dbHelper.AddIngredient(newIngredient);
        }

        private void CheckIfIngredientExists(string name)
        {
            if (dbHelper.DoesIngredientExist(name))
            {
                throw new AlreadyExistIngredientException(name);
            }
        }

        public List<Ingredient> GetAllIngredients()
        {
            return dbHelper.GetAllIngredients();
        }

        public void DeleteIngredient(Ingredient ingredient)
        {
            dbHelper.DeleteIngredient(ingredient);
        }

        public void UpdateIngredientDetails(Ingredient ingredient, string newName, TypeIngredient newType)
        {
            if (newName != ingredient.GetName() && IsIngredientNameTakenByOtherIngredient(ingredient, newName))
            {
                throw new AlreadyExistIngredientException(newName);
            }

            dbHelper.UpdateIngredientDetails(ingredient, newName, newType);
        }

        private bool IsIngredientNameTakenByOtherIngredient(Ingredient ingredient, string name)
        {
            return dbHelper.IsIngredientNameTakenByOtherIngredient(ingredient, name);
        }
    }
}