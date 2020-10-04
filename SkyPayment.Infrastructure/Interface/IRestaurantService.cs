using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using SkyPayment.Core.Entities;

namespace SkyPayment.Infrastructure.Services
{
    public interface IRestaurantService
    {
        public IEnumerable<Restaurant> GetAllRestaurant();
        public Restaurant CreateRestaurant(Restaurant restaurant);
    }
}