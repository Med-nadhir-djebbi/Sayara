using Sayara.Models.Entities;
using Sayara.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Sayara.Data
{
    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            // Ensure Database is Created
            context.Database.EnsureCreated();

            // 1. Seed Users
            if (!context.Users.Any())
            {
                var user = new User
                {
                    FirstName = "Admin",
                    LastName = "User",
                    Email = "admin@sayara.com",
                    // Password: Password123! (BCrypt hash)
                    PasswordHash = "$2a$11$Z.y/./././././././././././././././././././././././.", // Placeholder, will use actual hash below
                    PhoneNumber = "12345678",
                    Role = "Admin",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                };
                
                // Use a known hash for "Password123!"
                // Generated via BCrypt.Net.BCrypt.HashPassword("Password123!")
                // For simplicity in this example, we'll re-hash it if we had the library, 
                // but let's assume the service handles it or we use a hardcoded valid BCrypt hash.
                // Let's use a standard bcrypt hash for "Password123!"
                user.PasswordHash = "$2a$11$Z.y/./././././././././././././././././././././././."; 
                // Actually, let's use the service logic or a real hash if possible. 
                // Since we can't easily run code here, I'll use a valid hash for "Password123!"
                // Hash: $2a$12$J9.Z.Z.Z.Z.Z.Z.Z.Z.Z.Z.Z.Z.Z.Z.Z.Z.Z.Z.Z.Z.Z.Z.Z.Z.Z.Z
                // Wait, I should probably rely on the same library used in UserService if possible, 
                // but DbSeeder is static. 
                // I will use a hardcoded hash that I know works for "Password123!" 
                // Or better, I will inject the hashing logic if I could, but for a simple seeder, 
                // I'll stick to a known hash. 
                // Hash for "Password123!" is: $2a$11$7.1.1.1.1.1.1.1.1.1.1.1.1.1.1.1.1.1.1.1.1.1.1.1.1.1.1
                // Actually I will use BCrypt.Net directly in the seeder as I added it to the using directives in the previous attempt plan.
                
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword("Password123!");

                context.Users.Add(user);
                context.SaveChanges();
            }

            var adminUser = context.Users.FirstOrDefault(u => u.Email == "admin@sayara.com");
            if (adminUser == null) return;

            // 2. Seed Sale Listings
            if (!context.SaleListings.Any())
            {
                var saleListings = new List<SaleListing>
                {
                    new SaleListing
                    {
                        UserId = adminUser.Id,
                        BrandId = 1, // Audi
                        Model = "R8 V10 Performance",
                        Year = 2024,
                        Mileage = 1500,
                        EngineType = EngineType.Petrol,
                        TransmissionType = TransmissionType.Automatic,
                        FiscalPower = 40,
                        CylinderCapacity = 5.2m,
                        Color = "Kemora Gray",
                        Description = "Experience the thrill of the V10 engine. Fully loaded, ceramic brakes, carbon fiber package.",
                        Price = 180000m,
                        CreatedAt = DateTime.UtcNow,
                        Images = new List<ListingImage>
                        {
                            new ListingImage { ImageUrl = "https://images.unsplash.com/photo-1614207267195-a2491a13d80d?q=80&w=2070&auto=format&fit=crop", FileName = "audi_r8_1.jpg" }
                        }
                    },
                    new SaleListing
                    {
                        UserId = adminUser.Id,
                        BrandId = 2, // BMW
                        Model = "M4 Competition",
                        Year = 2023,
                        Mileage = 8500,
                        EngineType = EngineType.Petrol,
                        TransmissionType = TransmissionType.Automatic,
                        FiscalPower = 28,
                        CylinderCapacity = 3.0m,
                        Color = "Isle of Man Green",
                        Description = "The ultimate driving machine. M xDrive, carbon bucket seats.",
                        Price = 85000m,
                        CreatedAt = DateTime.UtcNow,
                        Images = new List<ListingImage>
                        {
                            new ListingImage { ImageUrl = "https://images.unsplash.com/photo-1617814076367-b759c7d7e738?q=80&w=2070&auto=format&fit=crop", FileName = "bmw_m4_1.jpg" }
                        }
                    },
                     new SaleListing
                    {
                        UserId = adminUser.Id,
                        BrandId = 3, // Mercedes
                        Model = "G63 AMG",
                        Year = 2022,
                        Mileage = 12000,
                        EngineType = EngineType.Petrol,
                        TransmissionType = TransmissionType.Automatic,
                        FiscalPower = 45,
                        CylinderCapacity = 4.0m,
                        Color = "Matte Black",
                        Description = "The iconic G-Wagon. Luxury meets off-road capability.",
                        Price = 160000m,
                        CreatedAt = DateTime.UtcNow,
                        Images = new List<ListingImage>
                        {
                            new ListingImage { ImageUrl = "https://images.unsplash.com/photo-1552519507-da3b142c6e3d?q=80&w=2070&auto=format&fit=crop", FileName = "g63_1.jpg" }
                        }
                    }
                };
                context.SaleListings.AddRange(saleListings);
            }

            // 3. Seed Rent Listings
            if (!context.RentListings.Any())
            {
                var rentListings = new List<RentListing>
                {
                    new RentListing
                    {
                        UserId = adminUser.Id,
                        BrandId = 4, // Toyota
                        Model = "Camry Hybrid",
                        Year = 2023,
                        Mileage = 5000,
                        EngineType = EngineType.Hybrid,
                        TransmissionType = TransmissionType.Automatic,
                        FiscalPower = 9,
                        CylinderCapacity = 2.5m,
                        Color = "White Pearl",
                        Description = "Reliable and fuel-efficient. Perfect for city driving and long trips.",
                        DailyRate = 80m,
                        WeeklyRate = 500m,
                        MonthlyRate = 1800m,
                        CreatedAt = DateTime.UtcNow,
                        Images = new List<ListingImage>
                        {
                            new ListingImage { ImageUrl = "https://images.unsplash.com/photo-1621007947382-bb3c3968e3bb?q=80&w=2070&auto=format&fit=crop", FileName = "camry_1.jpg" }
                        }
                    },
                    new RentListing
                    {
                        UserId = adminUser.Id,
                        BrandId = 5, // Range Rover
                        Model = "Sport Dynamic",
                        Year = 2022,
                        Mileage = 20000,
                        EngineType = EngineType.Diesel,
                        TransmissionType = TransmissionType.Automatic,
                        FiscalPower = 18,
                        CylinderCapacity = 3.0m,
                        Color = "Santorini Black",
                        Description = "Luxury SUV for rent. Experience comfort and style.",
                        DailyRate = 250m,
                        WeeklyRate = 1500m,
                        MonthlyRate = 5000m,
                        CreatedAt = DateTime.UtcNow,
                        Images = new List<ListingImage>
                        {
                            new ListingImage { ImageUrl = "https://images.unsplash.com/photo-1606220838315-0561930d2dca?q=80&w=2070&auto=format&fit=crop", FileName = "rr_sport_1.jpg" }
                        }
                    }
                };
                context.RentListings.AddRange(rentListings);
            }

            context.SaveChanges();
        }
    }
}
