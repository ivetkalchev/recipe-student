using exceptions;
using Microsoft.VisualBasic;

namespace entity_classes
{
    public class Drink : Recipe
    {
        private bool isAlcoholic;
        private bool containsCaffeine;
        private bool servedHot;
        private int pours;

        public Drink(int idRecipe, string title, string description, string instructions, List<IngredientRecipe> ingredients, DesktopUser user,
            TimeSpan preparationTime, TimeSpan cookingTime, DietRestriction dietRestriction, Difficulty difficulty, RecipePic? pic, bool isAlcoholic, 
            bool containsCaffeine, bool servedHot, int pours)
            : base(idRecipe, title, description, instructions, ingredients, user, preparationTime, cookingTime, dietRestriction, difficulty, pic)
        {
            IsAlcoholic = isAlcoholic;
            ContainsCaffeine = containsCaffeine;
            ServedHot = servedHot;
            Pours = pours;
        }

        public bool IsAlcoholic
        {
            get { return isAlcoholic; }
            set { isAlcoholic = value; }
        }

        public bool ContainsCaffeine
        {
            get { return containsCaffeine; }
            set { containsCaffeine = value; }
        }

        public bool ServedHot
        {
            get { return servedHot; }
            set { servedHot = value; }
        }

        public int Pours
        {
            get { return pours; }
            set
            {
                if (pours <= 0)
                    throw new NullRecipeException("Servings");

                pours = value;
            }
        }

        public override TimeSpan CalculateTotalTime()
        {
            var totalTime = PreparationTime + CookingTime;
            if (servedHot)
            {
                totalTime += TimeSpan.FromMinutes(5); // time for heating up
            }
            return totalTime;
        }
    }
}