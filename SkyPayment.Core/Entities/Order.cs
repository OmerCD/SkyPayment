using System.Collections.Generic;
using MongoORM4NetCore.Interfaces;

namespace SkyPayment.Core.Entities
{
    public class Order:DbObject
    {
        public string RestaurantId { get; set; }
        public short TableNumber { get; set; }
        public ICollection<MenuItem> OrderList { get; set; }
        public double Price { get; set; }
    }
}