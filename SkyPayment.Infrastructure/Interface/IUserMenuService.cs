using System;
using System.Collections.Generic;
using System.Text;
using SkyPayment.Core.Entities;

namespace SkyPayment.Infrastructure.Interface
{
    public interface IUserMenuService
    {
        public IEnumerable<Menu> GetAll(string id);
        Menu Create(Menu menuCreate);
        Menu GetById(string managementUserId, string menuId);
        bool DeleteMenu(string managementUserId, string menuId);

    }
}
