using System.Collections.Generic;


namespace SkyPayment.Shared
{
    public class MenuCreateModel
    {
        public string Name { get; set; }
        public ICollection<MenuItemCreateModel> Items { get; set; }
        public string RestaurantId { get; set; }
    }

    
}