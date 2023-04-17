using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Video_Library.Areas.Admin.Models.ViewModel
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage ="First Name can't be Empty!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name can't be Empty!")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Email is No Valid!")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password Can't be Empty!")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$",ErrorMessage ="Please Enter Strong Password")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage ="Confirm Password Not Matched!")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
    }
}
