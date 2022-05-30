using Bookstore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class VmBooks
    {
        public Books book { set; get; }
        public List<Books> LiBooks { set; get; }
        public List<Authors> LiAuthors { set; get; }
        public List<Categories> LiCategories { set; get; }
    }
}
