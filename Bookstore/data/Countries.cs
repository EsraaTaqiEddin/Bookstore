using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.data
{
    [Table("Countries")]
    public class Countries
    {
        public int ID { set; get; }

        [Required(ErrorMessage = "Please fill Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please fill Nationality")]
        public string Nationality { get; set; }

        public List<Authors> liAuthors { set; get; }
    }
}
