using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using SkyPayment.Core.Entities;
using SkyPayment.Infrastructure.Interface;

namespace SkyPayment.Infrastructure.Services
{
    public interface IRestaurantService:IService
    {
        public IEnumerable<Restaurant> GetAllRestaurant();
        public Restaurant CreateRestaurant(Restaurant restaurant);
    }
}