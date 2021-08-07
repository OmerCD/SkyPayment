using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;
using MediatR;
using SkyPayment.Core.Entities;
using SkyPayment.Domain.Commands.RestaurantCommand;
using SkyPayment.Infrastructure.Services;

namespace SkyPayment.Domain.Handler.RestaurantHandler
{
    public class RestaurantCreateHandler:IRequestHandler<RestaurantCreateCommand,bool>
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;

        public RestaurantCreateHandler(IRestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }
        public Task<bool> Handle(RestaurantCreateCommand request, CancellationToken cancellationToken)
        {
            var restaurant = _mapper.Map<Restaurant>(request);
            var b = _restaurantService.CreateRestaurant(restaurant);
            return Task.FromResult<bool>(b);
        }
    }
}