using SOproject.Data;
using SOproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOproject.Repositories
{
    public class SalesOrderRepository : Repository<SalesOrder>, ISalesOrderRepository
    {

        public SalesOrderRepository(ApplicationDbContext context) : base(context)
        {
        }
    
    }
}
