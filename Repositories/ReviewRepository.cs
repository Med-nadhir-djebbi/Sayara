using Sayara.Models.Entities;
using Sayara.Data;
using Microsoft.EntityFrameworkCore;

namespace Sayara.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            return await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Review>> GetAllAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<List<Review>> GetReviewsForUserAsync(int revieweeId)
        {
            return await _context.Reviews.Where(r => r.RevieweeId == revieweeId).ToListAsync();
        }

        public async Task<List<Review>> GetReviewsByUserAsync(int reviewerId)
        {
            return await _context.Reviews.Where(r => r.ReviewerId == reviewerId).ToListAsync();
        }

        public async Task AddAsync(Review review)
        {
            if (review.ReviewerId == review.RevieweeId)
            {
                throw new InvalidOperationException("A user cannot review themselves.");
            }
            await _context.Reviews.AddAsync(review);
        }

        public async Task UpdateAsync(Review review)
        {
            var reviewExists = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == review.Id);
            if (reviewExists == null)
            {
                throw new InvalidOperationException($"A review with Id '{review.Id}' doesn't exist.");
            }
            _context.Reviews.Update(review);
        }

        public async Task DeleteAsync(int id)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
            if (review == null)
            {
                throw new InvalidOperationException($"A review with Id '{id}' doesn't exist.");
            }
            _context.Reviews.Remove(review);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
