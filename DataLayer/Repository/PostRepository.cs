using DataLayer.Data;
using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class PostRepository : IRepository<Post>
    {
        SocialNetworkContext _context;
        public PostRepository(SocialNetworkContext context)
        {
            _context = context;
        }
        public async Task Create(Post item)
        {
            if (item != null)
            {
                await _context.Posts.AddAsync(item);
            }
        }

        public void Delete(int id)
        {
            var post = _context.Posts.Find(id);
            if (post != null)
                _context.Posts.Remove(post);
        }

        public async Task<Post> Find(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
                return post;

            throw new InvalidOperationException();
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts;
        }

        public void Update(Post item)
        {
            if (item != null)
            {
                var newItem = _context.Posts.Where(x => x.Id == item.Id).First();
                newItem.PostMessage = item.PostMessage;
                newItem.Title = item.Title;
                newItem.Image = item.Image;
            }
        }
    }
}
