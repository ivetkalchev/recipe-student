using System.Collections.Generic;
using entity_classes;
using exceptions;
using db_helpers;

namespace manager_classes
{
    public class IngredientManager
    {
        private IDBIngredientHelper dbHelper;

        public IngredientManager(IDBIngredientHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        public List<Unit> GetAllUnits()
        {
            return dbHelper.GetAllUnits();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            //ValidateIngredientName(ingredient.GetName());
            //ValidateIngredientPrice(price);
            //CheckIfIngredientExists(name);

            //Ingredient ingredient = new Ingredient(0, name, unit, price);
            //dbHelper.AddIngredient(ingredient);
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
            if (dbHelper.IsIngredientExist(name))
            {
                throw new AlreadyExistIngredientException(name);
            }
        }
    }
}
