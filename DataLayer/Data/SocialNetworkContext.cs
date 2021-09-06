using DataLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class SocialNetworkContext: IdentityDbContext<UserProfiles>
    {
        public SocialNetworkContext(DbContextOptions<SocialNetworkContext> connectionString) : base(connectionString)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<PrivateMessage> PrivateMessages { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<UserProfiles> UserProfiles { get; set; }
    }
}
