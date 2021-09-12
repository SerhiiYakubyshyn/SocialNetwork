using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Social_Network.Models
{
    public class Registration
    {
        [Required(ErrorMessage = "Enter email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Error confirmation Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
