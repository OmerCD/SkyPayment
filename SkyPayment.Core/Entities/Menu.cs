using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SkyPayment.Core.Entities
{
    public class Menu : DatedEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }
        public string Name { get; set; }
        public ICollection<MenuItem> Items { get; set; }
        public string ManagementUserId { get; set; }

    }
}