using REST.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.DataAccess.EntityFramework.Context
{
    public class PatikaContext :DbContext
    {
        public PatikaContext(DbContextOptions<PatikaContext> options) : base(options) 
        { 
        
        }

        public DbSet<User> User { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Genre> Genre { get; set; }

    }
}
