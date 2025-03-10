﻿using System.Data.SqlClient;
using entity_classes;

namespace db_helpers
{
    public class DBRecipeHelper : DBConnection, IDBRecipeHelper
    {
        private IDBUserHelper userHelper;

        public DBRecipeHelper(IDBUserHelper userHelper)
        {
            this.userHelper = userHelper;
        }

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

        public List<Recipe> GetAllRecipes()
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
                    FROM Recipe r
                    LEFT JOIN MainCourse m ON r.id_recipe = m.id_recipe
                    LEFT JOIN Drink d ON r.id_recipe = d.id_recipe
                    LEFT JOIN Dessert ds ON r.id_recipe = ds.id_recipe
                    LEFT JOIN RecipePicture rp ON r.id_recipe_pic = rp.id_recipe_pic";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idRecipe = (int)reader["id_recipe"];
                            string title = reader["title"].ToString();
                            string description = reader["description"].ToString();
                            string instructions = reader["instructions"].ToString();
                            int userId = (int)reader["id_desktop_user"];
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

                            DesktopUser user = userHelper.GetUserById(userId);
                            DietRestriction dietRestriction = GetDietRestrictionById(dietId);
                            Difficulty difficulty = GetDifficultyById(difficultyId);

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
                Console.WriteLine("Error fetching recipes: " + ex.Message);
                throw new Exception("Unable to fetch recipes. Please try again later.", ex);
            }

            return recipes;
        }

        public DietRestriction GetDietRestrictionById(int dietId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = "SELECT * FROM DietRestriction WHERE id_diet_restriction = @dietId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@dietId", dietId);

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
                Console.WriteLine("Error fetching diet restriction by ID: " + ex.Message);
                throw new Exception("Unable to fetch diet restriction by ID. Please try again later.", ex);
            }
        }

        public Difficulty GetDifficultyById(int difficultyId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = "SELECT * FROM Difficulty WHERE id_difficulty = @difficultyId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@difficultyId", difficultyId);

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
                Console.WriteLine("Error fetching difficulty by ID: " + ex.Message);
                throw new Exception("Unable to fetch difficulty by ID. Please try again later.", ex);
            }
        }

        public Recipe GetRecipeById(int id)
        {
            Recipe recipe = null;

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
                           rp.name AS pic_name, rp.data AS pic_data, rp.content_type AS pic_content_type,
                           ir.id_ingredient, ir.quantity, ir.id_unit,
                           i.name AS ingredient_name,
                           u.unit AS unit_name
                    FROM Recipe r
                    LEFT JOIN MainCourse m ON r.id_recipe = m.id_recipe
                    LEFT JOIN Drink d ON r.id_recipe = d.id_recipe
                    LEFT JOIN Dessert ds ON r.id_recipe = ds.id_recipe
                    LEFT JOIN RecipePicture rp ON r.id_recipe_pic = rp.id_recipe_pic
                    LEFT JOIN IngredientRecipe ir ON r.id_recipe = ir.id_recipe
                    LEFT JOIN Ingredient i ON ir.id_ingredient = i.id_ingredient
                    LEFT JOIN Unit u ON ir.id_unit = u.id_unit
                    WHERE r.id_recipe = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Dictionary<int, IngredientRecipe> ingredientRecipes = new Dictionary<int, IngredientRecipe>();

                        while (reader.Read())
                        {
                            if (recipe == null)
                            {
                                int idRecipe = (int)reader["id_recipe"];
                                string title = reader["title"].ToString();
                                string description = reader["description"].ToString();
                                string instructions = reader["instructions"].ToString();
                                int userId = (int)reader["id_desktop_user"];
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

                                DesktopUser user = userHelper.GetUserById(userId);
                                DietRestriction diet = GetDietRestrictionById(dietId);
                                Difficulty difficulty = GetDifficultyById(difficultyId);

                                if (reader["is_spicy"] != DBNull.Value)
                                {
                                    bool isSpicy = (bool)reader["is_spicy"];
                                    int servings = (int)reader["servings"];
                                    recipe = new MainCourse(idRecipe, title, description, instructions, new List<IngredientRecipe>(), user, preparationTime, cookingTime, diet, difficulty, pic, isSpicy, servings);
                                }
                                else if (reader["is_alcoholic"] != DBNull.Value)
                                {
                                    bool isAlcoholic = (bool)reader["is_alcoholic"];
                                    bool containsCaffeine = (bool)reader["contains_caffeine"];
                                    bool servedHot = (bool)reader["served_hot"];
                                    int pours = (int)reader["pours"];
                                    recipe = new Drink(idRecipe, title, description, instructions, new List<IngredientRecipe>(), user, preparationTime, cookingTime, diet, difficulty, pic, isAlcoholic, containsCaffeine, servedHot, pours);
                                }
                                else if (reader["is_sugar_free"] != DBNull.Value)
                                {
                                    bool isSugarFree = (bool)reader["is_sugar_free"];
                                    bool requiresFreezing = (bool)reader["requires_freezing"];
                                    recipe = new Dessert(idRecipe, title, description, instructions, new List<IngredientRecipe>(), user, preparationTime, cookingTime, diet, difficulty, pic, isSugarFree, requiresFreezing);
                                }
                            }

                            if (reader["id_ingredient"] != DBNull.Value)
                            {
                                int ingredientId = (int)reader["id_ingredient"];
                                string ingredientName = reader["ingredient_name"].ToString();
                                decimal quantity = (decimal)reader["quantity"];
                                int unitId = (int)reader["id_unit"];
                                string unitName = reader["unit_name"].ToString();

                                var ingredient = new Ingredient(ingredientId, ingredientName, null);
                                var unit = new Unit(unitId, unitName);
                                var ingredientRecipe = new IngredientRecipe(ingredient, quantity, unit);
                                recipe.GetIngredientRecipes().Add(ingredientRecipe);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching recipe by ID: " + ex.Message);
                throw new Exception("Unable to fetch recipe by ID. Please try again later.", ex);
            }

            return recipe;
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
                        cmd.Parameters.AddWithValue("@dietId", recipe.GetDietRestriction().GetId());
                        cmd.Parameters.AddWithValue("@difficultyId", recipe.GetDifficulty().GetId());
                        cmd.Parameters.AddWithValue("@picId", (object)picId ?? DBNull.Value);
                        int recipeId = (int)cmd.ExecuteScalar();

                        string mainCourseQuery = @"
                            INSERT INTO MainCourse (id_recipe, is_spicy, servings)
                            VALUES (@recipeId, @isSpicy, @servings)";
                        SqlCommand mainCourseCmd = new SqlCommand(mainCourseQuery, conn, transaction);
                        mainCourseCmd.Parameters.AddWithValue("@recipeId", recipeId);
                        mainCourseCmd.Parameters.AddWithValue("@isSpicy", recipe.GetIsSpicy());
                        mainCourseCmd.Parameters.AddWithValue("@servings", recipe.GetServings());
                        mainCourseCmd.ExecuteNonQuery();

                        foreach (var ingredient in recipe.GetIngredientRecipes())
                        {
                            string ingredientRecipeQuery = @"
                                INSERT INTO IngredientRecipe (id_recipe, id_ingredient, id_unit, quantity)
                                VALUES (@recipeId, @ingredientId, @unitId, @quantity)";
                            SqlCommand ingredientCmd = new SqlCommand(ingredientRecipeQuery, conn, transaction);
                            ingredientCmd.Parameters.AddWithValue("@recipeId", recipeId);
                            ingredientCmd.Parameters.AddWithValue("@ingredientId", ingredient.GetIngredient().GetId());
                            ingredientCmd.Parameters.AddWithValue("@unitId", ingredient.GetUnit().GetId());
                            ingredientCmd.Parameters.AddWithValue("@quantity", ingredient.GetQuantity());
                            ingredientCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Unable to save main course. Please try again later.", ex);
                    }
                }
            }
            catch (Exception ex)
            {
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
                        cmd.Parameters.AddWithValue("@dietId", recipe.GetDietRestriction().GetId());
                        cmd.Parameters.AddWithValue("@difficultyId", recipe.GetDifficulty().GetId());
                        cmd.Parameters.AddWithValue("@picId", (object)picId ?? DBNull.Value);
                        int recipeId = (int)cmd.ExecuteScalar();

                        string drinkQuery = @"
                            INSERT INTO Drink (id_recipe, is_alcoholic, contains_caffeine, served_hot, pours)
                            VALUES (@recipeId, @isAlcoholic, @containsCaffeine, @servedHot, @pours)";
                        SqlCommand drinkCmd = new SqlCommand(drinkQuery, conn, transaction);
                        drinkCmd.Parameters.AddWithValue("@recipeId", recipeId);
                        drinkCmd.Parameters.AddWithValue("@isAlcoholic", recipe.GetIsAlcoholic());
                        drinkCmd.Parameters.AddWithValue("@containsCaffeine", recipe.GetContainsCaffeine());
                        drinkCmd.Parameters.AddWithValue("@servedHot", recipe.GetServedHot());
                        drinkCmd.Parameters.AddWithValue("@pours", recipe.GetPours());
                        drinkCmd.ExecuteNonQuery();

                        foreach (var ingredient in recipe.GetIngredientRecipes())
                        {
                            string ingredientRecipeQuery = @"
                                INSERT INTO IngredientRecipe (id_recipe, id_ingredient, id_unit, quantity)
                                VALUES (@recipeId, @ingredientId, @unitId, @quantity)";
                            SqlCommand ingredientCmd = new SqlCommand(ingredientRecipeQuery, conn, transaction);
                            ingredientCmd.Parameters.AddWithValue("@recipeId", recipeId);
                            ingredientCmd.Parameters.AddWithValue("@ingredientId", ingredient.GetIngredient().GetId());
                            ingredientCmd.Parameters.AddWithValue("@unitId", ingredient.GetUnit().GetId());
                            ingredientCmd.Parameters.AddWithValue("@quantity", ingredient.GetQuantity());
                            ingredientCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Unable to save drink. Please try again later.", ex);
                    }
                }
            }
            catch (Exception ex)
            {
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
                        cmd.Parameters.AddWithValue("@dietId", recipe.GetDietRestriction().GetId());
                        cmd.Parameters.AddWithValue("@difficultyId", recipe.GetDifficulty().GetId());
                        cmd.Parameters.AddWithValue("@picId", (object)picId ?? DBNull.Value);
                        int recipeId = (int)cmd.ExecuteScalar();

                        string dessertQuery = @"
                            INSERT INTO Dessert (id_recipe, is_sugar_free, requires_freezing)
                            VALUES (@recipeId, @isSugarFree, @requiresFreezing)";
                        SqlCommand dessertCmd = new SqlCommand(dessertQuery, conn, transaction);
                        dessertCmd.Parameters.AddWithValue("@recipeId", recipeId);
                        dessertCmd.Parameters.AddWithValue("@isSugarFree", recipe.GetIsSugarFree());
                        dessertCmd.Parameters.AddWithValue("@requiresFreezing", recipe.GetRequiresFreezing());
                        dessertCmd.ExecuteNonQuery();

                        foreach (var ingredient in recipe.GetIngredientRecipes())
                        {
                            string ingredientRecipeQuery = @"
                                INSERT INTO IngredientRecipe (id_recipe, id_ingredient, id_unit, quantity)
                                VALUES (@recipeId, @ingredientId, @unitId, @quantity)";
                            SqlCommand ingredientCmd = new SqlCommand(ingredientRecipeQuery, conn, transaction);
                            ingredientCmd.Parameters.AddWithValue("@recipeId", recipeId);
                            ingredientCmd.Parameters.AddWithValue("@ingredientId", ingredient.GetIngredient().GetId());
                            ingredientCmd.Parameters.AddWithValue("@unitId", ingredient.GetUnit().GetId());
                            ingredientCmd.Parameters.AddWithValue("@quantity", ingredient.GetQuantity());
                            ingredientCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Unable to save dessert. Please try again later.", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to save dessert. Please try again later.", ex);
            }
        }

        public List<Recipe> GetPagedRecipes(int pageNumber, int pageSize, string searchQuery, string sortOption)
        {
            List<Recipe> recipes = new List<Recipe>();
            int skip = (pageNumber - 1) * pageSize;
            string orderByClause = "ORDER BY r.title";

            switch (sortOption)
            {
                case "PreparationTime":
                    orderByClause = "ORDER BY r.preparation_time";
                    break;
                case "Rating":
                    orderByClause = @"
                ORDER BY (
                    SELECT COALESCE(AVG(rev.rating_value), 0)
                    FROM Review rev
                    WHERE rev.id_recipe = r.id_recipe
                ) DESC";
                    break;
                default:
                    orderByClause = "ORDER BY r.title";
                    break;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = $@"
                SELECT r.id_recipe, r.title, r.description, r.instructions, r.id_desktop_user, r.preparation_time, r.cooking_time, r.id_diet_restriction, r.id_difficulty, r.id_recipe_pic,
                       m.is_spicy, m.servings,
                       d.is_alcoholic, d.contains_caffeine, d.served_hot, d.pours,
                       ds.is_sugar_free, ds.requires_freezing,
                       rp.name as pic_name, rp.data as pic_data, rp.content_type as pic_content_type
                FROM Recipe r
                LEFT JOIN MainCourse m ON r.id_recipe = m.id_recipe
                LEFT JOIN Drink d ON r.id_recipe = d.id_recipe
                LEFT JOIN Dessert ds ON r.id_recipe = ds.id_recipe
                LEFT JOIN RecipePicture rp ON r.id_recipe_pic = rp.id_recipe_pic
                WHERE (@searchQuery IS NULL OR r.title LIKE '%' + @searchQuery + '%' OR r.description LIKE '%' + @searchQuery + '%')
                {orderByClause}
                OFFSET @skip ROWS FETCH NEXT @pageSize ROWS ONLY";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@searchQuery", string.IsNullOrEmpty(searchQuery) ? (object)DBNull.Value : searchQuery);
                    cmd.Parameters.AddWithValue("@skip", skip);
                    cmd.Parameters.AddWithValue("@pageSize", pageSize);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idRecipe = (int)reader["id_recipe"];
                            string title = reader["title"].ToString();
                            string description = reader["description"].ToString();
                            string instructions = reader["instructions"].ToString();
                            int userId = (int)reader["id_desktop_user"];
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

                            DesktopUser user = userHelper.GetUserById(userId);
                            DietRestriction dietRestriction = GetDietRestrictionById(dietId);
                            Difficulty difficulty = GetDifficultyById(difficultyId);

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
                Console.WriteLine("Error fetching recipes: " + ex.Message);
                throw new Exception("Unable to fetch recipes. Please try again later.", ex);
            }

            return recipes;
        }

        public int GetTotalRecipesCount(string searchQuery)
        {
            int totalRecipes = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = @"
                        SELECT COUNT(*)
                        FROM Recipe r
                        WHERE (@searchQuery IS NULL OR r.title LIKE '%' + @searchQuery + '%' OR r.description LIKE '%' + @searchQuery + '%')";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@searchQuery", string.IsNullOrEmpty(searchQuery) ? (object)DBNull.Value : searchQuery);

                    totalRecipes = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching total recipes count: " + ex.Message);
                throw new Exception("Unable to fetch total recipes count. Please try again later.", ex);
            }

            return totalRecipes;
        }

        public void DeleteRecipe(int recipeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string deleteIngredientRecipeQuery = "DELETE FROM IngredientRecipe WHERE id_recipe = @recipeId";
                        SqlCommand ingredientRecipeCmd = new SqlCommand(deleteIngredientRecipeQuery, conn, transaction);
                        ingredientRecipeCmd.Parameters.AddWithValue("@recipeId", recipeId);
                        ingredientRecipeCmd.ExecuteNonQuery();

                        string checkMainCourseQuery = "SELECT COUNT(*) FROM MainCourse WHERE id_recipe = @recipeId";
                        SqlCommand checkMainCourseCmd = new SqlCommand(checkMainCourseQuery, conn, transaction);
                        checkMainCourseCmd.Parameters.AddWithValue("@recipeId", recipeId);
                        int mainCourseCount = (int)checkMainCourseCmd.ExecuteScalar();
                        if (mainCourseCount > 0)
                        {
                            string deleteMainCourseQuery = "DELETE FROM MainCourse WHERE id_recipe = @recipeId";
                            SqlCommand mainCourseCmd = new SqlCommand(deleteMainCourseQuery, conn, transaction);
                            mainCourseCmd.Parameters.AddWithValue("@recipeId", recipeId);
                            mainCourseCmd.ExecuteNonQuery();
                        }

                        string checkDrinkQuery = "SELECT COUNT(*) FROM Drink WHERE id_recipe = @recipeId";
                        SqlCommand checkDrinkCmd = new SqlCommand(checkDrinkQuery, conn, transaction);
                        checkDrinkCmd.Parameters.AddWithValue("@recipeId", recipeId);
                        int drinkCount = (int)checkDrinkCmd.ExecuteScalar();
                        if (drinkCount > 0)
                        {
                            string deleteDrinkQuery = "DELETE FROM Drink WHERE id_recipe = @recipeId";
                            SqlCommand drinkCmd = new SqlCommand(deleteDrinkQuery, conn, transaction);
                            drinkCmd.Parameters.AddWithValue("@recipeId", recipeId);
                            drinkCmd.ExecuteNonQuery();
                        }

                        string checkDessertQuery = "SELECT COUNT(*) FROM Dessert WHERE id_recipe = @recipeId";
                        SqlCommand checkDessertCmd = new SqlCommand(checkDessertQuery, conn, transaction);
                        checkDessertCmd.Parameters.AddWithValue("@recipeId", recipeId);
                        int dessertCount = (int)checkDessertCmd.ExecuteScalar();
                        if (dessertCount > 0)
                        {
                            string deleteDessertQuery = "DELETE FROM Dessert WHERE id_recipe = @recipeId";
                            SqlCommand dessertCmd = new SqlCommand(deleteDessertQuery, conn, transaction);
                            dessertCmd.Parameters.AddWithValue("@recipeId", recipeId);
                            dessertCmd.ExecuteNonQuery();
                        }

                        string deleteRecipeQuery = "DELETE FROM Recipe WHERE id_recipe = @recipeId";
                        SqlCommand cmd = new SqlCommand(deleteRecipeQuery, conn, transaction);
                        cmd.Parameters.AddWithValue("@recipeId", recipeId);
                        cmd.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error deleting recipe: " + ex.Message);
                        throw new Exception("Unable to delete recipe. Please try again later.", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting recipe: " + ex.Message);
                throw new Exception("Unable to delete recipe. Please try again later.", ex);
            }
        }


        public void UpdateDrink(Drink recipe)
        {
            if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe), "The recipe object cannot be null.");
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        int? picId = null;
                        var recipePic = recipe.GetRecipePic();
                        if (recipePic != null)
                        {
                            string picQuery = @"
                    INSERT INTO RecipePicture (name, data, content_type)
                    OUTPUT INSERTED.id_recipe_pic
                    VALUES (@name, @data, @contentType)";
                            SqlCommand picCmd = new SqlCommand(picQuery, conn, transaction);
                            picCmd.Parameters.AddWithValue("@name", recipePic.GetName() ?? (object)DBNull.Value);
                            picCmd.Parameters.AddWithValue("@data", recipePic.GetData() ?? (object)DBNull.Value);
                            picCmd.Parameters.AddWithValue("@contentType", recipePic.GetContentType() ?? (object)DBNull.Value);
                            picId = (int)picCmd.ExecuteScalar();
                        }

                        string updateRecipeQuery = @"
                UPDATE Recipe
                SET title = @title, description = @description, instructions = @instructions, id_desktop_user = @userId,
                    preparation_time = @prepTime, cooking_time = @cookTime, id_diet_restriction = @dietId, id_difficulty = @difficultyId, id_recipe_pic = @picId
                WHERE id_recipe = @recipeId";
                        SqlCommand updateRecipeCmd = new SqlCommand(updateRecipeQuery, conn, transaction);
                        updateRecipeCmd.Parameters.AddWithValue("@title", (object)recipe.GetTitle() ?? DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@description", (object)recipe.GetDescription() ?? DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@instructions", (object)recipe.GetInstructions() ?? DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@userId", recipe.GetUser()?.GetIdUser() ?? (object)DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@prepTime", recipe.GetPreparationTime() != default(TimeSpan) ? (object)recipe.GetPreparationTime() : DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@cookTime", recipe.GetCookingTime() != default(TimeSpan) ? (object)recipe.GetCookingTime() : DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@dietId", recipe.GetDietRestriction()?.GetId() ?? (object)DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@difficultyId", recipe.GetDifficulty()?.GetId() ?? (object)DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@picId", (object)picId ?? DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@recipeId", recipe.GetIdRecipe());
                        updateRecipeCmd.ExecuteNonQuery();

                        string updateDrinkQuery = @"
                UPDATE Drink
                SET is_alcoholic = @isAlcoholic, contains_caffeine = @containsCaffeine, served_hot = @servedHot, pours = @pours
                WHERE id_recipe = @recipeId";
                        SqlCommand updateDrinkCmd = new SqlCommand(updateDrinkQuery, conn, transaction);
                        updateDrinkCmd.Parameters.AddWithValue("@isAlcoholic", recipe.GetIsAlcoholic());
                        updateDrinkCmd.Parameters.AddWithValue("@containsCaffeine", recipe.GetContainsCaffeine());
                        updateDrinkCmd.Parameters.AddWithValue("@servedHot", recipe.GetServedHot());
                        updateDrinkCmd.Parameters.AddWithValue("@pours", recipe.GetPours());
                        updateDrinkCmd.Parameters.AddWithValue("@recipeId", recipe.GetIdRecipe());
                        updateDrinkCmd.ExecuteNonQuery();

                        string deleteIngredientRecipesQuery = @"
                DELETE FROM IngredientRecipe
                WHERE id_recipe = @recipeId";
                        SqlCommand deleteIngredientRecipesCmd = new SqlCommand(deleteIngredientRecipesQuery, conn, transaction);
                        deleteIngredientRecipesCmd.Parameters.AddWithValue("@recipeId", recipe.GetIdRecipe());
                        deleteIngredientRecipesCmd.ExecuteNonQuery();

                        foreach (var ingredient in recipe.GetIngredientRecipes())
                        {
                            if (ingredient != null)
                            {
                                string ingredientRecipeQuery = @"
                        INSERT INTO IngredientRecipe (id_recipe, id_ingredient, id_unit, quantity)
                        VALUES (@recipeId, @ingredientId, @unitId, @quantity)";
                                SqlCommand ingredientCmd = new SqlCommand(ingredientRecipeQuery, conn, transaction);
                                ingredientCmd.Parameters.AddWithValue("@recipeId", recipe.GetIdRecipe());
                                ingredientCmd.Parameters.AddWithValue("@ingredientId", ingredient.GetIngredient()?.GetId() ?? (object)DBNull.Value);
                                ingredientCmd.Parameters.AddWithValue("@unitId", ingredient.GetUnit()?.GetId() ?? (object)DBNull.Value);
                                ingredientCmd.Parameters.AddWithValue("@quantity", ingredient.GetQuantity());
                                ingredientCmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error in the transaction: " + ex.Message, ex);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating drink: " + ex.Message, ex);
            }
        }

        public void UpdateDessert(Dessert recipe)
        {
            if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe), "The recipe object cannot be null.");
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        int? picId = null;
                        var recipePic = recipe.GetRecipePic();
                        if (recipePic != null)
                        {
                            string picQuery = @"
                    INSERT INTO RecipePicture (name, data, content_type)
                    OUTPUT INSERTED.id_recipe_pic
                    VALUES (@name, @data, @contentType)";
                            SqlCommand picCmd = new SqlCommand(picQuery, conn, transaction);
                            picCmd.Parameters.AddWithValue("@name", recipePic.GetName() ?? (object)DBNull.Value);
                            picCmd.Parameters.AddWithValue("@data", recipePic.GetData() ?? (object)DBNull.Value);
                            picCmd.Parameters.AddWithValue("@contentType", recipePic.GetContentType() ?? (object)DBNull.Value);
                            picId = (int)picCmd.ExecuteScalar();
                        }

                        string updateRecipeQuery = @"
                UPDATE Recipe
                SET title = @title, description = @description, instructions = @instructions, id_desktop_user = @userId,
                    preparation_time = @prepTime, cooking_time = @cookTime, id_diet_restriction = @dietId, id_difficulty = @difficultyId, id_recipe_pic = @picId
                WHERE id_recipe = @recipeId";
                        SqlCommand updateRecipeCmd = new SqlCommand(updateRecipeQuery, conn, transaction);
                        updateRecipeCmd.Parameters.AddWithValue("@title", (object)recipe.GetTitle() ?? DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@description", (object)recipe.GetDescription() ?? DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@instructions", (object)recipe.GetInstructions() ?? DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@userId", recipe.GetUser()?.GetIdUser() ?? (object)DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@prepTime", recipe.GetPreparationTime() != default(TimeSpan) ? (object)recipe.GetPreparationTime() : DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@cookTime", recipe.GetCookingTime() != default(TimeSpan) ? (object)recipe.GetCookingTime() : DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@dietId", recipe.GetDietRestriction()?.GetId() ?? (object)DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@difficultyId", recipe.GetDifficulty()?.GetId() ?? (object)DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@picId", (object)picId ?? DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@recipeId", recipe.GetIdRecipe());
                        updateRecipeCmd.ExecuteNonQuery();

                        string updateDessertQuery = @"
                UPDATE Dessert
                SET is_sugar_free = @isSugarFree, requires_freezing = @requiresFreezing
                WHERE id_recipe = @recipeId";
                        SqlCommand updateDessertCmd = new SqlCommand(updateDessertQuery, conn, transaction);
                        updateDessertCmd.Parameters.AddWithValue("@isSugarFree", recipe.GetIsSugarFree());
                        updateDessertCmd.Parameters.AddWithValue("@requiresFreezing", recipe.GetRequiresFreezing());
                        updateDessertCmd.Parameters.AddWithValue("@recipeId", recipe.GetIdRecipe());
                        updateDessertCmd.ExecuteNonQuery();

                        string deleteIngredientRecipesQuery = @"
                DELETE FROM IngredientRecipe
                WHERE id_recipe = @recipeId";
                        SqlCommand deleteIngredientRecipesCmd = new SqlCommand(deleteIngredientRecipesQuery, conn, transaction);
                        deleteIngredientRecipesCmd.Parameters.AddWithValue("@recipeId", recipe.GetIdRecipe());
                        deleteIngredientRecipesCmd.ExecuteNonQuery();

                        foreach (var ingredient in recipe.GetIngredientRecipes())
                        {
                            if (ingredient != null)
                            {
                                string ingredientRecipeQuery = @"
                        INSERT INTO IngredientRecipe (id_recipe, id_ingredient, id_unit, quantity)
                        VALUES (@recipeId, @ingredientId, @unitId, @quantity)";
                                SqlCommand ingredientCmd = new SqlCommand(ingredientRecipeQuery, conn, transaction);
                                ingredientCmd.Parameters.AddWithValue("@recipeId", recipe.GetIdRecipe());
                                ingredientCmd.Parameters.AddWithValue("@ingredientId", ingredient.GetIngredient()?.GetId() ?? (object)DBNull.Value);
                                ingredientCmd.Parameters.AddWithValue("@unitId", ingredient.GetUnit()?.GetId() ?? (object)DBNull.Value);
                                ingredientCmd.Parameters.AddWithValue("@quantity", ingredient.GetQuantity());
                                ingredientCmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error in the transaction: " + ex.Message, ex);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating dessert: " + ex.Message, ex);
            }
        }

        public void UpdateMainCourse(MainCourse recipe)
        {
            if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe), "The recipe object cannot be null.");
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        int? picId = null;
                        var recipePic = recipe.GetRecipePic();
                        if (recipePic != null)
                        {
                            string picQuery = @"
                    INSERT INTO RecipePicture (name, data, content_type)
                    OUTPUT INSERTED.id_recipe_pic
                    VALUES (@name, @data, @contentType)";
                            SqlCommand picCmd = new SqlCommand(picQuery, conn, transaction);
                            picCmd.Parameters.AddWithValue("@name", recipePic.GetName() ?? (object)DBNull.Value);
                            picCmd.Parameters.AddWithValue("@data", recipePic.GetData() ?? (object)DBNull.Value);
                            picCmd.Parameters.AddWithValue("@contentType", recipePic.GetContentType() ?? (object)DBNull.Value);
                            picId = (int)picCmd.ExecuteScalar();
                        }

                        string updateRecipeQuery = @"
                UPDATE Recipe
                SET title = @title, description = @description, instructions = @instructions, id_desktop_user = @userId,
                    preparation_time = @prepTime, cooking_time = @cookTime, id_diet_restriction = @dietId, id_difficulty = @difficultyId, id_recipe_pic = @picId
                WHERE id_recipe = @recipeId";
                        SqlCommand updateRecipeCmd = new SqlCommand(updateRecipeQuery, conn, transaction);
                        updateRecipeCmd.Parameters.AddWithValue("@title", (object)recipe.GetTitle() ?? DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@description", (object)recipe.GetDescription() ?? DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@instructions", (object)recipe.GetInstructions() ?? DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@userId", recipe.GetUser()?.GetIdUser() ?? (object)DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@prepTime", recipe.GetPreparationTime() != default(TimeSpan) ? (object)recipe.GetPreparationTime() : DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@cookTime", recipe.GetCookingTime() != default(TimeSpan) ? (object)recipe.GetCookingTime() : DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@dietId", recipe.GetDietRestriction()?.GetId() ?? (object)DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@difficultyId", recipe.GetDifficulty()?.GetId() ?? (object)DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@picId", (object)picId ?? DBNull.Value);
                        updateRecipeCmd.Parameters.AddWithValue("@recipeId", recipe.GetIdRecipe());
                        updateRecipeCmd.ExecuteNonQuery();

                        string updateMainCourseQuery = @"
                UPDATE MainCourse
                SET is_spicy = @isSpicy, servings = @servings
                WHERE id_recipe = @recipeId";
                        SqlCommand updateMainCourseCmd = new SqlCommand(updateMainCourseQuery, conn, transaction);
                        updateMainCourseCmd.Parameters.AddWithValue("@isSpicy", recipe.GetIsSpicy());
                        updateMainCourseCmd.Parameters.AddWithValue("@servings", recipe.GetServings());
                        updateMainCourseCmd.Parameters.AddWithValue("@recipeId", recipe.GetIdRecipe());
                        updateMainCourseCmd.ExecuteNonQuery();

                        string deleteIngredientRecipesQuery = @"
                DELETE FROM IngredientRecipe
                WHERE id_recipe = @recipeId";
                        SqlCommand deleteIngredientRecipesCmd = new SqlCommand(deleteIngredientRecipesQuery, conn, transaction);
                        deleteIngredientRecipesCmd.Parameters.AddWithValue("@recipeId", recipe.GetIdRecipe());
                        deleteIngredientRecipesCmd.ExecuteNonQuery();

                        foreach (var ingredient in recipe.GetIngredientRecipes())
                        {
                            if (ingredient != null)
                            {
                                string ingredientRecipeQuery = @"
                        INSERT INTO IngredientRecipe (id_recipe, id_ingredient, id_unit, quantity)
                        VALUES (@recipeId, @ingredientId, @unitId, @quantity)";
                                SqlCommand ingredientCmd = new SqlCommand(ingredientRecipeQuery, conn, transaction);
                                ingredientCmd.Parameters.AddWithValue("@recipeId", recipe.GetIdRecipe());
                                ingredientCmd.Parameters.AddWithValue("@ingredientId", ingredient.GetIngredient()?.GetId() ?? (object)DBNull.Value);
                                ingredientCmd.Parameters.AddWithValue("@unitId", ingredient.GetUnit()?.GetId() ?? (object)DBNull.Value);
                                ingredientCmd.Parameters.AddWithValue("@quantity", ingredient.GetQuantity());
                                ingredientCmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error in the transaction: " + ex.Message, ex);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating main course: " + ex.Message, ex);
            }
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