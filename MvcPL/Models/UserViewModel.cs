using System;
using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models
{
    public class UserViewModel
    {

        public int Id { get; set; }
        [Display(Name = "User name")]
        public string UserName { get; set; }
        public string Password { get; set; }
        [Display(Name = "User's role in the system")]
        public string Role { get; set; }

        [Display(Name = "Date of user's registration")]
        public DateTime CreationDate { get; set; }      
    }
}