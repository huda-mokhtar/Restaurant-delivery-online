using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_delivery_online.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Meal")]
        public int MealId { get; set; }

        [ForeignKey("Bill")]
        public int BillId { get; set; }
        [RegularExpression("^100$|^\\d{0,8}(\\.\\d{1,2})? *%?$", ErrorMessage = "Please enter Presentage or number.")]
        public virtual Meal Meal { get; set; }
        public virtual Bill Bill { get; set; }
    }
}
