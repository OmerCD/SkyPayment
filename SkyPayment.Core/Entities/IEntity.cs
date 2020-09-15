using System;
using MongoDB.Bson.Serialization.Attributes;

namespace SkyPayment.Core.Entities
{
    public interface IEntity
    {
        [BsonId]
        Guid Id { get; set; }
        bool IsDeleted { get; set; }
    }

    public interface IDatedEntity : IEntity
    {
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
    }
}