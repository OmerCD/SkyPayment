using SkyPayment.Contract.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SkyPayment.Core.Entities;
using SkyPayment.Domain.Commands.UserMenuCommand;
using SkyPayment.Infrastructure.Interface;

namespace SkyPayment.Domain.Handlers.UserMenuHandler
{
    public class CreateUserMenuHandler : IBaseRequestHandler<CreateUserMenuCommand>
    {
        private readonly IUserMenuService _userMenuService;

        public CreateUserMenuHandler(IUserMenuService userMenuService)
        {
            _userMenuService = userMenuService;
        }

        public Task<BaseResponseModel> Handle(CreateUserMenuCommand request, CancellationToken cancellationToken)
        {
            _userMenuService.Create(new Menu
            {
                
            });
        }
    }
}
