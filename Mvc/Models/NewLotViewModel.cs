using System;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Models
{
    public class NewLotViewModel
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        [Display(Name = "Enter your lot name")]
        [Required(ErrorMessage = "The field can not be empty!")]
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int AuctionId { get; set; }




    }
}