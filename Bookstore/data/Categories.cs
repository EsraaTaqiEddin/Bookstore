using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.data
{
    [Table("Categories")]
    public class Categories
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please fill Name")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Please fill Category Code")]
        public string Category_Code { get; set; }

        public List<Books> liBooks { set; get; }

        public string Description { get; set; }
    }
}
