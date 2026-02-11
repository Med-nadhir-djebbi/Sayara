using Microsoft.AspNetCore.Mvc;
using Sayara.Models.DTOs;
using Sayara.Models;
using Sayara.Services;

namespace Sayara.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("profile")]
        public async Task<ActionResult<ApiResponse<UserProfileDTO>>> GetProfile([FromQuery] int id)
        {
            // Note: In real world, get ID from token claims
            var result = await _userService.GetUserByIdAsync(id);
            if (result == null) return Error<UserProfileDTO>("User not found", 404);
            return Success(result);
        }

        [Route("/register")]
        [HttpGet]
        public IActionResult RegisterView()
        {
            return View("Register");
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse>> Register([FromBody] RegisterDTO registerDto)
        {
            var result = await _userService.RegisterAsync(registerDto);
            if (!result) return ErrorResponse("Registration failed. Email might already be in use.");
            return SuccessResponse("User registered successfully", 201);
        }

        [Route("/login")]
        [HttpGet]
        public IActionResult LoginView()
        {
            return View("Login");
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<object>>> Login([FromBody] LoginDTO loginDto)
        {
            var token = await _userService.LoginAsync(loginDto);
            if (token == null) return Error<object>("Login failed. Invalid email or password.", 401);
            
            // Return Token in Data
            return Success<object>(new { Token = token }, "Login successful");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse>> UpdateProfile(int id, [FromBody] UserProfileDTO userProfileDto)
        {
            var result = await _userService.UpdateUserAsync(id, userProfileDto);
            if (!result) return ErrorResponse("Failed to update profile", 404);
            return SuccessResponse("Profile updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result) return ErrorResponse("User not found", 404);
            return SuccessResponse("User deleted successfully");
        }
    }
}
