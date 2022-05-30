using Bookstore.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.services
{
    public class BookService: IBookService
    {
        BookstoreContext context;
        public BookService(BookstoreContext _context)
        {
            context = _context;
        }
        public List<Books> LoadAll()
        {
            List<Books> li = new List<Books>();

            li = context.books.Include("category").Include("author").ToList();
            return li;
        }

        public void Insert(Books b)
        {
            context.books.Add(b);
            context.SaveChanges();
        }
        public Books LoadBookByID(int ID)
        {
            Books b = new Books();
            b = context.books.First(I => I.ID == ID);
            return b;
        }
        public void Update(Books b)
        {
            context.books.Attach(b);
            context.Entry(b).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteItem(int ID)
        {
            Books book = new Books();
            book = context.books.First(I => I.ID == ID);
            context.books.Remove(book);
            context.SaveChanges();
        }
    }
}
