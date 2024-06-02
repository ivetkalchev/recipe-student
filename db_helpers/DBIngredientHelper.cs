using entity_classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_helpers
{
    public class DBIngredientHelper : DBConnection, IDBIngredientHelper
    {
        public List<Unit> GetAllUnits()
        {
            List<Unit> units = new List<Unit>();

            using (SqlConnection conn = new SqlConnection(DBConnection.connection))
            {
                conn.Open();
                string query = "SELECT id_unit, unit FROM Unit";
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        units.Add(new Unit(reader.GetInt32(0), reader.GetString(1)));
                    }
                }
            }

            return units;
        }
    }
}
