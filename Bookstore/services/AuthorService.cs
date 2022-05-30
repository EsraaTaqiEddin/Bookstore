using Bookstore.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.services
{
    public class AuthorService : IAuthorService
    {
        BookstoreContext context;
        public AuthorService(BookstoreContext _context){
            context = _context;
                }
        public List<Authors> LoadAll()
        {
            List<Authors> li = new List<Authors>();
            li = context.authors.Include("country").ToList();
            return li;
        }

        public void Insert(Authors a)
        {
            context.authors.Add(a);
            context.SaveChanges();
        }
        public Authors LoadAuthorByID(int ID)
        {
            Authors a = new Authors();
            a = context.authors.First(I => I.ID == ID);
            return a;
        }
        public void Update(Authors a)
        {
            context.authors.Attach(a);
            context.Entry(a).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteItem(int ID)
        {
            Authors author = new Authors();
            author = context.authors.First(I => I.ID == ID);
            context.authors.Remove(author);
            context.SaveChanges();
        }
    }
}
