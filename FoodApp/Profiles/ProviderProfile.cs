using AutoMapper;
using FoodApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
