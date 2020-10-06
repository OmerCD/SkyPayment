using System;
using System.Collections.Generic;

namespace SkyPayment.Core.Entities
{
    public class Order : DatedEntity
    {
        public Guid RestaurantId { get; set; }
        public short TableNumber { get; set; }
        public ICollection<SingleOrder> OrderList { get; set; }
        public double Price { get; set; }
    }
}