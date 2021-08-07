using System.Collections.Generic;

namespace SkyPayment.Shared.Restaurant
{
    public class RestaurantCreateModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        //public ICollection<MenuCreateModel> Menus { get; set;}=new List<MenuCreateModel>();
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string ManagementUserId { get; set; }
        public int TableCount { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
    }
}