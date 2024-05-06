using DTOs;
using enum_classes.Recipes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class RecipeDAO
    {
        private string connectionString;

        public RecipeDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
