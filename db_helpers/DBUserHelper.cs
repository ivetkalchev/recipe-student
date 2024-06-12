using System.Data.SqlClient;
using entity_classes;

namespace db_helpers
{
    public class DBUserHelper : DBConnection, IDBUserHelper
    {
        public void InsertDesktopUser(DesktopUser newUser)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.connection))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string insertUserQuery = @"
                        INSERT INTO [dbo].[User] (username, email, password)
                        VALUES (@Username, @Email, @Password);
                        SELECT SCOPE_IDENTITY();";

                    SqlCommand insertUserCmd = new SqlCommand(insertUserQuery, conn, transaction);
                    insertUserCmd.Parameters.AddWithValue("@Username", newUser.GetUsername());
                    insertUserCmd.Parameters.AddWithValue("@Email", newUser.GetEmail());
                    insertUserCmd.Parameters.AddWithValue("@Password", newUser.GetPassword());

                    int userId = Convert.ToInt32(insertUserCmd.ExecuteScalar());

                    string insertDesktopUserQuery = @"
                        INSERT INTO [dbo].[DesktopUser] (id_user, id_role, first_name, last_name, bsn, id_gender, birthdate)
                        VALUES (@IdUser, @IdRole, @FirstName, @LastName, @Bsn, @IdGender, @Birthdate);";

                    SqlCommand insertDesktopUserCmd = new SqlCommand(insertDesktopUserQuery, conn, transaction);
                    insertDesktopUserCmd.Parameters.AddWithValue("@IdUser", userId);
                    insertDesktopUserCmd.Parameters.AddWithValue("@IdRole", newUser.GetRole().GetId());
                    insertDesktopUserCmd.Parameters.AddWithValue("@FirstName", newUser.GetFirstName());
                    insertDesktopUserCmd.Parameters.AddWithValue("@LastName", newUser.GetLastName());
                    insertDesktopUserCmd.Parameters.AddWithValue("@Bsn", newUser.GetBsn());
                    insertDesktopUserCmd.Parameters.AddWithValue("@IdGender", newUser.GetGender().GetId());
                    insertDesktopUserCmd.Parameters.AddWithValue("@Birthdate", newUser.GetBirthdate());

                    insertDesktopUserCmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error inserting DesktopUser: " + ex.Message);
                }
            }
        }

        public DesktopUser GetDesktopUser(string username, string hashedPassword)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();

                    string query = @"
                SELECT u.id_user, u.username, u.email, u.password, d.id_role, d.first_name, d.last_name, d.bsn, d.id_gender, d.birthdate
                FROM [dbo].[User] u
                INNER JOIN [dbo].[DesktopUser] d ON u.id_user = d.id_user
                WHERE u.username COLLATE Latin1_General_BIN = @Username AND u.password = @Password";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Role role = GetRoleById((int)reader["id_role"]);
                            Gender gender = GetGenderById((int)reader["id_gender"]);

                            return new DesktopUser(
                                (int)reader["id_user"],
                                reader["username"].ToString(),
                                reader["email"].ToString(),
                                reader["password"].ToString(),
                                role,
                                reader["first_name"].ToString(),
                                reader["last_name"].ToString(),
                                (int)reader["bsn"],
                                gender,
                                (DateTime)reader["birthdate"]
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving DesktopUser: " + ex.Message);
            }

            return null;
        }


        public bool IsUsernameTaken(string username)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM [dbo].[User] WHERE username = @Username";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking username: " + ex.Message);
                return false;
            }
        }

        public bool IsEmailTaken(string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM [dbo].[User] WHERE email = @Email";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking email: " + ex.Message);
                return false;
            }
        }

        public bool IsBSNTaken(int bsn)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM [dbo].[DesktopUser] WHERE bsn = @Bsn";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Bsn", bsn);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking BSN: " + ex.Message);
                return false;
            }
        }

        private Role GetRoleById(int roleId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();

                    string query = "SELECT id_role, role_name FROM [dbo].[Role] WHERE id_role = @RoleId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@RoleId", roleId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Role(
                                (int)reader["id_role"],
                                reader["role_name"].ToString()
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving Role: " + ex.Message);
            }
            return null;
        }

        public void UpdateDesktopUserDetails(DesktopUser user, string newFirstName, string newLastName, string newEmail, DateTime newBirthdate, Gender newGender, int newBSN)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.connection))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string updateQuery = @"
                    UPDATE [dbo].[User]
                    SET email = @Email
                    WHERE id_user = @UserId;

                    UPDATE [dbo].[DesktopUser]
                    SET first_name = @FirstName,
                        last_name = @LastName,
                        bsn = @BSN,
                        id_gender = @GenderId,
                        birthdate = @Birthdate
                    WHERE id_user = @UserId;";

                    SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction);
                    cmd.Parameters.AddWithValue("@UserId", user.GetIdUser());
                    cmd.Parameters.AddWithValue("@FirstName", newFirstName);
                    cmd.Parameters.AddWithValue("@LastName", newLastName);
                    cmd.Parameters.AddWithValue("@Email", newEmail);
                    cmd.Parameters.AddWithValue("@BSN", newBSN);
                    cmd.Parameters.AddWithValue("@GenderId", newGender.GetId());
                    cmd.Parameters.AddWithValue("@Birthdate", newBirthdate);

                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error updating user details: " + ex.Message);
                }
            }
        }


        public void DeleteUser(DesktopUser user)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.connection))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string deleteUserQuery = @"
                        DELETE FROM [dbo].[DesktopUser] WHERE id_user = @UserId;
                        DELETE FROM [dbo].[User] WHERE id_user = @UserId;";

                    SqlCommand cmd = new SqlCommand(deleteUserQuery, conn, transaction);
                    cmd.Parameters.AddWithValue("@UserId", user.GetIdUser());

                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error deleting user: " + ex.Message);
                }
            }
        }

        public void PromoteUserToAdmin(DesktopUser user)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.connection))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string promoteUserQuery = @"
                        UPDATE [dbo].[DesktopUser]
                        SET id_role = (SELECT id_role FROM [dbo].[Role] WHERE role_name = 'Admin')
                        WHERE id_user = @UserId;";

                    SqlCommand cmd = new SqlCommand(promoteUserQuery, conn, transaction);
                    cmd.Parameters.AddWithValue("@UserId", user.GetIdUser());

                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error promoting user: " + ex.Message);
                }
            }
        }

        public List<DesktopUser> GetAllDesktopUsers()
        {
            List<DesktopUser> users = new List<DesktopUser>();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();

                    string query = @"
                SELECT u.id_user, u.username, u.email, u.password, d.id_role, d.first_name, d.last_name, d.bsn, d.id_gender, d.birthdate
                FROM [dbo].[User] u
                INNER JOIN [dbo].[DesktopUser] d ON u.id_user = d.id_user";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Role role = GetRoleById((int)reader["id_role"]);
                            Gender gender = GetGenderById((int)reader["id_gender"]);

                            DesktopUser user = new DesktopUser(
                                (int)reader["id_user"],
                                reader["username"].ToString(),
                                reader["email"].ToString(),
                                reader["password"].ToString(),
                                role,
                                reader["first_name"].ToString(),
                                reader["last_name"].ToString(),
                                (int)reader["bsn"],
                                gender,
                                (DateTime)reader["birthdate"]
                            );

                            users.Add(user);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error connecting to the database: " + ex.Message);
            }

            return users;
        }
        public List<Gender> GetAllGenders()
        {
            List<Gender> genders = new List<Gender>();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = "SELECT id_gender, gender FROM [dbo].[Gender]";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            genders.Add(new Gender(reader.GetInt32(0), reader.GetString(1)));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error retrieving genders from the database: " + ex.Message);
            }
            return genders;
        }


        public Gender GetGenderById(int genderId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = "SELECT id_gender, gender FROM [dbo].[Gender] WHERE id_gender = @GenderId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@GenderId", genderId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Gender(reader.GetInt32(0), reader.GetString(1));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving Gender: " + ex.Message);
            }

            return null;
        }
        public bool IsEmailTakenByOtherUser(DesktopUser user, string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM [dbo].[User] WHERE email = @Email AND id_user != @UserId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@UserId", user.GetIdUser());

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking email for other users: " + ex.Message);
                return false;
            }
        }

        public bool IsBsnTakenByOtherUser(DesktopUser user, int bsn)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM [dbo].[DesktopUser] WHERE bsn = @Bsn AND id_user != @UserId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Bsn", bsn);
                    cmd.Parameters.AddWithValue("@UserId", user.GetIdUser());

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking BSN for other users: " + ex.Message);
                return false;
            }
        }
        public void InsertWebUser(WebUser newUser)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.connection))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string insertUserQuery = @"
                        INSERT INTO [dbo].[User] (username, email, password)
                        VALUES (@Username, @Email, @Password);
                        SELECT SCOPE_IDENTITY();";

                    SqlCommand insertUserCmd = new SqlCommand(insertUserQuery, conn, transaction);
                    insertUserCmd.Parameters.AddWithValue("@Username", newUser.GetUsername());
                    insertUserCmd.Parameters.AddWithValue("@Email", newUser.GetEmail());
                    insertUserCmd.Parameters.AddWithValue("@Password", newUser.GetPassword());

                    int userId = Convert.ToInt32(insertUserCmd.ExecuteScalar());

                    string insertWebUserQuery = @"
                        INSERT INTO [dbo].[WebUser] (id_user, caption)
                        VALUES (@IdUser, @Caption);";

                    SqlCommand insertWebUserCmd = new SqlCommand(insertWebUserQuery, conn, transaction);
                    insertWebUserCmd.Parameters.AddWithValue("@IdUser", userId);
                    insertWebUserCmd.Parameters.AddWithValue("@Caption", newUser.GetCaption());

                    insertWebUserCmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error inserting WebUser: " + ex.Message);
                }
            }
        }
        public WebUser GetWebUser(string username, string hashedPassword)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();

                    string query = @"
                SELECT u.id_user, u.username, u.email, u.password, w.caption
                FROM [dbo].[User] u
                INNER JOIN [dbo].[WebUser] w ON u.id_user = w.id_user
                WHERE u.username COLLATE Latin1_General_BIN = @Username AND u.password = @Password";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    Console.WriteLine($"Executing query: {query} with Username: {username}, Password: {hashedPassword}");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new WebUser(
                                (int)reader["id_user"],
                                reader["username"].ToString(),
                                reader["email"].ToString(),
                                reader["password"].ToString(),
                                reader["caption"].ToString()
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving WebUser: " + ex.Message);
            }

            return null;
        }



        public bool IsWebUsernameTaken(string username)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM [dbo].[User] WHERE username = @Username";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking WebUser username: " + ex.Message);
                return false;
            }
        }

        public bool IsWebEmailTaken(string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM [dbo].[User] WHERE email = @Email";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking WebUser email: " + ex.Message);
                return false;
            }
        }

        public void UpdateWebUserDetails(WebUser user, string newCaption, string newEmail)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.connection))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string updateQuery = @"
                UPDATE [dbo].[User]
                SET email = @Email
                WHERE id_user = @UserId;

                UPDATE [dbo].[WebUser]
                SET caption = @Caption
                WHERE id_user = @UserId;";

                    SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction);
                    cmd.Parameters.AddWithValue("@UserId", user.GetIdUser());
                    cmd.Parameters.AddWithValue("@Caption", newCaption);
                    cmd.Parameters.AddWithValue("@Email", newEmail);

                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error updating WebUser details: " + ex.Message);
                }
            }
        }

        public void DeleteWebUser(WebUser user)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.connection))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string deleteUserQuery = @"
                        DELETE FROM [dbo].[WebUser] WHERE id_user = @UserId;
                        DELETE FROM [dbo].[User] WHERE id_user = @UserId;";

                    SqlCommand cmd = new SqlCommand(deleteUserQuery, conn, transaction);
                    cmd.Parameters.AddWithValue("@UserId", user.GetIdUser());

                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error deleting WebUser: " + ex.Message);
                }
            }
        }

        public List<WebUser> GetAllWebUsers()
        {
            List<WebUser> users = new List<WebUser>();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();

                    string query = @"
                    SELECT u.id_user, u.username, u.email, u.password, w.caption
                    FROM [dbo].[User] u
                    INNER JOIN [dbo].[WebUser] w ON u.id_user = w.id_user";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            WebUser user = new WebUser(
                                (int)reader["id_user"],
                                reader["username"].ToString(),
                                reader["email"].ToString(),
                                reader["password"].ToString(),
                                reader["caption"].ToString()
                            );

                            users.Add(user);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error connecting to the database: " + ex.Message);
            }

            return users;
        }

        public WebUser GetWebUserByUsername(string username)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();

                    string query = @"
                SELECT u.id_user, u.username, u.email, u.password, w.caption
                FROM [dbo].[User] u
                INNER JOIN [dbo].[WebUser] w ON u.id_user = w.id_user
                WHERE u.username COLLATE Latin1_General_BIN = @Username";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new WebUser(
                                (int)reader["id_user"],
                                reader["username"].ToString(),
                                reader["email"].ToString(),
                                reader["password"].ToString(),
                                reader["caption"].ToString()
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving WebUser: " + ex.Message);
            }

            return null;
        }

        public DesktopUser GetUserById(int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = @"
            SELECT u.id_user, u.username, u.email, u.password, d.id_role, d.first_name, d.last_name, d.bsn, d.id_gender, d.birthdate
            FROM [dbo].[User] u
            INNER JOIN [DesktopUser] d ON u.id_user = d.id_user
            WHERE u.id_user = @userId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new DesktopUser(
                                (int)reader["id_user"],
                                reader["username"].ToString(),
                                reader["email"].ToString(),
                                reader["password"].ToString(),
                                GetRoleById((int)reader["id_role"]),
                                reader["first_name"].ToString(),
                                reader["last_name"].ToString(),
                                (int)reader["bsn"],
                                GetGenderById((int)reader["id_gender"]),
                                (DateTime)reader["birthdate"]
                            );
                        }
                        else
                        {
                            throw new Exception("User not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching user by ID: " + ex.Message);
                throw new Exception("Unable to fetch user by ID. Please try again later.", ex);
            }
        }
    }
}