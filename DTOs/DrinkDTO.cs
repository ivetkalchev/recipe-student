using enum_classes.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DrinkDTO
    {
        public bool IsAlcoholic { get; set; }
        public bool HasCaffeine { get; set; }
        public int Pours { get; set; }
    }
}
