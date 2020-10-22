using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Contract.ResponseModel.Restaurant;
using SkyPayment.Domain.CQ.Queries.RestaurantQueries;
using SkyPayment.Infrastructure.Interface;

namespace SkyPayment.Domain.Handlers.RestaurantHandlers
{
    public class GetAllRestaurantForDisplayHandler : IBaseRequestHandler<GetAllRestaurantForDisplayQuery>
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;

        public GetAllRestaurantForDisplayHandler(IRestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        public Task<BaseResponseModel> Handle(GetAllRestaurantForDisplayQuery request, CancellationToken cancellationToken)
        {
            var managementUserRestaurants = _restaurantService.GetManagementUserRestaurants(request.ManagementUserId);
            return Task.FromResult(new BaseResponseModel
            {
                Data = _mapper.Map<IEnumerable<GetRestaurantForDisplayViewModel>>(managementUserRestaurants),
                Description = "Restorant listesi",
                StatusCode = 200
            });
        }
    }
}