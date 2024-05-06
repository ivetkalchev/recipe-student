using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class IngredientToRecipeDTO
    {
        public int Id { get; set; }
        public int IdRecipe { get; set; }
        public int IdIngredient { get; set; }
        public decimal Quantity { get; set; }
    }
}