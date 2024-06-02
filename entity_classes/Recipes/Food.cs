using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_classes
{
    public class Food : Recipe
    {
        private int servings;
        private bool isSpicy;

        public Food(int idRecipe, string title, string description, string instructions, DesktopUser user, DateTime publishDate, TimeSpan cookingTime,
            List<RecipeIngredient> ingredients, DietRestriction dietRestriction, Difficulty difficulty, int servings, bool isSpicy)
            : base(idRecipe, title, description, instructions, user, publishDate, cookingTime, ingredients, dietRestriction, difficulty)
        {
            this.servings = servings;
            this.isSpicy = isSpicy;
        }

        public int GetServings()
        {
            return servings;
        }

        public bool GetIsSpicy()
        {
            return isSpicy;
        }

        public override decimal CalculatePrice()
        {
            decimal total = 0;
            foreach (var ingredient in GetIngredients())
            {
                total += ingredient.GetIngredient().GetPrice() * ingredient.GetQuantity();
            }
            return total * servings;
        }
    }
}
