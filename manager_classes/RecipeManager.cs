using entity_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using db_helpers;

namespace manager_classes
{
    public class RecipeManager : IRecipeManager
    {
        private IDBRecipeHelper dbHelper;

        public RecipeManager(IDBRecipeHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        public void AddRecipe(Recipe recipe)
        {
            dbHelper.InsertRecipe(recipe);
        }

        public void UpdateRecipe(Recipe recipe)
        {
            dbHelper.UpdateRecipe(recipe);
        }

        public void DeleteRecipe(int idRecipe)
        {
            dbHelper.DeleteRecipe(idRecipe);
        }

        //public Recipe GetRecipeById(int idRecipe)
        //{
        //    return dbHelper.GetRecipeById(idRecipe);
        //}

        //public List<Recipe> GetAllRecipes()
        //{
        //    return dbHelper.GetAllRecipes();
        //}
    }
}
