using Microsoft.EntityFrameworkCore;
using Restaurant_delivery_online.IServices;
using Restaurant_delivery_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_delivery_online.Services
{
    public class OrderItemService : IGenericService<OrderItem>
    {
        private readonly ApplicationDbContext _db;

        public OrderItemService(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<OrderItem> GetAll()
        {
            return _db.OrderItems.Include(a => a.Meal).ToList();
        }
        public OrderItem GetById(int id)
        {
            OrderItem OrderItem = _db.OrderItems.Include(a => a.Meal).FirstOrDefault(a => a.Id == id);
            return OrderItem;
        }
        public List<OrderItem> Add(OrderItem OrderItem)
        {
            _db.Add(OrderItem);
            _db.SaveChanges();
            return _db.OrderItems.ToList();
        }
        public List<OrderItem> Update(OrderItem OrderItem)
        {
            OrderItem OldOrderItem = _db.OrderItems.FirstOrDefault(a => a.Id == OrderItem.Id);
            OldOrderItem.Quantity = OrderItem.Quantity;
            _db.SaveChanges();
            return _db.OrderItems.ToList();
        }
        public List<OrderItem> Delete(int id)
        {
            OrderItem OrderItem = _db.OrderItems.FirstOrDefault(a => a.Id == id);
            _db.Remove(OrderItem);
            _db.SaveChanges();
            return _db.OrderItems.ToList();
        }
    }
}
