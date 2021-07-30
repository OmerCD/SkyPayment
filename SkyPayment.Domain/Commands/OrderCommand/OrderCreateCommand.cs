using System.Collections.Generic;
using MediatR;
using SkyPayment.Core.Entities;

namespace SkyPayment.Domain.Commands.OrderCommand
{
    public class OrderCreateCommand:IRequest<bool>
    {
        public string RestaurantId { get; set; }
        public short TableNumber { get; set; }
        public ICollection<MenuItem> OrderList { get; set; }
        public double Price { get; set; }
        public OrderCreateCommand(string restaurantId, short tableNumber, ICollection<MenuItem> orderList, double price)
        {
            RestaurantId = restaurantId;
            TableNumber = tableNumber;
            OrderList = orderList;
            Price = price;
        }

      
    }
}