using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnesLogicLayer.DTOModels
{
    public class PrivateMessageDTO
    {
        public int Id { get; set; }
        [Required]
        public int UserToId { get; set; }
        [Required]
        public MessageDTO PostMessage { get; set; }
        [Required]
        public DateTime ReadedDate { get; set; }
    }
}
