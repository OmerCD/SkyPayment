using System.Collections.Generic;
using MediatR;
using SkyPayment.Shared;

namespace SkyPayment.Domain.Queries.MenuQueries
{
    public class GetMenuByRestaurantQueries:IRequest<MenuResponseModel>
    {
        public string RestaurantId { get; set; }
        public string MenuId { get; set; }

        public GetMenuByRestaurantQueries(string restaurantId, string menuId)
        {
            RestaurantId = restaurantId;
            MenuId = menuId;
        }
    }
}