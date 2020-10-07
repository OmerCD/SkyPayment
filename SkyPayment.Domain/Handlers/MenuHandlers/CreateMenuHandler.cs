using System;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Core.Entities;
using SkyPayment.Domain.Commands.MenuCommand;
using SkyPayment.Infrastructure.Interface;

namespace SkyPayment.Domain.Handlers
{
    public class CreateMenuHandler:IBaseRequestHandler<MenuCreateCommand>
    {
        private readonly IMenuService _menuService;

        public CreateMenuHandler(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public Task<BaseResponseModel> Handle(MenuCreateCommand request, CancellationToken cancellationToken)
        {
            var menu = _menuService.Create(new Menu
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Name = request.Type,
                ManagementUserId = request.ManagementUserId,
                CreateDate = DateTime.Now
            });
            if (menu != null)
            {
                return Task.FromResult<BaseResponseModel>(new BaseResponseModel()
                {
                    Description = "Kayıt Başarılı",
                    StatusCode = 201
                });
            }

            return Task.FromResult<BaseResponseModel>(new BaseResponseModel
            {
                Description = "Bir hata oluştu",
                StatusCode = 400
            });
        }
    }
}