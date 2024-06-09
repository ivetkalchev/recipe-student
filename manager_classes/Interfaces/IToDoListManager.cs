namespace manager_classes
{
    public interface IToDoListManager
    {
        void AddToDoList(int userId, int recipeId);
        bool IsRecipeInToDoList(int userId, int recipeId);
    }
}