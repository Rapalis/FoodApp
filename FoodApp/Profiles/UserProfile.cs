using AutoMapper;
using FoodApp.Models;

namespace FoodApp.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateDishDTO, Dish>();
            CreateMap<Dish, DishDTO>();
        }
    }
}
