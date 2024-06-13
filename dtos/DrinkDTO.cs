using entity_classes;
using exceptions;

namespace dtos
{
    public class DrinkDTO : RecipeDTO
    {
        private bool isAlcoholic;
        private bool containsCaffeine;
        private bool servedHot;
        private int pours;

        public DrinkDTO(string title, string description, string instructions, List<IngredientRecipeDTO> ingredients, string user, TimeSpan preparationTime, TimeSpan cookingTime,
            DietRestriction dietRestriction, Difficulty difficulty, RecipePic? pic, bool isAlcoholic, bool containsCaffeine, bool servedHot, int pours)
            : base(title, description, instructions, ingredients, user, preparationTime, cookingTime, dietRestriction, difficulty, pic)
        {
            IsAlcoholic = isAlcoholic;
            ContainsCaffeine = containsCaffeine;
            ServedHot = servedHot;
            Pours = pours;
        }

        public bool IsAlcoholic
        {
            get { return isAlcoholic; }
            private set { isAlcoholic = value; }
        }

        public bool ContainsCaffeine
        {
            get { return containsCaffeine; }
            private set { containsCaffeine = value; }
        }

        public bool ServedHot
        {
            get { return servedHot; }
            private set { servedHot = value; }
        }

        public int Pours
        {
            get { return pours; }
            private set
            {
                if (value <= 0)
                    throw new InvalidRecipeQuantityException(nameof(Pours), value);

                pours = value;
            }
        }
    }
}