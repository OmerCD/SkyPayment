using System.Collections.Generic;

namespace SkyPayment.Shared.Restaurant
{
    public class RestaurantUpdateModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<MenuResponseModel> Menus { get; set;}=new List<MenuResponseModel>();
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