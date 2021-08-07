using System.Collections.Generic;
using System.Globalization;
using MediatR;
using SkyPayment.Shared;

namespace SkyPayment.Domain.Commands
{
    public class MenuUpdateCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<MenuItemUpdateModel> Items { get; set; }
        public string RestaurantId { get; set; }

        public MenuUpdateCommand(string name, ICollection<MenuItemUpdateModel> items, string restaurantId, string id)
        {
            Id = id;
            Name = name;
            Items = items;
            RestaurantId = restaurantId;
            Id = id;
        }
    }
}