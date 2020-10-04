using System.Collections;
using System.Collections.Generic;

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
        public ICollection<Restaurant> Restaurants { get; set; }
    }
}