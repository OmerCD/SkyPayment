using System;
using Microsoft.Extensions.DependencyInjection;
using SkyPayment.Infrastructure.Services;

namespace SkyPayment.Infrastructure.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<IScopedService>().FromAssemblyOf<MenuService>()
                .AddClasses(classes => classes.AssignableTo<IScopedService>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            return services;
        }
    }
}