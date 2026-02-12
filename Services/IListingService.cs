using Sayara.Models.DTOs;

namespace Sayara.Services
{
    public interface IListingService
    {
        Task<SaleListingDetailDTO?> GetSaleListingAsync(int id);
        Task<RentListingDetailDTO?> GetRentListingAsync(int id);
        Task<List<SaleListingCardDTO>> GetAllSaleListingsAsync();
        Task<List<RentListingCardDTO>> GetAllRentListingsAsync();
        Task<List<SaleListingDetailDTO>> FilterSaleListingsAsync(ListingFilterDTO filterDto);
        Task<List<RentListingDetailDTO>> FilterRentListingsAsync(ListingFilterDTO filterDto);
        Task<int> CreateSaleListingAsync(CreateSaleListingDTO createDto, int userId, IFormFileCollection photos);
        Task<int> CreateRentListingAsync(CreateRentListingDTO createDto, int userId, IFormFileCollection photos);
        Task<bool> UpdateSaleListingAsync(int id, CreateSaleListingDTO updateDto, int userId);
        Task<bool> UpdateRentListingAsync(int id, CreateRentListingDTO updateDto, int userId);
        Task<bool> DeleteListingAsync(int id, int userId);
    }
}
