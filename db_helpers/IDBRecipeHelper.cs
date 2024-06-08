using entity_classes;

namespace db_helpers
{
    public interface IDBRecipeHelper
    {
        void AddToDoList(int userId, int recipeId);
        List<DietRestriction> GetAllDietRestrictions();
        List<Difficulty> GetAllDifficulties();
        List<Recipe> GetAllRecipes();
        DietRestriction GetDietByName(string name);
        Difficulty GetDifficultyByName(string name);
        List<Recipe> GetPagedRecipes(int pageNumber, int pageSize, string searchQuery);
        Recipe GetRecipeById(int id);
        List<Review> GetReviewsByRecipeId(int recipeId);
        int GetTotalRecipesCount(string searchQuery);
        void InsertDessert(Dessert recipe);
        void InsertDrink(Drink recipe);
        void InsertMainCourse(MainCourse recipe);
        void InsertReview(Review review, int userId);
        bool IsRecipeInToDoList(int userId, int recipeId);
    }
}