﻿using MongoDB.Driver;
using SkyPayment.Core.Entities;

namespace SkyPayment.Core.Mongo
{
    public class SkyPaymentContext
    {
        private readonly IMongoDatabase _database;

        public SkyPaymentContext(Settings settings)
        {
            _database = new MongoClient(settings.MongoDbConnectionString).GetDatabase("SkyPaymentDb");
        }

        public IMongoCollection<T> Get<T>()
        {
            return _database.GetCollection<T>(nameof(T));
        }
        public void Test()
        {
            var collection = _database.GetCollection<Restaurant>(nameof(Restaurant));
            collection.InsertOne(new Restaurant(){Email = "test"});
        }
    }
}