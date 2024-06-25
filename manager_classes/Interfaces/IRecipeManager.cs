using entity_classes;

namespace manager_classes
{
    public interface IRecipeManager
    {
        void DeleteIngredientFromRecipe(int recipeId, int ingredientId);
        void DeleteRecipe(int recipeId);
        List<DietRestriction> GetAllDietRestrictions();
        List<Difficulty> GetAllDifficulties();
        List<Recipe> GetAllRecipes();
        DietRestriction GetDietByName(string name);
        Difficulty GetDifficultyByName(string name);
        List<Recipe> GetPagedRecipes(int pageNumber, int pageSize, string searchQuery, string sortOption);
        Recipe GetRecipeById(int id);
        int GetTotalRecipesCount(string searchQuery);
        void InsertIngredientToRecipe(int recipeId, int ingredientId, int unitId, decimal quantity);
        void UpdateDessert(Dessert dessert);
        void UpdateDrink(Drink drink);
        void UpdateMainCourse(MainCourse mainCourse);
        void UploadDessert(Dessert recipe);
        void UploadDrink(Drink recipe);
        void UploadMainCourse(MainCourse recipe);
    }
}