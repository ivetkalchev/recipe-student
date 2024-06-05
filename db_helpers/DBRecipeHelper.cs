using entity_classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace db_helpers
{
    public class DBRecipeHelper : DBConnection, IDBRecipeHelper
    {
        public List<DietRestriction> GetAllDietRestrictions()
        {
            List<DietRestriction> dietRestrictions = new List<DietRestriction>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    string query = "SELECT * FROM DietRestriction";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dietRestrictions.Add(new DietRestriction((int)reader["id_diet_restriction"], reader["diet"].ToString()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching diet restrictions: " + ex.Message);
                throw new Exception("Unable to fetch diet restrictions. Please try again later.");
            }

            return dietRestrictions;
        }

        public List<Difficulty> GetAllDifficulties()
        {
            List<Difficulty> difficulties = new List<Difficulty>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    string query = "SELECT * FROM Difficulty";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            difficulties.Add(new Difficulty((int)reader["id_difficulty"], reader["difficulty"].ToString()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching difficulties: " + ex.Message);
                throw new Exception("Unable to fetch difficulties. Please try again later.");
            }

            return difficulties;
        }

        public DietRestriction GetDietByName(string name)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    string query = "SELECT * FROM DietRestriction WHERE diet = @name";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", name);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new DietRestriction((int)reader["id_diet_restriction"], reader["diet"].ToString());
                        }
                        else
                        {
                            throw new Exception("Diet restriction not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching diet restriction by name: " + ex.Message);
                throw new Exception("Unable to fetch diet restriction by name. Please try again later.");
            }
        }

        public Difficulty GetDifficultyByName(string name)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    string query = "SELECT * FROM Difficulty WHERE difficulty = @name";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", name);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Difficulty((int)reader["id_difficulty"], reader["difficulty"].ToString());
                        }
                        else
                        {
                            throw new Exception("Difficulty not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching difficulty by name: " + ex.Message);
                throw new Exception("Unable to fetch difficulty by name. Please try again later.");
            }
        }

        public void SaveMainCourse(MainCourse mainCourse)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();

                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        int? picId = null;
                        if (mainCourse.GetRecipePic() != null)
                        {
                            string picQuery = @"
                        INSERT INTO RecipePicture (name, data, content_type)
                        OUTPUT INSERTED.id_recipe_pic
                        VALUES (@name, @data, @contentType)";

                            SqlCommand picCmd = new SqlCommand(picQuery, conn, transaction);
                            picCmd.Parameters.AddWithValue("@name", mainCourse.GetRecipePic().GetName());
                            picCmd.Parameters.AddWithValue("@data", mainCourse.GetRecipePic().GetData());
                            picCmd.Parameters.AddWithValue("@contentType", mainCourse.GetRecipePic().GetContentType());

                            picId = (int)picCmd.ExecuteScalar();
                            Console.WriteLine($"Recipe Picture ID: {picId}");
                        }

                        string query = @"
                    INSERT INTO Recipe (title, description, instructions, id_desktop_user, preparation_time, cooking_time, id_diet_restriction, id_difficulty, id_recipe_pic)
                    OUTPUT INSERTED.id_recipe
                    VALUES (@title, @description, @instructions, @userId, @prepTime, @cookTime, @dietId, @difficultyId, @picId)";

                        SqlCommand cmd = new SqlCommand(query, conn, transaction);
                        cmd.Parameters.AddWithValue("@title", mainCourse.GetTitle());
                        cmd.Parameters.AddWithValue("@description", mainCourse.GetDescription());
                        cmd.Parameters.AddWithValue("@instructions", mainCourse.GetInstructions());
                        cmd.Parameters.AddWithValue("@userId", mainCourse.GetUser().GetIdUser());
                        cmd.Parameters.AddWithValue("@prepTime", mainCourse.GetPreparationTime());
                        cmd.Parameters.AddWithValue("@cookTime", mainCourse.GetCookingTime());
                        cmd.Parameters.AddWithValue("@dietId", mainCourse.GetDietRestriction().GetIdDietRestriction());
                        cmd.Parameters.AddWithValue("@difficultyId", mainCourse.GetDifficulty().GetIdDifficulty());
                        cmd.Parameters.AddWithValue("@picId", (object)picId ?? DBNull.Value);

                        Console.WriteLine("Recipe Insertion Command: " + cmd.CommandText);

                        int recipeId = (int)cmd.ExecuteScalar();
                        Console.WriteLine($"Recipe ID: {recipeId}");

                        string mainCourseQuery = @"
                    INSERT INTO MainCourse (id_recipe, is_spicy, servings)
                    VALUES (@recipeId, @isSpicy, @servings)";

                        SqlCommand mainCourseCmd = new SqlCommand(mainCourseQuery, conn, transaction);
                        mainCourseCmd.Parameters.AddWithValue("@recipeId", recipeId);
                        mainCourseCmd.Parameters.AddWithValue("@isSpicy", mainCourse.GetIsSpicy());
                        mainCourseCmd.Parameters.AddWithValue("@servings", mainCourse.GetServings());

                        Console.WriteLine("MainCourse Insertion Command: " + mainCourseCmd.CommandText);

                        mainCourseCmd.ExecuteNonQuery();

                        foreach (var ingredient in mainCourse.GetIngredientRecipes())
                        {
                            string ingredientRecipeQuery = @"
                        INSERT INTO IngredientRecipe (id_recipe, id_ingredient, id_unit, quantity)
                        VALUES (@recipeId, @ingredientId, @unitId, @quantity)";

                            SqlCommand ingredientCmd = new SqlCommand(ingredientRecipeQuery, conn, transaction);
                            ingredientCmd.Parameters.AddWithValue("@recipeId", recipeId);
                            ingredientCmd.Parameters.AddWithValue("@ingredientId", ingredient.GetIngredient().GetIdIngredient());
                            ingredientCmd.Parameters.AddWithValue("@unitId", ingredient.GetUnit().GetId());
                            ingredientCmd.Parameters.AddWithValue("@quantity", ingredient.GetQuantity());

                            Console.WriteLine("IngredientRecipe Insertion Command: " + ingredientCmd.CommandText);

                            ingredientCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error saving main course: " + ex.Message);
                        throw new Exception("Unable to save main course. Please try again later.", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving main course: " + ex.Message);
                throw new Exception("Unable to save main course. Please try again later.", ex);
            }
        }
    }
}
