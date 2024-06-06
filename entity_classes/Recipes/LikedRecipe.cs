using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_classes.Recipes
{
    public class LikedRecipe
    {
        private WebUser user;
        private Recipe recipe;
        
        public LikedRecipe(WebUser user, Recipe recipe)
        {
            this.user = user;
            this.recipe = recipe;
        }

        public WebUser GetWebUser()
        {
            return user;
        }
        
        public Recipe GetRecipe()
        {
            return recipe;
        }

    }
}
