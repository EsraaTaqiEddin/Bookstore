using Bookstore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.services
{
    public interface IAuthorService
    {
        List<Authors> LoadAll();
        void Insert(Authors a);
        Authors LoadAuthorByID(int ID);
        void Update(Authors a);
        void DeleteItem(int ID);
    }
}
