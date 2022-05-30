using Bookstore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class VmAuthors
    {
        public Authors author { set; get; }
        public List<Authors> LiAuthors { set; get; }
        public List<Countries> LiCountries { set; get; }
    }
}
