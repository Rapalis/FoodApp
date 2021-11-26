using AutoMapper;
using FoodApp.Models;
using FoodApp.Models.DataTransferObjects;
using FoodApp.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> CheckPasswordAsync(long userId, string password)
        {
            User user = await _userRepository.GetAsync(userId);
            if (user == null)
                throw new Exception("Bad request");

            return password == user.Password ? true : false;

        }

        public async Task<User> FindByNameAsync(string username)
        {
            return await _userRepository.FindByNameAsync(username);
        }

        public async Task<User> CreateAsync(User user, string password)
        {
            user.Password = password;
            return await _userRepository.CreateAsync(user);
        }

        public async Task<string> GetRoleAsync(long userId)
        {
            User user = await _userRepository.GetAsync(userId);
            if (user == null)
                throw new Exception("Bad request");

            return user.Role;
        }
    }
}
