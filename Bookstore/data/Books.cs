using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.data
{
    [Table("Books")]
    public class Books
    {
        public int ID  { get; set; }
        [Required(ErrorMessage = "Please fill Book Title")]
        public string BookTitle { get; set; }

        public string Year { get; set; }

        [Required(ErrorMessage = "Please fill Price")]
        public Double Price { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
        public string ImagePath { get; set; }

        [ForeignKey("category")]
      
        public int Category_Id { set; get; }
        public Categories category { set; get; }


        [ForeignKey("author")]
      
        public int Author_Id { set; get; }
        public Authors author { set; get; }

        [Required(ErrorMessage = "stock field is required")]
        public int Stock { get; set; }
    }
}
