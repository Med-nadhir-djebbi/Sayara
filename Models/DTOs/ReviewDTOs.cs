namespace Sayara.Models.DTOs
{
    public class CreateReview
    {
        public int RevieweeId {get;set;}
        public int Rating {get;set;}
        public string Comment {get;set;}
    }
    public class ReviewDTO
    {
        public int Id {get; set;}
        public int ReviewerId {get;set;}
        public string ReviewerName { get; set; }
        public int RevieweeId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
