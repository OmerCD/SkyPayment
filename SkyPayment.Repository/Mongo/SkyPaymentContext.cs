using MongoDB.Driver;

namespace SkyPayment.Core.Mongo
{
    public class SkyPaymentContext
    {
        private readonly IMongoDatabase _database;

        public SkyPaymentContext(Settings settings)
        {
            _database = new MongoClient(settings.MongoDbConnectionString).GetDatabase("SkyPaymentDb");
        }
        
    }
}