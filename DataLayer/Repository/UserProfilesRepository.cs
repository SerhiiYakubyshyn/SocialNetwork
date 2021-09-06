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
    public class UserProfilesRepository : IRepository<UserProfiles>
    {
        SocialNetworkContext _context;
        public UserProfilesRepository(SocialNetworkContext context)
        {
            _context = context;
        }
        public async Task Create(UserProfiles item)
        {
            if (item != null)
            {
                await _context.UserProfiles.AddAsync(item);
            }
        }

        public void Delete(int id)
        {
            var privateMessage = _context.UserProfiles.Find(id);
            if (privateMessage != null)
                _context.UserProfiles.Remove(privateMessage);
        }

        public async Task<UserProfiles> Find(int id)
        {
            var privateMessage = await _context.UserProfiles.FindAsync(id);
            if (privateMessage != null)
                return privateMessage;

            throw new InvalidOperationException();
        }

        public IEnumerable<UserProfiles> GetAll()
        {
            return _context.UserProfiles;
        }

        public void Update(UserProfiles item)
        {
            if (item != null)
            {
                var newItem = _context.UserProfiles.Where(x => x.Id == item.Id).First();
                newItem.Birthday = item.Birthday;
                newItem.City = item.City;
                newItem.Country = item.Country;
                newItem.Email = item.Email;
                newItem.EmailConfirmed = item.EmailConfirmed;
                newItem.Gender = item.Gender;
                newItem.Image = item.Image;
                newItem.Groups = item.Groups;
                newItem.LastName = item.LastName;
                newItem.Messages = item.Messages;
                newItem.UserName = item.UserName;
                newItem.Posts = item.Posts;
                newItem.PhoneNumber = item.PhoneNumber;
                newItem.PhoneNumberConfirmed = item.PhoneNumberConfirmed;
                newItem.PasswordHash = item.PasswordHash;
            }
        }
    }
}
