using System.Collections.Generic;
using MediatR;
using SkyPayment.Shared;

namespace SkyPayment.Domain.Commands
{
    public class MenuCreateCommand:IRequest<bool>
    {
        public string Name { get; set; }
        public ICollection<MenuItemCreateModel> Items { get; set; }
        public string RestaurantId { get; set; }

        public MenuCreateCommand(string name, ICollection<MenuItemCreateModel> items, string restaurantId)
        {
            Name = name;
            Items = items;
            RestaurantId = restaurantId;
        }
    }
}