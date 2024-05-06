using System.Data.SqlClient;

namespace DAOs
{
    public class DatabaseConnection
    {
        protected static readonly string connection = "Data Source=mssqlstud.fhict.local;Initial Catalog=dbi526066_recipe;Persist Security Info=True;User ID=dbi526066_recipe;Password=123123;Encrypt=False";

        public static bool CheckConnection()
        {
            bool isConnected = false;
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.connection))
            {
                try
                {
                    connection.Open();
                    isConnected = true;
                    Console.WriteLine("Database connection successful.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Database connection failed: " + ex.Message);
                }
            }
            return isConnected;
        }
    }
}
