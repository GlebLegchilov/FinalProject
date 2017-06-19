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
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный email")]
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }///////////////////////////////////////////////////////////////////////////сделать комбобокс от туда и тип проперти

        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }

        public int Creator { get; set; }

        public byte[] Img { get; set; }
    }
}