using System.ComponentModel.DataAnnotations;

namespace recipe_web.DTOs
{
    public class ReviewDTO
    {
        [Range(0, 5)]
        public decimal RatingValue { get; set; }

        [StringLength(200)]
        [Required]
        public string ReviewText { get; set; }
    }
}
