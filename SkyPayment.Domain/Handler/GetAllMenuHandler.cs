using System.ComponentModel.Design;
using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;
using MediatR;
using SkyPayment.Core.Entities;
using SkyPayment.Domain.Queries.MenuQueries;
using SkyPayment.Infrastructure.Services;
using SkyPayment.Shared;

namespace SkyPayment.Domain.Handler
{
    public class GetAllMenuHandler:IRequestHandler<GetAllMenuQueries, MenuResponseModel>
    {
        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;
        public GetAllMenuHandler(IMenuService menuService, IMapper mapper)
        {
            _menuService = menuService;
            _mapper = mapper;
        }

        public  Task<MenuResponseModel> Handle(GetAllMenuQueries request, CancellationToken cancellationToken)
        {
            var allMenus = _menuService.GetAllMenus();
            return   Task.FromResult<MenuResponseModel>(_mapper.Map<MenuResponseModel>(allMenus));
        }
    }
}