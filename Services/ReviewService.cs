using Sayara.Models.DTOs;
using Sayara.Models.Entities;
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
                if (review == null)
                {
                    _logger.LogWarning("Review with ID {Id} not found.", id);
                    return null!;
                }
                return MapToDto(review);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving review with ID {Id}.", id);
                throw;
            }
        }

        public async Task<List<ReviewDTO>> GetReviewsByListingAsync(int listingId)
        {
            try
            {
                var reviews = await _reviewRepository.GetReviewsForUserAsync(listingId);
                return reviews.Select(MapToDto).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving reviews for listing {ListingId}.", listingId);
                throw;
            }
        }

        public async Task<List<ReviewDTO>> GetReviewsByUserAsync(int userId)
        {
            try
            {
                var reviews = await _reviewRepository.GetReviewsByUserAsync(userId);
                return reviews.Select(MapToDto).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving reviews by user {UserId}.", userId);
                throw;
            }
        }

        public async Task<int> CreateReviewAsync(ReviewDTO reviewDto)
        {
            try
            {
                var review = MapToEntity(reviewDto);
                review.CreatedAt = DateTime.UtcNow;

                await _reviewRepository.AddAsync(review);
                await _reviewRepository.SaveChangesAsync();

                _logger.LogInformation("Review created successfully with ID {Id}.", review.Id);
                return review.Id;
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Invalid operation while creating review.");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating review.");
                throw;
            }
        }

        public async Task<bool> UpdateReviewAsync(int id, ReviewDTO reviewDto)
        {
            try
            {
                var existingReview = await _reviewRepository.GetByIdAsync(id);
                if (existingReview == null)
                {
                    _logger.LogWarning("Review with ID {Id} not found for update.", id);
                    return false;
                }

                existingReview.Rating = reviewDto.Rating;
                existingReview.Comment = reviewDto.Comment;

                await _reviewRepository.UpdateAsync(existingReview);
                await _reviewRepository.SaveChangesAsync();

                _logger.LogInformation("Review with ID {Id} updated successfully.", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating review with ID {Id}.", id);
                throw;
            }
        }

        public async Task<bool> DeleteReviewAsync(int id)
        {
            try
            {
                var existingReview = await _reviewRepository.GetByIdAsync(id);
                if (existingReview == null)
                {
                    _logger.LogWarning("Review with ID {Id} not found for deletion.", id);
                    return false;
                }

                await _reviewRepository.DeleteAsync(id);
                await _reviewRepository.SaveChangesAsync();

                _logger.LogInformation("Review with ID {Id} deleted successfully.", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting review with ID {Id}.", id);
                throw;
            }
        }

        public async Task<decimal> GetAverageRatingAsync(int listingId)
        {
            try
            {
                var reviews = await _reviewRepository.GetReviewsForUserAsync(listingId);
                if (reviews == null || reviews.Count == 0)
                {
                    _logger.LogInformation("No reviews found for listing {ListingId}. Returning 0.", listingId);
                    return 0;
                }
                return (decimal)reviews.Average(r => r.Rating);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating average rating for listing {ListingId}.", listingId);
                throw;
            }
        }

        private static ReviewDTO MapToDto(Review review)
        {
            return new ReviewDTO
            {
                Id = review.Id,
                ReviewerId = review.ReviewerId,
                RevieweeId = review.RevieweeId,
                Rating = review.Rating,
                Comment = review.Comment,
                CreatedAt = review.CreatedAt,
                ReviewerName = null // This needs to be populated if navigation property exists
            };
        }

        private static Review MapToEntity(ReviewDTO dto)
        {
            return new Review
            {
                Id = dto.Id,
                ReviewerId = dto.ReviewerId,
                RevieweeId = dto.RevieweeId,
                Rating = dto.Rating,
                Comment = dto.Comment
            };
        }
    }
}
