using System.Collections.Generic;
using MediatR;
using SkyPayment.Shared;

namespace SkyPayment.Domain.Queries.MenuQueries
{
    public class GetMenuItemQueries:IRequest<IEnumerable<MenuItemResponse>>
    {
        public string RestaurantId { get; set; }
        public string MenuId { get; set; }
        public string MenuItemId { get; set; }

        public GetMenuItemQueries(string restaurantId, string menuId, string menuItemId)
        {
            RestaurantId = restaurantId;
            MenuId = menuId;
            MenuItemId = menuItemId;
        }
    }
}