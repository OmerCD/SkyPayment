using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace SkyPayment.API.DependencyInjectionExtension
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddMapster(this IServiceCollection services)
        {
            var config = new TypeAdapterConfig();
            config.Scan(typeof(Startup).Assembly);
            services.AddScoped<IMapper>(provider => new Mapper(config));
            return services;
        }
    }
}