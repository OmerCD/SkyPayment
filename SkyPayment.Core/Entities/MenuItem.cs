using System.Collections.Generic;
using MongoORM4NetCore.Interfaces;

namespace SkyPayment.Core.Entities
{
    public class MenuItem:DbObject
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Ingredients { get; set; }
        public ProductContent ProductContent { get; set; }
        public ICollection<MenuItemTag> Tags { get; set; }
        public int TagValue { get; set; }
    }
    public enum ProductContent
    {
        IsVegan,
        IsDiabetic,
        IsGlutenFree,
        IsVegetarian
    }
}