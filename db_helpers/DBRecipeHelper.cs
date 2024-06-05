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
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
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
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
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
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
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
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
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

        public void InsertMainCourse(MainCourse recipe)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();

                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        int? picId = null;
                        if (recipe.GetRecipePic() != null)
                        {
                            string picQuery = @"
                        INSERT INTO RecipePicture (name, data, content_type)
                        OUTPUT INSERTED.id_recipe_pic
                        VALUES (@name, @data, @contentType)";

                            SqlCommand picCmd = new SqlCommand(picQuery, conn, transaction);
                            picCmd.Parameters.AddWithValue("@name", recipe.GetRecipePic().GetName());
                            picCmd.Parameters.AddWithValue("@data", recipe.GetRecipePic().GetData());
                            picCmd.Parameters.AddWithValue("@contentType", recipe.GetRecipePic().GetContentType());

                            picId = (int)picCmd.ExecuteScalar();
                            Console.WriteLine($"Recipe Picture ID: {picId}");
                        }

                        string query = @"
                    INSERT INTO Recipe (title, description, instructions, id_desktop_user, preparation_time, cooking_time, id_diet_restriction, id_difficulty, id_recipe_pic)
                    OUTPUT INSERTED.id_recipe
                    VALUES (@title, @description, @instructions, @userId, @prepTime, @cookTime, @dietId, @difficultyId, @picId)";

                        SqlCommand cmd = new SqlCommand(query, conn, transaction);
                        cmd.Parameters.AddWithValue("@title", recipe.GetTitle());
                        cmd.Parameters.AddWithValue("@description", recipe.GetDescription());
                        cmd.Parameters.AddWithValue("@instructions", recipe.GetInstructions());
                        cmd.Parameters.AddWithValue("@userId", recipe.GetUser().GetIdUser());
                        cmd.Parameters.AddWithValue("@prepTime", recipe.GetPreparationTime());
                        cmd.Parameters.AddWithValue("@cookTime", recipe.GetCookingTime());
                        cmd.Parameters.AddWithValue("@dietId", recipe.GetDietRestriction().GetIdDietRestriction());
                        cmd.Parameters.AddWithValue("@difficultyId", recipe.GetDifficulty().GetIdDifficulty());
                        cmd.Parameters.AddWithValue("@picId", (object)picId ?? DBNull.Value);

                        Console.WriteLine("Recipe Insertion Command: " + cmd.CommandText);

                        int recipeId = (int)cmd.ExecuteScalar();
                        Console.WriteLine($"Recipe ID: {recipeId}");

                        string mainCourseQuery = @"
                    INSERT INTO MainCourse (id_recipe, is_spicy, servings)
                    VALUES (@recipeId, @isSpicy, @servings)";

                        SqlCommand mainCourseCmd = new SqlCommand(mainCourseQuery, conn, transaction);
                        mainCourseCmd.Parameters.AddWithValue("@recipeId", recipeId);
                        mainCourseCmd.Parameters.AddWithValue("@isSpicy", recipe.GetIsSpicy());
                        mainCourseCmd.Parameters.AddWithValue("@servings", recipe.GetServings());

                        Console.WriteLine("MainCourse Insertion Command: " + mainCourseCmd.CommandText);

                        mainCourseCmd.ExecuteNonQuery();

                        foreach (var ingredient in recipe.GetIngredientRecipes())
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

        public void InsertDrink(Drink recipe)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();

                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        int? picId = null;
                        if (recipe.GetRecipePic() != null)
                        {
                            string picQuery = @"
                        INSERT INTO RecipePicture (name, data, content_type)
                        OUTPUT INSERTED.id_recipe_pic
                        VALUES (@name, @data, @contentType)";

                            SqlCommand picCmd = new SqlCommand(picQuery, conn, transaction);
                            picCmd.Parameters.AddWithValue("@name", recipe.GetRecipePic().GetName());
                            picCmd.Parameters.AddWithValue("@data", recipe.GetRecipePic().GetData());
                            picCmd.Parameters.AddWithValue("@contentType", recipe.GetRecipePic().GetContentType());

                            picId = (int)picCmd.ExecuteScalar();
                            Console.WriteLine($"Recipe Picture ID: {picId}");
                        }

                        string query = @"
                    INSERT INTO Recipe (title, description, instructions, id_desktop_user, preparation_time, cooking_time, id_diet_restriction, id_difficulty, id_recipe_pic)
                    OUTPUT INSERTED.id_recipe
                    VALUES (@title, @description, @instructions, @userId, @prepTime, @cookTime, @dietId, @difficultyId, @picId)";

                        SqlCommand cmd = new SqlCommand(query, conn, transaction);
                        cmd.Parameters.AddWithValue("@title", recipe.GetTitle());
                        cmd.Parameters.AddWithValue("@description", recipe.GetDescription());
                        cmd.Parameters.AddWithValue("@instructions", recipe.GetInstructions());
                        cmd.Parameters.AddWithValue("@userId", recipe.GetUser().GetIdUser());
                        cmd.Parameters.AddWithValue("@prepTime", recipe.GetPreparationTime());
                        cmd.Parameters.AddWithValue("@cookTime", recipe.GetCookingTime());
                        cmd.Parameters.AddWithValue("@dietId", recipe.GetDietRestriction().GetIdDietRestriction());
                        cmd.Parameters.AddWithValue("@difficultyId", recipe.GetDifficulty().GetIdDifficulty());
                        cmd.Parameters.AddWithValue("@picId", (object)picId ?? DBNull.Value);

                        Console.WriteLine("Recipe Insertion Command: " + cmd.CommandText);

                        int recipeId = (int)cmd.ExecuteScalar();
                        Console.WriteLine($"Recipe ID: {recipeId}");

                        string drinkQuery = @"
                    INSERT INTO Drink (id_recipe, is_alcoholic, contains_caffeine, served_hot, pours)
                    VALUES (@recipeId, @isAlcoholic, @containsCaffeine, @servedHot, @pours)";

                        SqlCommand drinkCmd = new SqlCommand(drinkQuery, conn, transaction);
                        drinkCmd.Parameters.AddWithValue("@recipeId", recipeId);
                        drinkCmd.Parameters.AddWithValue("@isAlcoholic", recipe.GetIsAlcoholic());
                        drinkCmd.Parameters.AddWithValue("@containsCaffeine", recipe.GetContainsCaffeine());
                        drinkCmd.Parameters.AddWithValue("@servedHot", recipe.GetServedHot());
                        drinkCmd.Parameters.AddWithValue("@pours", recipe.GetPours());

                        Console.WriteLine("Drink Insertion Command: " + drinkCmd.CommandText);

                        drinkCmd.ExecuteNonQuery();

                        foreach (var ingredient in recipe.GetIngredientRecipes())
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
                        Console.WriteLine("Error saving drink: " + ex.Message);
                        throw new Exception("Unable to save drink. Please try again later.", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving drink: " + ex.Message);
                throw new Exception("Unable to save drink. Please try again later.", ex);
            }
        }

        public void InsertDessert(Dessert recipe)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();

                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        int? picId = null;
                        if (recipe.GetRecipePic() != null)
                        {
                            string picQuery = @"
                        INSERT INTO RecipePicture (name, data, content_type)
                        OUTPUT INSERTED.id_recipe_pic
                        VALUES (@name, @data, @contentType)";

                            SqlCommand picCmd = new SqlCommand(picQuery, conn, transaction);
                            picCmd.Parameters.AddWithValue("@name", recipe.GetRecipePic().GetName());
                            picCmd.Parameters.AddWithValue("@data", recipe.GetRecipePic().GetData());
                            picCmd.Parameters.AddWithValue("@contentType", recipe.GetRecipePic().GetContentType());

                            picId = (int)picCmd.ExecuteScalar();
                            Console.WriteLine($"Recipe Picture ID: {picId}");
                        }

                        string query = @"
                    INSERT INTO Recipe (title, description, instructions, id_desktop_user, preparation_time, cooking_time, id_diet_restriction, id_difficulty, id_recipe_pic)
                    OUTPUT INSERTED.id_recipe
                    VALUES (@title, @description, @instructions, @userId, @prepTime, @cookTime, @dietId, @difficultyId, @picId)";

                        SqlCommand cmd = new SqlCommand(query, conn, transaction);
                        cmd.Parameters.AddWithValue("@title", recipe.GetTitle());
                        cmd.Parameters.AddWithValue("@description", recipe.GetDescription());
                        cmd.Parameters.AddWithValue("@instructions", recipe.GetInstructions());
                        cmd.Parameters.AddWithValue("@userId", recipe.GetUser().GetIdUser());
                        cmd.Parameters.AddWithValue("@prepTime", recipe.GetPreparationTime());
                        cmd.Parameters.AddWithValue("@cookTime", recipe.GetCookingTime());
                        cmd.Parameters.AddWithValue("@dietId", recipe.GetDietRestriction().GetIdDietRestriction());
                        cmd.Parameters.AddWithValue("@difficultyId", recipe.GetDifficulty().GetIdDifficulty());
                        cmd.Parameters.AddWithValue("@picId", (object)picId ?? DBNull.Value);

                        Console.WriteLine("Recipe Insertion Command: " + cmd.CommandText);

                        int recipeId = (int)cmd.ExecuteScalar();
                        Console.WriteLine($"Recipe ID: {recipeId}");

                        string dessertQuery = @"
                    INSERT INTO Dessert (id_recipe, is_sugar_free, requires_freezing)
                    VALUES (@recipeId, @isSugarFree, @requiresFreezing)";

                        SqlCommand dessertCmd = new SqlCommand(dessertQuery, conn, transaction);
                        dessertCmd.Parameters.AddWithValue("@recipeId", recipeId);
                        dessertCmd.Parameters.AddWithValue("@isSugarFree", recipe.GetIsSugarFree());
                        dessertCmd.Parameters.AddWithValue("@requiresFreezing", recipe.GetRequiresFreezing());

                        Console.WriteLine("Dessert Insertion Command: " + dessertCmd.CommandText);

                        dessertCmd.ExecuteNonQuery();

                        foreach (var ingredient in recipe.GetIngredientRecipes())
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
                        Console.WriteLine("Error saving dessert: " + ex.Message);
                        throw new Exception("Unable to save dessert. Please try again later.", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving dessert: " + ex.Message);
                throw new Exception("Unable to save dessert. Please try again later.", ex);
            }
        }
    }
}