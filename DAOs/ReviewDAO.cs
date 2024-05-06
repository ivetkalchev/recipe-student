using DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class ReviewDAO
    {
        private string connectionString;

        public ReviewDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddReview(ReviewDTO review)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Reviews (IdRecipe, IdUser, ReviewText, RatingValue, PublishDate) VALUES (@IdRecipe, @IdUser, @ReviewText, @RatingValue, @PublishDate)", connection);
                command.Parameters.AddWithValue("@IdRecipe", review.IdRecipe);
                command.Parameters.AddWithValue("@IdUser", review.IdUser);
                command.Parameters.AddWithValue("@ReviewText", review.ReviewText);
                command.Parameters.AddWithValue("@RatingValue", review.RatingValue);
                command.Parameters.AddWithValue("@PublishDate", review.PublishDate);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateReview(ReviewDTO review)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Reviews SET ReviewText = @ReviewText, RatingValue = @RatingValue, PublishDate = @PublishDate WHERE IdReview = @IdReview", connection);
                command.Parameters.AddWithValue("@IdReview", review.IdReview);
                command.Parameters.AddWithValue("@ReviewText", review.ReviewText);
                command.Parameters.AddWithValue("@RatingValue", review.RatingValue);
                command.Parameters.AddWithValue("@PublishDate", review.PublishDate);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteReview(int idReview)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Reviews WHERE IdReview = @IdReview", connection);
                command.Parameters.AddWithValue("@IdReview", idReview);
                command.ExecuteNonQuery();
            }
        }

        public ReviewDTO GetReviewById(int idReview)
        {
            ReviewDTO review = null;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT IdReview, IdRecipe, IdUser, ReviewText, RatingValue, PublishDate FROM Reviews WHERE IdReview = @IdReview", connection);
                command.Parameters.AddWithValue("@IdReview", idReview);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        review = new ReviewDTO
                        {
                            IdReview = reader.GetInt32(reader.GetOrdinal("IdReview")),
                            IdRecipe = reader.GetInt32(reader.GetOrdinal("IdRecipe")),
                            IdUser = reader.GetInt32(reader.GetOrdinal("IdUser")),
                            ReviewText = reader.GetString(reader.GetOrdinal("ReviewText")),
                            RatingValue = reader.GetDecimal(reader.GetOrdinal("RatingValue")),
                            PublishDate = reader.GetDateTime(reader.GetOrdinal("PublishDate"))
                        };
                    }
                }
            }
            return review;
        }
    }
}
