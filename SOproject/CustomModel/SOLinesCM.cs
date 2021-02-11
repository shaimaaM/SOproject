using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOproject.CustomModel
{
    public class SOLinesCM
    {
        public int Id { get; set; }
        public int Port { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal ListPrice { get; set; }
        public decimal UnitPrice { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
    }
}
