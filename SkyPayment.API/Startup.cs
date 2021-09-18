using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoORM4NetCore;
using SkyPayment.Core.Entities;
using SkyPayment.Infrastructure.Extensions;
using Microsoft.OpenApi.Models;
using OhmsND.API.Extensions;
using SkyPayment.Core.Value;
using SkyPayment.Infrastructure.Hubs;
using SkyPayment.Infrastructure.Services;

namespace SkyPayment.API
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
            services.AddIdentityServerAuthentication();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "OhmsND.API", Version = "v1"});
            });
            services.AddOhm(
                Configuration.GetConnectionString("Mongo").Replace("@password", Configuration["Mongo:Password"]), "Orders",
                typeof(Menu));
            services.AddServices();
            services.AddMapster();
            services.Configure<Settings>(Configuration.GetSection("Settings"));
            services.AddMediatR(typeof(Domain.Domain));
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (!env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OhmsND.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
          
            app.UseCors(x =>
                x.AllowAnyHeader().WithOrigins("http://localhost:3000", "http://192.168.31.220:3000").AllowAnyMethod()
                    .AllowCredentials());
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers();
                endpoints.MapHub<OrderHub>("/orderHub");
            });
            
          
        }
    }
}