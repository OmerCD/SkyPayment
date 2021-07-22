using System.Collections.Generic;


namespace SkyPayment.Shared
{
    public class MenuResponseModel
    {
        public string Name { get; set; }
        public ICollection<MenuItemResponse> Items { get; set; }
        public string ManagementUserId { get; set; }
        
    }
}