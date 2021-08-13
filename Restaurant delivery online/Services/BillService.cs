using Microsoft.EntityFrameworkCore;
using Restaurant_delivery_online.IServices;
using Restaurant_delivery_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_delivery_online.Services
{
    public class BillService : IGenericService<Bill>
    {
        private readonly ApplicationDbContext _db;

        public BillService(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<Bill> GetAll()
        {
            return _db.Bills.Include(b => b.Customer).ToList();
        }
        public Bill GetById(int id)
        {
            Bill Bill = _db.Bills.Include(b => b.Customer).Include(a => a.OrderItems).FirstOrDefault(a => a.Id == id);
            return Bill;
        }
        public List<Bill> Add(Bill Bill)
        {
            _db.Add(Bill);
            _db.SaveChanges();
            return _db.Bills.ToList();
        }
        public List<Bill> Update(Bill Bill)
        {
            Bill OldBill = _db.Bills.FirstOrDefault(a => a.Id == Bill.Id);
            OldBill.Date = Bill.Date;
            OldBill.OrderItems = Bill.OrderItems;
            _db.SaveChanges();
            return _db.Bills.ToList();
        }
        public List<Bill> Delete(int id)
        {
            Bill Bill = _db.Bills.FirstOrDefault(a => a.Id == id);
            _db.Remove(Bill);
            _db.SaveChanges();
            return _db.Bills.ToList();
        }
    }
}
