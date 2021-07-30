using System.Collections.Generic;
using System.Globalization;

namespace SkyPayment.Shared
{
    public class MenuUpdateModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<MenuItemUpdateModel> Items { get; set; }
        public string RestaurantId { get; set; }

    }
}