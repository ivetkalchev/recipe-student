using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_classes
{
    public class Food : Recipe
    {
        private bool isSpicy;
        private int servings;
        public Food(int idRecipe, string title, string description, string instructions, DesktopUser user, DateTime publishDate, TimeSpan cookingTime,
            List<IngredientRecipe> ingredients, DietRestriction dietRestriction, Difficulty difficulty, bool isSpicy, int servings)
            : base(idRecipe, title, description, instructions, user, publishDate, cookingTime, dietRestriction, difficulty)
        {
            this.isSpicy = isSpicy;
            this.servings = servings;
        }

        public bool GetIsSpicy()
        {
            return isSpicy;
        }

        public int GetServings()
        {
            return servings;
        }

        //fix
        public override decimal CalculatePrice()
        {
            return 0;
        }
    }
}
