﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IServer.IDP
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address()
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            { };

        public static IEnumerable<Client> Clients =>
            new Client[] 
            { 
               new Client
               {
                   ClientName = "Image Gallery",
                   ClientId = "imagegalleryclient",
                   AllowedGrantTypes = GrantTypes.Code,
                   RequirePkce = true,
                   RedirectUris = new List<string>()
                   {
                       "https://localhost:44389/signin-oidc"
                   },
                   AllowedScopes =
                   {
                      IdentityServerConstants.StandardScopes.OpenId,
                      IdentityServerConstants.StandardScopes.Profile,
                      IdentityServerConstants.StandardScopes.Address
                   },
                   PostLogoutRedirectUris = new List<string>()
                   {
                       "https://localhost:44389/signout-callback-oidc"
                   },
                   ClientSecrets =
                   {
                       new Secret("secret".Sha256())
                   }
               }
            };
    }
}