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
    public static class ConfigurationBLL
    {

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
    }
}
