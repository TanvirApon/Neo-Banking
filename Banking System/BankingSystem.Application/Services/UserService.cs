using AutoMapper;
using BankingSystem.Application.DTOs;
using BankingSystem.Application.Interfaces.Users;
using BankingSystem.Domain.EntitiesNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto?> GetUserByIdAsync(long userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task AddUserAsync(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(long userId, UpdateUserDto updateUserDto)
        {
            var user = _userRepository.GetUserByIdAsync(userId).Result;
            if (user == null) throw new Exception("User not found");

            _mapper.Map(updateUserDto, user);
            await _userRepository.UpdateUserAsync(user);

        }

        public async Task DeleteUserAsync(long userId)
        {
            var user = _userRepository.GetUserByIdAsync(userId).Result;
            await _userRepository.DeleteUserAsync(userId);
        }

    }
}
