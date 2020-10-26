using System;
using System.Threading;
using System.Threading.Tasks;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Domain.CQ.Queries.MenuQueries;
using SkyPayment.Infrastructure.Interface;

namespace SkyPayment.Domain.Handlers.MenuHandlers
{
    public class GetRestaurantMenuHandler : IBaseRequestHandler<GetRestaurantMenuQuery>
    {
        private readonly IMenuService _menuService;

        public GetRestaurantMenuHandler(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public Task<BaseResponseModel> Handle(GetRestaurantMenuQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}