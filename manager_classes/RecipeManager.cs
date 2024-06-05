using db_helpers;
using entity_classes;
using System.Collections.Generic;

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

        public void SaveRecipe(MainCourse mainCourse)
        {
            dbHelper.SaveMainCourse(mainCourse);
        }
    }
}
