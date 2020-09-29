using System;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.Contract.RequestModel;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Infrastructure.Interface;

namespace SkyPayment.Infrastructure.Services
{
    public class MenuService:IMenuService
    {
        public CreateMenuResponseModel Add(CreateMenuRequestModel model)
        {
            var createMenuResponse = new CreateMenuResponseModel()
            {
                Name = model.Name,
                Type = model.Type,
                CreateDateTime =DateTime.Now
            };
            return createMenuResponse;
        }
    }
}