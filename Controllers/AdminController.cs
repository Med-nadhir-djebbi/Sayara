using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sayara.Services;
using Sayara.Models.DTOs;
using Sayara.Repositories;

namespace Sayara.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IListingService _listingService;
        private readonly IListingRepository _listingRepository;
        private readonly IReviewService _reviewService;

        public AdminController(IUserService userService, IListingService listingService, IListingRepository listingRepository, IReviewService reviewService)
        {
            _userService = userService;
            _listingService = listingService;
            _listingRepository = listingRepository;
            _reviewService = reviewService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Listings()
        {
            return View();
        }

        public IActionResult Reviews()
        {
            return View();
        }

        // API Endpoints for better management
        [Authorize(Roles = "Admin")]
        [HttpGet("/api/admin/users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(new { data = users });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("/api/admin/listings")]
        public async Task<IActionResult> GetAllListings()
        {
            var sales = await _listingService.GetAllSaleListingsAsync();
            var rents = await _listingService.GetAllRentListingsAsync();
            
            
            var all = sales.Select(s => new { 
                Type = "Sale", 
                Id = s.Id, 
                BrandName = s.BrandName, 
                Model = s.Model, 
                Year = s.Year, 
                Price = s.Price.ToString("F2") + " $", 
                Owner = s.SellerName 
            }).Concat(rents.Select(r => new { 
                Type = "Rent", 
                Id = r.Id, 
                BrandName = r.BrandName, 
                Model = r.Model, 
                Year = r.Year, 
                Price = r.DailyRate.ToString("F2") + " $/day", 
                Owner = r.LessorName 
            }));

            return Ok(new { data = all });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("/api/admin/listings/{id}")]
        public async Task<IActionResult> DeleteListing(int id)
        {
            try 
            {
                await _listingRepository.DeleteAsync(id);
                await _listingRepository.SaveChangesAsync();
                return Ok(new { message = "Listing deleted by admin" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("/api/admin/users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try 
            {
                await _userService.DeleteUserAsync(id);
                return Ok(new { message = "User deleted by admin" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("/api/admin/reviews")]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _reviewService.GetAllReviewsAsync();
            var result = new List<object>();

            foreach (var r in reviews)
            {
                var reviewee = await _userService.GetUserByIdAsync(r.RevieweeId);
                result.Add(new {
                    r.Id,
                    r.ReviewerId,
                    r.ReviewerName,
                    r.RevieweeId,
                    RevieweeName = reviewee != null ? $"{reviewee.FirstName} {reviewee.LastName}" : "Unknown",
                    r.Rating,
                    r.Comment,
                    r.CreatedAt
                });
            }

            return Ok(new { data = result });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("/api/admin/reviews/{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            try
            {
                await _reviewService.DeleteReviewAsync(id);
                return Ok(new { message = "Review deleted by admin" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
