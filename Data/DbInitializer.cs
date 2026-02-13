using Sayara.Models.Entities;
using Sayara.Data;
using Microsoft.EntityFrameworkCore;

namespace Sayara.Data
{
    public static class DbInitializer
    {
        public static async Task Seed(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            try
            {
                // Ensure database is created
                context.Database.EnsureCreated();

                // Ensure Admin Account exists
                var adminEmail = "admin@admin.com";
                var adminUser = await context.Users.FirstOrDefaultAsync(u => u.Email == adminEmail);

                if (adminUser == null)
                {
                    adminUser = new User
                    {
                        FirstName = "Admin",
                        LastName = "System",
                        Email = adminEmail,
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                        Role = "Admin",
                        PhoneNumber = "00000000",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    };

                    await context.Users.AddAsync(adminUser);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DB Seeding Warning: {ex.Message}");
            }
        }
    }
}
