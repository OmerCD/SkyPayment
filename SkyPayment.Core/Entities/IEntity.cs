﻿using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SkyPayment.Core.Entities
{
    public abstract class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
    }

    public abstract class DatedEntity : BaseEntity
    {
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }

    public abstract class UserEntity : DatedEntity
    {
        public abstract string Role { get; set; }
    }

    public class ManagementUser:UserEntity
    {
        public override string Role { get; set; } = "Management";
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}