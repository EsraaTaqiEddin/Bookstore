using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.data
{
    [Table("Authors")]
    public class Authors
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please fill First Name")]
        public string FName { get; set; }
        [Required(ErrorMessage = "Please fill Last Name")]
        public string LName { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
        public string ImagePath { get; set; }

        public List<Books> liBooks { set; get; }

        [ForeignKey("country")]
        public int Country_Id { set; get; }
        public Countries country { set; get; }
    }
}
