using Bookstore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.services
{
    public interface ICountryService
    {
        List<Countries> LoadAll();
        void Insert(Countries c);
        Countries LoadCountryByID(int ID);
        void Update(Countries c);

        void DeleteItem(int ID);
    }
}
