using System.Collections.Generic;
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
            ValidateIngredientName(newIngredient.GetName());
            ValidateIngredientPrice(newIngredient.GetPrice());
            CheckIfIngredientExists(newIngredient.GetName());

            dbHelper.AddIngredient(newIngredient);
        }

        private void ValidateIngredientName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || !System.Text.RegularExpressions.Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
            {
                throw new InvalidIngredientNameException();
            }
        }

        private void ValidateIngredientPrice(decimal price)
        {
            if (price <= 0)
            {
                throw new InvalidPriceException();
            }
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

        public void UpdateIngredientDetails(Ingredient currentIngredient, string newName, TypeIngredient newType, decimal newPrice)
        {
            dbHelper.UpdateIngredientDetails(currentIngredient, newName, newType, newPrice);
        }
    }
}
