using AutoMapper;
using FoodApp.Models;

namespace FoodApp.Profiles
{
    public class DishProfile: Profile
    {
        public DishProfile()
        {
            CreateMap<CreateDishDTO, Dish>();
            CreateMap<Dish, DishDTO>();
        }
    }
}
