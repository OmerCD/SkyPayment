using System.Collections.Generic;


namespace SkyPayment.Shared
{
    public class MenuCreateModel
    {
        public string Name { get; set; }
        public ICollection<MenuItemCreateModel> Items { get; set; }
        public IEnumerable<string> RestaurantId { get; set; }
        public string ManagerId { get; set; }
    }

    
}