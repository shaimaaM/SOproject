using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SOproject.Models
{
    public class SalesOrder
    {
        public SalesOrder()
        {
            SalesOrderLines = new HashSet<SOLines>();
        }
       // public int Id { get; set; }
        [Key]
        public string Number { get; set; }
        public string CustomerName { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Ammount { get; set; }

        public ICollection<SOLines> SalesOrderLines { get; set; }


    }
}
