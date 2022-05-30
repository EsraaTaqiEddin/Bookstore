using Bookstore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.services
{
    public interface IBookService
    {
        List<Books> LoadAll();
        void Insert(Books b);

        void Update(Books b);
        Books LoadBookByID(int ID);
        void DeleteItem(int ID);
    }
}
