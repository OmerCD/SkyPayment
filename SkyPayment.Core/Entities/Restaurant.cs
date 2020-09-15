using System;
using System.Collections.Generic;

namespace SkyPayment.Core.Entities
{
    public class Restaurant : IDatedEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<MenuItem> Menu { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public ICollection<MenuItemTag> AvailableTags { get; set; }
    }
}