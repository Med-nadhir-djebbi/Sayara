using Sayara.Models.Entities;
using Sayara.Models.DTOs;
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

        public async Task<SaleListingDetailDTO> GetSaleListingByIdAsync(int id)
        {
            return await _context.SaleListings
                .Where(l => l.Id == id)
                .Select(l => new SaleListingDetailDTO
                {
                    Id = l.Id,
                    Model = l.Model,
                    Year = l.Year,
                    Mileage = l.Mileage,
                    BrandId = l.BrandId,
                    EngineType = l.EngineType,
                    TransmissionType = l.TransmissionType,
                    FiscalPower = l.FiscalPower,
                    CylinderCapacity = l.CylinderCapacity,
                    Color = l.Color,
                    Description = l.Description,
                    Price = l.Price,
                    CreatedAt = l.CreatedAt,
                    SellerUserId = l.UserId,
                    SellerName = l.User.Name,
                    SellerPhone = l.User.PhoneNumber,
                    SellerRating = l.User.Reviews.Any() ? (decimal?)l.User.Reviews.Average(r => r.Rating) : null
                })
                .FirstOrDefaultAsync();
        }

        public async Task<RentListingDetailDTO> GetRentListingByIdAsync(int id)
        {
            return await _context.RentListings
                .Where(l => l.Id == id)
                .Select(l => new RentListingDetailDTO
                {
                    Id = l.Id,
                    Model = l.Model,
                    Year = l.Year,
                    Mileage = l.Mileage,
                    BrandId = l.BrandId,
                    EngineType = l.EngineType,
                    TransmissionType = l.TransmissionType,
                    FiscalPower = l.FiscalPower,
                    CylinderCapacity = l.CylinderCapacity,
                    Color = l.Color,
                    Description = l.Description,
                    DailyRate = l.DailyRate,
                    WeeklyRate = l.WeeklyRate,
                    MonthlyRate = l.MonthlyRate,
                    CreatedAt = l.CreatedAt,
                    SellerUserId = l.UserId,
                    SellerName = l.User.Name,
                    SellerPhone = l.User.PhoneNumber,
                    SellerRating = l.User.Reviews.Any() ? (decimal?)l.User.Reviews.Average(r => r.Rating) : null
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<Listing>> GetAllAsync()
        {
            return await _context.Listings.ToListAsync();
        }

        public async Task<List<SaleListingCardDTO>> GetAllSaleListingsAsync()
        {
            return await _context.SaleListings
                .Select(l => new SaleListingCardDTO
                {
                    Id = l.Id,
                    Model = l.Model,
                    Year = l.Year,
                    Price = l.Price,
                    SellerName = l.User.Name
                })
                .ToListAsync();
        }

        public async Task<List<RentListingCardDTO>> GetAllRentListingsAsync()
        {
            return await _context.RentListings
                .Select(l => new RentListingCardDTO
                {
                    Id = l.Id,
                    Model = l.Model,
                    Year = l.Year,
                    DailyRate = l.DailyRate,
                    LessorName = l.User.Name
                })
                .ToListAsync();
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

        public async Task<List<SaleListingDetailDTO>> FilterSaleListingsAsync(ListingFilterDTO filterDto)
        {
            var query = _context.SaleListings.AsQueryable();

            if (filterDto.MinPrice > 0 || filterDto.MaxPrice > 0)
            {
                query = query.Where(l => l.Price >= filterDto.MinPrice && l.Price <= filterDto.MaxPrice);
            }

            if (filterDto.MinYear > 0 || filterDto.MaxYear > 0)
            {
                query = query.Where(l => l.Year >= filterDto.MinYear && l.Year <= filterDto.MaxYear);
            }

            if (filterDto.MileageMin > 0 || filterDto.MileageMax > 0)
            {
                query = query.Where(l => l.Mileage >= filterDto.MileageMin && l.Mileage <= filterDto.MileageMax);
            }

            if (filterDto.EngineType != 0)
            {
                query = query.Where(l => l.EngineType == filterDto.EngineType);
            }

            if (filterDto.TransmissionType != 0)
            {
                query = query.Where(l => l.TransmissionType == filterDto.TransmissionType);
            }

            if (filterDto.FiscalPowerMin > 0 || filterDto.FiscalPowerMax > 0)
            {
                query = query.Where(l => l.FiscalPower >= filterDto.FiscalPowerMin && l.FiscalPower <= filterDto.FiscalPowerMax);
            }

            if (filterDto.CylinderCapacityMin > 0 || filterDto.CylinderCapacityMax > 0)
            {
                query = query.Where(l => l.CylinderCapacity >= filterDto.CylinderCapacityMin && l.CylinderCapacity <= filterDto.CylinderCapacityMax);
            }

            if (filterDto.BrandId > 0)
            {
                query = query.Where(l => l.BrandId == filterDto.BrandId);
            }

            if (!string.IsNullOrEmpty(filterDto.Model))
            {
                query = query.Where(l => l.Model.Contains(filterDto.Model));
            }

            return await query.Select(l => new SaleListingDetailDTO
            {
                Id = l.Id,
                Model = l.Model,
                Year = l.Year,
                Mileage = l.Mileage,
                BrandId = l.BrandId,
                EngineType = l.EngineType,
                TransmissionType = l.TransmissionType,
                FiscalPower = l.FiscalPower,
                CylinderCapacity = l.CylinderCapacity,
                Color = l.Color,
                Description = l.Description,
                Price = l.Price,
                CreatedAt = l.CreatedAt,
                SellerUserId = l.UserId,
                SellerName = l.User.Name,
                SellerPhone = l.User.PhoneNumber,
                SellerRating = l.User.Reviews.Any() ? (decimal?)l.User.Reviews.Average(r => r.Rating) : null
            }).ToListAsync();
        }

        public async Task<List<RentListingDetailDTO>> FilterRentListingsAsync(ListingFilterDTO filterDto)
        {
            var query = _context.RentListings.AsQueryable();

            if (filterDto.MinYear > 0 || filterDto.MaxYear > 0)
            {
                query = query.Where(l => l.Year >= filterDto.MinYear && l.Year <= filterDto.MaxYear);
            }

            if (filterDto.Mileage > 0)
            {
                query = query.Where(l => l.Mileage >= filterDto.Mileage);
            }

            if (filterDto.MinDailyRate > 0 || filterDto.MaxDailyRate > 0)
            {
                query = query.Where(l => l.DailyRate >= filterDto.MinDailyRate && l.DailyRate <= filterDto.MaxDailyRate);
            }

            if (filterDto.MinWeeklyRate > 0 || filterDto.MaxWeeklyRate > 0)
            {
                query = query.Where(l => l.WeeklyRate >= filterDto.MinWeeklyRate && l.WeeklyRate <= filterDto.MaxWeeklyRate);
            }

            if (filterDto.MinMonthlyRate > 0 || filterDto.MaxMonthlyRate > 0)
            {
                query = query.Where(l => l.MonthlyRate >= filterDto.MinMonthlyRate && l.MonthlyRate <= filterDto.MaxMonthlyRate);
            }

            if (filterDto.EngineType != 0)
            {
                query = query.Where(l => l.EngineType == filterDto.EngineType);
            }

            if (filterDto.TransmissionType != 0)
            {
                query = query.Where(l => l.TransmissionType == filterDto.TransmissionType);
            }

            if (filterDto.FiscalPowerMin > 0 || filterDto.FiscalPowerMax > 0)
            {
                query = query.Where(l => l.FiscalPower >= filterDto.FiscalPowerMin && l.FiscalPower <= filterDto.FiscalPowerMax);
            }

            if (filterDto.CylinderCapacityMin > 0 || filterDto.CylinderCapacityMax > 0)
            {
                query = query.Where(l => l.CylinderCapacity >= filterDto.CylinderCapacityMin && l.CylinderCapacity <= filterDto.CylinderCapacityMax);
            }

            if (filterDto.BrandId > 0)
            {
                query = query.Where(l => l.BrandId == filterDto.BrandId);
            }

            if (!string.IsNullOrEmpty(filterDto.Model))
            {
                query = query.Where(l => l.Model.Contains(filterDto.Model));
            }

            return await query.Select(l => new RentListingDetailDTO
            {
                Id = l.Id,
                Model = l.Model,
                Year = l.Year,
                Mileage = l.Mileage,
                BrandId = l.BrandId,
                EngineType = l.EngineType,
                TransmissionType = l.TransmissionType,
                FiscalPower = l.FiscalPower,
                CylinderCapacity = l.CylinderCapacity,
                Color = l.Color,
                Description = l.Description,
                DailyRate = l.DailyRate,
                WeeklyRate = l.WeeklyRate,
                MonthlyRate = l.MonthlyRate,
                CreatedAt = l.CreatedAt,
                SellerUserId = l.UserId,
                SellerName = l.User.Name,
                SellerPhone = l.User.PhoneNumber,
                SellerRating = l.User.Reviews.Any() ? (decimal?)l.User.Reviews.Average(r => r.Rating) : null
            }).ToListAsync();
        }
    }
}
