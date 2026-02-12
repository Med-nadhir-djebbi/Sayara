using Microsoft.AspNetCore.Mvc;
using Sayara.Models.DTOs;
using Sayara.Models;
using Sayara.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Sayara.Controllers
{
    public class ListingsController : BaseApiController
    {
        private readonly IListingService _listingService;

        public ListingsController(IListingService listingService)
        {
            _listingService = listingService;
        }

        // --- VIEWS ---
        [Route("/sale")]
        [HttpGet]
        public IActionResult SaleView()
        {
            return View("Sale");
        }

        [Route("/rent")]
        [HttpGet]
        public IActionResult RentView()
        {
            return View("Rent");
        }

        [Route("/vehicles")]
        [HttpGet]
        public IActionResult VehiclesView()
        {
            return View("Vehicles"); // New Unified View
        }

        [Route("/create")]
        [HttpGet]
        public IActionResult CreateView()
        {
            return View("Create");
        }

        [Route("/details/{id}")]
        [HttpGet]
        public IActionResult DetailsView(int id)
        {
            return View("Details"); // The view will fetch data via JS
        }

        // --- API ENDPOINTS ---

        [HttpGet("sale")]
        public async Task<ActionResult<ApiResponse<List<SaleListingCardDTO>>>> GetAllSale()
        {
            var result = await _listingService.GetAllSaleListingsAsync();
            return Success(result);
        }

        [HttpGet("rent")]
        public async Task<ActionResult<ApiResponse<List<RentListingCardDTO>>>> GetAllRent()
        {
            var result = await _listingService.GetAllRentListingsAsync();
            return Success(result);
        }

        [HttpGet("sale/{id}")]
        public async Task<ActionResult<ApiResponse<SaleListingDetailDTO>>> GetSale(int id)
        {
            var result = await _listingService.GetSaleListingAsync(id);
            if (result == null) return Error<SaleListingDetailDTO>("Sale listing not found", 404);
            return Success(result);
        }

        [HttpGet("rent/{id}")]
        public async Task<ActionResult<ApiResponse<RentListingDetailDTO>>> GetRent(int id)
        {
            var result = await _listingService.GetRentListingAsync(id);
            if (result == null) return Error<RentListingDetailDTO>("Rent listing not found", 404);
            return Success(result);
        }

        [HttpPost("filter/sale")]
        public async Task<ActionResult<ApiResponse<List<SaleListingDetailDTO>>>> FilterSale([FromBody] ListingFilterDTO filter)
        {
            var result = await _listingService.FilterSaleListingsAsync(filter);
            return Success(result);
        }

        [HttpPost("filter/rent")]
        public async Task<ActionResult<ApiResponse<List<RentListingDetailDTO>>>> FilterRent([FromBody] ListingFilterDTO filter)
        {
            var result = await _listingService.FilterRentListingsAsync(filter);
            return Success(result);
        }



        [Authorize]
        [HttpPost("sale")]
        public async Task<ActionResult<ApiResponse<int>>> CreateSale([FromForm] CreateSaleListingDTO createDto, IFormFileCollection photos)
        {
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out int userId))
            {
                return Unauthorized(new ApiResponse<string> { Success = false, Message = "Invalid user credentials" });
            }

            var id = await _listingService.CreateSaleListingAsync(createDto, userId, photos);
            return Success(id, "Sale listing created", 201);
        }

        [Authorize]
        [HttpPost("rent")]
        public async Task<ActionResult<ApiResponse<int>>> CreateRent([FromForm] CreateRentListingDTO createDto, IFormFileCollection photos)
        {
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out int userId))
            {
                return Unauthorized(new ApiResponse<string> { Success = false, Message = "Invalid user credentials" });
            }

            var id = await _listingService.CreateRentListingAsync(createDto, userId, photos);
            return Success(id, "Rent listing created", 201);
        }

        [HttpPut("sale/{id}")]
        public async Task<ActionResult<ApiResponse>> UpdateSale(int id, [FromBody] CreateSaleListingDTO updateDto)
        {
            var result = await _listingService.UpdateSaleListingAsync(id, updateDto);
            if (!result) return ErrorResponse("Failed to update sale listing", 404);
            return SuccessResponse("Sale listing updated");
        }

        [HttpPut("rent/{id}")]
        public async Task<ActionResult<ApiResponse>> UpdateRent(int id, [FromBody] CreateRentListingDTO updateDto)
        {
            var result = await _listingService.UpdateRentListingAsync(id, updateDto);
            if (!result) return ErrorResponse("Failed to update rent listing", 404);
            return SuccessResponse("Rent listing updated");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> Delete(int id)
        {
            var result = await _listingService.DeleteListingAsync(id);
            if (!result) return ErrorResponse("Listing not found", 404);
            return SuccessResponse("Listing deleted");
        }
    }
}
