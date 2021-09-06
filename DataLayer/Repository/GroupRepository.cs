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
    public class GroupRepository : IRepository<Group>
    {
        SocialNetworkContext _context;
        public GroupRepository(SocialNetworkContext context)
        {
            _context = context;
        }

        public async Task Create(Group item)
        {
            if (item != null)
            {
                await _context.Groups.AddAsync(item);
            }
        }

        public void Delete(int id)
        {
            var group = _context.Groups.Find(id);
            if (group != null)
                _context.Groups.Remove(group);
        }

        public async Task<Group> Find(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group != null)
                return group;

            throw new InvalidOperationException();
        }

        public IEnumerable<Group> GetAll()
        {
            return _context.Groups;
        }


        public void Update(Group item)
        {
            if (item != null)
            {
                var newItem = _context.Groups.Where(x => x.Id == item.Id).First();
                newItem.Title = item.Title;
                newItem.Posts = item.Posts;
                newItem.Users = item.Users;
            }
        }

    }
}
