using logic_layer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace data_access
{
    public class DataRegister
    {
        private readonly string connectionString = "Data Source=mssqlstud.fhict.local;Initial Catalog=dbi526066_recipe;Persist Security Info=True;User ID=dbi526066_recipe;Password=123;Encrypt=False";
        public DataRegister()
        {
        }

        public bool DoesBSNExist(int bsn)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM CompanyUser WHERE bsn = @BSN", connection);
                command.Parameters.AddWithValue("@BSN", bsn);
                int existingBSNCount = (int)command.ExecuteScalar();
                return existingBSNCount > 0;
            }
        }

        public bool DoesUsernameExist(string username)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE username = @Username", connection);
                command.Parameters.AddWithValue("@Username", username);
                int existingUserCount = (int)command.ExecuteScalar();
                return existingUserCount > 0;
            }
        }

        public bool DoesEmailExist(string email)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE email = @Email", connection);
                command.Parameters.AddWithValue("@Email", email);
                int existingEmailCount = (int)command.ExecuteScalar();
                return existingEmailCount > 0;
            }
        }

        public CompanyUser InsertCompanyUser(string username, string password, int bsn, string gender, string email, string firstName, string lastName, DateTime birthdate)
        {
            string salt = GenerateSalt();
            string hashedPassword = HashPassword(password, salt);

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"INSERT INTO [User] (role, username, password, hashedPassword, salt, email)
               VALUES (@Role, @Username, @Password, @HashedPassword, @Salt, @Email);
               INSERT INTO CompanyUser (firstName, lastName, bsn, gender, birthDate)
               VALUES (@FirstName, @LastName, @BSN, @Gender, @Birthdate);
               SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Role", "companyUser");
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", DBNull.Value);
                command.Parameters.AddWithValue("@HashedPassword", hashedPassword);
                command.Parameters.AddWithValue("@Salt", salt);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@BSN", bsn);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@Birthdate", birthdate);

                int userId = Convert.ToInt32(command.ExecuteScalar());

                return new CompanyUser(userId, "companyUser", username, null, hashedPassword, salt, email, firstName, lastName, bsn, gender, birthdate);
            }
        }
        public WebUser InsertWebUser(string username, string password, string email)
        {
            string salt = GenerateSalt();
            string hashedPassword = HashPassword(password, salt);

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"INSERT INTO [User] (role, username, password, hashedPassword, salt, email)
                       VALUES (@Role, @Username, @Password, @HashedPassword, @Salt, @Email);
                       SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Role", "webUser");
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", DBNull.Value);
                command.Parameters.AddWithValue("@HashedPassword", hashedPassword);
                command.Parameters.AddWithValue("@Salt", salt);
                command.Parameters.AddWithValue("@Email", email);

                int userId = Convert.ToInt32(command.ExecuteScalar());

                return new WebUser(userId, username, null, email);
            }
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

        private static string GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }
    }
}
