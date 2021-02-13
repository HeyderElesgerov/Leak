using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leak.Infrastructure.IoC;
using Microsoft.Extensions.Configuration;

namespace Leak.UI.MVC
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services, IWebHostEnvironment webHostEnvironment)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.{webHostEnvironment.EnvironmentName}.json")
                .Build();
            NativeInjectorBootStrapper.RegisterServices(services, configuration);
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
