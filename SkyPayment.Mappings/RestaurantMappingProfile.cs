using AutoMapper;
using SkyPayment.Contract.ResponseModel.Restaurant;
using SkyPayment.Core.Entities;

namespace SkyPayment.Mappings
{
    public class RestaurantMappingProfile : Profile
    {
        public RestaurantMappingProfile()
        {
            CreateMap<Restaurant, GetRestaurantByIdResponseModel>();
        }
    }
}