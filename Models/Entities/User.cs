namespace Sayara.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        
        
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Listing> Listings { get; set; } = new List<Listing>();
        
        public string Name => $"{FirstName} {LastName}";
    }
}