using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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

        public IEnumerable<MenuResponseModel> GetAll()
        {
            return _menuRepository.AsQueryable().Select(x=> new MenuResponseModel
            {
                Name = x.Name
            });
        }
    }
}