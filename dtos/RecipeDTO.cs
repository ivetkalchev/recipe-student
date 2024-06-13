using exceptions;
using entity_classes;

namespace dtos
{
    public class RecipeDTO
    {
        private string title;
        private string description;
        private string instructions;
        private List<IngredientRecipeDTO> ingredients;
        private string user;
        private TimeSpan preparationTime;
        private TimeSpan cookingTime;
        private DietRestriction dietRestriction;
        private Difficulty difficulty;
        private RecipePic? pic;

        private const int maxTitleLength = 100;
        private const int maxDescriptionLength = 400;
        private const int maxInstructionsLength = 4000;

        public RecipeDTO(string title, string description, string instructions, List<IngredientRecipeDTO> ingredients, string user, TimeSpan preparationTime, TimeSpan cookingTime,
            DietRestriction dietRestriction, Difficulty difficulty, RecipePic? pic)
        {
            Title = title;
            Description = description;
            Instructions = instructions;
            Ingredients = ingredients;
            User = user;
            PreparationTime = preparationTime;
            CookingTime = cookingTime;
            DietRestriction = dietRestriction;
            Difficulty = difficulty;
            Pic = pic;
        }

        public string Title
        {
            get { return title; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullRecipeException(nameof(Title));

                if (value.Length > maxTitleLength)
                    throw new LengthRecipeException(nameof(Title), maxTitleLength);

                title = value;
            }
        }

        public string Description
        {
            get { return description; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullRecipeException(nameof(Description));

                if (value.Length > maxDescriptionLength)
                    throw new LengthRecipeException(nameof(Description), maxDescriptionLength);

                description = value;
            }
        }

        public string Instructions
        {
            get { return instructions; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullRecipeException(nameof(Instructions));

                if (value.Length > maxInstructionsLength)
                    throw new LengthRecipeException(nameof(Instructions), maxInstructionsLength);
                instructions = value;
            }
        }

        public List<IngredientRecipeDTO> Ingredients
        {
            get { return ingredients; }
            private set
            {
                if (value == null || value.Count == 0)
                    throw new NullRecipeException(nameof(Ingredients));

                ingredients = value;
            }
        }

        public string User
        {
            get { return user; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullRecipeException(nameof(User));

                user = value;
            }
        }

        public TimeSpan PreparationTime
        {
            get { return preparationTime; }
            private set
            {
                if (value < TimeSpan.Zero)
                    throw new InvalidTimeException(nameof(PreparationTime));

                preparationTime = value;
            }
        }

        public TimeSpan CookingTime
        {
            get { return cookingTime; }
            private set
            {
                if (value < TimeSpan.Zero)
                    throw new InvalidTimeException(nameof(CookingTime));

                cookingTime = value;
            }
        }

        public DietRestriction DietRestriction
        {
            get { return dietRestriction; }
            private set
            {
                if (value == null)
                    throw new NullRecipeException(nameof(DietRestriction));

                dietRestriction = value;
            }
        }

        public Difficulty Difficulty
        {
            get { return difficulty; }
            private set
            {
                if (value == null)
                    throw new NullRecipeException(nameof(Difficulty));

                difficulty = value;
            }
        }

        public RecipePic? Pic
        {
            get { return pic; }
            private set { pic = value; }
        }
    }
}