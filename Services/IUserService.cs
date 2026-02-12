using Sayara.Models.DTOs;

namespace Sayara.Services
{
    public interface IUserService
    {
        Task<UserProfileDTO?> GetUserByIdAsync(int id);
        Task<UserProfileDTO?> GetUserByEmailAsync(string email);
        Task<List<UserProfileDTO>> GetAllUsersAsync();
        Task<bool> RegisterAsync(RegisterDTO registerDto);
        Task<string?> LoginAsync(LoginDTO loginDto);
        Task<bool> UpdateUserAsync(int id, UserProfileDTO userProfileDto);
        Task<bool> DeleteUserAsync(int id);
    }
}
