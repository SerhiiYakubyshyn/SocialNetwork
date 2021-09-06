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
    public class WorkPost : IWorkPost
    {
        private SocialNetworkContext socialNetworkContext;
        private PostRepository postRepository;
        public WorkPost(DbContextOptions<SocialNetworkContext> contextString)
        {
            this.socialNetworkContext = new SocialNetworkContext(contextString);
        }
        public IRepository<Post> Posts { get { return postRepository = new PostRepository(socialNetworkContext); } }

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
