using System.ComponentModel.DataAnnotations;
using Sayara.Models.Enums;

namespace Sayara.Models.DTOs
{
    public class CreateSaleListingDTO
    {
        [Required(ErrorMessage = "Brand is required")]
        public int BrandId { get; set; }

        [Required(ErrorMessage = "Model is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Model must be between 1 and 50 characters")]
        public required string Model { get; set; }

        [Required(ErrorMessage = "Year is required")]
        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Mileage is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Mileage cannot be negative")]
        public int Mileage { get; set; }

        [Required(ErrorMessage = "Engine type is required")]
        public EngineType EngineType { get; set; }

        [Required(ErrorMessage = "Transmission type is required")]
        public TransmissionType TransmissionType { get; set; }

        [Required(ErrorMessage = "Fiscal power is required")]
        [Range(0, 50, ErrorMessage = "Fiscal power must be between 0 and 50")]
        public int FiscalPower { get; set; }

        [Required(ErrorMessage = "Cylinder capacity is required")]
        [Range(0.1, 15, ErrorMessage = "Cylinder capacity must be between 0.1L and 15L")]
        public decimal CylinderCapacity { get; set; }

        [Required(ErrorMessage = "Color is required")]
        [StringLength(50)]
        public required string Color { get; set; }

        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 10000000, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }
    }

    public class CreateRentListingDTO
    {
        [Required(ErrorMessage = "Brand is required")]
        public int BrandId { get; set; }

        [Required(ErrorMessage = "Model is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Model must be between 1 and 50 characters")]
        public required string Model { get; set; }

        [Required(ErrorMessage = "Year is required")]
        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Mileage is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Mileage cannot be negative")]
        public int Mileage { get; set; }

        [Required(ErrorMessage = "Engine type is required")]
        public EngineType EngineType { get; set; }

        [Required(ErrorMessage = "Transmission type is required")]
        public TransmissionType TransmissionType { get; set; }

        [Required(ErrorMessage = "Fiscal power is required")]
        [Range(0, 50, ErrorMessage = "Fiscal power must be between 0 and 50")]
        public int FiscalPower { get; set; }

        [Required(ErrorMessage = "Cylinder capacity is required")]
        [Range(0.1, 15, ErrorMessage = "Cylinder capacity must be between 0.1L and 15L")]
        public decimal CylinderCapacity { get; set; }

        [Required(ErrorMessage = "Color is required")]
        [StringLength(50)]
        public required string Color { get; set; }

        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Daily rate is required")]
        [Range(0, 100000, ErrorMessage = "Daily rate must be non-negative")]
        public decimal DailyRate { get; set; }

        [Required(ErrorMessage = "Weekly rate is required")]
        [Range(0, 100000, ErrorMessage = "Weekly rate must be non-negative")]
        public decimal WeeklyRate { get; set; }

        [Required(ErrorMessage = "Monthly rate is required")]
        [Range(0, 100000, ErrorMessage = "Monthly rate must be non-negative")]
        public decimal MonthlyRate { get; set; }
    }

    public class SaleListingCardDTO
    {
        public int Id { get; set; }
        public required string BrandName { get; set; }
        public required string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public required string SellerName { get; set; }
        public List<string> ImageUrls { get; set; } = new();
    }

    public class RentListingCardDTO
    {
        public int Id { get; set; }
        public required string BrandName { get; set; }
        public required string Model { get; set; }
        public int Year { get; set; }
        public decimal DailyRate { get; set; }
        public required string LessorName { get; set; }
        public List<string> ImageUrls { get; set; } = new();
    }

    public class RentListingDetailDTO
    {
        public int Id { get; set; }

        [Required]
        public required string Model { get; set; }

        public int Year { get; set; }

        [Range(0, int.MaxValue)]
        public int Mileage { get; set; }

        public int BrandId { get; set; }
        public required string BrandName { get; set; }

        public EngineType EngineType { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public int FiscalPower { get; set; }
        public decimal CylinderCapacity { get; set; }
        public required string Color { get; set; }
        public string? Description { get; set; }
        public decimal DailyRate { get; set; }
        public decimal WeeklyRate { get; set; }
        public decimal MonthlyRate { get; set; }
        public DateTime CreatedAt { get; set; }
        public int SellerUserId { get; set; }
        public required string SellerName { get; set; }
        public required string SellerPhone { get; set; }
        public decimal? SellerRating { get; set; }
        public List<string> ImageUrls { get; set; } = new();
    }

    public class SaleListingDetailDTO
    {
        public int Id { get; set; }
        public required string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public int BrandId { get; set; }
        public required string BrandName { get; set; }
        public EngineType EngineType { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public int FiscalPower { get; set; }
        public decimal CylinderCapacity { get; set; }
        public required string Color { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public int SellerUserId { get; set; }
        public required string SellerName { get; set; }
        public required string SellerPhone { get; set; }
        public decimal? SellerRating { get; set; }
        public List<string> ImageUrls { get; set; } = new();
    }

    public class ListingFilterDTO
    {
        [Range(0, 10000000)]
        public decimal MinPrice { get; set; }

        [Range(0, 10000000)]
        public decimal MaxPrice { get; set; }

        public int BrandId { get; set; }

        [StringLength(50)]
        public string? Model { get; set; }

        [Range(1900, 2100)]
        public int MinYear { get; set; } = 1900;

        [Range(1900, 2100)]
        public int MaxYear { get; set; } = 2100;

        public int MileageMin { get; set; }

        public int MileageMax { get; set; }

        public int Mileage { get; set; }

        public EngineType EngineType { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public int FiscalPowerMin { get; set; }
        
        public int FiscalPowerMax { get; set; }
        
        public decimal CylinderCapacityMin { get; set; }

        public decimal CylinderCapacityMax { get; set; }

        [Range(0, 100000)]
        public decimal MinDailyRate { get; set; }

        [Range(0, 100000)]
        public decimal MaxDailyRate { get; set; }

        [Range(0, 100000)]
        public decimal MinWeeklyRate { get; set; }

        [Range(0, 100000)]
        public decimal MaxWeeklyRate { get; set; }

        [Range(0, 100000)]
        public decimal MinMonthlyRate { get; set; }

        [Range(0, 100000)]
        public decimal MaxMonthlyRate { get; set; }

        [StringLength(50)]
        public string? ListingType { get; set; }
    }
}
