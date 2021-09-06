using DataLayer.Data;
using DataLayer.Interfaces;
using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.WorkTemp
{
    public class WorkGroup : IWorkGroup
    {
        private SocialNetworkContext socialNetworkContext;
        private GroupRepository groupRepository;
        public WorkGroup(DbContextOptions<SocialNetworkContext> contextString)
        {
            this.socialNetworkContext = new SocialNetworkContext(contextString);
        }
        public IRepository<Group> Groups { get { return groupRepository = new GroupRepository(socialNetworkContext); }}

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
