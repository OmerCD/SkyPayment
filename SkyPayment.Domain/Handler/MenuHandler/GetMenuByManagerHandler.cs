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
    public class GetMenuByManagerHandler:IRequestHandler<GetMenuByManagerIdQueries,IEnumerable<MenuResponseModel>>
    {
        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;

        public GetMenuByManagerHandler(IMapper mapper, IMenuService menuService)
        {
            _mapper = mapper;
            _menuService = menuService;
        }

        public Task<IEnumerable<MenuResponseModel>> Handle(GetMenuByManagerIdQueries request, CancellationToken cancellationToken)
        {
            var allMenusByManager = _menuService.GetAllMenusByManager(request.ManagerId);
            var menuResponseModels = _mapper.Map<IEnumerable<MenuResponseModel>>(allMenusByManager);
            return Task.FromResult(menuResponseModels);
        }
    }

}