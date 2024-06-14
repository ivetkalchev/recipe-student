using System.ComponentModel.DataAnnotations;

namespace recipe_web.DTOs
{
    public class ReviewDTO
    {
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public decimal RatingValue { get; set; } = 1;

        [StringLength(200, ErrorMessage = "Review text cannot be longer than 200 characters.")]
        [Required(ErrorMessage = "Review text is required.")]
        public string ReviewText { get; set; } = string.Empty;
    }
}
