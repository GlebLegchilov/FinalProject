using System;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Models
{
    public class NewLotViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Enter your lot name")]
        [Required(ErrorMessage = "The field can not be empty!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        public string Price { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        public string Description { get; set; }
        public string Category { get; set; }
        

        public int Creator { get; set; }

        public byte[] Img { get; set; }


    }
}