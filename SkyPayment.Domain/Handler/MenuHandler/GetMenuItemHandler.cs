using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;
using MediatR;
using SkyPayment.Domain.Queries.MenuQueries;
using SkyPayment.Infrastructure.Services;
using SkyPayment.Shared;

namespace SkyPayment.Domain.Handler
{
    public class GetMenuItemHandler:IRequestHandler<GetMenuItemQueries,IEnumerable<MenuItemResponse>>
    {
        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;

        public GetMenuItemHandler(IMenuService menuService, IMapper mapper)
        {
            _menuService = menuService;
            _mapper = mapper;
        }

        public Task<IEnumerable<MenuItemResponse>> Handle(GetMenuItemQueries request, CancellationToken cancellationToken)
        {
            var menuItems = _menuService.GetMenuItems(request.RestaurantId,request.MenuId,request.MenuItemId);
            var menuItemResponses = _mapper.Map<IEnumerable<MenuItemResponse>>(menuItems);
            return Task.FromResult(menuItemResponses);
        }
    }
}