using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Social_Network.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Enter email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter password")]
        public string Password { get; set; }
    }

}
