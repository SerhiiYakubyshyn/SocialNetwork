using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class UserProfiles : IdentityUser
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public bool Gender { get; set; }  
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        public string Image { get; set; }
        public IEnumerable<Message> Messages { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Group> Groups { get; set; }
    }
}
