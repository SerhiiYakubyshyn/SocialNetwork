using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Social_Network.Models
{
    public class MessageView
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime SendDate { get; set; }
        [Required]
        public int UserSenderId { get; set; }
    }
}
