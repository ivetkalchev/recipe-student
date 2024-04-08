using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer.Recipe.Recipe
{
    public class Ingredient
    {
        public string Name { get; }
        public string Unit { get; }
        public decimal PricePerUnit { get; }

        public Ingredient(string name, string unit, decimal pricePerUnit)
        {
            Name = name;
            Unit = unit;
            PricePerUnit = pricePerUnit;
        }
        public override string ToString()
        {
            return $"{Name}, {Unit}, {PricePerUnit:C}";
        }
    }
}
