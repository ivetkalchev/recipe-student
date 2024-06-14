using entity_classes;

namespace db_helpers
{
    public interface IDBRecipeHelper
    {
        void DeleteIngredientFromRecipe(int recipeId, int ingredientId);
        void DeleteRecipe(int recipeId);
        List<DietRestriction> GetAllDietRestrictions();
        List<Difficulty> GetAllDifficulties();
        List<Recipe> GetAllRecipes();
        DietRestriction GetDietByName(string name);
        DietRestriction GetDietRestrictionById(int dietId);
        Difficulty GetDifficultyById(int difficultyId);
        Difficulty GetDifficultyByName(string name);
        List<Recipe> GetPagedRecipes(int pageNumber, int pageSize, string searchQuery);
        Recipe GetRecipeById(int id);
        int GetTotalRecipesCount(string searchQuery);
        void InsertDessert(Dessert recipe);
        void InsertDrink(Drink recipe);
        void InsertIngredientToRecipe(int recipeId, int ingredientId, int unitId, decimal quantity);
        void InsertMainCourse(MainCourse recipe);
        void UpdateDessert(Dessert recipe);
        void UpdateDrink(Drink recipe);
        void UpdateMainCourse(MainCourse recipe);
    }
}