using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer
{
    public class Ingredient
    {
        private string name;
        private string unit;
        private decimal pricePerUnit;

        public string Name { get { return name; } }
        public string Unit { get { return unit; } }
        public decimal PricePerUnit { get { return pricePerUnit; } }

        public Ingredient(string name, string unit, decimal pricePerUnit)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name cannot be null or empty.");

            if (pricePerUnit < 0)
                throw new ArgumentException("Price per unit cannot be negative.");

            this.name = name;
            this.unit = unit;
            this.pricePerUnit = pricePerUnit;
        }

        public decimal CalculateCost()
        {
            //add logic
            return 0;
        }
    }
}
