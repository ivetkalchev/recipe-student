using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Security;
using entity_classes;
using enum_classes;

namespace DBHelpers
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
                    insertDesktopUserCmd.Parameters.AddWithValue("@IdRole", 2); // Ensure role is set to Employee
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

        public DesktopUser GetDesktopUser(string email, string hashedPassword)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();

                    string query = @"
                        SELECT u.id_user, u.username, u.email, u.password, d.id_role, d.first_name, d.last_name, d.bsn, d.gender, d.birthdate, d.security_answer
                        FROM [dbo].[User] u
                        INNER JOIN [dbo].[DesktopUser] d ON u.id_user = d.id_user
                        WHERE u.email = @Email AND u.password = @Password";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Role role = GetRoleById((int)reader["id_role"]);
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
                                reader["security_answer"].ToString()
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
    }
}
