using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_classes;
using enum_classes;

namespace entity_classes.Recipes
{
    public abstract class Recipe
    {
        private int idRecipe;
        private string title;
        private List<Ingredient> ingredients;
        private string instructions;
        private DietaryRestriction dietaryRestriction;
        private Difficulty difficulty;
        private int cookingTime;
        protected Recipe(int idRecipe, string title, List<Ingredient> ingredients, string instructions, DietaryRestriction dietaryRestriction,
            Difficulty difficulty, int cookingTime)
        {
            this.idRecipe = idRecipe;
            this.title = title;
            this.ingredients = ingredients;
            this.instructions = instructions;
            this.dietaryRestriction = dietaryRestriction;
            this.difficulty = difficulty;
            this.cookingTime = cookingTime;
        }
        public abstract decimal CalculatePrice();
        public List<Ingredient> GetIngredients()
        {
            return ingredients;
        }
    }
}
