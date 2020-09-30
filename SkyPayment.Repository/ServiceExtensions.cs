using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SkyPayment.Core.Entities;
using SkyPayment.Repository.Interfaces;

namespace SkyPayment.Repository
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, Type domainType)
        {
            var domainTypeAssembly = domainType.Assembly;
            var type = typeof(IEntity);
            
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface);

            foreach (var entityType in types)
            {
                var repositoryType = typeof(Repository<>);
                var genericType = repositoryType.MakeGenericType(entityType);
                var interfaceGenericType = typeof(IRepository<>).MakeGenericType(entityType);
                services.AddScoped(interfaceGenericType, genericType);
            }

            return services;
        }
    }
}