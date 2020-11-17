using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SkyPayment.Core;
using SkyPayment.Core.Entities;
using SkyPayment.Core.Mongo;
using SkyPayment.Infrastructure;
using SkyPayment.Mappings;
using SkyPayment.Repository;

namespace SkyPayment.Client.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "SkyPayment.Client.API", Version = "v1"});
            });
            services.Configure<Settings>(Configuration);
            services.AddMediatR(typeof(Domain.Domain));
            services.AddRepositories(typeof(BaseEntity));
            services.AddServices();
            services.AddMvc().AddFluentValidation(configuration =>
            {
                configuration.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
                configuration.RegisterValidatorsFromAssemblyContaining<Startup>();
            });
            services.AddScoped(x =>
                new SkyPaymentContext(x.GetRequiredService<IOptions<Settings>>().Value));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Token:Issuer"],
                        ValidAudience = Configuration["Token:Issuer"],
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecretKey"]))
                    };
                });

            services.AddAutoMapper(typeof(MappingProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SkyPayment.Client.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}