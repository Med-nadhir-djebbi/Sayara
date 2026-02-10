using Sayara.Models.Entities;
using Sayara.Data;
using Microsoft.EntityFrameworkCore;

namespace Sayara.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email== email);
        }
        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task AddAsync(User user)
        {
            var UserExists = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (UserExists != null)
            {
                throw new InvalidOperationException($"A user with email '{user.Email}' already exists.");
            }
            await _context.Users.AddAsync(user);
        }
        public async Task UpdateAsync(User user)
        {
            var userExists = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (userExists == null)
            {
                throw new InvalidOperationException($"A user with Id '{user.Id}' doesn't exist");
            }
            _context.Users.Update(user);
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                throw new InvalidOperationException($"A user with Id '{id}' doesn't exist");
            }
            _context.Users.Remove(user);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}