using Bookstore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class VmCountry
    {
        public Countries country { set; get; }
        public List<Countries> LiCountries { set; get; }
    }
}
