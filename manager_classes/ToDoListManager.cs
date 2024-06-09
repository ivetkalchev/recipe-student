using db_helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
