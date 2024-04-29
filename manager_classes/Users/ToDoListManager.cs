using entity_classes.Ratings;
using entity_classes.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manager_classes.Users
{
    public class ToDoListManager
    {
        private List<Recipe> toDoList;
        public ToDoListManager()
        {
            toDoList = new List<Recipe>();
        }
        public void AddToToDoList(Recipe recipe)
        {
            toDoList.Add(recipe);
        }
        public void RemoveFromToDoList(Recipe recipe)
        {
            toDoList.Remove(recipe);
        }
    }
}
