using exceptions;
using System.Runtime.CompilerServices;

namespace entity_classes
{
    public abstract class Recipe
    {
        private int idRecipe;
        private string title;
        private string description;
        private string instructions;
        private List<IngredientRecipe> ingredients;
        private DesktopUser user;
        private TimeSpan preparationTime;
        private TimeSpan cookingTime;
        private DietRestriction dietRestriction;
        private Difficulty difficulty;
        private RecipePic? pic;

        private const int maxLengthTitle = 100;
        private const int maxLengthDescription = 400;
        private const int maxLengthInstructions = 4000;

        public Recipe(int idRecipe, string title, string description, string instructions, List<IngredientRecipe> ingredients, DesktopUser user,
            TimeSpan preparationTime, TimeSpan cookingTime, DietRestriction dietRestriction, Difficulty difficulty, RecipePic? pic)
        {
            IdRecipe = idRecipe;
            Title = title;
            Description = description;
            Instructions = instructions;
            IngredientRecipes = ingredients;
            User = user;
            PreparationTime = preparationTime;
            CookingTime = cookingTime;
            DietRestriction = dietRestriction;
            Difficulty = difficulty;
            RecipePic = pic;
        }

        public int IdRecipe
        {
            get { return idRecipe; }
            private set { idRecipe = value; }
        }

        public string Title
        {
            get { return title; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullRecipeException("Title");

                if (title.Length > maxLengthTitle)
                    throw new LengthRecipeException("Title", maxLengthTitle);

                title = value;
            }
        }

        public string Description
        {
            get { return description; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullRecipeException("Description");

                if (description.Length > maxLengthDescription)
                    throw new LengthRecipeException("Description", maxLengthDescription);

                description = value;
            }
        }

        public string Instructions
        {
            get { return instructions; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullRecipeException("Instructions");

                if (instructions.Length > maxLengthInstructions)
                    throw new LengthRecipeException("Instructions", maxLengthInstructions);

                instructions = value;
            }
        }

        public List<IngredientRecipe> IngredientRecipes
        {
            get { return ingredients; }
            private set
            {
                if (value == null)
                    throw new NullRecipeException("Ingredients");

                ingredients = value;
            }
        }

        public DesktopUser User
        {
            get { return user; }
            private set { user = value; }
        }

        public TimeSpan PreparationTime
        {
            get { return preparationTime; }
            private set
            {
                if (value < TimeSpan.Zero)
                    throw new InvalidTimeException("Preparation Time");

                preparationTime = value;
            }
        }

        public TimeSpan CookingTime
        {
            get { return cookingTime; }
            private set
            {
                if (value < TimeSpan.Zero)
                    throw new InvalidTimeException("Cooking Time");

                cookingTime = value;
            }
        }    

        public DietRestriction DietRestriction
        {
            get { return dietRestriction; }
            private set
            {
                if (value == null)
                    throw new NullRecipeException("Dietary Restriction");

                dietRestriction = value;
            }
        }

        public Difficulty Difficulty
        {
            get { return difficulty; }
            private set
            {
                if (value == null)
                    throw new NullRecipeException("Difficulty");

                difficulty = value;
            }
}

        public RecipePic? RecipePic
        {
            get { return pic; }
            private set
            {
                pic = value;
            }
        }

        public abstract TimeSpan CalculateTotalTime();
    }
}
