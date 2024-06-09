using entity_classes;

namespace manager_classes
{
    public interface IToDoListManager
    {
        void AddToDoList(int userId, int recipeId);
        List<Recipe> GetUserToDoList(int userId);
        bool IsRecipeInToDoList(int userId, int recipeId);
        void RemoveFromToDoList(int userId, int recipeId);
    }
}