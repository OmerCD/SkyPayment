using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using SkyPayment.Core.Entities;
using SkyPayment.Repository.Interfaces;

namespace SkyPayment.Infrastructure.Services
{
    public class RestaurantService:IRestaurantService
    {
        private readonly IRepository<Restaurant> _restaurantRepository;
        private readonly IRepository<ManagementUser> _managementUserRepository;
        public RestaurantService(IRepository<Restaurant> restaurantRepository, IRepository<ManagementUser> managementUserRepository)
        {
            _restaurantRepository = restaurantRepository;
            _managementUserRepository = managementUserRepository;
        }

        public IEnumerable<Restaurant> GetAllRestaurant()
        {
            return _restaurantRepository.AsQueryable();
        }

        public Restaurant CreateRestaurant(Restaurant restaurant)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Restaurant> GetManagementUserRestaurants(string userId)
        {
            return _managementUserRepository.FindById(userId).Restaurants;
        }

      

    }
}