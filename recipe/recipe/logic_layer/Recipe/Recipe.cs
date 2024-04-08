using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer.Recipe
{
    public class Recipe
    {
        public int Id { get; private set; }
        private string title;
        private readonly List<Ingredient> ingredients;
        private string instructions;

        protected Recipe(int id, string title, List<Ingredient> ingredients, string instructions)
        {
            Id = id;
            SetTitle(title);
            this.ingredients = new List<Ingredient>();
            SetIngredients(ingredients);
            SetInstructions(instructions);
        }

        public string GetTitle()
        {
            return title;
        }

        public List<Ingredient> GetIngredients()
        {
            return new List<Ingredient>(ingredients);
        }

        public string GetInstructions()
        {
            return instructions;
        }

        private void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                title = "No Title";
            }
            this.title = title;
        }

        private void SetIngredients(List<Ingredient> ingredients)
        {
            if (ingredients.Count() == 0)
            {
                this.ingredients.Clear();
            }
            else
            {
                this.ingredients.AddRange(ingredients);
            }
        }

        private void SetInstructions(string instructions)
        {
            if (string.IsNullOrWhiteSpace(instructions))
            {
                instructions = "No instructions provided.";
            }
            this.instructions = instructions;
        }
    }
}
