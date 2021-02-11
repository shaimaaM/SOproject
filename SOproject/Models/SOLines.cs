using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SOproject.Models
{
    public class SOLines
    {
        [Key]
        public string Number { get; set; }
        public int Port { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal ListPrice { get; set; }
        public decimal UnitPrice { get; set; }
        public string JobNumber { get; set; }


        public SalesOrder SalesOrder { get; set; }
    }
}
