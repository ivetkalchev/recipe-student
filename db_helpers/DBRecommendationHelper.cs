using entity_classes;
using exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace db_helpers
{
    public class DBRecommendationHelper : DBConnection, IDBRecommendationHelper
    {
        public bool HasLikedRecipes(int userId)
        {
            const string query = "SELECT COUNT(*) FROM Review WHERE id_web_user = @userId";

            try
            {
                using var conn = new SqlConnection(connection);
                conn.Open();

                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking if user has liked recipes: " + ex.Message);
                throw new Exception("Unable to check if user has liked recipes. Please try again later.", ex);
            }
        }

        public List<int> GetUsersWithSimilarLikes(int userId)
        {
            const string query = @"
                SELECT DISTINCT rv2.id_web_user
                FROM Review rv1
                INNER JOIN Review rv2 ON rv1.id_recipe = rv2.id_recipe
                WHERE rv1.id_web_user = @userId AND rv2.id_web_user != @userId";

            var userIds = new List<int>();

            try
            {
                using var conn = new SqlConnection(connection);
                conn.Open();

                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userIds.Add((int)reader["id_web_user"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching users with similar likes: " + ex.Message);
                throw new Exception("Unable to fetch users with similar likes. Please try again later.", ex);
            }

            return userIds;
        }

        public List<Recipe> GetTopMostLikedRecipes(int count)
        {
            List<Recipe> recipes = new List<Recipe>();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = @"
                SELECT TOP (@count) r.*, COUNT(rv.id_review) as Likes, rp.name as pic_name, rp.data as pic_data, rp.content_type as pic_content_type,
                       m.is_spicy, m.servings,
                       d.is_alcoholic, d.contains_caffeine, d.served_hot, d.pours,
                       ds.is_sugar_free, ds.requires_freezing,
                       u.email
                FROM Recipe r
                LEFT JOIN Review rv ON r.id_recipe = rv.id_recipe
                LEFT JOIN RecipePicture rp ON r.id_recipe_pic = rp.id_recipe_pic
                LEFT JOIN MainCourse m ON r.id_recipe = m.id_recipe
                LEFT JOIN Drink d ON r.id_recipe = d.id_recipe
                LEFT JOIN Dessert ds ON r.id_recipe = ds.id_recipe
                LEFT JOIN DesktopUser du ON r.id_desktop_user = du.id_user
                LEFT JOIN [User] u ON du.id_user = u.id_user
                GROUP BY r.id_recipe, r.title, r.description, r.instructions, r.id_desktop_user, r.preparation_time, r.cooking_time, r.id_diet_restriction, r.id_difficulty, r.id_recipe_pic,
                         rp.name, rp.data, rp.content_type,
                         m.is_spicy, m.servings,
                         d.is_alcoholic, d.contains_caffeine, d.served_hot, d.pours,
                         ds.is_sugar_free, ds.requires_freezing,
                         u.email
                ORDER BY COUNT(rv.id_review) DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@count", count);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Recipe recipe = CreateRecipeFromReader(reader);
                            if (recipe != null)
                            {
                                recipes.Add(recipe);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching top most liked recipes: " + ex.Message);
                throw new Exception("Unable to fetch top most liked recipes. Please try again later.", ex);
            }

            return recipes;
        }



        public List<Recipe> GetRecipesLikedByUsers(List<int> userIds, int count)
        {
            const string query = @"
                SELECT TOP (@count) r.*, COUNT(rv.id_review) as Likes, rp.name as pic_name, rp.data as pic_data, rp.content_type as pic_content_type,
                       m.is_spicy, m.servings,
                       d.is_alcoholic, d.contains_caffeine, d.served_hot, d.pours,
                       ds.is_sugar_free, ds.requires_freezing
                FROM Recipe r
                LEFT JOIN Review rv ON r.id_recipe = rv.id_recipe
                LEFT JOIN RecipePicture rp ON r.id_recipe_pic = rp.id_recipe_pic
                LEFT JOIN MainCourse m ON r.id_recipe = m.id_recipe
                LEFT JOIN Drink d ON r.id_recipe = d.id_recipe
                LEFT JOIN Dessert ds ON r.id_recipe = ds.id_recipe
                WHERE rv.id_web_user IN (@userIds)
                GROUP BY r.id_recipe, r.title, r.description, r.instructions, r.id_desktop_user, r.preparation_time, r.cooking_time, r.id_diet_restriction, r.id_difficulty, r.id_recipe_pic,
                         rp.name, rp.data, rp.content_type,
                         m.is_spicy, m.servings,
                         d.is_alcoholic, d.contains_caffeine, d.served_hot, d.pours,
                         ds.is_sugar_free, ds.requires_freezing
                ORDER BY COUNT(rv.id_review) DESC";

            var recipes = new List<Recipe>();

            try
            {
                using var conn = new SqlConnection(connection);
                conn.Open();

                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@count", count);
                cmd.Parameters.AddWithValue("@userIds", string.Join(",", userIds));

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var recipe = CreateRecipeFromReader(reader);
                    if (recipe != null)
                    {
                        recipes.Add(recipe);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching recipes liked by users: " + ex.Message);
                throw new Exception("Unable to fetch recipes liked by users. Please try again later.", ex);
            }

            return recipes;
        }

        private Recipe CreateRecipeFromReader(SqlDataReader reader)
        {
            RecipePic pic = reader["id_recipe_pic"] != DBNull.Value ? new RecipePic((int)reader["id_recipe_pic"], reader["pic_name"].ToString(), reader["pic_data"].ToString(), reader["pic_content_type"].ToString()) : null;

            DesktopUser user = null;
            try
            {
                string email = reader["email"] != DBNull.Value ? reader["email"].ToString() : "default@example.com";
                user = new DesktopUser((int)reader["id_desktop_user"], "", email, "", new Role(0, ""), "", "", 0, new Gender(0, ""), DateTime.Now);
            }
            catch (InvalidEmailException ex)
            {
                Console.WriteLine("Invalid email encountered: " + ex.Message);

                user = new DesktopUser((int)reader["id_desktop_user"], "", "default@example.com", "", new Role(0, ""), "", "", 0, new Gender(0, ""), DateTime.Now);
            }

            int idRecipe = (int)reader["id_recipe"];
            string title = reader["title"].ToString();
            string description = reader["description"].ToString();
            string instructions = reader["instructions"].ToString();
            TimeSpan preparationTime = (TimeSpan)reader["preparation_time"];
            TimeSpan cookingTime = (TimeSpan)reader["cooking_time"];
            DietRestriction dietRestriction = new DietRestriction((int)reader["id_diet_restriction"], "");
            Difficulty difficulty = new Difficulty((int)reader["id_difficulty"], "");

            if (reader["is_spicy"] != DBNull.Value)
            {
                bool isSpicy = (bool)reader["is_spicy"];
                int servings = (int)reader["servings"];
                return new MainCourse(idRecipe, title, description, instructions, new List<IngredientRecipe>(), user, preparationTime, cookingTime, dietRestriction, difficulty, pic, isSpicy, servings);
            }
            else if (reader["is_alcoholic"] != DBNull.Value)
            {
                bool isAlcoholic = (bool)reader["is_alcoholic"];
                bool containsCaffeine = (bool)reader["contains_caffeine"];
                bool servedHot = (bool)reader["served_hot"];
                int pours = (int)reader["pours"];
                return new Drink(idRecipe, title, description, instructions, new List<IngredientRecipe>(), user, preparationTime, cookingTime, dietRestriction, difficulty, pic, isAlcoholic, containsCaffeine, servedHot, pours);
            }
            else if (reader["is_sugar_free"] != DBNull.Value)
            {
                bool isSugarFree = (bool)reader["is_sugar_free"];
                bool requiresFreezing = (bool)reader["requires_freezing"];
                return new Dessert(idRecipe, title, description, instructions, new List<IngredientRecipe>(), user, preparationTime, cookingTime, dietRestriction, difficulty, pic, isSugarFree, requiresFreezing);
            }
            return null;
        }
    }
}