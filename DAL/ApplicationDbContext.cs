using DAL.DataContext;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ApplicationDbContext : DbContext, IDbContext
    {
        public ApplicationDbContext() : base("name=MyApplication_API")
        {

        }

        public DbSet<User> User { get; set; }
    }
}
