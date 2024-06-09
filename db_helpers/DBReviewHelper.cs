using entity_classes;
using System.Data.SqlClient;

namespace db_helpers
{
    public class DBReviewHelper : DBConnection, IDBReviewHelper
    {
        private IDBRecipeHelper recipeHelper;
        public DBReviewHelper(IDBRecipeHelper recipeHelper)
        {
            this.recipeHelper = recipeHelper;
        }

        public void InsertReview(Review review)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO Review (id_recipe, id_web_user, rating_value, review_text)
                        VALUES (@idRecipe, @idWebUser, @ratingValue, @reviewText)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idRecipe", review.GetRecipe().GetIdRecipe());
                    cmd.Parameters.AddWithValue("@idWebUser", review.GetUser().GetIdUser());
                    cmd.Parameters.AddWithValue("@ratingValue", review.GetRatingValue());
                    cmd.Parameters.AddWithValue("@reviewText", review.GetReviewText());

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
            List<Review> reviews = new List<Review>();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connection))
                {
                    conn.Open();
                    string query = @"
                SELECT r.id_review, r.rating_value, r.review_text, wu.id_user, u.username, u.email, u.password, wu.caption
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
                            int idReview = (int)reader["id_review"];
                            decimal ratingValue = (decimal)reader["rating_value"];
                            string reviewText = reader["review_text"].ToString();

                            WebUser user = new WebUser(
                                (int)reader["id_user"],
                                reader["username"].ToString(),
                                reader["email"].ToString(),
                                reader["password"].ToString(),
                                reader["caption"].ToString()
                            );

                            // Assuming you have a method to get the recipe by its ID
                            Recipe recipe = recipeHelper.GetRecipeById(recipeId);

                            Review review = new Review(idReview, recipe, ratingValue, reviewText);
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
