using db_helpers;
using entity_classes;

namespace manager_classes
{
    public class RecipeManager : IRecipeManager
    {
        private IDBRecipeHelper dbHelper;

        public RecipeManager(IDBRecipeHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        public List<DietRestriction> GetAllDietRestrictions()
        {
            return dbHelper.GetAllDietRestrictions();
        }

        public List<Difficulty> GetAllDifficulties()
        {
            return dbHelper.GetAllDifficulties();
        }

        public DietRestriction GetDietByName(string name)
        {
            return dbHelper.GetDietByName(name);
        }

        public Difficulty GetDifficultyByName(string name)
        {
            return dbHelper.GetDifficultyByName(name);
        }

        public void UploadMainCourse(MainCourse recipe)
        {
            dbHelper.InsertMainCourse(recipe);
        }

        public void UploadDrink(Drink recipe)
        {
            dbHelper.InsertDrink(recipe);
        }

        public void UploadDessert(Dessert recipe)
        {
            dbHelper.InsertDessert(recipe);
        }

        public List<Recipe> GetAllRecipes()
        {
            return dbHelper.GetAllRecipes();
        }

        public Recipe GetRecipeById(int id)
        {
            return dbHelper.GetRecipeById(id);
        }

        public void AddToDoList(int userId, int recipeId)
        {
            dbHelper.AddToDoList(userId, recipeId);
        }

        public bool IsRecipeInToDoList(int userId, int recipeId)
        {
            return dbHelper.IsRecipeInToDoList(userId, recipeId);
        }

        public List<Recipe> GetPagedRecipes(int pageNumber, int pageSize, string searchQuery)
        {
            return dbHelper.GetPagedRecipes(pageNumber, pageSize, searchQuery);
        }

        public int GetTotalRecipesCount(string searchQuery)
        {
            return dbHelper.GetTotalRecipesCount(searchQuery);
        }

        public void AddReview(Review review, int userId)
        {
            dbHelper.InsertReview(review, userId);
        }

        public List<Review> GetReviewsByRecipeId(int recipeId)
        {
            var reviews = dbHelper.GetReviewsByRecipeId(recipeId);
            var recipe = GetRecipeById(recipeId);
            foreach (var review in reviews)
            {
                review.SetRecipe(recipe);
            }
            return reviews;
        }
    }
}
