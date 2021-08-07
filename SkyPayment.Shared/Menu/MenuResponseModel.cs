using System.Collections.Generic;


namespace SkyPayment.Shared
{
    public class MenuResponseModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<MenuItemResponse> Items { get; set; }
        public string ManagementUserId { get; set; }
        public IEnumerable<string> RestaurantId { get; set; }

    }


}