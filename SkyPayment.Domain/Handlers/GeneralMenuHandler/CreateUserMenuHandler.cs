using SkyPayment.Contract.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using SkyPayment.Core.Entities;
using SkyPayment.Domain.CQ.Commands.GeneralMenuCommand;
using SkyPayment.Infrastructure.Interface;

namespace SkyPayment.Domain.Handlers.UserMenuHandler
{
    public class CreateUserMenuHandler : IBaseRequestHandler<CreateUserMenuCommand>
    {
        private readonly IGeneralMenuService _generalMenuService;

        public CreateUserMenuHandler(IGeneralMenuService generalMenuService)
        {
            _generalMenuService = generalMenuService;
        }

        public Task<BaseResponseModel> Handle(CreateUserMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = _generalMenuService.Create(new Menu
            {
                CreateDate=DateTime.Now,
                Name=request.Name,
                ManagementUserId=request.ManagementUserId,
                Id=ObjectId.GenerateNewId().ToString()
            });
            if (menu != null)
            {
               return Task.FromResult<BaseResponseModel>(new BaseResponseModel
                {
                    Description = "Kayıt başarılı",
                    StatusCode = 200
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
