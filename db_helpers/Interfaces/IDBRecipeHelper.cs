using entity_classes;

namespace db_helpers
{
    public interface IDBRecipeHelper
    {
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
        void InsertMainCourse(MainCourse recipe);
    }
}