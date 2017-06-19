using System.ComponentModel.DataAnnotations;

namespace Mvc.Models
{
    public class LogOnViewModel
    {
       
        [Display(Name = "Name")]
        [Required(ErrorMessage = "The field can not be empty!")]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный email")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember password?")]
        public bool RememberMe { get; set; }
    }
}