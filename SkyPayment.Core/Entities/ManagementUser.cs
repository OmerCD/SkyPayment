using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace SkyPayment.Core.Entities
{
    public class ManagementUser:UserEntity
    {
        public override string Role { get; set; } = "Management";
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string NormalizedUserName { get; set; }
        public ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
        public ICollection<Menu> ManagementMenus { get; set; } = new List<Menu>();
        [BsonIgnore] public string FullName => $"{Name} {LastName}";
    }
}