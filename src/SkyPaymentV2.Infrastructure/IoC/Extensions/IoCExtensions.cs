using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using SkyPaymentV2.Core.ValueObjects;

namespace SkyPaymentV2.Infrastructure.IoC.Extensions
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddIdentityOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<IdentityOptions>(configuration.GetSection("IdentityOptions"));
            return services;
        }

        public static IServiceCollection AddIdentityServerWithOptions(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<IdentityOptions>(configuration.GetSection("IdentityOptions"));
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = configuration["ServiceUrls:IdentityServer"];
                    options.TokenValidationParameters = new()
                    {
                        ValidateAudience = false
                    };
                });
            services.AddHttpClient("IdentityServer",
                    client => { client.BaseAddress = new Uri(configuration["ServiceUrls:IdentityServer"]); })
                .AddTransientHttpErrorPolicy(builder =>
                    builder.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(300))
                );
            services.AddIdentityOptions(configuration);
            return services;
        }
    }
}