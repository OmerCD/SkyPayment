using System.Threading;
using System.Threading.Tasks;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Domain.Commands.MenuCommand;
using SkyPayment.Infrastructure.Interface;

namespace SkyPayment.Domain.Handlers
{
    public class DeleteMenuHandler:IBaseRequestHandler<DeleteMenuCommand>
    {
        private readonly IMenuService _menuService;

        public DeleteMenuHandler(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public Task<BaseResponseModel> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult<BaseResponseModel>(new BaseResponseModel());
        }
    }
}