using Models.Enums;
namespace Models.Entities
{
    public class RentListing : Listing
    {
        public decimal DailyRate { get; set; }
        public decimal WeeklyRate { get; set; }
        public decimal MonthlyRate { get; set; }
    }
}