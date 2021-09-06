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
    public class PrivateMessageRepository : IRepository<PrivateMessage>
    {
        SocialNetworkContext _context;
        public PrivateMessageRepository(SocialNetworkContext context)
        {
            _context = context;
        }
        public async Task Create(PrivateMessage item)
        {
            if (item != null)
            {
                await _context.PrivateMessages.AddAsync(item);
            }
        }

        public void Delete(int id)
        {
            var privateMessage = _context.PrivateMessages.Find(id);
            if (privateMessage != null)
                _context.PrivateMessages.Remove(privateMessage);
        }

        public async Task<PrivateMessage> Find(int id)
        {
            var privateMessage = await _context.PrivateMessages.FindAsync(id);
            if (privateMessage != null)
                return privateMessage;

            throw new InvalidOperationException();
        }

        public IEnumerable<PrivateMessage> GetAll()
        {
            return _context.PrivateMessages;
        }

        public void Update(PrivateMessage item)
        {
            if (item != null)
            {
                var newItem = _context.PrivateMessages.Where(x => x.Id == item.Id).First();
                newItem.PostMessage = item.PostMessage;
                newItem.ReadedDate = item.ReadedDate;
                newItem.UserToId = item.UserToId;
            }
        }
    }
}
