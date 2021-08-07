using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SkyPayment.Domain.Commands;
using SkyPayment.Infrastructure.Services;

namespace SkyPayment.Domain.Handler
{
    public class MenuDeleteHandler:IRequestHandler<MenuDeleteCommand,bool>
    {
        private readonly IMenuService _menuService;

        public MenuDeleteHandler(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public Task<bool> Handle(MenuDeleteCommand request, CancellationToken cancellationToken)
        {
            var deleteMenu = _menuService.DeleteMenu(request.Id);
            return Task.FromResult(deleteMenu);
        }
    }
}