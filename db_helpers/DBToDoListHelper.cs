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
