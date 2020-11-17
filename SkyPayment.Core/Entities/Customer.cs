using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace SkyPayment.Core.Entities
{
    public class Customer : UserEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<Order> CurrentOrders { get; set; }
        public ICollection<Order> PreviousOrders { get; set; }
        public ICollection<PaymentMethod> PaymentMethods { get; set; }
        public override string Role { get; set; } = "Customer";
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        [BsonIgnore] public string FullName => Name + ' ' + LastName;
    }
}