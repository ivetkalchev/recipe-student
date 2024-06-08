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
        Recipe GetRecipeById(int id);
        void InsertDessert(Dessert recipe);
        void InsertDrink(Drink recipe);
        void InsertMainCourse(MainCourse recipe);
        void AddToDoList(int userId, int recipeId);
        bool IsRecipeInToDoList(int userId, int recipeId);
    }
}