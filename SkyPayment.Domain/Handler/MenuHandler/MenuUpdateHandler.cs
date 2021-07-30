using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;
using MediatR;
using SkyPayment.Core.Entities;
using SkyPayment.Domain.Commands;
using SkyPayment.Infrastructure.Services;

namespace SkyPayment.Domain.Handler
{
    public class MenuUpdateHandler:IRequestHandler<MenuUpdateCommand,bool>
    {
        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;

        public MenuUpdateHandler(IMenuService menuService, IMapper mapper)
        {
            _menuService = menuService;
            _mapper = mapper;
        }

        public Task<bool> Handle(MenuUpdateCommand request, CancellationToken cancellationToken)
        {
            var menu = _mapper.Map<Menu>(request);
            var updateMenu = _menuService.UpdateMenu(menu);
           return  Task.FromResult(updateMenu);
        }
    }
}