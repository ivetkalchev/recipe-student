using enum_classes.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class RecipeDTO
    {
        public int IdRecipe { get; set; }
        public int IdUser { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Instructions { get; set; }
        public string DietaryRestriction { get; set; }
        public string Difficulty { get; set; }
        public int CookingTime { get; set; }
        public DateTime PublishDate { get; set; }
        public byte[] RecipePic { get; set; }

    }
}
