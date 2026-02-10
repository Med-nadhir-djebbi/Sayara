using Sayara.Models.DTOs;

namespace Sayara.Services
{
    public interface IReviewService
    {
        Task<ReviewDTO> GetReviewAsync(int id);
        Task<List<ReviewDTO>> GetReviewsByListingAsync(int listingId);
        Task<List<ReviewDTO>> GetReviewsByUserAsync(int userId);
        Task<int> CreateReviewAsync(ReviewDTO reviewDto);
        Task<bool> UpdateReviewAsync(int id, ReviewDTO reviewDto);
        Task<bool> DeleteReviewAsync(int id);
        Task<decimal> GetAverageRatingAsync(int listingId);
    }
}
