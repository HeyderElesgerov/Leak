using Leak.Domain.Models;
using Leak.Infrastructure.Data.Context;
using Leak.Infrastructure.IoC;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Leak.UI.MVC
{
    public class Startup
    {
        IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "LeakAPI",
                    Version = "v1.0"
                });

                c.SwaggerDoc("v2.0", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "LeakAPI2",
                    Version = "v2.0"
                });
            });

            services.AddIdentity<AppUser, IdentityRole<Guid>>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<LeakDbContext>();

            services.AddMediatR(typeof(Startup).Assembly);
            services
                .WithAutoMapper()
                .WithDbContext(Configuration.GetSection("ConnectionStrings:DefaultConnection").Value)
                .WithRepositories()
                .WithUnitOfWork()
                .WithServices()
                .WithRequestHandlers();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (c, n) =>
            {
                string apiVersion = c.Request.Headers["api-version"];

                if (!string.IsNullOrEmpty(apiVersion))
                {
                    if (apiVersion == "1.0")
                        await n();
                }
                else
                {
                    await n();
                }
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "LeakAPI v1");
                c.SwaggerEndpoint("/swagger/v2.0/swagger.json", "LeakAPI v2");
            });

          

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();

            });
        }
    }
}
