using entity_classes;

namespace db_helpers
{
    public interface IDBRecipeHelper
    {
        List<DietRestriction> GetAllDietRestrictions();
        List<Difficulty> GetAllDifficulties();
        List<Recipe> GetAllRecipes();
        DietRestriction GetDietByName(string name);
        Difficulty GetDifficultyByName(string name);
        List<Recipe> GetPagedRecipes(int pageNumber, int pageSize, string searchQuery);
        Recipe GetRecipeById(int id);
        void InsertDessert(Dessert recipe);
        void InsertDrink(Drink recipe);
        void InsertMainCourse(MainCourse recipe);
    }
}