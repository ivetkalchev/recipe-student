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
        public int IdRecipe { get; private set; }
        public int IdUser { get; private set; }
        public string Title { get; private set; }
        public string Instructions { get; private set; }
        public DietaryRestriction DietaryRestriction { get; private set; }
        public Difficulty Difficulty { get; private set; }
        public int CookingTime { get; private set; }
        public DateTime PublishDate { get; private set; }
        public bool IsAlcoholic { get; private set; }
        public bool HasCaffeine { get; private set; }
        public int Pours { get; private set; }
    }
}
