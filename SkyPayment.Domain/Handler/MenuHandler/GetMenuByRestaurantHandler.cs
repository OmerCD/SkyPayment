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
    public class GetMenuByRestaurantHandler:IRequestHandler<GetMenuByRestaurantQueries,MenuResponseModel>
    {
        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;

        public GetMenuByRestaurantHandler(IMapper mapper, IMenuService menuService)
        {
            _mapper = mapper;
            _menuService = menuService;
        }

        public Task<MenuResponseModel> Handle(GetMenuByRestaurantQueries request, CancellationToken cancellationToken)
        {
            var allMenusByRestaurant = _menuService.GetAllMenusByRestaurant(request.RestaurantId,request.MenuId);
            var menuResponseModels = _mapper.Map<MenuResponseModel>(allMenusByRestaurant);
            menuResponseModels.Id = request.MenuId;
            
            return Task.FromResult(menuResponseModels);
        }
    }
}