using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnesLogicLayer.DTOModels
{
    public class GroupDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public IEnumerable<UserProfilesDTO> Users { get; set; }
        [Required]
        public IEnumerable<PostDTO> Posts { get; set; }
    }
}
