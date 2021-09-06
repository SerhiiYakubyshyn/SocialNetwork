using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnesLogicLayer.Interfaces
{
    public interface IServices
    {
        IEnumerable<DTOModels.GroupDTO> GetGroups();
        IEnumerable<DTOModels.MessageDTO> GetMessages();
        IEnumerable<DTOModels.PostDTO> GetPosts();
        IEnumerable<DTOModels.PrivateMessageDTO> GetPrivateMessages();
        IEnumerable<DTOModels.UserProfilesDTO> GetUserProfiles();
        void DeleteGroup(int id);
        void DeleteMessage(int id);
        void DeletePost(int id);
        void DeltePrivateMessage(int id);
        void DeleteUserProfiles(int id);
        void AddItem(object item);
    }
}
