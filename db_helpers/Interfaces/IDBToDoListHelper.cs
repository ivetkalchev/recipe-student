using entity_classes;

namespace db_helpers
{
    public interface IDBToDoListHelper
    {
        void AddToDoList(int userId, int recipeId);
        bool IsRecipeInToDoList(int userId, int recipeId);
        List<Recipe> GetUserToDoList(int userId);
        void RemoveFromToDoList(int userId, int recipeId);
    }
}