namespace entity_classes
{
    public class Dessert : Recipe
    {
        private bool isSugarFree;
        private bool requiresFreezing;
        public Dessert(int idRecipe, string title, string description, string instructions, List<IngredientRecipe> ingredients, DesktopUser user, DateTime publishDate,
            TimeSpan preparationTime, TimeSpan cookingTime, DietRestriction dietRestriction, Difficulty difficulty, RecipePic? pic, bool isSugarFree, bool requiresFreezing)
            : base(idRecipe, title, description, instructions, ingredients, user, publishDate, preparationTime, cookingTime, dietRestriction, difficulty, pic)
        {
            this.isSugarFree = isSugarFree;
            this.requiresFreezing = requiresFreezing;
        }

        public bool GetIsSugarFree()
        {
            return isSugarFree;
        }

        public bool GetRequiresFreezing()
        {
            return requiresFreezing;
        }

        public override decimal CalculateTotalTime()
        {
            decimal totalTime = (decimal)(GetPreparationTime() + GetCookingTime()).TotalMinutes;
            if (requiresFreezing)
            {
                totalTime += 60; //freezing time
            }
            return totalTime;
        }
    }
}
