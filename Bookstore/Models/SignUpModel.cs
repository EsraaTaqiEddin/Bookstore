using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage="Please fill Name")]
        public string Name { set; get; }

        [Required(ErrorMessage = "Please fill Email")]
        public string Email { set; get; }
        [RegularExpression(@"07[789]\d{7}",
            ErrorMessage = "phone number must be 10 digits and starts with 077, 078 or 079")]
        public string Phone { set; get; }
        [Compare("ConfrimPassword")]
        public string Password { set; get; }
        public string ConfrimPassword { set; get; }
        public string RoleId { set; get; }
    }
}
