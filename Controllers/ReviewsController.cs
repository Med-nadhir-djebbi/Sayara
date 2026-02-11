using Microsoft.AspNetCore.Mvc;
using Sayara.Models.DTOs;
using Sayara.Models;
using Sayara.Services;

namespace Sayara.Controllers
{
    public class ReviewsController : BaseApiController
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ReviewDTO>>> Get(int id)
        {
            var result = await _reviewService.GetReviewAsync(id);
            if (result == null) return Error<ReviewDTO>("Review not found", 404);
            return Success(result);
        }

        [HttpGet("listing/{listingId}")]
        public async Task<ActionResult<ApiResponse<List<ReviewDTO>>>> GetByListing(int listingId)
        {
            var result = await _reviewService.GetReviewsByListingAsync(listingId);
            return Success(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<ApiResponse<List<ReviewDTO>>>> GetByUser(int userId)
        {
            var result = await _reviewService.GetReviewsByUserAsync(userId);
            return Success(result);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<int>>> Create([FromBody] ReviewDTO reviewDto)
        {
            var id = await _reviewService.CreateReviewAsync(reviewDto);
            return Success(id, "Review created", 201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse>> Update(int id, [FromBody] ReviewDTO reviewDto)
        {
            var result = await _reviewService.UpdateReviewAsync(id, reviewDto);
            if (!result) return ErrorResponse("Failed to update review", 404);
            return SuccessResponse("Review updated");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> Delete(int id)
        {
            var result = await _reviewService.DeleteReviewAsync(id);
            if (!result) return ErrorResponse("Review not found", 404);
            return SuccessResponse("Review deleted");
        }

        [HttpGet("listing/{listingId}/average")]
        public async Task<ActionResult<ApiResponse<decimal>>> GetAverageRating(int listingId)
        {
            var result = await _reviewService.GetAverageRatingAsync(listingId);
            return Success(result);
        }
    }
}
