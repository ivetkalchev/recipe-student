using entity_classes;
using System.Collections.Generic;
using System.Linq;

namespace manager_classes
{
    public class RecipeRecommendationService : IRecipeRecommendationService
    {
        private readonly IRecipeManager recipeManager;
        private readonly IToDoListManager toDoListManager;
        private readonly IReviewManager reviewManager;

        public RecipeRecommendationService(IRecipeManager recipeManager, IToDoListManager toDoListManager, IReviewManager reviewManager)
        {
            this.recipeManager = recipeManager;
            this.toDoListManager = toDoListManager;
            this.reviewManager = reviewManager;
        }

        public List<Recipe> GetRecommendedRecipes(int userId)
        {
            var userToDoList = toDoListManager.GetUserToDoList(userId);

            if (userToDoList == null || userToDoList.Count == 0)
            {
                return GetMostPopularRecipes();
            }
            else
            {
                return GetSimilarRecipes(userToDoList);
            }
        }

        private List<Recipe> GetMostPopularRecipes()
        {
            var allRecipes = recipeManager.GetAllRecipes();
            var popularRecipes = allRecipes.OrderByDescending(r => reviewManager.GetReviewsByRecipeId(r.GetIdRecipe()).Count)
                                          .Take(4)
                                          .ToList();
            return popularRecipes;
        }

        private List<Recipe> GetSimilarRecipes(List<Recipe> userToDoList)
        {
            var allRecipes = recipeManager.GetAllRecipes();
            var similarRecipes = new List<Recipe>();
            var uniqueRecipeIds = new HashSet<int>();

            foreach (var toDoRecipe in userToDoList)
            {
                var toDoRecipeDetails = recipeManager.GetRecipeById(toDoRecipe.GetIdRecipe());

                if (toDoRecipeDetails == null || toDoRecipeDetails.GetDietRestriction() == null || toDoRecipeDetails.GetDifficulty() == null)
                {
                    continue;
                }

                var dietRestriction = toDoRecipeDetails.GetDietRestriction();
                var difficulty = toDoRecipeDetails.GetDifficulty();

                foreach (var recipe in allRecipes)
                {
                    if (recipe == null || recipe.GetDietRestriction() == null || recipe.GetDifficulty() == null)
                        continue;

                    var recipeDiet = recipe.GetDietRestriction();
                    var recipeDifficulty = recipe.GetDifficulty();

                    if (recipeDiet.GetId() == dietRestriction.GetId() &&
                        recipeDifficulty.GetId() == difficulty.GetId() &&
                        recipe.GetIdRecipe() != toDoRecipe.GetIdRecipe() &&
                        !uniqueRecipeIds.Contains(recipe.GetIdRecipe()))
                    {
                        similarRecipes.Add(recipe);
                        uniqueRecipeIds.Add(recipe.GetIdRecipe());

                        if (similarRecipes.Count >= 2)
                            return similarRecipes.Take(2).ToList();
                    }
                }
            }

            return similarRecipes.Take(2).ToList();
        }
    }
}