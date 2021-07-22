// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using System.Linq;
using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using SkyPayment.IdentityService.Data;
using SkyPayment.IdentityService.Models;

namespace SkyPayment.IdentityService
{
    public class SeedData
    {
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                IdentityRole userRole = null;
                IdentityRole personnelRole = null;
                IdentityRole managerRole = null;
                using (var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>())
                {
                    IdentityRole AddRole(string roleName)
                    {
                        var role = roleManager.FindByNameAsync(roleName).Result;
                        if (role != null) return role;
                        role = new IdentityRole()
                        {
                            Name = roleName
                        };
                        roleManager.CreateAsync(role).Wait();
                        return role;
                    }
                    userRole = AddRole("user");
                    personnelRole = AddRole("personnel");
                    managerRole = AddRole("manager");
                }
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                    context.Database.Migrate();

                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var alice = userMgr.FindByNameAsync("alice").Result;
                    if (alice == null)
                    {
                        alice = new ApplicationUser
                        {
                            UserName = "alice",
                            Email = "AliceSmith@email.com",
                            EmailConfirmed = true
                        };
                        var result = userMgr.CreateAsync(alice, "Pass123$").Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        result = userMgr.AddClaimsAsync(alice, new Claim[]
                        {
                            new Claim(JwtClaimTypes.Name, "Alice Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Alice"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                            new Claim(JwtClaimTypes.Role, userRole.Name),
                        }).Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        Log.Debug("alice created");
                    }
                    else
                    {
                        Log.Debug("alice already exists");
                    }

                    var bob = userMgr.FindByNameAsync("bob").Result;
                    if (bob == null)
                    {
                        bob = new ApplicationUser
                        {
                            UserName = "bob",
                            Email = "BobSmith@email.com",
                            EmailConfirmed = true
                        };
                        var result = userMgr.CreateAsync(bob, "Pass123$").Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        result = userMgr.AddClaimsAsync(bob, new Claim[]
                        {
                            new Claim(JwtClaimTypes.Name, "Bob Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Bob"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                            new Claim(JwtClaimTypes.Role, personnelRole.Name),
                            new Claim("location", "somewhere")
                        }).Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        Log.Debug("bob created");
                    }
                    else
                    {
                        Log.Debug("bob already exists");
                    }
                    var jhon = userMgr.FindByNameAsync("jhon").Result;
                    if (jhon == null)
                    {
                        jhon = new ApplicationUser
                        {
                            UserName = "jhon",
                            Email = "BobSmith@email.com",
                            EmailConfirmed = true
                        };
                        var result = userMgr.CreateAsync(jhon, "Pass123$").Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        result = userMgr.AddClaimsAsync(jhon, new Claim[]
                        {
                            new Claim(JwtClaimTypes.Name, "Jhon Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Jhon"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.WebSite, "http://jhon.com"),
                            new Claim(JwtClaimTypes.Role, managerRole.Name),
                            new Claim("location", "somewhere")
                        }).Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        Log.Debug("jhon created");
                    }
                    else
                    {
                        Log.Debug("jhon already exists");
                    }

                    if (!userMgr.IsInRoleAsync(alice, userRole.Name).Result)
                    {
                        userMgr.AddToRoleAsync(alice, userRole.Name).Wait();
                    }
                    if (!userMgr.IsInRoleAsync(bob, personnelRole.Name).Result)
                    {
                        userMgr.AddToRoleAsync(bob, personnelRole.Name).Wait();
                    }
                    if (!userMgr.IsInRoleAsync(jhon, managerRole.Name).Result)
                    {
                        userMgr.AddToRoleAsync(jhon, managerRole.Name).Wait();
                    }
                }
            }
        }
    }
}