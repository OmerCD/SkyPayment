// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace SkyPaymentV2.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("userApi", "User Api"),
                new ApiScope("managerApi", "Manager Api"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client()
                {
                    ClientId = "customer",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets =
                    {
                        new Secret(@"mXRATs<#UF<QTp_'Z4PM~4`J;Qwkg-\v".Sha256())
                    },
                    AllowedScopes = {"userApi"}
                },
                new Client()
                {
                    ClientId = "manager",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets =
                    {
                        new Secret(@"xiWfKS}BI_*[>=Awqs)D<XbUw-*um-k}Gn_{{j%DS]f/c%alamn*uEtzqrGHSwR".Sha256())
                    },
                    AllowedScopes = {"managerApi"}
                }
            };
    }
}