using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace Social_Network.Models
{
    public class RoleViewModel
    {
        public RoleViewModel()
        {
            UserRoles = new List<string>();
        }
        public string UserEmail { get; set; }
        public int UserId { get; set; }

        public IList<string> UserRoles { get; set; }

    }
}
