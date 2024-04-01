using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access
{
    public class DataForgottenPassword
    {
        private string connectionString;

        public DataForgottenPassword(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public (string Username, string Password, string FirstName, string LastName) GetUserDataByBSN(string bsn)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Username, Password, FirstName, LastName FROM RegisterTbl WHERE BSN = @BSN";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BSN", bsn);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return (
                                    reader["Username"].ToString(),
                                    reader["Password"].ToString(),
                                    reader["FirstName"].ToString(),
                                    reader["LastName"].ToString()
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
