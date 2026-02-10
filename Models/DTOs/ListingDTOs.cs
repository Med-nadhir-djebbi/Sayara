using Sayara.Models.Enums;
namespace Sayara.Models.DTOs{
    public class CreateSaleListingDTO
    {
        public string Model { get; set; }
            public int Year { get; set; }
            public int Mileage { get; set; }
            public EngineType EngineType { get; set; }
            public TransmissionType TransmissionType { get; set; }
            public int FiscalPower { get; set; }
            public decimal CylinderCapacity { get; set; }  
            public string Color { get; set; }
            public string Description { get; set; }
        public decimal Price {get;set;}
    }
    public class CreateRentListingDTO
    {
    public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public EngineType EngineType { get; set; }
    public TransmissionType TransmissionType { get; set; }
        public int FiscalPower { get; set; }
        public decimal CylinderCapacity { get; set; }  
        public string Color { get; set; }
        public string Description { get; set; }
        public decimal DailyRate { get; set; }
        public decimal WeeklyRate { get; set; }
        public decimal MonthlyRate { get; set; }
    }
    public class SaleListingCardDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }  
        public string SellerName { get; set; }
    }

    public class RentListingCardDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal DailyRate { get; set; }
        public string lessorName { get; set; }
    }
    public class RentListingDetailDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public int BrandId { get; set; }
        public EngineType EngineType { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public int FiscalPower { get; set; }
        public decimal CylinderCapacity { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public decimal DailyRate { get; set; }  
        public decimal WeeklyRate { get; set; }  
        public decimal MonthlyRate { get; set; }  
        public DateTime CreatedAt { get; set; }
        
        public int SellerUserId { get; set; }
        public string SellerName { get; set; }
        public string SellerPhone { get; set; }
        public decimal? SellerRating { get; set; }
    }
    public class SaleListingDetailDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public int BrandId { get; set; }
        public EngineType EngineType { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public int FiscalPower { get; set; }
        public decimal CylinderCapacity { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }  
        public DateTime CreatedAt { get; set; }
        public int SellerUserId { get; set; }
        public string SellerName { get; set; }
        public string SellerPhone { get; set; }
        public decimal? SellerRating { get; set; }
    }
    public class ListingFilterDTO
    {
        public decimal MinPrice{get ; set;}
        public decimal MaxPrice{get ; set;}
        public int BrandId{get ; set;}
        public string Model{get ; set;}
        public int YearMin{get ; set;}
        public int YearMax{get ; set;}
        public EngineType EngineType{get ; set;}  
        public TransmissionType TransmissionType{get; set;}
        public String ListingType{get; set;}       
    }
}