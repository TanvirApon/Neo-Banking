using BankingSystem.Application.Interfaces.Users;
using BankingSystem.Domain.EntitiesNew;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly BankingSystemContext _context;

        public UserRepository(BankingSystemContext context)
        {
            this._context = context;
        }

        public  async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(long userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(long userId)
        {
            _context.Users.Remove(new User { UserId = userId });
            await _context.SaveChangesAsync();
        }
    }
}
