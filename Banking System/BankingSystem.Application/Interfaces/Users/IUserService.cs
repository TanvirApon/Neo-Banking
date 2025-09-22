using BankingSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application.Interfaces.Users
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(long userId);
        Task AddUserAsync(CreateUserDto createUserDto);
        Task UpdateUserAsync(long userId, UpdateUserDto updateUserDto);
        Task DeleteUserAsync(long userId);

    }
}
