using Sayara.Models.Entities;

namespace Sayara.Repositories
{interface IListingRepository
{
    Task<Listing> GetByIdAsync(int id);
    Task<List<Listing>> GetAllAsync();
    Task<List<SaleListing>> GetAllSaleListingsAsync();
    Task<List<RentListing>> GetAllRentListingsAsync();
    Task<List<Listing>> GetListingsByUserIdAsync(int userId);
    Task<Listing> GetListingWithImagesAsync(int id);
    Task AddAsync(Listing listing);
    Task UpdateAsync(Listing listing);
    Task DeleteAsync(int id);
    Task SaveChangesAsync();
}
}