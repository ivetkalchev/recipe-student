using db_helpers;
using entity_classes;
using manager_classes;

namespace unit_tests
{
    public class FakeDBToDoListHelper : IDBToDoListHelper
    {
        private Dictionary<int, List<int>> userToDoList = new Dictionary<int, List<int>>();

        public void AddToDoList(int userId, int recipeId)
        {
            if (!userToDoList.ContainsKey(userId))
            {
                userToDoList[userId] = new List<int>();
            }
            userToDoList[userId].Add(recipeId);
        }

        public bool IsRecipeInToDoList(int userId, int recipeId)
        {
            return userToDoList.ContainsKey(userId) && userToDoList[userId].Contains(recipeId);
        }

        public List<Recipe> GetUserToDoList(int userId)
        {
            var recipeIds = userToDoList.ContainsKey(userId) ? userToDoList[userId] : new List<int>();
            var recipes = new List<Recipe>();
            foreach (var recipeId in recipeIds)
            {
                recipes.Add(new RecipeManager(new FakeDBRecipeHelper()).GetRecipeById(recipeId));
            }
            return recipes;
        }

        public void RemoveFromToDoList(int userId, int recipeId)
        {
            if (userToDoList.ContainsKey(userId))
            {
                userToDoList[userId].Remove(recipeId);
            }
        }
    }
}