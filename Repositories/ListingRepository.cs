using Sayara.Models.Entities;
using Sayara.Data;
using Microsoft.EntityFrameworkCore;

namespace Sayara.Repositories
{
    public class ListingRepository : IListingRepository
    {
        private readonly ApplicationDbContext _context;

        public ListingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Listing> GetByIdAsync(int id)
        {
            return await _context.Listings.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<Listing>> GetAllAsync()
        {
            return await _context.Listings.ToListAsync();
        }

        public async Task<List<SaleListing>> GetAllSaleListingsAsync()
        {
            return await _context.SaleListings.ToListAsync();
        }

        public async Task<List<RentListing>> GetAllRentListingsAsync()
        {
            return await _context.RentListings.ToListAsync();
        }

        public async Task<List<Listing>> GetListingsByUserIdAsync(int userId)
        {
            return await _context.Listings.Where(l => l.UserId == userId).ToListAsync();
        }

        public async Task<Listing> GetListingWithImagesAsync(int id)
        {
            return await _context.Listings
                .Include(l => l.Images)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task AddAsync(Listing listing)
        {
            var listingExists = await _context.Listings.FirstOrDefaultAsync(l => l.Id == listing.Id);
            if (listingExists != null)
            {
                throw new InvalidOperationException($"A listing with Id '{listing.Id}' already exists.");
            }
            await _context.Listings.AddAsync(listing);
        }

        public async Task UpdateAsync(Listing listing)
        {
            var listingExists = await _context.Listings.FirstOrDefaultAsync(l => l.Id == listing.Id);
            if (listingExists == null)
            {
                throw new InvalidOperationException($"A listing with Id '{listing.Id}' doesn't exist.");
            }
            _context.Listings.Update(listing);
        }

        public async Task DeleteAsync(int id)
        {
            var listing = await _context.Listings.FirstOrDefaultAsync(l => l.Id == id);
            if (listing == null)
            {
                throw new InvalidOperationException($"A listing with Id '{id}' doesn't exist.");
            }
            _context.Listings.Remove(listing);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
