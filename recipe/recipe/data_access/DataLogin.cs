using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace data_access
{
    public class DataLogin
    {
        private readonly string connectionString = "Data Source=mssqlstud.fhict.local;Initial Catalog=dbi526066_recipe;Persist Security Info=True;User ID=dbi526066_recipe;Password=123;Encrypt=False";

        public DataLogin()
        {
        }

        public bool CheckLoginCredentials(string username, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT hashedPassword, salt FROM [User] WHERE username = @Username";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string hashedPasswordFromDb = reader.GetString(0);
                                string salt = reader.GetString(1);
                                string hashedInputPassword = HashPassword(password, salt);
                                return hashedPasswordFromDb == hashedInputPassword;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("An error occurred while processing your request. Please try again later.");
            }
        }

        private string HashPassword(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] saltedPasswordBytes = Encoding.UTF8.GetBytes(password + salt);
                byte[] hashBytes = sha256.ComputeHash(saltedPasswordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
