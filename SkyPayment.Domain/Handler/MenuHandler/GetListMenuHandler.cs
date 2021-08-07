using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;
using MediatR;
using SkyPayment.Domain.Queries.MenuQueries;
using SkyPayment.Infrastructure.Services;
using SkyPayment.Shared;

namespace SkyPayment.Domain.Handler
{
    public class GetListMenuHandler:IRequestHandler<GetMenuListQueries,MenuListResponse>
    {
        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;

        public GetListMenuHandler(IMenuService menuService, IMapper mapper)
        {
            _menuService = menuService;
            _mapper = mapper;
        }

        public Task<MenuListResponse> Handle(GetMenuListQueries request, CancellationToken cancellationToken)
        {
            var allMenus = _menuService.GetAllMenus();
            var menuList = allMenus.Select(x =>new 
            {
                x.Id,
                x.Name
            });
            return Task.FromResult<MenuListResponse>(_mapper.Map<MenuListResponse>(menuList));
        }
    }
}