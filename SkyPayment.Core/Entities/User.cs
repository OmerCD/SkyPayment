using MongoORM4NetCore.Interfaces;

namespace SkyPayment.Core.Entities
{
    public class User:DbObject
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}