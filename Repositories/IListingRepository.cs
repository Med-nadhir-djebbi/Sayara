using Sayara.Models.Entities;
using Sayara.Models.DTOs;

namespace Sayara.Repositories
{
    public interface IListingRepository
    {
        Task<Listing> GetByIdAsync(int id);
        Task<SaleListingDetailDTO> GetSaleListingByIdAsync(int id);
        Task<RentListingDetailDTO> GetRentListingByIdAsync(int id);
        Task<List<Listing>> GetAllAsync();
        Task<List<SaleListingCardDTO>> GetAllSaleListingsAsync();
        Task<List<RentListingCardDTO>> GetAllRentListingsAsync();
        Task<List<SaleListingDetailDTO>> FilterSaleListingsAsync(ListingFilterDTO filterDto);
        Task<List<RentListingDetailDTO>> FilterRentListingsAsync(ListingFilterDTO filterDto);
        Task<List<Listing>> GetListingsByUserIdAsync(int userId);
        Task<Listing> GetListingWithImagesAsync(int id);
        Task AddAsync(Listing listing);
        Task UpdateAsync(Listing listing);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}