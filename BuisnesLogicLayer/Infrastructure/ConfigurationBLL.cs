using BuisnesLogicLayer.Interfaces;
using DataLayer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnesLogicLayer.Infrastructure
{
    public static class ConfigurationBLL //: ISocialNetworkConfiguration
    {
        //IConfiguration configuration;
        //public ConfigurationBLL(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //}
        //public string SocialNetworkConnection => configuration["ConnectionStrings:DefaultConnection"];

        //public string GetConnectionString(string connectionString)
        //{
        //    return configuration.GetConnectionString(connectionString);
        //}
        //public static void ConfigureServices(IConfiguration configuration)
        //{

        //    //services.AddDbContext<SocialNetworkContext>(opt => opt.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
        //    //services.AddDbContext<SocialNetworkContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        //}

        public static IServiceCollection AddDependecy(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(DataLayer.Interfaces.IWorkGroup), typeof(DataLayer.WorkTemp.WorkGroup));
            services.AddScoped(typeof(DataLayer.Interfaces.IWorkMessage), typeof(DataLayer.WorkTemp.WorkMessage));
            services.AddScoped(typeof(DataLayer.Interfaces.IWorkPost), typeof(DataLayer.WorkTemp.WorkPost));
            services.AddScoped(typeof(DataLayer.Interfaces.IWorkPrivateMessage), typeof(DataLayer.WorkTemp.WorkPrivateMessage));
            services.AddScoped(typeof(DataLayer.Interfaces.IWorkUserProfile), typeof(DataLayer.WorkTemp.WorkUserProfiles));
            
            services.AddDbContext<SocialNetworkContext>(o => o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        //public IServiceCollection MyConfigureServices(IServiceCollection services)
        //{
        //    services.AddSingleton(typeof(DataLayer.Interfaces.IWorkGroup), typeof(DataLayer.WorkTemp.WorkGroup));
        //    services.AddSingleton(typeof(DataLayer.Interfaces.IWorkMessage), typeof(DataLayer.WorkTemp.WorkMessage));
        //    services.AddSingleton(typeof(DataLayer.Interfaces.IWorkPost), typeof(DataLayer.WorkTemp.WorkPost));
        //    services.AddSingleton(typeof(DataLayer.Interfaces.IWorkPrivateMessage), typeof(DataLayer.WorkTemp.WorkPrivateMessage));
        //    services.AddSingleton(typeof(DataLayer.Interfaces.IWorkUserProfile), typeof(DataLayer.WorkTemp.WorkUserProfiles));
        //    services.AddDbContext<DataLayer.Data.SocialNetworkContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
        //    //services.AddIdentityCore<DataLayer.Models.UserProfiles, IdentityRole>().AddEntityFrameworkStores<DataLayer.Data.SocialNetworkContext>();
        //    return services;
        //}
    }
}
