using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.data
{
    public class BookstoreContext: IdentityDbContext<ApplicationUser>
    {
        IConfiguration Config;
        public BookstoreContext(IConfiguration _Config)
        {
            Config = _Config;
        }

        public DbSet<Authors> authors { set; get; }
        public DbSet<Books> books { get; set; }
        public DbSet<Categories> categories { get; set; }

        public DbSet<Countries> countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.GetConnectionString("BookstoreConnection"));
            base.OnConfiguring(optionsBuilder);
        }

    }
}
