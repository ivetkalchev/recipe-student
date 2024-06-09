using entity_classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_helpers
{
    public class DBToDoListHelper : DBConnection, IDBToDoListHelper
    {
        private IDBRecipeHelper recipeHelper;
        private IDBUserHelper userHelper;

        public DBToDoListHelper(IDBRecipeHelper recipeHelper, IDBUserHelper userHelper)
        {
            this.recipeHelper = recipeHelper;
            this.userHelper = userHelper;
        }

        public void AddToDoList(int userId, int recipeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = "INSERT INTO ToDoList (id_web_user, id_recipe) VALUES (@userId, @recipeId)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@recipeId", recipeId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding to-do list: " + ex.Message);
                throw new Exception("Unable to add to-do list. Please try again later.");
            }
        }

        public bool IsRecipeInToDoList(int userId, int recipeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM ToDoList WHERE id_web_user = @userId AND id_recipe = @recipeId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@recipeId", recipeId);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking to-do list: " + ex.Message);
                throw new Exception("Unable to check to-do list. Please try again later.");
            }
        }

        public List<Recipe> GetUserToDoList(int userId)
        {
            List<Recipe> recipes = new List<Recipe>();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = @"
                SELECT r.id_recipe, r.title, r.description, r.instructions, r.id_desktop_user, r.preparation_time, r.cooking_time, r.id_diet_restriction, r.id_difficulty, r.id_recipe_pic,
                       m.is_spicy, m.servings,
                       d.is_alcoholic, d.contains_caffeine, d.served_hot, d.pours,
                       ds.is_sugar_free, ds.requires_freezing,
                       rp.name as pic_name, rp.data as pic_data, rp.content_type as pic_content_type
                FROM ToDoList t
                JOIN Recipe r ON t.id_recipe = r.id_recipe
                LEFT JOIN MainCourse m ON r.id_recipe = m.id_recipe
                LEFT JOIN Drink d ON r.id_recipe = d.id_recipe
                LEFT JOIN Dessert ds ON r.id_recipe = ds.id_recipe
                LEFT JOIN RecipePicture rp ON r.id_recipe_pic = rp.id_recipe_pic
                WHERE t.id_web_user = @userId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idRecipe = (int)reader["id_recipe"];
                            string title = reader["title"].ToString();
                            string description = reader["description"].ToString();
                            string instructions = reader["instructions"].ToString();
                            int userIdFromDb = (int)reader["id_desktop_user"];
                            TimeSpan preparationTime = (TimeSpan)reader["preparation_time"];
                            TimeSpan cookingTime = reader["cooking_time"] != DBNull.Value ? (TimeSpan)reader["cooking_time"] : TimeSpan.Zero;
                            int dietId = (int)reader["id_diet_restriction"];
                            int difficultyId = (int)reader["id_difficulty"];
                            RecipePic? pic = null;

                            if (reader["id_recipe_pic"] != DBNull.Value)
                            {
                                int picId = (int)reader["id_recipe_pic"];
                                string picName = reader["pic_name"].ToString();
                                string picData = reader["pic_data"].ToString();
                                string picContentType = reader["pic_content_type"].ToString();

                                pic = new RecipePic(picId, picName, picData, picContentType);
                            }

                            DesktopUser user = userHelper?.GetUserById(userIdFromDb);
                            if (user == null)
                            {
                                Console.WriteLine("User not found for ID: " + userIdFromDb);
                                continue;
                            }

                            DietRestriction dietRestriction = recipeHelper?.GetDietRestrictionById(dietId);
                            if (dietRestriction == null)
                            {
                                Console.WriteLine("Diet restriction not found for ID: " + dietId);
                                continue;
                            }

                            Difficulty difficulty = recipeHelper?.GetDifficultyById(difficultyId);
                            if (difficulty == null)
                            {
                                Console.WriteLine("Difficulty not found for ID: " + difficultyId);
                                continue;
                            }

                            if (reader["is_spicy"] != DBNull.Value)
                            {
                                bool isSpicy = (bool)reader["is_spicy"];
                                int servings = (int)reader["servings"];
                                recipes.Add(new MainCourse(idRecipe, title, description, instructions, new List<IngredientRecipe>(), user, preparationTime, cookingTime, dietRestriction, difficulty, pic, isSpicy, servings));
                            }
                            else if (reader["is_alcoholic"] != DBNull.Value)
                            {
                                bool isAlcoholic = (bool)reader["is_alcoholic"];
                                bool containsCaffeine = (bool)reader["contains_caffeine"];
                                bool servedHot = (bool)reader["served_hot"];
                                int pours = (int)reader["pours"];
                                recipes.Add(new Drink(idRecipe, title, description, instructions, new List<IngredientRecipe>(), user, preparationTime, cookingTime, dietRestriction, difficulty, pic, isAlcoholic, containsCaffeine, servedHot, pours));
                            }
                            else if (reader["is_sugar_free"] != DBNull.Value)
                            {
                                bool isSugarFree = (bool)reader["is_sugar_free"];
                                bool requiresFreezing = (bool)reader["requires_freezing"];
                                recipes.Add(new Dessert(idRecipe, title, description, instructions, new List<IngredientRecipe>(), user, preparationTime, cookingTime, dietRestriction, difficulty, pic, isSugarFree, requiresFreezing));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching user to-do list: " + ex.Message);
                throw new Exception("Unable to fetch user to-do list. Please try again later.", ex);
            }

            return recipes;
        }



        public void RemoveFromToDoList(int userId, int recipeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = "DELETE FROM ToDoList WHERE id_web_user = @userId AND id_recipe = @recipeId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@recipeId", recipeId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error removing from to-do list: " + ex.Message);
                throw new Exception("Unable to remove from to-do list. Please try again later.", ex);
            }
        }
    }
}
