using System.Collections.Generic;
using MediatR;
using SkyPayment.Shared.Restaurant;

namespace SkyPayment.Domain.Queries.RestaurantQueries
{
    public class GetAllRestaurantQueries: IRequest<IEnumerable<RestaurantListModel>>
    {
        public GetAllRestaurantQueries(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}