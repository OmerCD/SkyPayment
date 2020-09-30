using System;

namespace SkyPayment.Core.Entities
{
    public class SingleOrder : DatedEntity
    {
        public MenuItem MenuItem { get; set; }
        public double Price { get; set; }
    }
}