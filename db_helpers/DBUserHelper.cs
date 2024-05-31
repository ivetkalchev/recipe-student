using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using entity_classes;
using enum_classes;

namespace db_helpers
{
    public class DBUserHelper : DBConnection, IDBUserHelper
    {
        public void InsertDesktopUser(DesktopUser desktopUser)
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
                    insertUserCmd.Parameters.AddWithValue("@Username", desktopUser.GetUsername());
                    insertUserCmd.Parameters.AddWithValue("@Email", desktopUser.GetEmail());
                    insertUserCmd.Parameters.AddWithValue("@Password", desktopUser.GetPassword());

                    int userId = Convert.ToInt32(insertUserCmd.ExecuteScalar());

                    string insertDesktopUserQuery = @"
                        INSERT INTO [dbo].[DesktopUser] (id_user, id_role, first_name, last_name, bsn, gender, birthdate, security_answer)
                        VALUES (@IdUser, @IdRole, @FirstName, @LastName, @Bsn, @Gender, @Birthdate, @SecurityAnswer);";

                    SqlCommand insertDesktopUserCmd = new SqlCommand(insertDesktopUserQuery, conn, transaction);
                    insertDesktopUserCmd.Parameters.AddWithValue("@IdUser", userId);
                    insertDesktopUserCmd.Parameters.AddWithValue("@IdRole", 2);
                    insertDesktopUserCmd.Parameters.AddWithValue("@FirstName", desktopUser.GetFirstName());
                    insertDesktopUserCmd.Parameters.AddWithValue("@LastName", desktopUser.GetLastName());
                    insertDesktopUserCmd.Parameters.AddWithValue("@Bsn", desktopUser.GetBsn());
                    insertDesktopUserCmd.Parameters.AddWithValue("@Gender", desktopUser.GetGender().ToString());
                    insertDesktopUserCmd.Parameters.AddWithValue("@Birthdate", desktopUser.GetBirthdate());
                    insertDesktopUserCmd.Parameters.AddWithValue("@SecurityAnswer", desktopUser.GetSecurityAnswer());

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
                        SELECT u.id_user, u.username, u.email, u.password, u.id_profile_pic, d.id_role, d.first_name, d.last_name, d.bsn, d.gender, d.birthdate, d.security_answer,
                               p.name AS profile_pic_name, p.data AS profile_pic_data, p.content_type AS profile_pic_content_type
                        FROM [dbo].[User] u
                        INNER JOIN [dbo].[DesktopUser] d ON u.id_user = d.id_user
                        LEFT JOIN [dbo].[UserProfilePicture] p ON u.id_profile_pic = p.id_profile_pic
                        WHERE u.username = @Username AND u.password = @Password";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Role role = GetRoleById((int)reader["id_role"]);
                            UserProfilePicture profilePicture = null;

                            if (!reader.IsDBNull(reader.GetOrdinal("profile_pic_name")))
                            {
                                profilePicture = new UserProfilePicture(
                                    reader["profile_pic_name"].ToString(),
                                    (byte[])reader["profile_pic_data"],
                                    reader["profile_pic_content_type"].ToString()
                                );
                            }

                            return new DesktopUser(
                                (int)reader["id_user"],
                                reader["username"].ToString(),
                                reader["email"].ToString(),
                                reader["password"].ToString(),
                                role,
                                reader["first_name"].ToString(),
                                reader["last_name"].ToString(),
                                (int)reader["bsn"],
                                (Gender)Enum.Parse(typeof(Gender), reader["gender"].ToString()),
                                (DateTime)reader["birthdate"],
                                reader["security_answer"].ToString(),
                                profilePicture
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
                                reader["role_name"].ToString(),
                                GetPermissionsByRoleId((int)reader["id_role"])
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

        private List<Permission> GetPermissionsByRoleId(int roleId)
        {
            List<Permission> permissions = new List<Permission>();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();

                    string query = @"
                        SELECT p.id_permission, p.permission_name
                        FROM [dbo].[Permission] p
                        INNER JOIN [dbo].[RoleToPermission] rp ON p.id_permission = rp.id_permission
                        WHERE rp.id_role = @RoleId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@RoleId", roleId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            permissions.Add(new Permission(
                                (int)reader["id_permission"],
                                reader["permission_name"].ToString()
                            ));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving Permissions: " + ex.Message);
            }

            return permissions;
        }

        public void UpdateUserDetails(DesktopUser user, string newLastName, string newUsername, string newEmail)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.connection))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string updateQuery = @"
                    UPDATE [dbo].[User]
                    SET username = @Username, email = @Email
                    WHERE id_user = @UserId;

                    UPDATE [dbo].[DesktopUser]
                    SET last_name = @LastName
                    WHERE id_user = @UserId;";

                    SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction);
                    cmd.Parameters.AddWithValue("@UserId", user.GetIdUser());
                    cmd.Parameters.AddWithValue("@Username", newUsername);
                    cmd.Parameters.AddWithValue("@Email", newEmail);
                    cmd.Parameters.AddWithValue("@LastName", newLastName);

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

    }
}
