using entity_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using db_helpers;

namespace manager_classes
{
    public class IngredientManager : IIngredientManager
    {
        private IDBIngredientHelper dbHelper;

        public IngredientManager(IDBIngredientHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        public List<Unit> GetAllUnits()
        {
            return dbHelper.GetAllUnits();
        }
    }
}
