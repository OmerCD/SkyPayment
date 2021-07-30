using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkyPayment.Core.Entities;
using SkyPayment.Infrastructure.Extensions;
using SkyPayment.Shared;

namespace SkyPayment.Infrastructure.Services
{
    public interface IMenuService:IScopedService
    {
        IEnumerable<Menu> GetAllMenus();
        IEnumerable<Menu> GetAllMenusByRestaurant(string restaurantId, string menuId);
        bool CreateMenu(Menu menu);
        IEnumerable<MenuItem> GetMenuItems(string restaurantId, string menuId, string menuItemId);
    }
}