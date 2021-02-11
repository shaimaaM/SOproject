using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOproject.CustomModel
{
    public class SalesOrderCM
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string CustomerName { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Ammount { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
      //  public string SearchNo { get; set; }

    }
}
