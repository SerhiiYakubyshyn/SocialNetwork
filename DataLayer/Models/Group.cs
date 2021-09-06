using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Group
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public IEnumerable<UserProfiles> Users { get; set; }
        [Required]
        public IEnumerable<Post> Posts { get; set; }

    }
}
