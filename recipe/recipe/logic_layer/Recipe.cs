using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipe
{
    public class Recipe
    {
        private int id;
        private string? title;
        private List<Ingredient>? ingredients;
        private string? instructions;
        private Difficulty difficulty;
        private TimeRequired timeRequired;
        private DietaryRestriction dietaryRestriction;
        private Budget budget;
        private List<Rating>? ratings;
        private List<Review>? reviews;

        public Recipe(int Id, string title, List<Ingredient> ingredients, string instructions, Difficulty difficulty,
                      TimeRequired timeRequired, DietaryRestriction dietaryRestriction, Budget budget)
        {
            Id = id;
            Title = title;
            Ingredients = ingredients;
            Instructions = instructions;
            Difficulty = difficulty;
            TimeRequired = timeRequired;
            DietaryRestriction = dietaryRestriction;
            Budget = budget;

            ratings = new List<Rating>();
            reviews = new List<Review>();
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public List<Ingredient> Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }

        public string Instructions
        {
            get { return instructions; }
            set { instructions = value; }
        }

        public Difficulty Difficulty
        {
            get { return difficulty; }
            set { difficulty = value; }
        }

        public TimeRequired TimeRequired
        {
            get { return timeRequired; }
            set { timeRequired = value; }
        }

        public DietaryRestriction DietaryRestriction
        {
            get { return dietaryRestriction; }
            set { dietaryRestriction = value; }
        }
        
        public Budget Budget
        {
            get { return budget; }
            set { budget = value; }
        }

        public List<Rating> Ratings
        {
            get { return ratings; }
            set { ratings = value; }
        }

        public List<Review> Reviews
        {
            get { return reviews; }
            set { reviews = value; }
        }

        public void EditRecipe(string newTitle, List<Ingredient> newIngredients, string newInstructions, Difficulty newDifficulty, TimeRequired newTimeRequired, DietaryRestriction newDietaryRestriction, Budget newBudget)
        {
            Title = newTitle;
            Ingredients = newIngredients;
            Instructions = newInstructions;
            Difficulty = newDifficulty;
            TimeRequired = newTimeRequired;
            DietaryRestriction = newDietaryRestriction;
            Budget = newBudget;
        }

        public void DeleteRecipe()
        {
        }

    }
}
