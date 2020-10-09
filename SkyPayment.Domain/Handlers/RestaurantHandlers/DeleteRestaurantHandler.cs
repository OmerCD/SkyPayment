using System.Threading;
using System.Threading.Tasks;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Domain.Command;
using SkyPayment.Infrastructure.Interface;

namespace SkyPayment.Domain.Handlers
{
    public class DeleteRestaurantHandler : IBaseRequestHandler<DeleteRestaurantCommand>
    {
        private readonly IRestaurantService _restaurantService;

        public DeleteRestaurantHandler(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public Task<BaseResponseModel> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var result = _restaurantService.DeleteRestaurant(request.ManagementUserId, request.RestaurantId);
            if (result)
            {
                return Task.FromResult<BaseResponseModel>(new BaseResponseModel
                {
                    StatusCode = 200,
                    Description = "Resoran Silindi"
                });
            }
            return Task.FromResult<BaseResponseModel>(new BaseResponseModel
            {
                StatusCode = 404,
                Description = "Restoran bulunamadı"
            });
        }
    }
}