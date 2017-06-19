using System;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Models
{
    public class LotViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Lot name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public byte[] Img { get; set; }
        [Display(Name = "Lot's category")]
        public string Category { get; set; }
        [Display(Name = "Date of lot's creation")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "Date of lot's purchase")]
        public DateTime PurchaseDate { get; set; }
        public int CreatorId { get; set; }
        public int OwnerId { get; set; }

    }
}