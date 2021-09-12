using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Social_Network.Models
{
    public class PrivateMessageView
    {
        public int Id { get; set; }
        [Required]
        public int UserToId { get; set; }
        [Required]
        public MessageView PostMessage { get; set; }
        [Required]
        public DateTime ReadedDate { get; set; }
    }
}
