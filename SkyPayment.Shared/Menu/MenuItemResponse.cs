using System.Collections.Generic;

namespace SkyPayment.Shared
{
    public class MenuItemResponse
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Ingredients { get; set; }
        public ProductContent ProductContent { get; set; }

    }
    public enum ProductContent
    {
        IsVegan=1,
        IsDiabetic=2,
        IsGlutenFree=4,
        IsVegetarian=8
    }
}