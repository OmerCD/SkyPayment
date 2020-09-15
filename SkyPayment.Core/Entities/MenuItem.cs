using System;
using System.Collections.Generic;

namespace SkyPayment.Core.Entities
{
    public class MenuItem : IDatedEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Ingredients { get; set; }
        public bool IsVegan { get; set; }
        public bool IsDiabetic { get; set; }
        public bool IsGlutenFree { get; set; }
        public bool IsVegetarian { get; set; }
        public ICollection<MenuItemTag> Tags { get; set; }
        public int TagValue { get; set; }
    }
}