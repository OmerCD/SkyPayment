using System.Collections.Generic;

namespace SkyPayment.Shared
{
    public class MenuItemResponse
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Ingredients { get; set; }
        public ProductContent ProductContent { get; set; }
        public ICollection<MenuItemTagResponse> Tags { get; set; }
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