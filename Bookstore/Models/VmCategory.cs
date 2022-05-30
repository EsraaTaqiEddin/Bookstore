using Bookstore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class VmCategory
    {
        public Categories category { set; get; }
        public List<Categories> LiCategories { set; get; }
    }
}
