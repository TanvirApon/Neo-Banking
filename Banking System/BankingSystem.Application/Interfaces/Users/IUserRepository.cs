using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Domain.EntitiesNew;

namespace BankingSystem.Application.Interfaces.Users
{
    public interface IUserRepository
    {
       Task<List<User>> GetAllUsersAsync();
       Task<User?> GetUserByIdAsync(long userId);
       Task AddUserAsync(User user);
       Task UpdateUserAsync(User user);
       Task DeleteUserAsync(long userId);

    }
}
