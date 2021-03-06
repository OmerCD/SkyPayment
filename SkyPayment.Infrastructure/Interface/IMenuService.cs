﻿using System.Collections.Generic;
using SkyPayment.Contract.RequestModel;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Core.Entities;

namespace SkyPayment.Infrastructure.Interface
{
    public interface IMenuService : IService
    {
        public IEnumerable<Menu> GetAll(string id);
        Menu Create(Menu menuCreate);
        Menu GetById(string managementUserId, string menuId);
        bool DeleteMenu(string managementUserId, string menuId);
    }
}