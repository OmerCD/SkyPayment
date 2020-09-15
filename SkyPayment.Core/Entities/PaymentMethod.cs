using System;

namespace SkyPayment.Core.Entities
{
    public class PaymentMethod : IEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
    }
}