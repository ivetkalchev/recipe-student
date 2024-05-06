using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using enum_classes.Users;
using entity_classes.Recipes;
using entity_classes.Users;
using System.IO;
using System.Collections;
using System.Security.Cryptography;


namespace DAOs
{
    public class UserDAO : DatabaseConnection, IUserDAO
    {
        public bool IsUsernameTaken(string username)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.connection))
            {
                try
                {
                    connection.Open();

                    string query = @"SELECT COUNT(*) FROM [User] WHERE Username = @Username";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception occurred while checking username availability: " + ex.Message);
                    return true;
                }
            }
        }

        public bool IsBsnTaken(int bsn)
        {

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.connection))
            {
                try
                {
                    connection.Open();

                    string query = @"SELECT COUNT(*) FROM DesktopUser WHERE bsn = @Bsn";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Bsn", bsn);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception occurred while checking BSN availability: " + ex.Message);
                    return true;
                }
            }
        }

        public bool IsEmailTaken(string email)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.connection))
            {
                try
                {
                    connection.Open();

                    string query = @"SELECT COUNT(*) FROM [User] WHERE Email = @Email";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Email", email);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception occurred while checking email availability: " + ex.Message);
                    return true;
                }
            }
        }

        public void CreateUser(DesktopUserDTO user)
        {
            if (IsUsernameTaken(user.Username))
            {
                Console.WriteLine("Username is already taken.");
                return;
            }

            if (IsBsnTaken(user.Bsn))
            {
                Console.WriteLine("BSN is already taken.");
                return;
            }

            if (IsEmailTaken(user.Email))
            {
                Console.WriteLine("Email is already taken.");
                return;
            }
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.connection))
            {
                try
                {
                    connection.Open();

                    string userQuery = @"INSERT INTO [User] (Username, Email, Password) 
                                     VALUES (@Username, @Email, @Password);
                                     SELECT SCOPE_IDENTITY();";

                    SqlCommand userCommand = new SqlCommand(userQuery, connection);
                    userCommand.Parameters.AddWithValue("@Username", user.Username);
                    userCommand.Parameters.AddWithValue("@Email", user.Email);
                    userCommand.Parameters.AddWithValue("@Password", user.Password);

                    int userId = Convert.ToInt32(userCommand.ExecuteScalar());

                    string desktopUserQuery = @"INSERT INTO DesktopUser (id_user, role, first_name, last_name, bsn, gender, birthdate, security_answer) 
                            VALUES (@IdUser, @Role, @FirstName, @LastName, @Bsn, @Gender, @Birthdate, @SecurityAnswer);";


                    SqlCommand desktopUserCommand = new SqlCommand(desktopUserQuery, connection);
                    desktopUserCommand.Parameters.AddWithValue("@IdUser", userId);
                    desktopUserCommand.Parameters.AddWithValue("@Role", "Employee");
                    desktopUserCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
                    desktopUserCommand.Parameters.AddWithValue("@LastName", user.LastName);
                    desktopUserCommand.Parameters.AddWithValue("@Bsn", user.Bsn);
                    desktopUserCommand.Parameters.AddWithValue("@Gender", user.Gender.ToString());
                    desktopUserCommand.Parameters.AddWithValue("@Birthdate", user.Birthdate.Date);
                    desktopUserCommand.Parameters.AddWithValue("@SecurityAnswer", user.SecurityAnswer);

                    desktopUserCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occurred while creating user: " + ex.Message);
                    throw;
                }
            }
        }
        public bool AuthenticateUser(string username, string password, out DesktopUserDTO user)
        {
            user = null;

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.connection))
            {
                try
                {
                    connection.Open();

                    string query = @"SELECT Id, Username, Email, Password FROM [User] WHERE Username = @Username";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string hashedPasswordFromDb = reader["Password"].ToString();

                        if (VerifyPassword(password, hashedPasswordFromDb))
                        {
                            user = new DesktopUserDTO
                            {
                                IdUser = Convert.ToInt32(reader["Id"]),
                                Username = reader["Username"].ToString(),
                                Email = reader["Email"].ToString(),
                            };

                            Console.WriteLine("User authenticated successfully: " + user.Username);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid password for the user: " + username);
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No user found with the given username: " + username);
                        return false;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Exception occurred: " + ex.Message);
                    Console.WriteLine("Inner Exception: " + ex.InnerException?.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception occurred while authenticating user: " + ex.Message);
                    return false;
                }
            }
        }


        private bool VerifyPassword(string plainPassword, string hashedPassword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(plainPassword));
                string hashedInputPassword = Convert.ToBase64String(hashBytes);
                return hashedInputPassword == hashedPassword;
            }
        }

        public DesktopUserDTO GetUserByUsername(string username)
        {
            DesktopUserDTO user = null;

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.connection))
            {
                try
                {
                    connection.Open();

                    string query = @"SELECT Id, Username, Email FROM [User] WHERE Username = @Username";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        user = new DesktopUserDTO
                        {
                            IdUser = Convert.ToInt32(reader["Id"]),
                            Username = reader["Username"].ToString(),
                            Email = reader["Email"].ToString(),
                        };

                        Console.WriteLine("User found: " + user.Username);
                    }
                    else
                    {
                        Console.WriteLine("No user found with the given username: " + username);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Exception occurred: " + ex.Message);
                    Console.WriteLine("Inner Exception: " + ex.InnerException?.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception occurred while retrieving user by username: " + ex.Message);
                }
            }

            return user;
        }


    }
}

