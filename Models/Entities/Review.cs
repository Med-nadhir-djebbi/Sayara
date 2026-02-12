namespace Sayara.Models.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int ReviewerId { get; set; }
        public int RevieweeId { get; set; }
        public int Rating { get; set; }
        public required string Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}