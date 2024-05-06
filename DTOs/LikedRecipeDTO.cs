using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class LikedRecipeDTO
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdRecipe { get; set; }
    }
}
