using Microsoft.EntityFrameworkCore;
using Restaurant_delivery_online.IServices;
using Restaurant_delivery_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_delivery_online.Services
{
    public class CityService : ICity
    {
        private readonly ApplicationDbContext _db;

        public CityService(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<City> GetAll()
        {
            try
            {
                return _db.Cities.ToList();
            }
            catch
            {
                return null;
            }
        }
        public City GetById(int id)
        {
            try
            {
                City City = _db.Cities.FirstOrDefault(a => a.Id == id);
                return City;
            }
            catch
            {
                return null;
            }
        }
        public List<City> Add(City City)
        {
            try
            {
                _db.Add(City);
                _db.SaveChanges();
                return _db.Cities.ToList();
            }
            catch
            {
                return null;
            }
        }
        public List<City> Update(City City)
        {
            try
            {
                City OldCity = _db.Cities.FirstOrDefault(a => a.Id == City.Id);
                OldCity.Name = City.Name;
                _db.SaveChanges();
                return _db.Cities.ToList();
            }
            catch
            {
                return null;
            }
        }
        public List<City> Delete(int id)
        {
            try
            {
                City City = _db.Cities.FirstOrDefault(a => a.Id == id);
                _db.Remove(City);
                _db.SaveChanges();
                return _db.Cities.ToList();
            }
            catch
            {
                return null;
            }
        }
        public City GetByName(string Name)
        {
            try
            {
                City City = _db.Cities.FirstOrDefault(a => a.Name == Name);
                return City;
            }
            catch
            {
                return null;
            }
        }

    }
}