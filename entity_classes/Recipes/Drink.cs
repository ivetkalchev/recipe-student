using exceptions;

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
            this.isAlcoholic = isAlcoholic;
            this.containsCaffeine = containsCaffeine;
            this.servedHot = servedHot;
            this.pours = pours;
        }

        public bool GetIsAlcoholic()
        {
            return isAlcoholic;
        }

        public bool GetContainsCaffeine()
        {
            return containsCaffeine;
        }

        public bool GetServedHot()
        {
            return servedHot;
        }

        public int GetPours()
        {
            return pours;
        }

        public override TimeSpan CalculateTotalTime()
        {
            var totalTime = GetPreparationTime() + GetCookingTime();
            if (servedHot)
            {
                totalTime += TimeSpan.FromMinutes(5); // time for heating
            }
            return totalTime;
        }

        private void ValidatePours(int pours)
        {
            if (pours <= 0)
            {
                throw new InvalidRecipeQuantityException("Pours", pours);
            }
        }

        public void DrinkValidation()
        {
            ValidatePours(pours);
        }
    }
}