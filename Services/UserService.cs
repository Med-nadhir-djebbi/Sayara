using Sayara.Models.DTOs;
using Sayara.Models.Entities;
using Sayara.Repositories;
using BCrypt.Net;

namespace Sayara.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ITokenService tokenService, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _logger = logger;
        }

        public async Task<UserProfileDTO?> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (user == null)
                {
                    _logger.LogWarning($"User with ID {id} not found");
                    return null;
                }

                return MapToUserProfileDTO(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting user by ID: {ex.Message}");
                throw;
            }
        }

        public async Task<UserProfileDTO?> GetUserByEmailAsync(string email)
        {
            try
            {
                var user = await _userRepository.GetByEmailAsync(email);
                if (user == null)
                {
                    _logger.LogWarning($"User with email {email} not found");
                    return null;
                }

                return MapToUserProfileDTO(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting user by email: {ex.Message}");
                throw;
            }
        }

        public async Task<List<UserProfileDTO>> GetAllUsersAsync()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                return users.Select(MapToUserProfileDTO).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting all users: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> RegisterAsync(RegisterDTO registerDto)
        {
            try
            {
                var existingUser = await _userRepository.GetByEmailAsync(registerDto.Email);
                if (existingUser != null)
                {
                    _logger.LogWarning($"Registration failed: Email {registerDto.Email} already exists");
                    return false;
                }

                var user = new User
                {
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    Email = registerDto.Email,
                    PhoneNumber = registerDto.PhoneNumber,
                    PasswordHash = HashPassword(registerDto.Password),
                    Role = "User",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                };

                await _userRepository.AddAsync(user);
                await _userRepository.SaveChangesAsync();

                _logger.LogInformation($"User {registerDto.Email} registered successfully");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error during registration: {ex.Message}");
                return false;
            }
        }

        public async Task<string?> LoginAsync(LoginDTO loginDto)
        {
            try
            {
                var user = await _userRepository.GetByEmailAsync(loginDto.Email);
                if (user == null || !VerifyPassword(loginDto.Password, user.PasswordHash))
                {
                    _logger.LogWarning($"Login failed for email: {loginDto.Email}");
                    return null;
                }

                _logger.LogInformation($"User {loginDto.Email} logged in successfully");
                return _tokenService.GenerateToken(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error during login: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> UpdateUserAsync(int id, UserProfileDTO userProfileDto)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (user == null)
                {
                    _logger.LogWarning($"User with ID {id} not found for update");
                    return false;
                }

                user.FirstName = userProfileDto.FirstName;
                user.LastName = userProfileDto.LastName;
                user.Email = userProfileDto.Email;
                user.PhoneNumber = userProfileDto.PhoneNumber;

                await _userRepository.UpdateAsync(user);
                await _userRepository.SaveChangesAsync();

                _logger.LogInformation($"User {id} updated successfully");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating user: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (user == null)
                {
                    _logger.LogWarning($"User with ID {id} not found for deletion");
                    return false;
                }

                await _userRepository.DeleteAsync(id);
                await _userRepository.SaveChangesAsync();

                _logger.LogInformation($"User {id} deleted successfully");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting user: {ex.Message}");
                return false;
            }
        }

        private UserProfileDTO MapToUserProfileDTO(User user)
        {
            return new UserProfileDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                CreatedAt = user.CreatedAt
            };
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
