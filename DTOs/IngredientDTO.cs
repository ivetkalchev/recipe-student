﻿using enum_classes.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class IngredientDTO
    {
        public int IdIngredient { get; set; }
        public string Name { get; set; }
        public Unit Unit { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
