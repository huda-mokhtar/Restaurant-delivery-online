using Restaurant_delivery_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_delivery_online.IServices
{
    public interface IRestaurant : IGenericService<Restaurant>
    {
        public List<Restaurant> GetByCity(string city ,string resturant);
    }
}
