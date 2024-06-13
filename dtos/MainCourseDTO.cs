using exceptions;
using entity_classes;

namespace dtos
{
    public class MainCourseDTO : RecipeDTO
    {
        private bool isSpicy;
        private int servings;

        public MainCourseDTO(string title, string description, string instructions, List<IngredientRecipeDTO> ingredients, string user, TimeSpan preparationTime, TimeSpan cookingTime,
            DietRestriction dietRestriction, Difficulty difficulty, RecipePic? pic, bool isSpicy, int servings)
            : base(title, description, instructions, ingredients, user, preparationTime, cookingTime, dietRestriction, difficulty, pic)
        {
            IsSpicy = isSpicy;
            Servings = servings;
        }

        public bool IsSpicy
        {
            get { return isSpicy; }
            private set { isSpicy = value; }
        }

        public int Servings
        {
            get { return servings; }
            private set
            {
                if (value <= 0)
                    throw new InvalidRecipeQuantityException(nameof(Servings), value);

                servings = value;
            }
        }
    }
}