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
      
        public MenuService(IRepository<Menu> menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public CreateMenuResponseModel Add(CreateMenuRequestModel model)
        {
            var menu = new Menu
            {
                Name = model.Name,
                CreateDate = DateTime.Now,
                IsDeleted = false
            };
            _menuRepository.InsertOne(menu);
            var createMenuResponse = new CreateMenuResponseModel()
            {
                Name = model.Name,
                Type = model.Type,
                CreateDateTime =DateTime.Now
            };
            return createMenuResponse;
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
            var managementUser = _managementUserRepository.FindOne(x => x.Id == menuCreate.ManagementUserId);
            foreach (var userRestaurantMenu in managementUser.Restaurants)
            {
                userRestaurantMenu.Menus.Add(menuCreate);
            }
            _managementUserRepository.UpdateOne(managementUser,Builders<ManagementUser>.Update.Set(nameof(managementUser.Restaurants),managementUser.Restaurants));
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
    }
}