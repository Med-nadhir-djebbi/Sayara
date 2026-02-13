using Sayara.Models.Entities;
using Sayara.Models.DTOs;
using Sayara.Data;
using Microsoft.EntityFrameworkCore;

namespace Sayara.Repositories
{
    public class ListingRepository : IListingRepository
    {
        private readonly ApplicationDbContext _context;
        private static readonly Dictionary<int, string> Brands = new()
        {
            { 1, "Audi" }, { 2, "BMW" }, { 3, "Mercedes" }, { 4, "Porsche" }, { 5, "Volkswagen" },
            { 6, "Toyota" }, { 7, "Ford" }, { 8, "Renault" }, { 9, "Peugeot" }, { 10, "Citroen" },
            { 11, "Fiat" }, { 12, "Hyundai" }, { 13, "Kia" }, { 14, "Nissan" }, { 15, "Honda" },
            { 16, "Mazda" }, { 17, "Mitsubishi" }, { 18, "Suzuki" }, { 19, "Tesla" }, { 20, "Volvo" },
            { 21, "Land Rover" }, { 22, "Jaguar" }, { 23, "Ferrari" }, { 24, "Lamborghini" }, { 25, "Maserati" },
            { 26, "Aston Martin" }, { 27, "Bentley" }, { 28, "Rolls-Royce" }, { 29, "Alfa Romeo" }, { 30, "Lexus" },
            { 31, "Jeep" }, { 32, "Chevrolet" }, { 33, "Dodge" }, { 34, "Chrysler" }, { 35, "Cadillac" },
            { 36, "GMC" }, { 37, "RAM" }, { 38, "Subaru" }, { 39, "Isuzu" }, { 40, "Infiniti" },
            { 41, "Acura" }, { 42, "Genesis" }, { 43, "Cupra" }, { 44, "Seat" }, { 45, "Skoda" },
            { 46, "Mini" }, { 47, "Smart" }, { 48, "Dacia" }, { 49, "Lada" }, { 50, "MG" }
        };

        private static string GetBrandName(int id) => Brands.TryGetValue(id, out var name) ? name : "Unknown";

        public ListingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Listing?> GetByIdAsync(int id)
        {
            return await _context.Listings.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<SaleListingDetailDTO?> GetSaleListingByIdAsync(int id)
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
                    BrandName = l.BrandId == 1 ? "Audi" : l.BrandId == 2 ? "BMW" : l.BrandId == 3 ? "Mercedes" : l.BrandId == 4 ? "Porsche" : l.BrandId == 5 ? "Volkswagen" : l.BrandId == 6 ? "Toyota" : l.BrandId == 7 ? "Ford" : l.BrandId == 8 ? "Renault" : l.BrandId == 9 ? "Peugeot" : l.BrandId == 10 ? "Citroen" : l.BrandId == 11 ? "Fiat" : l.BrandId == 12 ? "Hyundai" : l.BrandId == 13 ? "Kia" : l.BrandId == 14 ? "Nissan" : l.BrandId == 15 ? "Honda" : l.BrandId == 16 ? "Mazda" : l.BrandId == 17 ? "Mitsubishi" : l.BrandId == 18 ? "Suzuki" : l.BrandId == 19 ? "Tesla" : l.BrandId == 20 ? "Volvo" : l.BrandId == 21 ? "Land Rover" : l.BrandId == 22 ? "Jaguar" : l.BrandId == 23 ? "Ferrari" : l.BrandId == 24 ? "Lamborghini" : l.BrandId == 25 ? "Maserati" : l.BrandId == 26 ? "Aston Martin" : l.BrandId == 27 ? "Bentley" : l.BrandId == 28 ? "Rolls-Royce" : l.BrandId == 29 ? "Alfa Romeo" : l.BrandId == 30 ? "Lexus" : l.BrandId == 31 ? "Jeep" : l.BrandId == 32 ? "Chevrolet" : l.BrandId == 33 ? "Dodge" : l.BrandId == 34 ? "Chrysler" : l.BrandId == 35 ? "Cadillac" : l.BrandId == 36 ? "GMC" : l.BrandId == 37 ? "RAM" : l.BrandId == 38 ? "Subaru" : l.BrandId == 39 ? "Isuzu" : l.BrandId == 40 ? "Infiniti" : l.BrandId == 41 ? "Acura" : l.BrandId == 42 ? "Genesis" : l.BrandId == 43 ? "Cupra" : l.BrandId == 44 ? "Seat" : l.BrandId == 45 ? "Skoda" : l.BrandId == 46 ? "Mini" : l.BrandId == 47 ? "Smart" : l.BrandId == 48 ? "Dacia" : l.BrandId == 49 ? "Lada" : l.BrandId == 50 ? "MG" : "Unknown",
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
                    SellerRating = l.User.Reviews.Any() ? (decimal?)l.User.Reviews.Average(r => r.Rating) : null,
                    ImageUrls = l.Images.Select(i => i.ImageUrl).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<RentListingDetailDTO?> GetRentListingByIdAsync(int id)
        {
            return await _context.RentListings
                .Where(l => l.Id == id)
                .Select(l => new RentListingDetailDTO
                {
                    Id = l.Id,
                    BrandName = l.BrandId == 1 ? "Audi" : l.BrandId == 2 ? "BMW" : l.BrandId == 3 ? "Mercedes" : l.BrandId == 4 ? "Porsche" : l.BrandId == 5 ? "Volkswagen" : l.BrandId == 6 ? "Toyota" : l.BrandId == 7 ? "Ford" : l.BrandId == 8 ? "Renault" : l.BrandId == 9 ? "Peugeot" : l.BrandId == 10 ? "Citroen" : l.BrandId == 11 ? "Fiat" : l.BrandId == 12 ? "Hyundai" : l.BrandId == 13 ? "Kia" : l.BrandId == 14 ? "Nissan" : l.BrandId == 15 ? "Honda" : l.BrandId == 16 ? "Mazda" : l.BrandId == 17 ? "Mitsubishi" : l.BrandId == 18 ? "Suzuki" : l.BrandId == 19 ? "Tesla" : l.BrandId == 20 ? "Volvo" : l.BrandId == 21 ? "Land Rover" : l.BrandId == 22 ? "Jaguar" : l.BrandId == 23 ? "Ferrari" : l.BrandId == 24 ? "Lamborghini" : l.BrandId == 25 ? "Maserati" : l.BrandId == 26 ? "Aston Martin" : l.BrandId == 27 ? "Bentley" : l.BrandId == 28 ? "Rolls-Royce" : l.BrandId == 29 ? "Alfa Romeo" : l.BrandId == 30 ? "Lexus" : l.BrandId == 31 ? "Jeep" : l.BrandId == 32 ? "Chevrolet" : l.BrandId == 33 ? "Dodge" : l.BrandId == 34 ? "Chrysler" : l.BrandId == 35 ? "Cadillac" : l.BrandId == 36 ? "GMC" : l.BrandId == 37 ? "RAM" : l.BrandId == 38 ? "Subaru" : l.BrandId == 39 ? "Isuzu" : l.BrandId == 40 ? "Infiniti" : l.BrandId == 41 ? "Acura" : l.BrandId == 42 ? "Genesis" : l.BrandId == 43 ? "Cupra" : l.BrandId == 44 ? "Seat" : l.BrandId == 45 ? "Skoda" : l.BrandId == 46 ? "Mini" : l.BrandId == 47 ? "Smart" : l.BrandId == 48 ? "Dacia" : l.BrandId == 49 ? "Lada" : l.BrandId == 50 ? "MG" : "Unknown",
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
                    SellerRating = l.User.Reviews.Any() ? (decimal?)l.User.Reviews.Average(r => r.Rating) : null,
                    ImageUrls = l.Images.Select(i => i.ImageUrl).ToList()
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
                    BrandName = l.BrandId == 1 ? "Audi" : l.BrandId == 2 ? "BMW" : l.BrandId == 3 ? "Mercedes" : l.BrandId == 4 ? "Porsche" : l.BrandId == 5 ? "Volkswagen" : l.BrandId == 6 ? "Toyota" : l.BrandId == 7 ? "Ford" : l.BrandId == 8 ? "Renault" : l.BrandId == 9 ? "Peugeot" : l.BrandId == 10 ? "Citroen" : l.BrandId == 11 ? "Fiat" : l.BrandId == 12 ? "Hyundai" : l.BrandId == 13 ? "Kia" : l.BrandId == 14 ? "Nissan" : l.BrandId == 15 ? "Honda" : l.BrandId == 16 ? "Mazda" : l.BrandId == 17 ? "Mitsubishi" : l.BrandId == 18 ? "Suzuki" : l.BrandId == 19 ? "Tesla" : l.BrandId == 20 ? "Volvo" : l.BrandId == 21 ? "Land Rover" : l.BrandId == 22 ? "Jaguar" : l.BrandId == 23 ? "Ferrari" : l.BrandId == 24 ? "Lamborghini" : l.BrandId == 25 ? "Maserati" : l.BrandId == 26 ? "Aston Martin" : l.BrandId == 27 ? "Bentley" : l.BrandId == 28 ? "Rolls-Royce" : l.BrandId == 29 ? "Alfa Romeo" : l.BrandId == 30 ? "Lexus" : l.BrandId == 31 ? "Jeep" : l.BrandId == 32 ? "Chevrolet" : l.BrandId == 33 ? "Dodge" : l.BrandId == 34 ? "Chrysler" : l.BrandId == 35 ? "Cadillac" : l.BrandId == 36 ? "GMC" : l.BrandId == 37 ? "RAM" : l.BrandId == 38 ? "Subaru" : l.BrandId == 39 ? "Isuzu" : l.BrandId == 40 ? "Infiniti" : l.BrandId == 41 ? "Acura" : l.BrandId == 42 ? "Genesis" : l.BrandId == 43 ? "Cupra" : l.BrandId == 44 ? "Seat" : l.BrandId == 45 ? "Skoda" : l.BrandId == 46 ? "Mini" : l.BrandId == 47 ? "Smart" : l.BrandId == 48 ? "Dacia" : l.BrandId == 49 ? "Lada" : l.BrandId == 50 ? "MG" : "Unknown",
                    Model = l.Model,
                    Year = l.Year,
                    Price = l.Price,
                    SellerName = l.User.Name,
                    ImageUrls = l.Images.Select(i => i.ImageUrl).ToList()
                })
                .ToListAsync();
        }

        public async Task<List<RentListingCardDTO>> GetAllRentListingsAsync()
        {
            return await _context.RentListings
                .Select(l => new RentListingCardDTO
                {
                    Id = l.Id,
                    BrandName = l.BrandId == 1 ? "Audi" : l.BrandId == 2 ? "BMW" : l.BrandId == 3 ? "Mercedes" : l.BrandId == 4 ? "Porsche" : l.BrandId == 5 ? "Volkswagen" : l.BrandId == 6 ? "Toyota" : l.BrandId == 7 ? "Ford" : l.BrandId == 8 ? "Renault" : l.BrandId == 9 ? "Peugeot" : l.BrandId == 10 ? "Citroen" : l.BrandId == 11 ? "Fiat" : l.BrandId == 12 ? "Hyundai" : l.BrandId == 13 ? "Kia" : l.BrandId == 14 ? "Nissan" : l.BrandId == 15 ? "Honda" : l.BrandId == 16 ? "Mazda" : l.BrandId == 17 ? "Mitsubishi" : l.BrandId == 18 ? "Suzuki" : l.BrandId == 19 ? "Tesla" : l.BrandId == 20 ? "Volvo" : l.BrandId == 21 ? "Land Rover" : l.BrandId == 22 ? "Jaguar" : l.BrandId == 23 ? "Ferrari" : l.BrandId == 24 ? "Lamborghini" : l.BrandId == 25 ? "Maserati" : l.BrandId == 26 ? "Aston Martin" : l.BrandId == 27 ? "Bentley" : l.BrandId == 28 ? "Rolls-Royce" : l.BrandId == 29 ? "Alfa Romeo" : l.BrandId == 30 ? "Lexus" : l.BrandId == 31 ? "Jeep" : l.BrandId == 32 ? "Chevrolet" : l.BrandId == 33 ? "Dodge" : l.BrandId == 34 ? "Chrysler" : l.BrandId == 35 ? "Cadillac" : l.BrandId == 36 ? "GMC" : l.BrandId == 37 ? "RAM" : l.BrandId == 38 ? "Subaru" : l.BrandId == 39 ? "Isuzu" : l.BrandId == 40 ? "Infiniti" : l.BrandId == 41 ? "Acura" : l.BrandId == 42 ? "Genesis" : l.BrandId == 43 ? "Cupra" : l.BrandId == 44 ? "Seat" : l.BrandId == 45 ? "Skoda" : l.BrandId == 46 ? "Mini" : l.BrandId == 47 ? "Smart" : l.BrandId == 48 ? "Dacia" : l.BrandId == 49 ? "Lada" : l.BrandId == 50 ? "MG" : "Unknown",
                    Model = l.Model,
                    Year = l.Year,
                    DailyRate = l.DailyRate,
                    LessorName = l.User.Name,
                    ImageUrls = l.Images.Select(i => i.ImageUrl).ToList()
                })
                .ToListAsync();
        }

        public async Task<List<Listing>> GetListingsByUserIdAsync(int userId)
        {
            return await _context.Listings.Where(l => l.UserId == userId).ToListAsync();
        }

        public async Task<Listing?> GetListingWithImagesAsync(int id)
        {
            return await _context.Listings
                .Include(l => l.Images)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task AddAsync(Listing listing)
        {
            if (listing.Id != 0)
            {
                var listingExists = await _context.Listings.FirstOrDefaultAsync(l => l.Id == listing.Id);
                if (listingExists != null)
                {
                    throw new InvalidOperationException($"A listing with Id '{listing.Id}' already exists.");
                }
            }
            await _context.Listings.AddAsync(listing);
        }

        public async Task UpdateAsync(Listing listing)
        {
            var tracked = _context.Listings.Local.FirstOrDefault(l => l.Id == listing.Id);
            if (tracked == null)
            {
                _context.Listings.Update(listing);
            }
            else if (tracked != listing)
            {
                _context.Entry(tracked).CurrentValues.SetValues(listing);
            }
            
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

            if (filterDto.MinPrice > 0)
            {
                query = query.Where(l => l.Price >= filterDto.MinPrice);
            }
            if (filterDto.MaxPrice > 0)
            {
                query = query.Where(l => l.Price <= filterDto.MaxPrice);
            }

            if (filterDto.MinYear > 0)
            {
                query = query.Where(l => l.Year >= filterDto.MinYear);
            }
            if (filterDto.MaxYear > 0)
            {
                query = query.Where(l => l.Year <= filterDto.MaxYear);
            }

            if (filterDto.MileageMin > 0)
            {
                query = query.Where(l => l.Mileage >= filterDto.MileageMin);
            }
            if (filterDto.MileageMax > 0)
            {
                query = query.Where(l => l.Mileage <= filterDto.MileageMax);
            }

            if (filterDto.EngineType != 0)
            {
                query = query.Where(l => l.EngineType == filterDto.EngineType);
            }

            if (filterDto.TransmissionType != 0)
            {
                query = query.Where(l => l.TransmissionType == filterDto.TransmissionType);
            }

            if (filterDto.FiscalPowerMin > 0)
            {
                query = query.Where(l => l.FiscalPower >= filterDto.FiscalPowerMin);
            }
            if (filterDto.FiscalPowerMax > 0)
            {
                query = query.Where(l => l.FiscalPower <= filterDto.FiscalPowerMax);
            }

            if (filterDto.CylinderCapacityMin > 0)
            {
                query = query.Where(l => l.CylinderCapacity >= filterDto.CylinderCapacityMin);
            }
            if (filterDto.CylinderCapacityMax > 0)
            {
                query = query.Where(l => l.CylinderCapacity <= filterDto.CylinderCapacityMax);
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
                BrandName = l.BrandId == 1 ? "Audi" : l.BrandId == 2 ? "BMW" : l.BrandId == 3 ? "Mercedes" : l.BrandId == 4 ? "Porsche" : l.BrandId == 5 ? "Volkswagen" : l.BrandId == 6 ? "Toyota" : l.BrandId == 7 ? "Ford" : l.BrandId == 8 ? "Renault" : l.BrandId == 9 ? "Peugeot" : l.BrandId == 10 ? "Citroen" : l.BrandId == 11 ? "Fiat" : l.BrandId == 12 ? "Hyundai" : l.BrandId == 13 ? "Kia" : l.BrandId == 14 ? "Nissan" : l.BrandId == 15 ? "Honda" : l.BrandId == 16 ? "Mazda" : l.BrandId == 17 ? "Mitsubishi" : l.BrandId == 18 ? "Suzuki" : l.BrandId == 19 ? "Tesla" : l.BrandId == 20 ? "Volvo" : l.BrandId == 21 ? "Land Rover" : l.BrandId == 22 ? "Jaguar" : l.BrandId == 23 ? "Ferrari" : l.BrandId == 24 ? "Lamborghini" : l.BrandId == 25 ? "Maserati" : l.BrandId == 26 ? "Aston Martin" : l.BrandId == 27 ? "Bentley" : l.BrandId == 28 ? "Rolls-Royce" : l.BrandId == 29 ? "Alfa Romeo" : l.BrandId == 30 ? "Lexus" : l.BrandId == 31 ? "Jeep" : l.BrandId == 32 ? "Chevrolet" : l.BrandId == 33 ? "Dodge" : l.BrandId == 34 ? "Chrysler" : l.BrandId == 35 ? "Cadillac" : l.BrandId == 36 ? "GMC" : l.BrandId == 37 ? "RAM" : l.BrandId == 38 ? "Subaru" : l.BrandId == 39 ? "Isuzu" : l.BrandId == 40 ? "Infiniti" : l.BrandId == 41 ? "Acura" : l.BrandId == 42 ? "Genesis" : l.BrandId == 43 ? "Cupra" : l.BrandId == 44 ? "Seat" : l.BrandId == 45 ? "Skoda" : l.BrandId == 46 ? "Mini" : l.BrandId == 47 ? "Smart" : l.BrandId == 48 ? "Dacia" : l.BrandId == 49 ? "Lada" : l.BrandId == 50 ? "MG" : "Unknown",
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
                SellerRating = l.User.Reviews.Any() ? (decimal?)l.User.Reviews.Average(r => r.Rating) : null,
                ImageUrls = l.Images.Select(i => i.ImageUrl).ToList()
            }).ToListAsync();
        }

        public async Task<List<RentListingDetailDTO>> FilterRentListingsAsync(ListingFilterDTO filterDto)
        {
            var query = _context.RentListings.AsQueryable();

            if (filterDto.MinYear > 0)
            {
                query = query.Where(l => l.Year >= filterDto.MinYear);
            }
            if (filterDto.MaxYear > 0)
            {
                query = query.Where(l => l.Year <= filterDto.MaxYear);
            }

            if (filterDto.MileageMin > 0)
            {
                query = query.Where(l => l.Mileage >= filterDto.MileageMin);
            }
            if (filterDto.MileageMax > 0)
            {
                query = query.Where(l => l.Mileage <= filterDto.MileageMax);
            }

            if (filterDto.MinDailyRate > 0)
            {
                query = query.Where(l => l.DailyRate >= filterDto.MinDailyRate);
            }
            if (filterDto.MaxDailyRate > 0)
            {
                query = query.Where(l => l.DailyRate <= filterDto.MaxDailyRate);
            }

            if (filterDto.MinWeeklyRate > 0)
            {
                query = query.Where(l => l.WeeklyRate >= filterDto.MinWeeklyRate);
            }
            if (filterDto.MaxWeeklyRate > 0)
            {
                query = query.Where(l => l.WeeklyRate <= filterDto.MaxWeeklyRate);
            }

            if (filterDto.MinMonthlyRate > 0)
            {
                query = query.Where(l => l.MonthlyRate >= filterDto.MinMonthlyRate);
            }
            if (filterDto.MaxMonthlyRate > 0)
            {
                query = query.Where(l => l.MonthlyRate <= filterDto.MaxMonthlyRate);
            }

            if (filterDto.EngineType != 0)
            {
                query = query.Where(l => l.EngineType == filterDto.EngineType);
            }

            if (filterDto.TransmissionType != 0)
            {
                query = query.Where(l => l.TransmissionType == filterDto.TransmissionType);
            }

            if (filterDto.FiscalPowerMin > 0)
            {
                query = query.Where(l => l.FiscalPower >= filterDto.FiscalPowerMin);
            }
            if (filterDto.FiscalPowerMax > 0)
            {
                query = query.Where(l => l.FiscalPower <= filterDto.FiscalPowerMax);
            }

            if (filterDto.CylinderCapacityMin > 0)
            {
                query = query.Where(l => l.CylinderCapacity >= filterDto.CylinderCapacityMin);
            }
            if (filterDto.CylinderCapacityMax > 0)
            {
                query = query.Where(l => l.CylinderCapacity <= filterDto.CylinderCapacityMax);
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
                    BrandName = l.BrandId == 1 ? "Audi" : l.BrandId == 2 ? "BMW" : l.BrandId == 3 ? "Mercedes" : l.BrandId == 4 ? "Porsche" : l.BrandId == 5 ? "Volkswagen" : l.BrandId == 6 ? "Toyota" : l.BrandId == 7 ? "Ford" : l.BrandId == 8 ? "Renault" : l.BrandId == 9 ? "Peugeot" : l.BrandId == 10 ? "Citroen" : l.BrandId == 11 ? "Fiat" : l.BrandId == 12 ? "Hyundai" : l.BrandId == 13 ? "Kia" : l.BrandId == 14 ? "Nissan" : l.BrandId == 15 ? "Honda" : l.BrandId == 16 ? "Mazda" : l.BrandId == 17 ? "Mitsubishi" : l.BrandId == 18 ? "Suzuki" : l.BrandId == 19 ? "Tesla" : l.BrandId == 20 ? "Volvo" : l.BrandId == 21 ? "Land Rover" : l.BrandId == 22 ? "Jaguar" : l.BrandId == 23 ? "Ferrari" : l.BrandId == 24 ? "Lamborghini" : l.BrandId == 25 ? "Maserati" : l.BrandId == 26 ? "Aston Martin" : l.BrandId == 27 ? "Bentley" : l.BrandId == 28 ? "Rolls-Royce" : l.BrandId == 29 ? "Alfa Romeo" : l.BrandId == 30 ? "Lexus" : l.BrandId == 31 ? "Jeep" : l.BrandId == 32 ? "Chevrolet" : l.BrandId == 33 ? "Dodge" : l.BrandId == 34 ? "Chrysler" : l.BrandId == 35 ? "Cadillac" : l.BrandId == 36 ? "GMC" : l.BrandId == 37 ? "RAM" : l.BrandId == 38 ? "Subaru" : l.BrandId == 39 ? "Isuzu" : l.BrandId == 40 ? "Infiniti" : l.BrandId == 41 ? "Acura" : l.BrandId == 42 ? "Genesis" : l.BrandId == 43 ? "Cupra" : l.BrandId == 44 ? "Seat" : l.BrandId == 45 ? "Skoda" : l.BrandId == 46 ? "Mini" : l.BrandId == 47 ? "Smart" : l.BrandId == 48 ? "Dacia" : l.BrandId == 49 ? "Lada" : l.BrandId == 50 ? "MG" : "Unknown",
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
                    SellerRating = l.User.Reviews.Any() ? (decimal?)l.User.Reviews.Average(r => r.Rating) : null,
                    ImageUrls = l.Images.Select(i => i.ImageUrl).ToList()
            }).ToListAsync();
        }
    }
}
