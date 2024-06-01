﻿using System;
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
                        SELECT u.id_user, u.username, u.email, u.password, d.id_role, d.first_name, d.last_name, d.bsn, d.gender, d.birthdate, d.security_answer
                        FROM [dbo].[User] u
                        INNER JOIN [dbo].[DesktopUser] d ON u.id_user = d.id_user
                        WHERE u.username = @Username AND u.password = @Password";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
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

        public void UpdateUserDetails(DesktopUser user, string newLastName, string newEmail)
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
                    SET last_name = @LastName
                    WHERE id_user = @UserId;";

                    SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction);
                    cmd.Parameters.AddWithValue("@UserId", user.GetIdUser());
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
                SELECT u.id_user, u.username, u.email, u.password, d.id_role, d.first_name, d.last_name, d.bsn, d.gender, d.birthdate, d.security_answer
                FROM [dbo].[User] u
                INNER JOIN [dbo].[DesktopUser] d ON u.id_user = d.id_user";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Role role = GetRoleById((int)reader["id_role"]);

                            DesktopUser user = new DesktopUser(
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
    }
}
