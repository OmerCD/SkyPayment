using System.Collections.Generic;
using SkyPayment.Core.Entities;

namespace SkyPayment.Shared.Order
{
    public class OrderCreateModel
    {
        public string RestaurantId { get; set; }
        public short TableNumber { get; set; }
        public ICollection<MenuItemResponse> OrderList { get; set; }
        public double Price { get; set; }
    }
}