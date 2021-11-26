using AutoMapper;
using FoodApp.Models;
using FoodApp.Models.DataTransferObjects;

namespace FoodApp.Profiles
{
    public class DishProfile: Profile
    {
        public DishProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
        }
    }
}
