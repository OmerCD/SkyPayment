using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;
using MediatR;
using SkyPayment.Domain.Queries.RestaurantQueries;
using SkyPayment.Infrastructure.Services;
using SkyPayment.Shared.Restaurant;

namespace SkyPayment.Domain.Handler.RestaurantHandler
{
    public class GetAllRestaurantHandler:IRequestHandler<GetAllRestaurantQueries,IEnumerable<RestaurantListModel>>
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;

        public GetAllRestaurantHandler(IRestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        public Task<IEnumerable<RestaurantListModel>> Handle(GetAllRestaurantQueries request, CancellationToken cancellationToken)
        {
            var allRestaurants = _restaurantService.GetAllRestaurants(request.UserId);
            var restaurantListModel = _mapper.Map<IEnumerable<RestaurantListModel>>(allRestaurants);
            return Task.FromResult(restaurantListModel);
        }
    }
}