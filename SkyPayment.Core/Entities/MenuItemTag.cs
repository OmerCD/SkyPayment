using System;

namespace SkyPayment.Core.Entities
{
    public class MenuItemTag : IEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}