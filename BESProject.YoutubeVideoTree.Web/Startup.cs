using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BESProject.YoutubeVideoTree.Business.Concrete;
using BESProject.YoutubeVideoTree.Business.Interfaces;
using BESProject.YoutubeVideoTree.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using BESProject.YoutubeVideoTree.DataAccess.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BESProject.YoutubeVideoTree.Web
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt => {
                opt.LoginPath = "/Home/Login";
                opt.LogoutPath = "/Panel/Logout";
                opt.Cookie.HttpOnly = true;
                opt.Cookie.Name = "YTUserCookie";
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
            });

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDal, EfUserRepository>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();            

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
