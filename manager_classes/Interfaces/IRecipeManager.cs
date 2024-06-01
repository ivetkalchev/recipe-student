using entity_classes;

namespace manager_classes
{
    public interface IRecipeManager
    {
        void AddRecipe(Recipe recipe);
        void DeleteRecipe(int idRecipe);
        //List<Recipe> GetAllRecipes();
        //Recipe GetRecipeById(int idRecipe);
        void UpdateRecipe(Recipe recipe);
    }
}