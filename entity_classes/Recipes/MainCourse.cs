using exceptions;

namespace entity_classes
{
    public class MainCourse : Recipe
    {
        private bool isSpicy;
        private int servings;

        public MainCourse(int idRecipe, string title, string description, string instructions, List<IngredientRecipe> ingredients, DesktopUser user,
            TimeSpan preparationTime, TimeSpan cookingTime, DietRestriction dietRestriction, Difficulty difficulty, RecipePic? pic, bool isSpicy, int servings)
            : base(idRecipe, title, description, instructions, ingredients, user, preparationTime, cookingTime, dietRestriction, difficulty, pic)
        {
            Servings = servings;
            IsSpicy = isSpicy;
        }

        public bool IsSpicy
        {
            get { return isSpicy; }
            set { isSpicy = value; }
        }

        public int Servings
        {
            get { return servings; }
            set
            {
                if (servings <= 0)
                    throw new NullRecipeException("Servings");

                servings = value;
            }
        }

        public override TimeSpan CalculateTotalTime()
        {
            return PreparationTime + CookingTime;
        }
    }
}
