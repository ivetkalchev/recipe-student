using enum_classes.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class IngredientDTO
    {
        public int IdIngredient { get; private set; }
        public string Name { get; private set; }
        public Unit Unit { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}
