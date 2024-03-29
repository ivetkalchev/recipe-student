using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipe
{
    public class MealPrep
    {
        private List<Recipe> recipes;
        private List<Ingredient> shoppingList = new List<Ingredient>();
        public List<Recipe> Recipes
        {
            get { return recipes; }
            set { recipes = value; }
        }

        public List<Ingredient> ShoppingList 
        {
            get { return shoppingList; }
            set { shoppingList = value; }
        }

        public MealPrep()
        {
            recipes = new List<Recipe>();
            shoppingList = new List<Ingredient>();
        }

        public void AddRecipeToPlan(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public void GenerateShoppingList()
        {
            shoppingList.Clear();

            foreach (var recipe in recipes)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    if (Enum.TryParse(ingredient.Name, out Groceries groceries)) //!
                    {
                        decimal pricePerUnit = GroceriesPrices.GetPrice(groceries); 
                        shoppingList.Add(new Ingredient(ingredient.Name, ingredient.Quantity, ingredient.Unit, pricePerUnit));
                    }
                    else
                    {
                        throw new ArgumentException($"Ingredient '{ingredient.Name}' is not recognized.");
                    }
                }
            }
        }

    }
}
