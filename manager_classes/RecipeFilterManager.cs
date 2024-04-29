using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_classes.Recipes;
using enum_classes;

namespace manager_classes
{
    //add logic
    public class RecipeFilterManager
    {
        public List<Recipe> FilterByTitle(string title)
        {
            return new List<Recipe>();
        }
        public List<Recipe> FilterByType(string title)
        {
            return new List<Recipe>();
        }
        public List<Recipe> FilterBySpiciness(bool isSpicy)
        {
            return new List<Recipe>();
        }
        public List<Recipe> FilterByAlcoholContent(bool isAlcoholic)
        {
            return new List<Recipe>();
        }
        public List<Recipe> FilterByCaffeineContent(bool hasCaffeine)
        {
            return new List<Recipe>();
        }
        public List<Recipe> FilterByDietaryRestriction(DietaryRestriction dietaryRestriction)
        {
            return new List<Recipe>();
        }
        public List<Recipe> FilterByDifficulty(Difficulty difficulty)
        {
            return new List<Recipe>();
        }
        public List<Recipe> FilterByCookingTime(int maxCookingTime)
        {
            return new List<Recipe>();
        }
        public List<Recipe> FilterByPrice(decimal maxPrice)
        {
            return new List<Recipe>();
        }
    }
}
