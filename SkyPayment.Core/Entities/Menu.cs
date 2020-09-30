using System.Collections.Generic;

namespace SkyPayment.Core.Entities
{
    public class Menu : DatedEntity
    {
        public string Name { get; set; }
        public ICollection<MenuItem> Items { get; set; }
    }
}