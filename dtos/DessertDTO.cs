using entity_classes;

namespace dtos
{
    public class DessertDTO : RecipeDTO
    {
        private bool isSugarFree;
        private bool requiresFreezing;

        public DessertDTO(string title, string description, string instructions, List<IngredientRecipeDTO> ingredients, string user, TimeSpan preparationTime, TimeSpan cookingTime,
            DietRestriction dietRestriction, Difficulty difficulty, RecipePic? pic, bool isSugarFree, bool requiresFreezing)
            : base(title, description, instructions, ingredients, user, preparationTime, cookingTime, dietRestriction, difficulty, pic)
        {
            IsSugarFree = isSugarFree;
            RequiresFreezing = requiresFreezing;
        }

        public bool IsSugarFree
        {
            get { return isSugarFree; }
            private set { isSugarFree = value; }
        }

        public bool RequiresFreezing
        {
            get { return requiresFreezing; }
            private set { requiresFreezing = value; }
        }
    }
}