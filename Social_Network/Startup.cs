using BuisnesLogicLayer.Infrastructure;
using BuisnesLogicLayer.Interfaces;
using BuisnesLogicLayer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SocialNetwork.AppBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Social_Network
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
            services.AddMvc();
            ConfigurationBLL.AddDependecy(services,Configuration);
            services.AddScoped<IServices, MainService>();
            //services.AddScoped<ISocialNetworkConfiguration, ConfigurationBLL>();
            //services.AddTransient<ConfigurationBLL>();
            
            //services.AddTransient(ConfigurationBLL.AddDependecy());

            //services.AddIdentity<DataLayer.Models.UserProfiles, Microsoft.AspNetCore.Identity.IdentityRole>().AddEntityFrameworkStores<DataLayer.Data.SocialNetworkContext>();
            services.AddSignalR();
            services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.PropertyNamingPolicy = null);
            
            //services.AddDbContext(Configuration.GetConnectionString("DefaultConnection"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Culture();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<SocialNetwork.Hubs.ChatHub>("/chathub");
            });
        }
    }
}