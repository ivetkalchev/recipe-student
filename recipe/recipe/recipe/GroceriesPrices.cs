using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipe
{
    public class GroceriesPrices
    {
        private static Dictionary<Groceries, decimal> groceriesPrices = new Dictionary<Groceries, decimal>()
        {
            { Groceries.Eggs, 1.5m },
            { Groceries.Flour, 0.8m },
            { Groceries.Sugar, 1m },
            { Groceries.Butter, 1.5m },
            { Groceries.Milk, 0.7m },
            { Groceries.Salt, 0.5m },
            { Groceries.Pepper, 1m },
            { Groceries.OliveOil, 5m },
            { Groceries.Onions, 1.2m },
            { Groceries.Garlic, 0.5m }
        };

        public static decimal GetPrice(Groceries ingredient)
        {
            if (groceriesPrices.ContainsKey(ingredient))
            {
                return groceriesPrices[ingredient];
            }
            else
            {
                throw new ArgumentException("Grocery price not found.");
            }
        }
    }
}
