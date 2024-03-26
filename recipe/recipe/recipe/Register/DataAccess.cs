using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace recipe
{
    /*public class DataAccess
    {
        //Register
        string connectionString = "Server=mssqlstud.fhict.local;Database=dbi526066_recipe;User Id=dbi526066_recipe;Password=123123;";
        public DataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public bool UsernameExists(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM RegisterTbl WHERE Username = @Username", connection);
                command.Parameters.AddWithValue("@Username", username);
                int existingUserCount = (int)command.ExecuteScalar();
                return existingUserCount > 0;
            }
        }
        public bool BSNExists(string bsn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM RegisterTbl WHERE BSN = @BSN", connection);
                command.Parameters.AddWithValue("@BSN", bsn);
                int existingBSNCount = (int)command.ExecuteScalar();
                return existingBSNCount > 0;
            }
        }
        public void InsertUser(string username, string password, string bsn, string gender, string email, string firstName, string lastName, DateTime birthdate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"INSERT INTO RegisterTbl (Username, Password, BSN, Gender, Email, First_Name, Last_Name, Birthdate)
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
    }*/
}
