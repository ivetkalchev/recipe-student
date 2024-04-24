using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_classes.Recipe
{
    public class Ingredient
    {
        private int idIngredient;
        private string name;
        private Unit unit;
        private decimal quantity;
        private bool vegan;
        private bool diary;
        private bool peanut;

        public Ingredient(int idIngredient, string name, Unit unit, decimal quantity, bool vegan, bool diary, bool peanut)
        {
            this.idIngredient = idIngredient;
            this.name = name;
            this.unit = unit;
            this.quantity = quantity;
            this.vegan = vegan;
            this.diary = diary;
            this.peanut = peanut;
        }
    }
}
