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
                new IdentityResources.Address(),
                new IdentityResource(
                    "roles",
                    "Your role(s)",
                    new List<string>(){"role"}),
                new IdentityResource(
                    "country",
                    "The country you're living in",
                    new List<string>() {"country"}),
                new IdentityResource(
                    "subscriptionlevel",
                    "your subscription level",
                    new List<string>(){"subscriptionlevel"})
            };



        public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope
            (  "imagegalleryapi",
                "Image Gallery API scope")

        };

        public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
        {
              new ApiResource("imagegalleryapi", 
                  "Image Gallery API",
                  new List<string>() {"role" })
              {
                  Scopes={"imagegalleryapi"},
                  ApiSecrets = {new Secret("apisecret".Sha256()) }
              }
            };

        public static IEnumerable<Client> Clients =>
            new Client[] 
            { 
               new Client
               {
                   AccessTokenType = AccessTokenType.Reference,
                   AccessTokenLifetime  = 120,
                   AllowOfflineAccess = true, //requirement for refresh token
                   UpdateAccessTokenClaimsOnRefresh = true,
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
                      IdentityServerConstants.StandardScopes.Address,
                      "roles",
                      "imagegalleryapi",
                      "country",
                      "subscriptionlevel"
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