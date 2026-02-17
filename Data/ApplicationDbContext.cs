using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using tpFINAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace tpFINAL.Data;
public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options):base(options){}
    public DbSet<Customer> Customers {get;set;}
    public DbSet<MembershipType> MembershipTypes {get;set;}
    public DbSet<Movie> Movies {get;set;}
    public DbSet<Genre> Genres {get;set;}
    public DbSet<Produit> Produits {get;set;}
    public DbSet<PanierParUser> paniers {get;set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Customer>()
        .HasOne(c=>c.Membership)
        .WithMany(m=>m.Customers)
        .HasForeignKey(c=>c.MembershipTypeId)
        .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Movie>()
        .HasOne(m=>m.Genre)
        .WithMany(g=>g.Movies)
        .HasForeignKey(m=>m.GenreId)
        .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Customer>()
                .HasMany(c => c.Movies)
                .WithMany(m => m.Customers)
                .UsingEntity<Dictionary<string, object>>(
                    "CustomerMovie",
                    j => j.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    j => j.HasOne<Customer>().WithMany().HasForeignKey("CustomerId")); 

        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Action" },
            new Genre { Id = 2, Name = "Comedy" },
            new Genre { Id = 3, Name = "Drama" },
            new Genre { Id = 4, Name = "Horror" }
        );
    }
}    

