namespace db_helpers
{
    public interface IDBToDoListHelper
    {
        void AddToDoList(int userId, int recipeId);
        bool IsRecipeInToDoList(int userId, int recipeId);
    }
}