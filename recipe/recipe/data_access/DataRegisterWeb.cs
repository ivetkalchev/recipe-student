using logic_layer;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace data_access
{
    public class DataRegisterWeb
    {
        private readonly string connectionString;

        public DataRegisterWeb(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool DoesUsernameExist(string username)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE username = @Username", connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    int existingUserCount = (int)command.ExecuteScalar();
                    return existingUserCount > 0;
                }
            }
        }

        public bool DoesEmailExist(string email)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE email = @Email", connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    int existingEmailCount = (int)command.ExecuteScalar();
                    return existingEmailCount > 0;
                }
            }
        }

        public WebUser InsertUser(string username, string password, string email)
        {
            string salt = GenerateSalt();
            string hashedPassword = HashPassword(password, salt);

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = @"INSERT INTO [User] (role, username, password, hashedPassword, salt, email)
                       VALUES (@Role, @Username, @Password, @HashedPassword, @Salt, @Email);
                       SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Role", "webUser");
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@HashedPassword", hashedPassword);
                    command.Parameters.AddWithValue("@Salt", salt);
                    command.Parameters.AddWithValue("@Email", email);

                    int userId = Convert.ToInt32(command.ExecuteScalar());

                    return new WebUser(userId, username, password, email);
                }
            }
        }

        private static string GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        public static string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedPassword = new byte[saltBytes.Length + passwordBytes.Length];
            Array.Copy(saltBytes, 0, saltedPassword, 0, saltBytes.Length);
            Array.Copy(passwordBytes, 0, saltedPassword, saltBytes.Length, passwordBytes.Length);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(saltedPassword);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
