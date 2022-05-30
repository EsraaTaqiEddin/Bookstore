using Bookstore.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.services
{
    public class CountryService : ICountryService
    {
        BookstoreContext context;
        public CountryService(BookstoreContext _context)
        {
            context = _context;
        }
        public List<Countries> LoadAll()
        {
            List<Countries> li = new List<Countries>();

            li = context.countries.ToList();
            return li;
        }

        public void Insert(Countries c)
        {
            context.countries.Add(c);
            context.SaveChanges();
        }

        public Countries LoadCountryByID(int ID)
        {
            Countries c = new Countries();
            c = context.countries.First(I => I.ID == ID);
            return c;
        }
        public void Update(Countries c)
        {
            context.countries.Attach(c);
            context.Entry(c).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteItem(int ID)
        {
            Countries country = new Countries();
            country = context.countries.First(I => I.ID == ID);
            context.countries.Remove(country);
            context.SaveChanges();
        }
    }
}
