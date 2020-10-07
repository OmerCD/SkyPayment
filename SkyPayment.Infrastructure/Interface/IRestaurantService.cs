using System.Collections.Generic;
using SkyPayment.Core.Entities;

namespace SkyPayment.Infrastructure.Interface
{
    public interface IRestaurantService:IService
    {
        public IEnumerable<Restaurant> GetAllRestaurant();
        public Restaurant CreateRestaurant(Restaurant restaurant);
        Restaurant GetById(string managementUserId, string restaurantId);
        IEnumerable<Restaurant> GetManagementUserRestaurants(string userId);
        bool DeleteRestaurant(string managementUserId, string restaurantId);
    }
}