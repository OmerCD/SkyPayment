using System.Collections.Generic;
using MongoORM4NetCore.Interfaces;

namespace SkyPayment.Core.Entities
{
    public class Menu:DbObject
    {
        public string Name { get; set; }
        public ICollection<MenuItem> Items { get; set; }
        public string ManagementUserId { get; set; }
    }
}