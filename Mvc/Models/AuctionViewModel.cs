using System;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Models
{
    public class AuctionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        //[Required]
        //[Display(Name = "Min price")]
        //[Range(typeof(decimal), "0,0", "999999,9", ErrorMessage = "Error")]
        public decimal Price { get; set; }
        public int CreatorId { get; set; }
        public DateTime EndingDate { get; set; }
        public bool AvailabilityStatus { get; set; }

        public string LotId { get; set; }
    }
}