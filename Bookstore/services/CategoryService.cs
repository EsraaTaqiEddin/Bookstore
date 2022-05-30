using Bookstore.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.services
{
    public class CategoryService: ICategoryService
    {
        BookstoreContext context;
        public CategoryService(BookstoreContext _context)
        {
            context = _context;
        }
        public List<Categories> LoadAll()
        {
            List<Categories> li = new List<Categories>();
            li = context.categories.ToList();
            return li;
        }
        public void Insert(Categories c)
        {
            context.categories.Add(c);
            context.SaveChanges();
        }
        public Categories LoadCategoryByID(int ID)
        {
            Categories c = new Categories();
            c = context.categories.First(I => I.ID == ID);
            return c;
        }
        public void Update(Categories c)
        {
            context.categories.Attach(c);
            context.Entry(c).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteItem(int ID)
        {
            Categories category = new Categories();
            category = context.categories.First(I => I.ID == ID);
            context.categories.Remove(category);
            context.SaveChanges();
        }
    }
}
