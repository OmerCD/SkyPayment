using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace SkyPayment.Infrastructure.Extensions
{
    public static class DIExtensions
    {
        public static IServiceCollection AddMongoClient(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IMongoClient>(provider => new MongoClient(connectionString));
            return services;
        }
    }
}