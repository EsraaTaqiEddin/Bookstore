using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Please fill Username")]
        public string Username { set; get; }

        [Required]
        public string Password { set; get; }
        public bool Rememberme { set; get; }
    }
}
