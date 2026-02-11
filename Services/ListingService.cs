using Sayara.Models.DTOs;
using Sayara.Models.Entities;
using Sayara.Repositories;

namespace Sayara.Services
{
    public class ListingService : IListingService
    {
        private readonly IListingRepository _listingRepository;
        private readonly ILogger<ListingService> _logger;

        public ListingService(IListingRepository listingRepository, ILogger<ListingService> logger)
        {
            _listingRepository = listingRepository;
            _logger = logger;
        }

        public async Task<SaleListingDetailDTO> GetSaleListingAsync(int id)
        {
            var listing = await _listingRepository.GetSaleListingByIdAsync(id);
            if (listing == null)
            {
                _logger.LogWarning("Sale listing with ID {Id} not found", id);
                return null;
            }
            return listing;
        }
        public async Task<RentListingDetailDTO> GetRentListingAsync(int id)
        {
            var listing = await _listingRepository.GetRentListingByIdAsync(id);
            if (listing == null)
            {
                _logger.LogWarning("Rent listing with ID {Id} not found", id);
                return null;
            }
            return listing;
        }
        public async Task<List<SaleListingCardDTO>> GetAllSaleListingsAsync()
        {
            var listings = await _listingRepository.GetAllSaleListingsAsync();
            return listings;
        }
        public async Task<List<RentListingCardDTO>> GetAllRentListingsAsync()
        {
            var listings = await _listingRepository.GetAllRentListingsAsync();
            return listings;
        }

        public async Task<List<SaleListingDetailDTO>> FilterSaleListingsAsync(ListingFilterDTO filterDto)
        {
            var listings = await _listingRepository.FilterSaleListingsAsync(filterDto);
            return listings;
        }

        public async Task<List<RentListingDetailDTO>> FilterRentListingsAsync(ListingFilterDTO filterDto)
        {
            var listings = await _listingRepository.FilterRentListingsAsync(filterDto);
            return listings;
        }

        public async Task<int> CreateSaleListingAsync(CreateSaleListingDTO createDto, int userId)
        {
            var saleListing = new SaleListing
            {
                Model = createDto.Model,
                Year = createDto.Year,
                Mileage = createDto.Mileage,
                EngineType = createDto.EngineType,
                TransmissionType = createDto.TransmissionType,
                FiscalPower = createDto.FiscalPower,
                CylinderCapacity = createDto.CylinderCapacity,
                Color = createDto.Color,
                Description = createDto.Description,
                Price = createDto.Price,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };

            await _listingRepository.AddAsync(saleListing);
            await _listingRepository.SaveChangesAsync();
            _logger.LogInformation("Sale listing created with ID {Id}", saleListing.Id);
            return saleListing.Id;
        }

        public async Task<int> CreateRentListingAsync(CreateRentListingDTO createDto, int userId)
        {
            var rentListing = new RentListing
            {
                Model = createDto.Model,
                Year = createDto.Year,
                Mileage = createDto.Mileage,
                EngineType = createDto.EngineType,
                TransmissionType = createDto.TransmissionType,
                FiscalPower = createDto.FiscalPower,
                CylinderCapacity = createDto.CylinderCapacity,
                Color = createDto.Color,
                Description = createDto.Description,
                DailyRate = createDto.DailyRate,
                WeeklyRate = createDto.WeeklyRate,
                MonthlyRate = createDto.MonthlyRate,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };

            await _listingRepository.AddAsync(rentListing);
            await _listingRepository.SaveChangesAsync();
            _logger.LogInformation("Rent listing created with ID {Id}", rentListing.Id);
            return rentListing.Id;
        }

        public async Task<bool> UpdateSaleListingAsync(int id, CreateSaleListingDTO updateDto)
        {
            var listing = await _listingRepository.GetByIdAsync(id);
            if (listing == null || listing is not SaleListing)
            {
                _logger.LogWarning("Sale listing with ID {Id} not found", id);
                return false;
            }

            var saleListing = (SaleListing)listing;
            saleListing.Model = updateDto.Model;
            saleListing.Year = updateDto.Year;
            saleListing.Mileage = updateDto.Mileage;
            saleListing.EngineType = updateDto.EngineType;
            saleListing.TransmissionType = updateDto.TransmissionType;
            saleListing.FiscalPower = updateDto.FiscalPower;
            saleListing.CylinderCapacity = updateDto.CylinderCapacity;
            saleListing.Color = updateDto.Color;
            saleListing.Description = updateDto.Description;
            saleListing.Price = updateDto.Price;

            await _listingRepository.UpdateAsync(saleListing);
            await _listingRepository.SaveChangesAsync();
            _logger.LogInformation("Sale listing with ID {Id} updated", id);
            return true;
        }

        public async Task<bool> UpdateRentListingAsync(int id, CreateRentListingDTO updateDto)
        {
            var listing = await _listingRepository.GetByIdAsync(id);
            if (listing == null || listing is not RentListing)
            {
                _logger.LogWarning("Rent listing with ID {Id} not found", id);
                return false;
            }

            var rentListing = (RentListing)listing;
            rentListing.Model = updateDto.Model;
            rentListing.Year = updateDto.Year;
            rentListing.Mileage = updateDto.Mileage;
            rentListing.EngineType = updateDto.EngineType;
            rentListing.TransmissionType = updateDto.TransmissionType;
            rentListing.FiscalPower = updateDto.FiscalPower;
            rentListing.CylinderCapacity = updateDto.CylinderCapacity;
            rentListing.Color = updateDto.Color;
            rentListing.Description = updateDto.Description;
            rentListing.DailyRate = updateDto.DailyRate;
            rentListing.WeeklyRate = updateDto.WeeklyRate;
            rentListing.MonthlyRate = updateDto.MonthlyRate;

            await _listingRepository.UpdateAsync(rentListing);
            await _listingRepository.SaveChangesAsync();
            _logger.LogInformation("Rent listing with ID {Id} updated", id);
            return true;
        }

        public async Task<bool> DeleteListingAsync(int id)
        {
            var listing = await _listingRepository.GetByIdAsync(id);
            if (listing == null)
            {
                _logger.LogWarning("Listing with ID {Id} not found", id);
                return false;
            }

            await _listingRepository.DeleteAsync(id);
            await _listingRepository.SaveChangesAsync();
            _logger.LogInformation("Listing with ID {Id} deleted", id);
            return true;
        }
        
        
    }
}
