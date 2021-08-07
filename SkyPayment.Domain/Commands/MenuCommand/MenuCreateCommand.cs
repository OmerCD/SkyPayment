using System.Collections.Generic;
using MediatR;
using SkyPayment.Shared;

namespace SkyPayment.Domain.Commands
{
    public class MenuCreateCommand:IRequest<bool>
    {
        public string Name { get; set; }
        public ICollection<MenuItemCreateModel> Items { get; set; }
        public IEnumerable<string> RestaurantId { get; set; }
        public string ManagerId { get; set; }
        

        public MenuCreateCommand(string name, ICollection<MenuItemCreateModel> items, IEnumerable<string> restaurantId, string managerId)
        {
            Name = name;
            Items = items;
            RestaurantId = restaurantId;
            ManagerId = managerId;
            
        }
    }
}