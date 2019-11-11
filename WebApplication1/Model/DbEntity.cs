using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model.Entity
{
    public class Order
    {
        [Key]
        public long OxId { get; set; }
        public DateTime OrderDatetime { get; set; }
        public Byte OrderStatus { get; set; }
        public int InvoiceNumber { get; set; }
    }
}
