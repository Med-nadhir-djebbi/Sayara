using Microsoft.AspNetCore.Mvc;
using Sayara.Models;

namespace Sayara.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : Controller
    {
        protected ActionResult<ApiResponse<T>> Success<T>(T data, string message = "Operation successful", int statusCode = 200)
        {
            return StatusCode(statusCode, ApiResponse<T>.SuccessResponse(data, message, statusCode));
        }

        protected ActionResult<ApiResponse> SuccessResponse(string message = "Operation successful", int statusCode = 200)
        {
            return StatusCode(statusCode, ApiResponse.SuccessResponse(message, statusCode));
        }

        protected ActionResult<ApiResponse<T>> Error<T>(string message, int statusCode = 400, T data = default)
        {
            return StatusCode(statusCode, ApiResponse<T>.ErrorResponse(message, statusCode, data));
        }

        protected ActionResult<ApiResponse> ErrorResponse(string message, int statusCode = 400)
        {
            return StatusCode(statusCode, ApiResponse.ErrorResponse(message, statusCode));
        }
    }
}
