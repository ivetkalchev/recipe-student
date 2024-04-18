using System;
using System.Data.SqlClient;

namespace data_access
{
    public class DataLogin
    {
        private string connectionString;

        public DataLogin(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool CheckLoginCredentials(string username, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT COUNT(*) FROM [User] 
                             WHERE username = @Username AND password = @Password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
