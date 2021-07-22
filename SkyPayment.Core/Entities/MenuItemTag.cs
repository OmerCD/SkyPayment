using MongoORM4NetCore.Interfaces;

namespace SkyPayment.Core.Entities
{
    public class MenuItemTag:DbObject
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
}