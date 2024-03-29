using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipe
{
    public class Ingredient
    {
        private string name;
        private decimal quantity;
        private string unit;
        private decimal pricePerUnit;

        public string Name { get { return name; } }
        public decimal Quantity { get { return quantity; } }
        public string Unit { get { return unit; } }
        public decimal PricePerUnit { get { return pricePerUnit; } }

        public Ingredient(string name, decimal quantity, string unit, decimal pricePerUnit)
        {
            this.name = name;
            this.quantity = quantity;
            this.unit = unit;
            this.pricePerUnit = pricePerUnit;
        }

        public decimal CalculateCost()
        {
            return quantity * pricePerUnit;
        }
    }
}
