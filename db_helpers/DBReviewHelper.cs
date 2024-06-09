using entity_classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_helpers
{
    public class DBReviewHelper : DBConnection, IDBReviewHelper
    {
        public void InsertReview(Review review, int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();

                    string query = @"
                        INSERT INTO Review (id_recipe, id_web_user, rating_value, review_text)
                        VALUES (@recipeId, @userId, @ratingValue, @reviewText)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@recipeId", review.GetRecipe().GetIdRecipe());
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@ratingValue", review.GetRatingValue());
                    cmd.Parameters.AddWithValue("@reviewText", (object)review.GetReviewText() ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting review: " + ex.Message);
                throw new Exception("Unable to insert review. Please try again later.", ex);
            }
        }

        public List<Review> GetReviewsByRecipeId(int recipeId)
        {
            var reviews = new List<Review>();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();

                    string query = @"
                SELECT r.id_review, r.rating_value, r.review_text, u.id_user, u.username, u.email, u.password, wu.caption
                FROM Review r
                INNER JOIN WebUser wu ON r.id_web_user = wu.id_user
                INNER JOIN [User] u ON wu.id_user = u.id_user
                WHERE r.id_recipe = @recipeId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@recipeId", recipeId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new WebUser(
                                (int)reader["id_user"],
                                reader["username"].ToString(),
                                reader["email"].ToString(),
                                reader["password"].ToString(),
                                reader["caption"].ToString()
                            );

                            var review = new Review(
                                (int)reader["id_review"],
                                null, // Recipe object should be set appropriately
                                (decimal)reader["rating_value"],
                                reader["review_text"] != DBNull.Value ? reader["review_text"].ToString() : null
                            );
                            review.SetUser(user);
                            reviews.Add(review);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching reviews: " + ex.Message);
                throw new Exception("Unable to fetch reviews. Please try again later.", ex);
            }

            return reviews;
        }
    }
}
