using System;
using System.Collections.Generic;
using MediatR;
using SkyPayment.Contract.ResponseModel;

namespace SkyPayment.Domain.Queries
{
    public class GetAllRestaurantQuery: IRequest<IEnumerable<RestaurantResponseModel>>
    {
        public GetAllRestaurantQuery(object userId)
        {
            UserId = userId;
        }

        public object UserId { get; set; }

        
    }
}