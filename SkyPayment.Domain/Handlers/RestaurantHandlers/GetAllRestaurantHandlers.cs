using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Core.Entities;
using SkyPayment.Domain.CQ.Queries;
using SkyPayment.Infrastructure.Interface;
using SkyPayment.Infrastructure.Services;

namespace SkyPayment.Domain.Handlers
{
    public class GetAllRestaurantHandlers : IRequestHandler<GetAllRestaurantQuery, IEnumerable<RestaurantResponseModel>>
    {
        private readonly IRestaurantService _restaurantService;
        public GetAllRestaurantHandlers(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public async  Task<IEnumerable<RestaurantResponseModel>> Handle(GetAllRestaurantQuery request,
            CancellationToken cancellationToken)
        {
            var allRestaurant = _restaurantService.GetManagementUserRestaurants(request.UserId).Select(Build);
            return allRestaurant;
        }

        private RestaurantResponseModel Build(Restaurant restaurant)
        {
            return new RestaurantResponseModel
            {
                Address = restaurant.Address,
                Email = restaurant.Email,
                Name = restaurant.Name,
                Website = restaurant.Website,
                FaxNumber = restaurant.FaxNumber,
                PhoneNumber = restaurant.PhoneNumber,
                Id = restaurant.Id
            };
        }
    }
}