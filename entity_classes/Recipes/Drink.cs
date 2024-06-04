using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_classes
{
    public class Drink : Recipe
    {
        private bool isAlcholic;
        private bool hasCaffeineContent;
        private int pours;
        public Drink(int idRecipe, string title, string description, string instructions, DesktopUser user, DateTime publishDate, TimeSpan cookingTime,
            List<IngredientRecipe> ingredients, DietRestriction dietRestriction, Difficulty difficulty, bool isAlcholic, bool hasCaffeineContent, int pours)
            : base(idRecipe, title, description, instructions, user, publishDate, cookingTime, dietRestriction, difficulty)
        {
            this.isAlcholic = isAlcholic;
            this.hasCaffeineContent = hasCaffeineContent;
            this.pours = pours;
        }

        public bool GetIsAlcholic()
        {
            return isAlcholic;
        }

        public bool GetHasCaffeineContent()
        {
            return hasCaffeineContent; 
        }

        public int GetPours()
        {
            return pours;
        }
        //fix
        public override decimal CalculatePrice()
        {
            return 0;
        }
    }
}
