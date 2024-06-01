using entity_classes;

namespace db_helpers
{
    public interface IDBRecipeHelper
    {
        void DeleteRecipe(int idRecipe);
        //List<Recipe> GetAllRecipes();
        //Recipe GetRecipeById(int idRecipe);
        void InsertRecipe(Recipe recipe);
        void UpdateRecipe(Recipe recipe);
    }
}