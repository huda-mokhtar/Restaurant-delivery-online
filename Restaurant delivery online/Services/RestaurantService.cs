using Restaurant_delivery_online.IServices;
using Restaurant_delivery_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_delivery_online.Services
{
    public class RestaurantService : IRestaurant
    {
        private readonly ApplicationDbContext _db;

        public RestaurantService(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<Restaurant> GetAll()
        {
            return _db.Restaurants.ToList();
        }
        public Restaurant GetById(int id)
        {
            Restaurant Restaurant = _db.Restaurants.FirstOrDefault(a => a.Id == id);
            return Restaurant;
        }
        public List<Restaurant> Add(Restaurant Restaurant)
        {
            _db.Add(Restaurant);
            _db.SaveChanges();
            return _db.Restaurants.ToList();
        }
        public List<Restaurant> Update(Restaurant Restaurant)
        {
            Restaurant OldRestaurant = _db.Restaurants.FirstOrDefault(a => a.Id == Restaurant.Id);
            OldRestaurant.Name = Restaurant.Name;
            OldRestaurant.CityId = Restaurant.CityId;
            _db.SaveChanges();
            return _db.Restaurants.ToList();
        }
        public List<Restaurant> Delete(int id)
        {
            Restaurant Restaurant = _db.Restaurants.FirstOrDefault(a => a.Id == id);
            _db.Remove(Restaurant);
            _db.SaveChanges();
            return _db.Restaurants.ToList();
        }
        public List<Restaurant> GetByCity(string city,string resturant)
        {
            City City = _db.Cities.FirstOrDefault(a => a.Name == city);
            List<Restaurant> Restaurants = _db.Restaurants.Where(a => a.CityId == City.Id &&a.Name==resturant).ToList();
            return Restaurants;
        }

    }
}
