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
    public class WorkPrivateMessage : IWorkPrivateMessage
    {
        private SocialNetworkContext socialNetworkContext;
        private PrivateMessageRepository privateMessageRepository;
        public WorkPrivateMessage(DbContextOptions<SocialNetworkContext> contextString)
        {
            this.socialNetworkContext = new SocialNetworkContext(contextString);
        }
        public IRepository<PrivateMessage> PrivateMessages { get { return privateMessageRepository = new PrivateMessageRepository(socialNetworkContext); } }

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
