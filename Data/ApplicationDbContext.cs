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
                entity.Property(u => u.Role).HasDefaultValueSql("'User'");
                entity.Property(u => u.IsActive).HasDefaultValueSql("1");
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
            });

            modelBuilder.Entity<SaleListing>();
            modelBuilder.Entity<RentListing>();

            
            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(r => r.Id);
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
        }
    }
}
