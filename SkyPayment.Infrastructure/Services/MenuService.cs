using System.Collections;
using System.Collections.Generic;
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
            var test=  _menu.GetAll(new BsonDocument {{"RestaurantId", restaurantId}, {"Id", menuId}});
            return test;
        }

        public bool CreateMenu(Menu menu)
        {
            return _menu.Insert(menu);
        }

        public IEnumerable<MenuItem> GetMenuItems(string restaurantId, string menuId, string menuItemId)
        {
            // var filter = Builders<Menu>.Filter.Eq(x => x.RestaurantId, restaurantId) & Builders<Menu>.Filter.Eq(x=>x.Id, menuId).ToBsonDocument();
            var menus = _menu.Search(x=>x.RestaurantId==restaurantId && x.Id==menuId);
            var menuItems = menus.SelectMany(x=>x.Items).Where(x=>x.Id==menuItemId);
            return menuItems;
        }
    }
}