using System;
using System.Collections.Generic;

namespace SkyPayment.Core.Entities
{
    public class Customer : IDatedEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<Order> CurrentOrders { get; set; }
        public ICollection<Order> PreviousOrders { get; set; }
        public ICollection<PaymentMethod> PaymentMethods { get; set; }
    }
}