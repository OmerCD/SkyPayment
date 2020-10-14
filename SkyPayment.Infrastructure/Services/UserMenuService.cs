using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using SkyPayment.Core.Entities;
using SkyPayment.Infrastructure.Interface;
using SkyPayment.Repository.Interfaces;

namespace SkyPayment.Infrastructure.Services
{
    public class UserMenuService : IUserMenuService
    {
        private readonly IRepository<ManagementUser> _managementUserRepository;
        private readonly IRepository<Menu> _menuRepository;

        public UserMenuService(IRepository<ManagementUser> managementUserRepository, IRepository<Menu> menuRepository)
        {
            _managementUserRepository = managementUserRepository;
            _menuRepository = menuRepository;
        }
        
        public Menu Create(Menu menuCreate)
        {
            var managementUser = _managementUserRepository.FindById(menuCreate.ManagementUserId);
            managementUser.ManagementMenus.Add(menuCreate);
            _managementUserRepository.UpdateOne(managementUser,Builders<ManagementUser>.Update.Set(nameof(managementUser.ManagementMenus),managementUser.ManagementMenus));
            return menuCreate;
        }

        public bool DeleteMenu(string managementUserId, string menuId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Menu> GetAll(string id)
        {
            throw new NotImplementedException();
        }

        public Menu GetById(string managementUserId, string menuId)
        {
            throw new NotImplementedException();
        }
    }
}
