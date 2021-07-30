using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;
using MediatR;
using SkyPayment.Core.Entities;
using SkyPayment.Domain.Commands;
using SkyPayment.Infrastructure.Services;
using SkyPayment.Shared;

namespace SkyPayment.Domain.Handler
{
    public class MenuCreateHandler:IRequestHandler<MenuCreateCommand,bool>
    {
        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;

        public MenuCreateHandler(IMenuService menuService, IMapper mapper)
        {
            _menuService = menuService;
            _mapper = mapper;
        }

        public Task<bool> Handle(MenuCreateCommand request, CancellationToken cancellationToken)
        {
            var menu = _mapper.Map<Menu>(request);
         ;
            return  Task.FromResult(_menuService.CreateMenu(menu));
        }
    }
}