using System.Collections.Generic;
using MongoORM4NetCore.Interfaces;

namespace SkyPayment.Core.Entities
{
    public class Restaurant:DbObject
    {
   
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Menu> Menus { get; set;}=new List<Menu>();
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string ManagementUserId { get; set; }
      
        public int TableCount { get; set; }
        public string Link { get; set; }
    }
}