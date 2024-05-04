using entity_classes.Users;
using enum_classes.Recipes;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using entity_classes.Ingredients;

namespace entity_classes.Recipes
{
    public class Drink : Recipe
    {
        private bool isAlcoholic;
        private bool hasCaffeine;
        private int pours;
        public Drink(int idRecipe, User user, string title, List<Ingredient> ingredients,
            string instructions, DietaryRestriction dietaryRestriction, Difficulty difficulty, int cookingTime, DateTime publishDate,
            bool isAlcoholic, bool hasCaffeine, int pours)
            : base(idRecipe, user, title, ingredients, instructions, dietaryRestriction, difficulty, cookingTime, publishDate)
        {
            this.isAlcoholic = isAlcoholic;
            this.hasCaffeine = hasCaffeine;
            this.pours = pours;
        }
        public override decimal CalculatePrice()
        {
            decimal totalPrice = 0;
            foreach (Ingredient ingredient in this.GetIngredients())
            {
                totalPrice += ingredient.GetPrice() * ingredient.GetQuantity();
            }

            if (pours != 0)
            {
                return totalPrice * pours;
            }

            return totalPrice;
        }
        public bool GetAlcoholicContent()
        {
            return isAlcoholic;
        }
        public bool GetCaffeineContent()
        {
            return hasCaffeine;
        }
        public int GetPours()
        {
            return pours;
        }
    }
}
