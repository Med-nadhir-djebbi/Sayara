using Sayara.Models.Enums;

namespace Sayara.Models.Entities
{
    public abstract class Listing
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public EngineType EngineType { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public int FiscalPower { get; set; }
        public decimal CylinderCapacity { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public VerificationStatus VerificationStatus { get; set; } = VerificationStatus.Pending;
        public string VerificationNotes { get; set; }
        public DateTime? VerifiedDate { get; set; }
        public ICollection<ListingImage> Images { get; set; } = new List<ListingImage>();
    }
}