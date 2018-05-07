using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Lab_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Lab_1
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
            
            
                // внерение зависимости для доступа к БД с использ EF
                string connection = Configuration.GetConnectionString("SqlConnection");
                services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
                options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
            });
            // внедрение зависимости Service
            services.AddTransient<Service>();
            // добавление кэширования
            services.AddMemoryCache();
            // добавление поддержки сессии
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddMvc();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseAuthentication();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            // добавляем поддержку сессий
            app.UseSession();

        

            // добавляем компонент middleware для реализации кэширования и записывем данные в кэш
            app.UseOperatinCache("Entry 10");
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Visitors}/{action=Index}/{id?}");
            });
        }
    }
}
