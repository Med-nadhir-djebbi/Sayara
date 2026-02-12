using Sayara.Models.Enums;

namespace Sayara.Models.Entities
{
    public abstract class Listing
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BrandId { get; set; }
        public required string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public EngineType EngineType { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public int FiscalPower { get; set; }
        public decimal CylinderCapacity { get; set; }
        public required string Color { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public User User { get; set; } = default!;
        public ICollection<ListingImage> Images { get; set; } = new List<ListingImage>();
    }
}