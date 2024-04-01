using System;
using System.Data;
using System.Data.SqlClient;

namespace data_access
{
    public class DataRegister
    {
        private SqlConnection connection;

        public DataRegister(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        public bool IsBSNExists(string bsn)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM RegisterTbl WHERE BSN = @BSN", connection);
            command.Parameters.AddWithValue("@BSN", bsn);
            int existingBSNCount = (int)command.ExecuteScalar();
            return existingBSNCount > 0;
        }

        public bool IsUsernameExists(string username)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM RegisterTbl WHERE Username = @Username", connection);
            command.Parameters.AddWithValue("@Username", username);
            int existingUserCount = (int)command.ExecuteScalar();
            return existingUserCount > 0;
        }

        public void InsertUser(string username, string password, string bsn, string gender, string email, string firstName, string lastName, DateTime birthdate)
        {
            string sql = @"INSERT INTO RegisterTbl (Username, Password, BSN, Gender, Email, FirstName, LastName, Birthdate)
                           VALUES (@Username, @Password, @BSN, @Gender, @Email, @FirstName, @LastName, @Birthdate)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@BSN", bsn);
            command.Parameters.AddWithValue("@Gender", gender);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@Birthdate", birthdate);
            command.ExecuteNonQuery();
        }
    }
}
