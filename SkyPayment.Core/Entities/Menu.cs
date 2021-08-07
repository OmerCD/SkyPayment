using System.Collections.Generic;
using MongoORM4NetCore.Interfaces;

namespace SkyPayment.Core.Entities
{
    public class Menu:DbObject
    {
        public string Name { get; set; }
        public ICollection<MenuItem> Items { get; set; }
        public ICollection<string> RestaurantId { get; set; }
        public string ManagerId { get; set; }
        
    }
}