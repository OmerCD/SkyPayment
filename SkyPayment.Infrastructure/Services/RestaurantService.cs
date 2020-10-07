using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using MongoDB.Bson;
using MongoDB.Driver;
using SkyPayment.Core.Entities;
using SkyPayment.Infrastructure.Interface;
using SkyPayment.Repository.Interfaces;

namespace SkyPayment.Infrastructure.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRepository<Restaurant> _restaurantRepository;
        private readonly IRepository<ManagementUser> _managementUserRepository;

        public RestaurantService(IRepository<Restaurant> restaurantRepository,
            IRepository<ManagementUser> managementUserRepository)
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
            var managementUser = _managementUserRepository.FindOne(x => x.Id == restaurant.ManagementUserId);
            managementUser.Restaurants.Add(restaurant);
            _managementUserRepository.UpdateOne(managementUser,
                Builders<ManagementUser>.Update.Set(nameof(managementUser.Restaurants), managementUser.Restaurants));
            return restaurant;
        }

        public Restaurant GetById(string managementUserId, string restaurantId)
        {
            var managementUser = _managementUserRepository.FindById(managementUserId);
            return managementUser.Restaurants.FirstOrDefault(x => x.Id == restaurantId);
        }

        public IEnumerable<Restaurant> GetManagementUserRestaurants(string userId)
        {
            return _managementUserRepository.FindById(userId).Restaurants;
        }

        public bool DeleteRestaurant(string managementUserId, string restaurantId)
        {
            var foundManager = _managementUserRepository.FindById(managementUserId);

            var foundRestaurant = foundManager?.Restaurants.FirstOrDefault(x => x.Id == restaurantId);
            if (foundRestaurant == null)
            {
                return false;
            }

            foundManager.Restaurants.Remove(foundRestaurant);
            _managementUserRepository.UpdateOne(foundManager,
                Builders<ManagementUser>.Update.Set(nameof(foundManager.Restaurants), foundManager.Restaurants));

            return true;
        }
    }
}