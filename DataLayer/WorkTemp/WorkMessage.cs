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
    public class WorkMessage : IWorkMessage
    {
        private SocialNetworkContext socialNetworkContext;
        private MessageRepository messageRepository;
        public WorkMessage(DbContextOptions<SocialNetworkContext> contextString)
        {
            this.socialNetworkContext = new SocialNetworkContext(contextString);
        }
        public IRepository<Message> Messages { get { return messageRepository = new MessageRepository(socialNetworkContext); } }

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
