using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SkyPayment.Domain.Commands.RestaurantCommand;
using SkyPayment.Infrastructure.Services;

namespace SkyPayment.Domain.Handler.RestaurantHandler
{
    public class RestaurantDeleteHandler : IRequestHandler<RestaurantDeleteCommand,bool>
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantDeleteHandler(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public Task<bool> Handle(RestaurantDeleteCommand request, CancellationToken cancellationToken)
        {
            var deleteRestaurant = _restaurantService.DeleteRestaurant(request.Id);
            return Task.FromResult(deleteRestaurant);
        }
    }
}