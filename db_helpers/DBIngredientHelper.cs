﻿using System.Data.SqlClient;
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
                    string query = "INSERT INTO Ingredient (name, id_type) VALUES (@Name, @IdType)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", newIngredient.GetName());
                    cmd.Parameters.AddWithValue("@IdType", newIngredient.GetType().GetId());

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
                    string query = @"SELECT i.id_ingredient, i.name, t.id_type, t.type 
                                     FROM Ingredient i 
                                     JOIN TypeIngredient t ON i.id_type = t.id_type";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TypeIngredient typeIngredient = new TypeIngredient((int)reader["id_type"], reader["type"].ToString());
                            Ingredient ingredient = new Ingredient((int)reader["id_ingredient"], reader["name"].ToString(), typeIngredient);
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
                    cmd.Parameters.AddWithValue("@Id", ingredient.GetId());

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting ingredient: " + ex.Message);
                throw new Exception("Unable to delete ingredient. Please try again later.");
            }
        }

        public void UpdateIngredientDetails(Ingredient ingredient, string newName, TypeIngredient newType)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.connection))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string updateQuery = @"
                    UPDATE Ingredient
                    SET name = @Name, id_type = @IdType
                    WHERE id_ingredient = @Id";

                    SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction);
                    cmd.Parameters.AddWithValue("@Id", ingredient.GetId());
                    cmd.Parameters.AddWithValue("@Name", newName);
                    cmd.Parameters.AddWithValue("@IdType", newType.GetId());

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
                    cmd.Parameters.AddWithValue("@Id", ingredient.GetId());

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

        public List<IngredientRecipe> GetIngredientsForRecipe(int recipeId)
        {
            List<IngredientRecipe> ingredients = new List<IngredientRecipe>();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = @"
                        SELECT ir.id_recipe, ir.id_ingredient, ir.id_unit, ir.quantity, 
                               i.name AS ingredient_name, 
                               u.unit AS unit_name,
                               t.id_type, t.type
                        FROM IngredientRecipe ir
                        JOIN Ingredient i ON ir.id_ingredient = i.id_ingredient
                        JOIN Unit u ON ir.id_unit = u.id_unit
                        JOIN TypeIngredient t ON i.id_type = t.id_type
                        WHERE ir.id_recipe = @RecipeId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@RecipeId", recipeId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ingredient ingredient = new Ingredient(
                                (int)reader["id_ingredient"],
                                reader["ingredient_name"].ToString(),
                                new TypeIngredient((int)reader["id_type"], reader["type"].ToString())
                            );

                            Unit unit = new Unit((int)reader["id_unit"], reader["unit_name"].ToString());
                            decimal quantity = (decimal)reader["quantity"];

                            ingredients.Add(new IngredientRecipe(ingredient, quantity, unit));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching ingredients for recipe: " + ex.Message);
                throw new Exception("Unable to fetch ingredients for recipe. Please try again later.");
            }

            return ingredients;
        }

        public void InsertIngredientToRecipe(int recipeId, int ingredientId, int unitId, decimal quantity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = "INSERT INTO IngredientRecipe (id_recipe, id_ingredient, id_unit, quantity) VALUES (@recipeId, @ingredientId, @unitId, @quantity)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@recipeId", recipeId);
                    cmd.Parameters.AddWithValue("@ingredientId", ingredientId);
                    cmd.Parameters.AddWithValue("@unitId", unitId);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding ingredient to recipe: " + ex.Message);
                throw new Exception("Unable to add ingredient to recipe. Please try again later.", ex);
            }
        }

        public void DeleteIngredientFromRecipe(int recipeId, int ingredientId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = "DELETE FROM IngredientRecipe WHERE id_recipe = @recipeId AND id_ingredient = @ingredientId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@recipeId", recipeId);
                    cmd.Parameters.AddWithValue("@ingredientId", ingredientId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting ingredient from recipe: " + ex.Message);
                throw new Exception("Unable to delete ingredient from recipe. Please try again later.", ex);
            }
        }
    }
}