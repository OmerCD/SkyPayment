using System.Collections.Generic;
using SkyPayment.Core.Entities;
using SkyPayment.Infrastructure.Extensions;

namespace SkyPayment.Infrastructure.Services
{
    public interface IRestaurantService: IScopedService
    {
        IEnumerable<Restaurant> GetAllRestaurants(string userId);
       
        bool CreateRestaurant(Restaurant restaurant);
       
        bool UpdateRestaurant(Restaurant menu);
        bool DeleteRestaurant(string id);
    }
}