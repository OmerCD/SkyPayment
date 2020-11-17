using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SkyPayment.Infrastructure.Interface;
using SkyPayment.Infrastructure.Services;

namespace SkyPayment.Infrastructure
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            var type = typeof(IService);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface);
            foreach (var serviceType in types)
            {
                var interfaceType = serviceType.GetInterfaces().FirstOrDefault();
                services.AddScoped(interfaceType, serviceType);
            }

            services.AddSingleton<ISecurePasswordHasherService, SecurePasswordHasherService>(provider =>
                new SecurePasswordHasherService(16, 20, 10000));

            return services;
        }
    }
}