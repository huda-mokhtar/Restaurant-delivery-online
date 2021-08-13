using Restaurant_delivery_online.IServices;
using Restaurant_delivery_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_delivery_online.Services
{
    public class MealService : IMeal
    {
        private readonly ApplicationDbContext _db;

        public MealService(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<Meal> GetAll()
        {
            return _db.Meals.ToList();
        }
        public Meal GetById(int id)
        {
            Meal Meal = _db.Meals.FirstOrDefault(a => a.Id == id);
            return Meal;
        }
        public List<Meal> Add(Meal Meal)
        {
            _db.Add(Meal);
            _db.SaveChanges();
            return _db.Meals.ToList();
        }
        public List<Meal> Update(Meal Meal)
        {
            Meal OldMeal = _db.Meals.FirstOrDefault(a => a.Id == Meal.Id);
            try
            {
                OldMeal.Title = Meal.Title;
                OldMeal.Description = Meal.Description;
                OldMeal.Price = Meal.Price;
                OldMeal.Image = Meal.Image;
                _db.SaveChanges();
            }
            catch
            {
                throw;
            }
            return _db.Meals.ToList();
        }
        public List<Meal> Delete(int id)
        {
            Meal Meal = _db.Meals.FirstOrDefault(a => a.Id == id);
            _db.Remove(Meal);
            _db.SaveChanges();
            return _db.Meals.ToList();
        }
        public List<Meal> GetAllMealsByRestaurant(int id)
        {
            List<Meal> Meals = _db.Meals.Where(a => a.RestaurantId == id).ToList();
            return Meals;
        }
    }
}
