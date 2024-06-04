namespace entity_classes
{
    public class Dessert : Recipe
    {
        private bool isSugarFree;
        private bool requiresFreezing;
        private int sweetnessLevel;
        
        public Dessert(int idRecipe, string title, string description, string instructions, DesktopUser user, DateTime publishDate, TimeSpan preparationTime, TimeSpan cookingTime,
            DietRestriction dietRestriction, Difficulty difficulty, bool isSugarFree, bool requiresFreezing, int sweetnessLevel)
            : base(idRecipe, title, description, instructions, user, publishDate, preparationTime, cookingTime, dietRestriction, difficulty)
        {
            this.isSugarFree = isSugarFree;
            this.requiresFreezing = requiresFreezing;
            this.sweetnessLevel = sweetnessLevel;
        }

        public bool GetIsSugarFree()
        {
            return isSugarFree;
        }

        public bool GetRequiresFreezing()
        {
            return requiresFreezing;
        }

        public int GetSweetnessLevel()
        {
            return sweetnessLevel;
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
