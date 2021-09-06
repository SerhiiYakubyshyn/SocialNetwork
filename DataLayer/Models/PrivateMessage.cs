using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class PrivateMessage
    {
        public int Id { get; set; }
        [Required]
        public int UserToId { get; set; }
        [Required]
        public Message PostMessage { get; set; }
        [Required]
        public DateTime ReadedDate { get; set; }
    }
}
