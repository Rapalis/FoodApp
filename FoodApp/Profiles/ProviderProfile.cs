using AutoMapper;
using FoodApp.Models;

namespace FoodApp.Profiles
{
    public class ProviderProfile: Profile
    {
        public ProviderProfile()
        {
            CreateMap<CreateProviderDTO, Provider>();
            CreateMap<Provider, ProviderDTO>();
        }
    }
}
