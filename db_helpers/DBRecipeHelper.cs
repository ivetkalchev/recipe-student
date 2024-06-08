using entity_classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
                            TimeSpan cookingTime = (TimeSpan)reader["cooking_time"];
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



        private DietRestriction GetDietRestrictionById(int dietId)
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


        private Difficulty GetDifficultyById(int difficultyId)
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
                        var ingredients = new List<IngredientRecipe>();

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
                                TimeSpan cookingTime = (TimeSpan)reader["cooking_time"];
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
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Column not found: " + ex.Message);
                throw new Exception("Column not found: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching recipe by ID: " + ex.Message);
                throw new Exception("Unable to fetch recipe by ID. Please try again later.", ex);
            }

            return recipe;
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
    }
}