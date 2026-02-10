using Microsoft.EntityFrameworkCore;
using Sayara.Models.Entities;

namespace Sayara.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<SaleListing> SaleListings { get; set; }
        public DbSet<RentListing> RentListings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ListingImage> ListingImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Email).IsRequired();
                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.FirstName).IsRequired();
                entity.Property(u => u.LastName).IsRequired();
                entity.Property(u => u.PhoneNumber).IsRequired(false);
                entity.Property(u => u.Role).HasDefaultValueSql("'User'");
                entity.Property(u => u.IsActive).HasDefaultValueSql("1").HasSentinel(false);
                entity.Property(u => u.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            });

            
            modelBuilder.Entity<Listing>(entity =>
            {
                entity.HasKey(l => l.Id);
                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(l => l.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.Property(l => l.Model).IsRequired();
                entity.Property(l => l.Color).IsRequired();
                entity.Property(l => l.CylinderCapacity).HasPrecision(10, 2);
            });

            modelBuilder.Entity<SaleListing>(entity =>
            {
                entity.Property(s => s.Price).HasPrecision(18, 2);
            });

            modelBuilder.Entity<RentListing>(entity =>
            {
                entity.Property(r => r.DailyRate).HasPrecision(10, 2);
                entity.Property(r => r.WeeklyRate).HasPrecision(10, 2);
                entity.Property(r => r.MonthlyRate).HasPrecision(10, 2);
            });

            
            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(r => r.ReviewerId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(r => r.RevieweeId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.Property(r => r.Rating).IsRequired();
                entity.Property(r => r.Comment).IsRequired();
            });

            
            modelBuilder.Entity<ListingImage>(entity =>
            {
                entity.HasKey(li => li.Id);
                entity.Property(li => li.ImageUrl).IsRequired();
                entity.Property(li => li.FileName).IsRequired();
                entity.HasOne(li => li.Listing)
                    .WithMany(l => l.Images)
                    .HasForeignKey(li => li.ListingId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
