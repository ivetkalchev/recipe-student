using db_helpers;
using entity_classes;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace manager_classes
{
    public class RecipeRecommendationService : IRecipeRecommendationService
    {
        private readonly IRecipeManager recipeManager;
        private readonly IToDoListManager toDoListManager;
        private readonly IReviewManager reviewManager;
        private readonly IDBRecommendationHelper recommendationHelper;

        public RecipeRecommendationService(IRecipeManager recipeManager, IToDoListManager toDoListManager, IReviewManager reviewManager, IDBRecommendationHelper recommendationHelper)
        {
            this.recipeManager = recipeManager;
            this.toDoListManager = toDoListManager;
            this.reviewManager = reviewManager;
            this.recommendationHelper = recommendationHelper;
        }

        public List<Recipe> GetRecommendedRecipes(int userId)
        {
            try
            {
                var userLikedRecipes = recommendationHelper.GetUserLikedRecipes(userId);

                if (userLikedRecipes == null || userLikedRecipes.Count == 0)
                {
                    return GetMostPopularRecipes();
                }
                else
                {
                    return GetUserBasedRecommendations(userId, userLikedRecipes);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get recommended recipes. Please try again later.");
            }
        }

        public List<Recipe> GetMostPopularRecipes()
        {
            var allRecipes = recipeManager.GetAllRecipes();

            var recipeReviewCounts = new Dictionary<int, int>();
            foreach (var recipe in allRecipes)
            {
                int reviewCount = reviewManager.GetReviewsByRecipeId(recipe.GetIdRecipe()).Count;
                if (reviewCount > 0)
                {
                    recipeReviewCounts.Add(recipe.GetIdRecipe(), reviewCount);
                }
            }

            var sortedRecipes = new List<KeyValuePair<int, int>>(recipeReviewCounts);
            sortedRecipes.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

            var popularRecipes = new List<Recipe>();
            for (int i = 0; i < sortedRecipes.Count && i < 4; i++)
            {
                int recipeId = sortedRecipes[i].Key;
                foreach (var recipe in allRecipes)
                {
                    if (recipe.GetIdRecipe() == recipeId)
                    {
                        popularRecipes.Add(recipe);
                        break;
                    }
                }
            }

            return popularRecipes;
        }

        private List<Recipe> GetUserBasedRecommendations(int userId, List<Recipe> userLikedRecipes)
        {
            var similarUsers = recommendationHelper.GetUsersWithSimilarLikes(userId);

            if (similarUsers.Count == 0)
            {
                return new List<Recipe>();
            }

            var recommendedRecipes = recommendationHelper.GetRecipesLikedByUsers(similarUsers, 4);
            var uniqueRecommendations = new List<Recipe>();

            foreach (var recipe in recommendedRecipes)
            {
                if (!userLikedRecipes.Contains(recipe))
                {
                    uniqueRecommendations.Add(recipe);
                }
            }
            return uniqueRecommendations;
        }
    }
}
