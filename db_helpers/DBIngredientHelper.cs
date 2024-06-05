using System.Data.SqlClient;
using entity_classes;

namespace db_helpers
{
    public class DBIngredientHelper : DBConnection, IDBIngredientHelper
    {
        public List<TypeIngredient> GetAllTypes()
        {
            List<TypeIngredient> types = new List<TypeIngredient>();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = "SELECT * FROM TypeIngredient";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            types.Add(new TypeIngredient((int)reader["id_type"], reader["type"].ToString()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching types: " + ex.Message);
                throw new Exception("Unable to fetch types. Please try again later.");
            }

            return types;
        }

        public void AddIngredient(Ingredient newIngredient)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = "INSERT INTO Ingredient (name, id_type, price) VALUES (@Name, @IdType, @Price)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", newIngredient.GetName());
                    cmd.Parameters.AddWithValue("@IdType", newIngredient.GetTypeIngredient().GetId());
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
                    string query = "SELECT i.id_ingredient, i.name, i.price, t.id_type, t.type FROM Ingredient i JOIN TypeIngredient t ON i.id_type = t.id_type";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TypeIngredient typeIngredient = new TypeIngredient((int)reader["id_type"], reader["type"].ToString());
                            Ingredient ingredient = new Ingredient((int)reader["id_ingredient"], reader["name"].ToString(), typeIngredient, (decimal)reader["price"]);
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

        public void UpdateIngredientDetails(Ingredient ingredient, string newName, TypeIngredient newType, decimal newPrice)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.connection))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string updateQuery = @"
                    UPDATE Ingredient
                    SET name = @Name, id_type = @IdType, price = @Price
                    WHERE id_ingredient = @Id";

                    SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction);
                    cmd.Parameters.AddWithValue("@Id", ingredient.GetIdIngredient());
                    cmd.Parameters.AddWithValue("@Name", newName);
                    cmd.Parameters.AddWithValue("@IdType", newType.GetId());
                    cmd.Parameters.AddWithValue("@Price", newPrice);

                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error updating ingredient details: " + ex.Message);
                    throw new Exception("Unable to update ingredient details. Please try again later.");
                }
            }
        }

        public bool IsIngredientNameTakenByOtherIngredient(Ingredient ingredient, string name)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Ingredient WHERE name = @Name AND id_ingredient != @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Id", ingredient.GetIdIngredient());

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking if ingredient name is taken by another ingredient: " + ex.Message);
                throw new Exception("Unable to verify ingredient name. Please try again later.");
            }
        }
    }
}
