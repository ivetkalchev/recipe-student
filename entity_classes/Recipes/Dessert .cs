using exceptions;

namespace entity_classes
{
    public class Dessert : Recipe
    {
        private bool isSugarFree;
        private bool requiresFreezing;
        public Dessert(int idRecipe, string title, string description, string instructions, List<IngredientRecipe> ingredients, DesktopUser user,
            TimeSpan preparationTime, TimeSpan cookingTime, DietRestriction dietRestriction, Difficulty difficulty, RecipePic? pic, bool isSugarFree, bool requiresFreezing)
            : base(idRecipe, title, description, instructions, ingredients, user, preparationTime, cookingTime, dietRestriction, difficulty, pic)
        {
            IsSugarFree = isSugarFree;
            RequiresFreezing = requiresFreezing;
        }

        public bool IsSugarFree
        {
            get { return isSugarFree; }
            set { isSugarFree = value; }
        }

        public bool RequiresFreezing
        {
            get { return requiresFreezing; }
            set { requiresFreezing = value; }
        }

        public override TimeSpan CalculateTotalTime()
        {
            var totalTime = PreparationTime + CookingTime;
            if (requiresFreezing)
            {
                totalTime += TimeSpan.FromMinutes(60); // freezing time
            }
            return totalTime;
        }
    }
}
