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
using System.Data.Common;
using System.Transactions;

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
        public void CreateDesktopUser(DesktopUserDTO user)
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
        public bool ValidateUserCredentials(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.connection))
            {
                connection.Open();
                string query = @"SELECT COUNT(*) FROM [User] WHERE Username = @Username AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        public bool ValidateSecurityAnswer(string username, string securityAnswer)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.connection))
            {
                connection.Open();
                var command = new SqlCommand("SELECT security_answer FROM DesktopUser WHERE id_user = (SELECT id_user FROM [User] WHERE Username = @Username)", connection);
                command.Parameters.AddWithValue("@Username", username);

                var storedAnswer = command.ExecuteScalar() as string;
                return storedAnswer != null && storedAnswer.Equals(securityAnswer, StringComparison.OrdinalIgnoreCase);
            }
        }
        public bool UpdateDesktopPassword(string username, string newPassword)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.connection))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE [User] SET Password = @Password WHERE Username = @Username", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", newPassword);
                return command.ExecuteNonQuery() == 1;
            }
        }

        public void CreateWebUser(WebUserDTO user)
        {
            if (IsUsernameTaken(user.Username))
            {
                Console.WriteLine("Username is already taken.");
                return;
            }

            if (IsEmailTaken(user.Email))
            {
                Console.WriteLine("Email is already taken.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.connection))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    string userQuery = @"INSERT INTO [User] (Username, Email, Password) 
                                 VALUES (@Username, @Email, @Password);
                                 SELECT SCOPE_IDENTITY();";

                    SqlCommand userCommand = new SqlCommand(userQuery, connection, transaction);
                    userCommand.Parameters.AddWithValue("@Username", user.Username);
                    userCommand.Parameters.AddWithValue("@Email", user.Email);
                    userCommand.Parameters.AddWithValue("@Password", user.Password);

                    int newUserId = Convert.ToInt32(userCommand.ExecuteScalar());

                    if (newUserId > 0)
                    {
                        string finalCaption = string.IsNullOrEmpty(user.Caption) ? "Caption not added yet" : user.Caption;
                        string webUserQuery = @"INSERT INTO WebUser (id_user, caption) 
                                        VALUES (@IdUser, @Caption);";

                        SqlCommand webUserCommand = new SqlCommand(webUserQuery, connection, transaction);
                        webUserCommand.Parameters.AddWithValue("@IdUser", newUserId);
                        webUserCommand.Parameters.AddWithValue("@Caption", finalCaption);

                        int result = webUserCommand.ExecuteNonQuery();

                        if (result > 0)
                        {
                            transaction.Commit();
                            Console.WriteLine("Web user created successfully.");
                        }
                        else
                        {
                            throw new Exception("Failed to insert web user data.");
                        }
                    }
                    else
                    {
                        throw new Exception("Failed to insert user data.");
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error occurred while creating web user: " + ex.Message);
                    throw;
                }
            }
        }
        public WebUserDTO GetWebUserByUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.connection))
            {
                try
                {
                    connection.Open();

                    string query = @"
            SELECT u.Username, u.Email, w.Caption
            FROM [User] u
            INNER JOIN WebUser w ON u.id_user = w.id_user
            WHERE u.Username = @Username";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new WebUserDTO
                            {
                                Username = reader["Username"].ToString(),
                                Email = reader["Email"].ToString(),
                                Caption = reader["Caption"].ToString()
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception occurred while retrieving web user data: " + ex.Message);
                    return null;
                }
            }
        }
        public bool UpdateWebUserPassword(string username, string newPassword)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.connection))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand("UPDATE [User] SET Password = @Password WHERE Username = @Username", connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", newPassword);
                    return command.ExecuteNonQuery() == 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occurred while updating password: " + ex.Message);
                    return false;
                }
            }
        }
        public bool UploadProfilePicture(int userId, string imagePath, string imageType)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.connection))
            {
                try
                {
                    connection.Open();

                    string query = @"
                INSERT INTO ProfilePicture (id_user, image_path, image_type)
                VALUES (@IdUser, @ImagePath, @ImageType);";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdUser", userId);
                    command.Parameters.AddWithValue("@ImagePath", imagePath);
                    command.Parameters.AddWithValue("@ImageType", imageType);

                    int result = command.ExecuteNonQuery();
                    return result == 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occurred while uploading profile picture: " + ex.Message);
                    return false;
                }
            }
        }
        public ProfilePicDTO GetProfilePicByUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.connection))
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT p.image_path, p.image_type 
                FROM ProfilePicture p
                JOIN [User] u ON p.id_user = u.id_user
                WHERE u.Username = @Username";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ProfilePicDTO
                            {
                                Username = username,
                                ImagePath = reader["image_path"].ToString(),
                                ImageType = reader["image_type"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occurred while retrieving profile picture: " + ex.Message);
                    return null;
                }
                return null;
            }
        }
	}
}