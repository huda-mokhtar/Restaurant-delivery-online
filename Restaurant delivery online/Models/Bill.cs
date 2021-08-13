using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_delivery_online.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("Customer")]
        public int customerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
