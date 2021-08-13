using Restaurant_delivery_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_delivery_online.IServices
{
    public interface ICity : IGenericService<City>
    {
        public City GetByName(string name);
    }
}
