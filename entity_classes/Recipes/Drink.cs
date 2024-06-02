using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_classes
{
    public class Drink : Recipe
    {
        private int pours;
        private bool isAlcholic;
        private bool hasCaffeineContent;

        public Drink(int idRecipe, string title, string description, string instructions, DesktopUser user, DateTime publishDate, TimeSpan cookingTime,
            List<RecipeIngredient> ingredients, DietRestriction dietRestriction, Difficulty difficulty, int pours, bool isAlcholic, bool hasCaffeineContent)
            : base(idRecipe, title, description, instructions, user, publishDate, cookingTime, ingredients, dietRestriction, difficulty)
        {
            this.pours = pours;
            this.isAlcholic = isAlcholic;
            this.hasCaffeineContent = hasCaffeineContent;
        }

        public int GetPours()
        {
            return pours; 
        }

        public bool GetIsAlcholic()
        {
            return isAlcholic;
        }

        public bool GetHasCaffeineContent()
        {
            return hasCaffeineContent; 
        }

        public override decimal CalculatePrice()
        {
            decimal total = 0;
            foreach (var ingredient in GetIngredients())
            {
                total += ingredient.GetIngredient().GetPrice() * ingredient.GetQuantity();
            }
            return total * pours;
        }
    }
}
