// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServerHost.Quickstart.UI;
using IServer.IDP.DbContexts;
using IServer.IDP.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace IServer.IDP
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }

        public Startup(IWebHostEnvironment environment)
        {
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
           
            var iserverIDPDataDBConnectionString =
                "Server=(localdb)\\mssqllocaldb;Database=IServerIDPDataDB;Trusted_Connection=True;";


            // uncomment, if you want to add an MVC-based UI
            services.AddControllersWithViews();
            services.AddDbContext<IdentityDbContext>(options =>
            {
                options.UseSqlServer(iserverIDPDataDBConnectionString);
            });

            services.AddScoped<IPasswordHasher<Entities.User>, PasswordHasher<Entities.User>>();
            services.AddScoped<ILocalUserService, LocalUserService>();

            var builder = services.AddIdentityServer();
            //.AddInMemoryApiScopes(Config.ApiScopes)
            //.AddInMemoryIdentityResources(Config.IdentityResources)
            //.AddInMemoryApiResources(Config.ApiResources)
            //.AddInMemoryClients(Config.Clients)
            builder.AddProfileService<LocalUserProfileService>();


            // not recommended for production - you need to store your key material somewhere secure
            //builder.AddDeveloperSigningCredential();
            builder.AddSigningCredential(LoadCertificateFromStore());

            var migrationAssembly = typeof(Startup)
                                            .GetTypeInfo().Assembly.GetName().Name;

            builder.AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = builder =>
                            builder.UseSqlServer(iserverIDPDataDBConnectionString, 
                            options => options.MigrationsAssembly(migrationAssembly));
            });

            builder.AddOperationalStore(options =>
            {
                options.ConfigureDbContext = builder =>
                                builder.UseSqlServer(iserverIDPDataDBConnectionString,
                                options => options.MigrationsAssembly(migrationAssembly));
            });
        }
   
        public void Configure(IApplicationBuilder app)
        {

            if (Environment.IsDevelopment())
            {
            
                app.UseDeveloperExceptionPage();
            }

            InitializeDatabase(app);
            // uncomment if you want to add MVC
            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();

            // uncomment, if you want to add MVC
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
          
        }

        public X509Certificate2 LoadCertificateFromStore()
        {
            string thumbPrint = System.Environment.GetEnvironmentVariable("tempcert", EnvironmentVariableTarget.User);

            using (var store = new X509Store(StoreName.My, StoreLocation.LocalMachine))
            {
                store.Open(OpenFlags.ReadOnly);
                var certCollection = store.Certificates.Find(X509FindType.FindByThumbprint, thumbPrint, true);
                if (certCollection.Count == 0)
                {
                    throw new Exception("The specified certificate wasn't found");
                }
                return certCollection[0];

            }
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.
                GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider
                    .GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider
                        .GetRequiredService<ConfigurationDbContext>();
                context.Database.Migrate();
                if(!context.Clients.Any())
                {
                    foreach(var client in Config.Clients)
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }

                if(!context.IdentityResources.Any())
                {
                    foreach(var resource in Config.IdentityResources)
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.ApiResources.Any())
                {
                    foreach (var resource in Config.ApiResources)
                    {
                        context.ApiResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                if(!context.ApiScopes.Any())
                {
                    foreach(var scope in Config.ApiScopes)
                    {
                        context.ApiScopes.Add(scope.ToEntity());

                    }
                    context.SaveChanges();
                }
            }
        }

    }
}
