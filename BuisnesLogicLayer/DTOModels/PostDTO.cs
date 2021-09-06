using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnesLogicLayer.DTOModels
{
    public class PostDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public MessageDTO PostMessage { get; set; }
        public string Image { get; set; }
    }
}
