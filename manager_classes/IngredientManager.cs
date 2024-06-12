using db_helpers;
using entity_classes;
using exceptions;
using System.Collections.Generic;
using System.Xml.Linq;

namespace manager_classes
{
    public class IngredientManager : IIngredientManager
    {
        private readonly IDBIngredientHelper ingredientHelper;

        public IngredientManager(IDBIngredientHelper ingredientHelper)
        {
            this.ingredientHelper = ingredientHelper ?? throw new ArgumentNullException(nameof(ingredientHelper));
        }

        public List<TypeIngredient> GetAllTypeIngredients()
        {
            return ingredientHelper.GetAllTypes();
        }

        public List<Unit> GetAllUnits()
        {
            return ingredientHelper.GetAllUnits();
        }

        public TypeIngredient GetTypeIngredientByName(string name)
        {
            var types = ingredientHelper.GetAllTypes();

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
            if (ingredientHelper.DoesIngredientExist(newIngredient.GetName()))
            {
                throw new AlreadyExistIngredientException(newIngredient.GetName());
            }

            ingredientHelper.AddIngredient(newIngredient);
        }

        public List<Ingredient> GetAllIngredients()
        {
            return ingredientHelper.GetAllIngredients();
        }

        public void DeleteIngredient(Ingredient ingredient)
        {
            ingredientHelper.DeleteIngredient(ingredient);
        }

        public void UpdateIngredientDetails(Ingredient ingredient, string newName, TypeIngredient newType)
        {
            if (newName != ingredient.GetName() && IsIngredientNameTakenByOtherIngredient(ingredient, newName))
            {
                throw new AlreadyExistIngredientException(newName);
            }

            ingredientHelper.UpdateIngredientDetails(ingredient, newName, newType);
        }

        private bool IsIngredientNameTakenByOtherIngredient(Ingredient ingredient, string name)
        {
            return ingredientHelper.IsIngredientNameTakenByOtherIngredient(ingredient, name);
        }
    }
}
