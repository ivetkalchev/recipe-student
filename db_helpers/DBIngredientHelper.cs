using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using entity_classes;

namespace db_helpers
{
    public class DBIngredientHelper : DBConnection, IDBIngredientHelper
    {
        public List<Unit> GetAllUnits()
        {
            List<Unit> units = new List<Unit>();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = "SELECT * FROM Unit";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            units.Add(new Unit((int)reader["id_unit"], reader["unit"].ToString()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching units: " + ex.Message);
                throw new Exception("Unable to fetch units. Please try again later.");
            }

            return units;
        }

        public void AddIngredient(Ingredient newIngredient)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = "INSERT INTO Ingredient (name, id_unit, price) VALUES (@Name, @UnitId, @Price)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", newIngredient.GetName());
                    cmd.Parameters.AddWithValue("@UnitId", newIngredient.GetUnit().GetId());
                    cmd.Parameters.AddWithValue("@Price", newIngredient.GetPrice());

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding ingredient: " + ex.Message);
                throw new Exception("Unable to add ingredient. Please try again later.");
            }
        }

        public bool DoesIngredientExist(string name)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Ingredient WHERE name = @Name";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", name);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking if ingredient exists: " + ex.Message);
                throw new Exception("Unable to verify ingredient existence. Please try again later.");
            }
        }

        public List<Ingredient> GetAllIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = "SELECT i.id_ingredient, i.name, i.price, u.id_unit, u.unit FROM Ingredient i JOIN Unit u ON i.id_unit = u.id_unit";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Unit unit = new Unit((int)reader["id_unit"], reader["unit"].ToString());
                            Ingredient ingredient = new Ingredient((int)reader["id_ingredient"], reader["name"].ToString(), unit, (decimal)reader["price"]);
                            ingredients.Add(ingredient);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching ingredients: " + ex.Message);
                throw new Exception("Unable to fetch ingredients. Please try again later.");
            }

            return ingredients;
        }

        public void DeleteIngredient(Ingredient ingredient)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = "DELETE FROM Ingredient WHERE id_ingredient = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", ingredient.GetIdIngredient());

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting ingredient: " + ex.Message);
                throw new Exception("Unable to delete ingredient. Please try again later.");
            }
        }
    }
}
