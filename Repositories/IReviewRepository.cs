using Sayara.Models.Entities;

namespace Sayara.Repositories
{
    public interface IReviewRepository
    {
        Task<Review> GetByIdAsync(int id);
        Task<List<Review>> GetAllAsync();
        Task<List<Review>> GetReviewsForUserAsync(int revieweeId);
        Task<List<Review>> GetReviewsByUserAsync(int reviewerId);
        Task AddAsync(Review review);
        Task UpdateAsync(Review review);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
