using System.Collections.Generic;
using MongoORM4NetCore.Interfaces;
using SkyPayment.Core.Entities;

namespace SkyPayment.Infrastructure.Services
{
    public class RestaurantService:IRestaurantService
    {
        private readonly IRepository<Restaurant> _restaurant;

        public RestaurantService(IRepository<Restaurant> restaurant)
        {
            _restaurant = restaurant;
        }

        public IEnumerable<Restaurant> GetAllRestaurants(string userId)
        {
            return _restaurant.Search(x => x.UserId == userId);
        }

        public bool CreateRestaurant(Restaurant restaurant)
        {
            return _restaurant.Insert(restaurant);
        }

        public bool UpdateRestaurant(Restaurant menu)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteRestaurant(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}