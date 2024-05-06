using entity_classes.Users;
using enum_classes.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_classes.Ingredients;

namespace entity_classes.Recipes
{
    public class Food : Recipe
    {
        private bool isSpicy;
        private int servings;
        public Food(int idRecipe, User user, string title, List<Ingredient> ingredients,
            string instructions, DietaryRestriction dietaryRestriction, Difficulty difficulty, int cookingTime, DateTime publishDate,
            bool isSpicy, int servings)
            : base(idRecipe, user, title, ingredients, instructions, dietaryRestriction, difficulty, cookingTime, publishDate)
        {
            this.isSpicy = isSpicy;
            this.servings = servings;
        }
        public override decimal CalculatePrice()
        {
            decimal totalPrice = 0;
            foreach (Ingredient ingredient in this.GetIngredients())
            {
                totalPrice += ingredient.GetPrice() * ingredient.GetQuantity();
            }

            if (servings != 0)
            {
                return totalPrice * servings;
            }

            return totalPrice;
        }
        public bool GetSpiciness()
        {
            return isSpicy;
        }
        public int GetServings()
        {
            return servings;
        }
    }
}
