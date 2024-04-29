using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_classes.Users;
using enum_classes.Recipes;

namespace entity_classes.Recipes
{
    public class Ingredient
    {
        private int idIngredient;
        private string name;
        private Unit unit;
        private decimal quantity;
        private decimal price;
        public Ingredient(int idIngredient, string name, Unit unit, decimal quantity, decimal price)
        {
            this.idIngredient = idIngredient;
            this.name = name;
            this.unit = unit;
            this.quantity = quantity;
            this.price = price;
        }
        public decimal GetQuantity() 
        { 
            return quantity;
        }

        public decimal GetPrice() 
        { 
            return price;
        }
    }
}
