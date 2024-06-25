using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using entity_classes;

namespace db_helpers
{
    public class DBRecommendationHelper : DBConnection, IDBRecommendationHelper
    {
        public List<int> GetUsersWithSimilarLikes(int userId)
        {
            var similarUsers = new List<int>();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = @"
                        SELECT DISTINCT t2.id_web_user
                        FROM ToDoList t1
                        JOIN ToDoList t2 ON t1.id_recipe = t2.id_recipe
                        WHERE t1.id_web_user = @userId AND t2.id_web_user != @userId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                similarUsers.Add(reader.GetInt32(reader.GetOrdinal("id_web_user")));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching users with similar likes: " + ex.Message);
                throw new Exception("Unable to fetch users with similar likes. Please try again later.");
            }

            return similarUsers;
        }

        public List<Recipe> GetRecipesLikedByUsers(List<int> userIds, int count)
        {
            var recipes = new List<Recipe>();

            if (userIds == null || userIds.Count == 0)
            {
                return recipes;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string userIdsString = string.Join(",", userIds);
                    string query = $@"
                        SELECT TOP (@count) r.id_recipe, r.title, r.description, r.instructions, r.id_desktop_user, 
                               r.preparation_time, r.cooking_time, r.id_diet_restriction, r.id_difficulty, r.id_recipe_pic,
                               m.is_spicy, m.servings,
                               d.is_alcoholic, d.contains_caffeine, d.served_hot, d.pours,
                               ds.is_sugar_free, ds.requires_freezing,
                               rp.name AS pic_name, rp.data AS pic_data, rp.content_type AS pic_content_type
                        FROM ToDoList t
                        JOIN Recipe r ON t.id_recipe = r.id_recipe
                        LEFT JOIN MainCourse m ON r.id_recipe = m.id_recipe
                        LEFT JOIN Drink d ON r.id_recipe = d.id_recipe
                        LEFT JOIN Dessert ds ON r.id_recipe = ds.id_recipe
                        LEFT JOIN RecipePicture rp ON r.id_recipe_pic = rp.id_recipe_pic
                        WHERE t.id_web_user IN ({userIdsString})
                        ORDER BY NEWID()";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@count", count);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                recipes.Add(ReadRecipe(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching recipes liked by users: " + ex.Message);
                throw new Exception("Unable to fetch recipes liked by users. Please try again later.");
            }

            return recipes;
        }

        public List<Recipe> GetUserLikedRecipes(int userId)
        {
            var recipes = new List<Recipe>();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = @"
                        SELECT r.id_recipe, r.title, r.description, r.instructions, r.id_desktop_user, 
                               r.preparation_time, r.cooking_time, r.id_diet_restriction, r.id_difficulty, r.id_recipe_pic,
                               m.is_spicy, m.servings,
                               d.is_alcoholic, d.contains_caffeine, d.served_hot, d.pours,
                               ds.is_sugar_free, ds.requires_freezing,
                               rp.name AS pic_name, rp.data AS pic_data, rp.content_type AS pic_content_type
                        FROM ToDoList t
                        JOIN Recipe r ON t.id_recipe = r.id_recipe
                        LEFT JOIN MainCourse m ON r.id_recipe = m.id_recipe
                        LEFT JOIN Drink d ON r.id_recipe = d.id_recipe
                        LEFT JOIN Dessert ds ON r.id_recipe = ds.id_recipe
                        LEFT JOIN RecipePicture rp ON r.id_recipe_pic = rp.id_recipe_pic
                        WHERE t.id_web_user = @userId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                recipes.Add(ReadRecipe(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching user liked recipes: " + ex.Message);
                throw new Exception("Unable to fetch user liked recipes. Please try again later.");
            }

            return recipes;
        }

        private Recipe ReadRecipe(SqlDataReader reader)
        {
            int idRecipe = reader.GetInt32(reader.GetOrdinal("id_recipe"));
            string title = reader.GetString(reader.GetOrdinal("title"));
            string description = reader.GetString(reader.GetOrdinal("description"));
            string instructions = reader.GetString(reader.GetOrdinal("instructions"));
            int userId = reader.GetInt32(reader.GetOrdinal("id_desktop_user"));
            TimeSpan preparationTime = reader.GetTimeSpan(reader.GetOrdinal("preparation_time"));
            TimeSpan cookingTime = reader.IsDBNull(reader.GetOrdinal("cooking_time")) ? TimeSpan.Zero : reader.GetTimeSpan(reader.GetOrdinal("cooking_time"));
            int dietId = reader.GetInt32(reader.GetOrdinal("id_diet_restriction"));
            int difficultyId = reader.GetInt32(reader.GetOrdinal("id_difficulty"));
            RecipePic? pic = null;

            if (!reader.IsDBNull(reader.GetOrdinal("id_recipe_pic")))
            {
                int picId = reader.GetInt32(reader.GetOrdinal("id_recipe_pic"));
                string picName = reader.GetString(reader.GetOrdinal("pic_name"));
                string picData = reader.GetString(reader.GetOrdinal("pic_data"));
                string picContentType = reader.GetString(reader.GetOrdinal("pic_content_type"));
                pic = new RecipePic(picId, picName, picData, picContentType);
            }

            DesktopUser user = new DesktopUser(userId, "", "", "", null, "", "", 0, null, DateTime.Now);
            DietRestriction dietRestriction = new DietRestriction(dietId, "");
            Difficulty difficulty = new Difficulty(difficultyId, "");

            if (!reader.IsDBNull(reader.GetOrdinal("is_spicy")))
            {
                bool isSpicy = reader.GetBoolean(reader.GetOrdinal("is_spicy"));
                int servings = reader.GetInt32(reader.GetOrdinal("servings"));
                return new MainCourse(idRecipe, title, description, instructions, new List<IngredientRecipe>(), user, preparationTime, cookingTime, dietRestriction, difficulty, pic, isSpicy, servings);
            }
            else if (!reader.IsDBNull(reader.GetOrdinal("is_alcoholic")))
            {
                bool isAlcoholic = reader.GetBoolean(reader.GetOrdinal("is_alcoholic"));
                bool containsCaffeine = reader.GetBoolean(reader.GetOrdinal("contains_caffeine"));
                bool servedHot = reader.GetBoolean(reader.GetOrdinal("served_hot"));
                int pours = reader.GetInt32(reader.GetOrdinal("pours"));
                return new Drink(idRecipe, title, description, instructions, new List<IngredientRecipe>(), user, preparationTime, cookingTime, dietRestriction, difficulty, pic, isAlcoholic, containsCaffeine, servedHot, pours);
            }
            else if (!reader.IsDBNull(reader.GetOrdinal("is_sugar_free")))
            {
                bool isSugarFree = reader.GetBoolean(reader.GetOrdinal("is_sugar_free"));
                bool requiresFreezing = reader.GetBoolean(reader.GetOrdinal("requires_freezing"));
                return new Dessert(idRecipe, title, description, instructions, new List<IngredientRecipe>(), user, preparationTime, cookingTime, dietRestriction, difficulty, pic, isSugarFree, requiresFreezing);
            }

            throw new InvalidOperationException("Unrecognized recipe type.");
        }
    }
}
