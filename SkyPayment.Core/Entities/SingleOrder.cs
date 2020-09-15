using System;

namespace SkyPayment.Core.Entities
{
    public class SingleOrder : IDatedEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public MenuItem MenuItem { get; set; }
        public double Price { get; set; }
    }
}