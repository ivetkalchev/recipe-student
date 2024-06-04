namespace entity_classes
{
    public class MainCourse : Recipe
    {
        private bool isSpicy;
        private int servings;
        public MainCourse(int idRecipe, string title, string description, string instructions, DesktopUser user, DateTime publishDate, TimeSpan preparationTime, TimeSpan cookingTime,
            DietRestriction dietRestriction, Difficulty difficulty, bool isVegetarian, bool isSpicy, int servings)
            : base(idRecipe, title, description, instructions, user, publishDate, preparationTime, cookingTime, dietRestriction, difficulty)
        {
            this.servings = servings;
            this.isSpicy = isSpicy;
        }

        public bool GetIsSpicy()
        {
            return isSpicy;
        }

        public int GetServings()
        {
            return servings;
        }

        public override decimal CalculateTotalTime()
        {
            return (decimal)(GetPreparationTime() + GetCookingTime()).TotalMinutes;
        }
    }
}
