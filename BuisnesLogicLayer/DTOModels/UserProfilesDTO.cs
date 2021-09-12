using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnesLogicLayer.DTOModels
{
    public class UserProfilesDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
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
        public IEnumerable<MessageDTO> Messages { get; set; }
        public IEnumerable<PostDTO> Posts { get; set; }
        public IEnumerable<GroupDTO> Groups { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
