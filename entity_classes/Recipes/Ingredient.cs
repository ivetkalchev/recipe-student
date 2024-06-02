using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_classes
{
    public class Ingredient
    {
        private int idIngredient;
        private string name;
        private Unit unit;
        private decimal price;

        public Ingredient(int idIngredient, string name, Unit unit, decimal price)
        {
            this.idIngredient = idIngredient;
            this.name = name;
            this.unit = unit;
            this.price = price;
        }

        public int GetIdIngredient()
        {
            return idIngredient;
        }

        public string GetName()
        {
            return name;
        }

        public Unit GetUnit()
        {
            return unit;
        }

        public decimal GetPrice()
        {
            return price;
        }
    }
}
