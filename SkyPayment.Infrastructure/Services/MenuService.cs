using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;
using MongoORM4NetCore.Interfaces;
using SkyPayment.Core.Entities;
using SkyPayment.Shared;

namespace SkyPayment.Infrastructure.Services
{
    public class MenuService:IMenuService
    {
        private readonly IRepository<Menu> _menu;

        public MenuService(IRepository<Menu> menu)
        {
            _menu = menu;
        }

        public  IEnumerable<Menu> GetAllMenus()
        {
            
            return   _menu.GetAll(new BsonDocument());
        }

        public IEnumerable<Menu> GetAllMenusByRestaurant(string restaurantId, string menuId)
        {
            return _menu.Search(x => x.RestaurantId.FirstOrDefault() == restaurantId && x.Id == menuId);
        }

        public IEnumerable<Menu> GetAllMenusByManager(string managerId)
        {
            return _menu.Search(x => x.ManagerId==managerId);
        }


        public bool CreateMenu(Menu menu)
        {
            return _menu.Insert(menu);
        }

        public IEnumerable<MenuItem> GetMenuItems(string restaurantId, string menuId, string menuItemId)
        {
            
            var menus = _menu.Search(x=>x.RestaurantId.Contains(restaurantId) && x.Id==menuId);
            var menuItems = menus.SelectMany(x=>x.Items).Where(x=>x.Id==menuItemId);
            return menuItems;
        }

        public bool UpdateMenu(Menu menu)
        {
            return _menu.Update(menu);
        }

        public bool DeleteMenu(string id)
        {
            return _menu.Delete(id);
        }
    }
}