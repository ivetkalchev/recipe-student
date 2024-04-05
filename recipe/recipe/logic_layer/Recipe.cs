using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer
{
    public class Recipe
    {
        private int id;
        private string title;
        private List<Ingredient> ingredients;
        private string instructions;

        public Recipe(int id, string title, List<Ingredient> ingredients, string instructions)
        {
            this.id = id;
            this.title = title;
            this.ingredients = ingredients;
            this.instructions = instructions;
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
    }
}
