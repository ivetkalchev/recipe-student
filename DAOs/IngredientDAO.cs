using DTOs;
using entity_classes.Ingredients;
using enum_classes.Ingredients;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class IngredientDAO
    {
        private string connectionString;

        public IngredientDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddIngredient(IngredientDTO ingredient)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Ingredient (id_ingredient, name, unit, quantity, price) VALUES (@IdIngredient, @Name, @Unit, @Quantity, @Price)", connection);
                command.Parameters.AddWithValue("@IdIngredient", ingredient.IdIngredient);
                command.Parameters.AddWithValue("@Name", ingredient.Name);
                command.Parameters.AddWithValue("@Unit", ingredient.Unit.ToString());
                command.Parameters.AddWithValue("@Quantity", ingredient.Quantity);
                command.Parameters.AddWithValue("@Price", ingredient.Price);
                command.ExecuteNonQuery();
            }
        }

        public IngredientDTO GetIngredientById(int idIngredient)
        {
            IngredientDTO ingredient = null;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT id_ingredient, name, unit, quantity, price FROM Ingredient WHERE id_ingredient = @IdIngredient", connection);
                command.Parameters.AddWithValue("@IdIngredient", idIngredient);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ingredient = new IngredientDTO
                        {
                            IdIngredient = reader.GetInt32(reader.GetOrdinal("id_ingredient")),
                            Name = reader.GetString(reader.GetOrdinal("name")),
                            Unit = (Unit)Enum.Parse(typeof(Unit), reader.GetString(reader.GetOrdinal("unit"))),
                            Quantity = reader.GetDecimal(reader.GetOrdinal("quantity")),
                            Price = reader.GetDecimal(reader.GetOrdinal("price"))
                        };
                    }
                }
            }
            return ingredient;
        }

        public void UpdateIngredient(IngredientDTO ingredient)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Ingredient SET name = @Name, unit = @Unit, quantity = @Quantity, price = @Price WHERE id_ingredient = @IdIngredient", connection);
                command.Parameters.AddWithValue("@IdIngredient", ingredient.IdIngredient);
                command.Parameters.AddWithValue("@Name", ingredient.Name);
                command.Parameters.AddWithValue("@Unit", ingredient.Unit.ToString());
                command.Parameters.AddWithValue("@Quantity", ingredient.Quantity);
                command.Parameters.AddWithValue("@Price", ingredient.Price);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteIngredient(int idIngredient)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Ingredient WHERE id_ingredient = @IdIngredient", connection);
                command.Parameters.AddWithValue("@IdIngredient", idIngredient);
                command.ExecuteNonQuery();
            }
        }

        public List<Ingredient> GetAllIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT id_ingredient, name, unit, quantity, price FROM Ingredient", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ingredient ingredient = new Ingredient(
                            idIngredient: reader.GetInt32(reader.GetOrdinal("id_ingredient")),
                            name: reader.GetString(reader.GetOrdinal("name")),
                            unit: (Unit)Enum.Parse(typeof(Unit), reader.GetString(reader.GetOrdinal("unit"))),
                            quantity: reader.GetDecimal(reader.GetOrdinal("quantity")),
                            price: reader.GetDecimal(reader.GetOrdinal("price"))
                        );
                        ingredients.Add(ingredient);
                    }
                }
            }

            return ingredients;
        }

    }
}
