using SOproject.Data;
using SOproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOproject.Repositories
{
    public class SalesOrderLinesRepository : Repository<SOLines>, ISalesOrderLinesRepository
    {
        public SalesOrderLinesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
