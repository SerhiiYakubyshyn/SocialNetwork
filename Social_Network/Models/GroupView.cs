using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Social_Network.Models
{
    public class GroupView
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public IEnumerable<UserProfileView> Users { get; set; }
        [Required]
        public IEnumerable<PostView> Posts { get; set; }
    }
}
