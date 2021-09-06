using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Data;
using DataLayer.Interfaces;
using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.WorkTemp
{
    public class WorkUserProfiles : IWorkUserProfile
    {
        private SocialNetworkContext socialNetworkContext;
        private UserProfilesRepository userProfilesRepository;
        public WorkUserProfiles(DbContextOptions<SocialNetworkContext> contextString)
        {
            this.socialNetworkContext = new SocialNetworkContext(contextString);
        }
        public IRepository<UserProfiles> UserProfiles { get { return userProfilesRepository = new UserProfilesRepository(socialNetworkContext); } }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await socialNetworkContext.SaveChangesAsync();
        }
    }
}
