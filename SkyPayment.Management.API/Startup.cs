using System.Text;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SkyPayment.Core;
using SkyPayment.Core.Mongo;
using SkyPayment.Core.Entities;
using SkyPayment.Infrastructure;
using SkyPayment.Mappings;
using SkyPayment.Repository;

namespace SkyPayment.Management.API
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
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddControllers();
            services.Configure<Settings>(Configuration);
            services.AddRepositories(typeof(BaseEntity));
            services.AddServices();
            services.AddMediatR(typeof(Domain.Domain));
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<SkyPaymentContext>(x =>
                new SkyPaymentContext(x.GetRequiredService<IOptions<Settings>>().Value));
            services.AddSwaggerGen();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("PersonnelRole", builder => builder.RequireRole("Management","Personnel"));
                options.AddPolicy("ManagementRole", builder => builder.RequireRole("Management"));
            });
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("ApiCorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SkyPayment");
            });
        }
    }
}