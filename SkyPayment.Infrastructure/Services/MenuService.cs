using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SkyPayment.Contract.RequestModel;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Core.Entities;
using SkyPayment.Infrastructure.Interface;
using SkyPayment.Repository.Interfaces;

namespace SkyPayment.Infrastructure.Services
{
    public class MenuService:IMenuService
    {
        private readonly IRepository<Menu> _menuRepository;
        private readonly IRepository<ManagementUser> _managementUserRepository;
      
        public MenuService(IRepository<Menu> menuRepository, IRepository<ManagementUser> managementUserRepository)
        {
            _menuRepository = menuRepository;
            _managementUserRepository = managementUserRepository;
        }

        public IEnumerable<Menu> GetAll(string id)
        {
            var menus = _managementUserRepository.FindById(id).Restaurants.Select(x => x.Menus);
            if (!menus.Any())
            {
                foreach (var menu in menus)
                {
                    return menu;
                }
            }
            return null;
        }

        public Menu Create(Menu menuCreate)
        {
            var managementUser = _managementUserRepository.AsQueryable().First();
              //  FindOne(x => x.Id == menuCreate.ManagementUserId);
          
            foreach (var userRestaurantMenu in managementUser.Restaurants)
            {
                if (userRestaurantMenu.Menus == null)
                {
                    userRestaurantMenu.Menus=new List<Menu>();
                }
                userRestaurantMenu.Menus.Add(menuCreate);
                _managementUserRepository.UpdateOne(managementUser, Builders<ManagementUser>.Update.Set(nameof(userRestaurantMenu.Menus), userRestaurantMenu.Menus));
            }
           
            return menuCreate;
        }
        
        public Menu GetById(string managementUserId, string menuId)
        {
            var managementUser = _managementUserRepository.FindById(managementUserId);
            if (managementUser!=null)
            {
                foreach (var restaurant in managementUser.Restaurants)
                {
                    return restaurant.Menus.FirstOrDefault(x => x.Id == menuId);
                }
            }

            return null;
        }

        public bool DeleteMenu(string managementUserId, string menuId)
        {
            var foundManager = _managementUserRepository.FindById(managementUserId);
            if (foundManager == null)
            {
                return false;
            }
            

            foreach (var restaurant in foundManager.Restaurants)
            {
                var foundMenu = restaurant.Menus.FirstOrDefault(x=>x.Id==menuId);
                restaurant.Menus.Remove(foundMenu);
               // _menuRepository.UpdateOne(foundManager,Builders<ManagementUser>.Update.Set(nameof(foundManager.Restaurants.)));
            }

            return false;
        }
        // public bool DeleteRestaurant(string managementUserId, string restaurantId)
        // {
        //     var foundManager = _managementUserRepository.FindById(managementUserId);
        //
        //     var foundRestaurant = foundManager?.Restaurants.FirstOrDefault(x => x.Id == restaurantId);
        //     if (foundRestaurant == null)
        //     {
        //         return false;
        //     }
        //
        //     foundManager.Restaurants.Remove(foundRestaurant);
        //     _managementUserRepository.UpdateOne(foundManager,
        //         Builders<ManagementUser>.Update.Set(nameof(foundManager.Restaurants), foundManager.Restaurants));
        //
        //     return true;
        // }
        
    }
}