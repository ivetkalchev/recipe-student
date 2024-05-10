using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_classes;
using enum_classes.Recipes;
using entity_classes.Users;
using entity_classes.Ingredients;

namespace entity_classes.Recipes
{
    public abstract class Recipe
    {
        private int idRecipe;
        private User user;
        private string title;
        private List<Ingredient> ingredients;
        private string instructions;
        private DietaryRestriction dietaryRestriction;
        private Difficulty difficulty;
        private int cookingTime;
        private DateTime publishDate;
        public Recipe(int idRecipe, User user, string title, List<Ingredient> ingredients, string instructions, 
            DietaryRestriction dietaryRestriction, Difficulty difficulty, int cookingTime, DateTime publishDate)
        {
            this.idRecipe = idRecipe;
            this.user = user;
            this.title = title;
            this.ingredients = ingredients;
            this.instructions = instructions;
            this.dietaryRestriction = dietaryRestriction;
            this.difficulty = difficulty;
            this.cookingTime = cookingTime;
            this.publishDate = publishDate;
        }
        public abstract decimal CalculatePrice();
        public List<Ingredient> GetIngredients()
        {
            return ingredients;
        }
    }
}
