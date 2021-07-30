namespace SkyPayment.Shared
{
    public class MenuItemCreateModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Ingredients { get; set; }
        public ProductContent ProductContent { get; set; }
    }
}