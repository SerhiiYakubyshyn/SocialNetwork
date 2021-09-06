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
    public class MessageRepository : IRepository<Message>
    {
        SocialNetworkContext _context;
        public MessageRepository(SocialNetworkContext context)
        {
            _context = context;
        }
        public async Task Create(Message item)
        {
            if (item != null)
            {
                await _context.Messages.AddAsync(item);
            }
        }

        public void Delete(int id)
        {
            var message = _context.Messages.Find(id);
            if (message != null)
                _context.Messages.Remove(message);
        }

        public async Task<Message> Find(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message != null)
                return message;

            throw new InvalidOperationException();
        }

        public IEnumerable<Message> GetAll()
        {
            return _context.Messages;
        }

        public void Update(Message item)
        {
            if (item != null)
            {
                var newItem = _context.Messages.Where(x => x.Id == item.Id).First();
                newItem.Text = item.Text;
                newItem.SendDate = item.SendDate;
                newItem.UserSenderId = item.UserSenderId;
            }
        }
    }
}
