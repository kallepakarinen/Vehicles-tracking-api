using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiclesTrackingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace VehiclesTrackingApi.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly VehiclesDbContext _context;

        public PaymentRepository(VehiclesDbContext context)
        {
            _context = context;
        }
        public List<Payment> Get()
        {
            return _context.Payment.AsNoTracking().ToList();
        }
        public Payment Get(int id)
        {
            return _context.Payment.AsNoTracking().FirstOrDefault(p => p.Id == id);
        }
        public Payment Create(Payment payment)
        {
            _context.Payment.Add(payment);
            _context.SaveChanges();
            return payment;
        }
        public Payment Update(Payment payment)
        {
            _context.Payment.Update(payment);
            _context.SaveChanges();
            return payment;
        }
        public void Delete(int id)
        {
            var payment = Get(id);
            _context.Payment.Remove(payment);
            _context.SaveChanges();
            return;
        }
      
    }
}
