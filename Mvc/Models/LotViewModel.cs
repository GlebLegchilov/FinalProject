using System;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Models
{
    public class LotViewModel
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        [Display(Name = "Lot name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int AuctionId { get; set; }



    }
}