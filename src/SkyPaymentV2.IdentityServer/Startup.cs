// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SkyPaymentV2.Core.Entities.EF.Identity;
using SkyPaymentV2.IdentityServer.DbContext;

namespace SkyPaymentV2.IdentityServer
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get;}

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // uncomment, if you want to add an MVC-based UI
            //services.AddControllersWithViews();

            var builder = services.AddIdentityServer(options =>
            {
                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
            })
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryClients(Config.Clients);
            // services.AddDbContext<IdentityDbContext>(optionsBuilder => optionsBuilder.UseSqlServer(Configuration.GetConnectionString("MsSql")));
            services.AddDbContext<IdentityDbContext>(optionsBuilder => optionsBuilder.UseSqlite("Data Source=identity.db"))
                .AddIdentity<User,UserRole>()
                .AddEntityFrameworkStores<IdentityDbContext>();
            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();
        }

        public void Configure(IApplicationBuilder app,RoleManager<UserRole> roleManager, UserManager<User> userManager)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // uncomment if you want to add MVC
            //app.UseStaticFiles();
            //app.UseRouting();
            SeedData(roleManager, userManager).Wait();
            app.UseIdentityServer();

            // uncomment, if you want to add MVC
            //app.UseAuthorization();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapDefaultControllerRoute();
            //});
        }

        public static async Task SeedData(RoleManager<UserRole> roleManager, UserManager<User> userManager)
        {
            await SeedRoles(roleManager);
            await SeedDefaultUsers(userManager);
        }

        public static async Task SeedRoles(RoleManager<UserRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Customer"))
            {
                var customerRole = new UserRole()
                {
                    Name = "Customer"
                };
                await roleManager.CreateAsync(customerRole);
            }
            if (!await roleManager.RoleExistsAsync("Personnel"))
            {
                var customerRole = new UserRole()
                {
                    Name = "Personnel"
                };
                await roleManager.CreateAsync(customerRole);
            }
            if (!await roleManager.RoleExistsAsync("Manager"))
            {
                var customerRole = new UserRole()
                {
                    Name = "Manager"
                };
                await roleManager.CreateAsync(customerRole);
            }
        }

        public static async Task SeedDefaultUsers(UserManager<User> userManager)
        {
            if (await userManager.FindByNameAsync("customer1") == null)
            {
                var user = new User()
                {
                    UserName = "customer1",
                    Email = "customer1@test.com",
                    Name = "Cust",
                    Surname = "Omer"
                };
                var result = await userManager.CreateAsync(user, "123456Customer!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Customer");
                }
            }
            if (await userManager.FindByNameAsync("personnel1") == null)
            {
                var user = new User()
                {
                    UserName = "personnel1",
                    Email = "personnel1@test.com",
                    Name = "Person",
                    Surname = "Nel"
                };
                var result = await userManager.CreateAsync(user, "123456Personnel!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Personnel");
                }
            }
            if (await userManager.FindByNameAsync("manager1") == null)
            {
                var user = new User()
                {
                    UserName = "manager1",
                    Email = "manager1@test.com",
                    Name = "Mana",
                    Surname = "Ger"
                };
                var result = await userManager.CreateAsync(user, "123456Manager!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Manager");
                }
            }
        }
    }
}
