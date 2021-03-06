﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Lab_3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Lab_3
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
            string connection = Configuration.GetConnectionString("SQLConnection");
            services.AddDbContext<SportContext>(options => options.UseSqlServer(connection));

            services.AddTransient<SportContext>();
            services.AddMemoryCache();
            services.AddResponseCaching();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddMvc().AddSessionStateTempDataProvider();

            services.AddMvc(options =>
            {
                options.CacheProfiles.Add("Caching",
                   new CacheProfile()
                   {
                       Duration = 2 * 16 + 240,
                       Location = ResponseCacheLocation.Any
                   });
                options.CacheProfiles.Add("NoCaching",
                   new CacheProfile()
                   {
                       Location = ResponseCacheLocation.None,
                       NoStore = true
                   });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseLastElementCache();
            app.UseSession();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseResponseCaching();
            app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
