using System;
using System.Data.SqlClient;

namespace data_access
{
    public class DataForgottenPassword
    {
        private string connectionString;

        public DataForgottenPassword(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public (string? Username, string? Password, string? FirstName, string? LastName) GetUserDataByBSN(string bsn)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT U.username, U.password, CU.firstName, CU.lastName 
                                     FROM [User] U 
                                     JOIN CompanyUser CU ON U.id = CU.id 
                                     WHERE CU.bsn = @BSN";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BSN", bsn);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return (
                                    reader["Username"]?.ToString(),
                                    reader["Password"]?.ToString(),
                                    reader["FirstName"]?.ToString(),
                                    reader["LastName"]?.ToString()
                                );
                            }
                            else
                            {
                                return (null, null, null, null);
                            }
                        }
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
