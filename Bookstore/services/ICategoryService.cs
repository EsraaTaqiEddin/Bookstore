using Bookstore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.services
{
    public interface ICategoryService
    {
        List<Categories> LoadAll();
        void Insert(Categories c);
        Categories LoadCategoryByID(int ID);
        void Update(Categories c);
        void DeleteItem(int ID);
    }
}
