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
    }
}
