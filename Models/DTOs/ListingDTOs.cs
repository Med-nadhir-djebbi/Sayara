using System.ComponentModel.DataAnnotations;
using Sayara.Models.Enums;

namespace Sayara.Models.DTOs
{
    public class CreateSaleListingDTO
    {
        [Required(ErrorMessage = "Model is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Model must be between 1 and 50 characters")]
        public string Model { get; set; }

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
        [Range(0, 30, ErrorMessage = "Fiscal power must be between 0 and 30")]
        public int FiscalPower { get; set; }

        [Required(ErrorMessage = "Cylinder capacity is required")]
        [Range(0.1, 10, ErrorMessage = "Cylinder capacity must be between >1.0L and 10L")]
        public decimal CylinderCapacity { get; set; }

        [Required(ErrorMessage = "Color is required")]
        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 10000000, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }
    }

    public class CreateRentListingDTO
    {
        [Required(ErrorMessage = "Model is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Model must be between 1 and 50 characters")]
        public string Model { get; set; }

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
        [Range(0, 30, ErrorMessage = "Fiscal power must be between 0 and 30")]
        public int FiscalPower { get; set; }

        [Required(ErrorMessage = "Cylinder capacity is required")]
        [Range(0.1, 10, ErrorMessage = "Cylinder capacity must be between >1.0L and 10L")]
        public decimal CylinderCapacity { get; set; }

        [Required(ErrorMessage = "Color is required")]
        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Daily rate is required")]
        [Range(0.01, 100000, ErrorMessage = "Daily rate must be greater than 0")]
        public decimal DailyRate { get; set; }

        [Required(ErrorMessage = "Weekly rate is required")]
        [Range(0.01, 100000, ErrorMessage = "Weekly rate must be greater than 0")]
        public decimal WeeklyRate { get; set; }

        [Required(ErrorMessage = "Monthly rate is required")]
        [Range(0.01, 100000, ErrorMessage = "Monthly rate must be greater than 0")]
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
        public string LessorName { get; set; }
    }

    public class RentListingDetailDTO
    {
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        public int Year { get; set; }

        [Range(0, int.MaxValue)]
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
        [Range(0, 10000000)]
        public decimal MinPrice { get; set; }

        [Range(0, 10000000)]
        public decimal MaxPrice { get; set; }

        public int BrandId { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        [Range(1900, 2100)]
        public int YearMin { get; set; }

        [Range(1900, 2100)]
        public int YearMax { get; set; }

        public EngineType EngineType { get; set; }

        public TransmissionType TransmissionType { get; set; }

        [StringLength(50)]
        public string ListingType { get; set; }
    }
}
