using AutoMapper;
using FoodApp.Models;
using FoodApp.Models.DataTransferObjects;

namespace FoodApp.Profiles
{
    public class ReviewProfile: Profile
    {
        public ReviewProfile()
        {
            CreateMap<CreateReviewDTO, Review>();
            CreateMap<Review, ReviewDTO>();
        }
    }
}
