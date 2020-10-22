using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Contract.ResponseModel.Restaurant;
using SkyPayment.Domain.CQ.Queries.RestaurantQueries;
using SkyPayment.Infrastructure.Interface;
using SkyPayment.Infrastructure.Services;

namespace SkyPayment.Domain.Handlers.RestaurantHandlers
{
    public class GetRestaurantByIdHandler : IBaseRequestHandler<GetRestaurantByIdQuery>
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;

        public GetRestaurantByIdHandler(IRestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        public Task<BaseResponseModel> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            var restaurant = _restaurantService.GetById(request.ManagementUserId, request.RestaurantId);
            if (restaurant == null)
            {
                return Task.FromResult<BaseResponseModel>(new BaseResponseModel
                {
                    Description = "Restoran bulunamadı",
                    StatusCode = 404
                });
            }
            return Task.FromResult<BaseResponseModel>(new BaseResponseModel
            {
                Data = _mapper.Map<GetRestaurantByIdResponseModel>(restaurant),
                Description = "Restoran bilgisi",
                StatusCode = 200
            });
        }
    }
}