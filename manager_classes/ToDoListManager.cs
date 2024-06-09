using db_helpers;
using entity_classes;

namespace manager_classes
{
    public class ToDoListManager : IToDoListManager
    {
        private IDBToDoListHelper toDoHelper;

        public ToDoListManager(IDBToDoListHelper toDoHelper)
        {
            this.toDoHelper = toDoHelper;
        }

        public void AddToDoList(int userId, int recipeId)
        {
            toDoHelper.AddToDoList(userId, recipeId);
        }

        public bool IsRecipeInToDoList(int userId, int recipeId)
        {
            return toDoHelper.IsRecipeInToDoList(userId, recipeId);
        }

        public List<Recipe> GetUserToDoList(int userId)
        {
            return toDoHelper.GetUserToDoList(userId);
        }

        public void RemoveFromToDoList(int userId, int recipeId)
        {
            toDoHelper.RemoveFromToDoList(userId, recipeId);
        }
    }
}
