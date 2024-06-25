using db_helpers;
using entity_classes;
using manager_classes;

namespace unit_tests
{
    public class FakeDBRecommendationHelper : IDBRecommendationHelper
    {
        private Dictionary<int, List<int>> userLikedRecipes = new Dictionary<int, List<int>>();
        private Dictionary<int, List<int>> userSimilarities = new Dictionary<int, List<int>>();
        private IRecipeManager recipeManager;

        public FakeDBRecommendationHelper(IRecipeManager recipeManager)
        {
            this.recipeManager = recipeManager;
        }

        public void AddUserLikedRecipe(int userId, int recipeId)
        {
            if (!userLikedRecipes.ContainsKey(userId))
            {
                userLikedRecipes[userId] = new List<int>();
            }
            userLikedRecipes[userId].Add(recipeId);
        }

        public void AddUserSimilarities(int userId, List<int> similarUsers)
        {
            userSimilarities[userId] = similarUsers;
        }

        public List<Recipe> GetUserLikedRecipes(int userId)
        {
            if (!userLikedRecipes.ContainsKey(userId))
                return new List<Recipe>();

            var likedRecipes = new List<Recipe>();
            foreach (var recipeId in userLikedRecipes[userId])
            {
                var recipe = recipeManager.GetRecipeById(recipeId);
                if (recipe != null)
                {
                    likedRecipes.Add(recipe);
                }
            }
            return likedRecipes;
        }

        public List<int> GetUsersWithSimilarLikes(int userId)
        {
            if (!userSimilarities.ContainsKey(userId))
                return new List<int>();

            return userSimilarities[userId];
        }

        public List<Recipe> GetRecipesLikedByUsers(List<int> userIds, int count)
        {
            var recipeIds = new HashSet<int>();
            foreach (var userId in userIds)
            {
                if (userLikedRecipes.ContainsKey(userId))
                {
                    foreach (var recipeId in userLikedRecipes[userId])
                    {
                        recipeIds.Add(recipeId);
                    }
                }
            }

            var recipes = new List<Recipe>();
            foreach (var recipeId in recipeIds)
            {
                var recipe = recipeManager.GetRecipeById(recipeId);
                if (recipe != null)
                {
                    recipes.Add(recipe);
                }
            }

            return recipes.GetRange(0, recipes.Count > count ? count : recipes.Count);
        }
    }
}