using Microsoft.EntityFrameworkCore;
using SOproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOproject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<SalesOrder> SalesOrder { get; set; }
        public DbSet<SOLines> SOLines { get; set; }
    }
}
