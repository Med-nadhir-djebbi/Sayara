using Sayara.Models.DTOs;
using Sayara.Repositories;

namespace Sayara.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly ILogger<ReviewService> _logger;

        public ReviewService(IReviewRepository reviewRepository, ILogger<ReviewService> logger)
        {
            _reviewRepository = reviewRepository;
            _logger = logger;
        }
        public async Task<ReviewDTO> GetReviewAsync(int id)
        {
            try
            {
                var review = await _reviewRepository.GetByIdAsync(id);
                if(review == null)
                {
                    _logger.LogWarning("Review with ID {ReviewId} not found", id);
                    return null;
                }
                return new ReviewDTO
                {
                    Id = review.Id,
                    ReviewerId = review.ReviewerId,
                    ReviewerName = review.Reviewer?.Name,
                    RevieweeId = review.RevieweeId,
                    Rating = review.Rating,
                    Comment = review.Comment,
                    CreatedAt = review.CreatedAt
                };
            }
            catch(Exception ex)
            {
                
            }
        }

    }

}
