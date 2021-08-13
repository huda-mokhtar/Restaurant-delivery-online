using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_delivery_online.Models
{
    public class City
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "CityName is required")]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
