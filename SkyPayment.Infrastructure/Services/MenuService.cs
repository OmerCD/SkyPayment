using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoORM4NetCore.Interfaces;
using SkyPayment.Core.Entities;

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
    }
}