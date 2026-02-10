using System.ComponentModel.DataAnnotations;

namespace Sayara.Models.DTOs
{
    public class CreateReviewDTO
    {
        [Required(ErrorMessage = "Reviewee ID is required")]
        public int RevieweeId { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Comment is required")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Comment must be between 10 and 1000 characters")]
        public string Comment { get; set; }
    }

    public class ReviewDTO
    {
        public int Id { get; set; }

        [Required]
        public int ReviewerId { get; set; }

        public string ReviewerName { get; set; }

        [Required]
        public int RevieweeId { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Comment must be between 10 and 1000 characters")]
        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
