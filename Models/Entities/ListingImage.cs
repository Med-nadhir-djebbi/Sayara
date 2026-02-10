namespace Sayara.Models.Entities
{
    public class ListingImage
    {
        public int Id { get; set; }
        public int ListingId { get; set; }
        public string ImageUrl { get; set; }
        public string FileName { get; set; }
        public bool IsPrimary { get; set; } = false;
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
        public Listing Listing { get; set; }
    }
}
