using System.Collections.Generic;
using MediatR;
using SkyPayment.Contract.ResponseModel;

namespace SkyPayment.Domain.CQ.Queries
{
    public class GetAllRestaurantQuery: IRequest<IEnumerable<RestaurantResponseModel>>
    {
        public GetAllRestaurantQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }

        
    }
}