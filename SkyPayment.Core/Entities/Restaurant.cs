using System;
using System.Collections.Generic;

namespace SkyPayment.Core.Entities
{
    public class Restaurant : DatedEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Menu> Menus { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public ICollection<MenuItemTag> AvailableTags { get; set; }
    }
}