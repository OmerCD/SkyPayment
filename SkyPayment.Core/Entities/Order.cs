using System;
using System.Collections.Generic;

namespace SkyPayment.Core.Entities
{
    public class Order : IDatedEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid RestaurantId { get; set; }
        public ICollection<SingleOrder> OrderList { get; set; }
        public double Price { get; set; }
    }
}