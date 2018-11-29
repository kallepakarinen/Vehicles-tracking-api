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
        private readonly VehicleDbContext _context;

        public PaymentRepository(VehicleDbContext context)
        {
            _context = context;
        }

        public List<Payment> Get()
        {
            return _context.Payment.AsNoTracking().ToList();
        }


       // private List<PaymentsReport> _paymentsReport;
        public List<PaymentsReport> GetReport(PaymentsReport paymentsReport)
        {
            var x = new List<PaymentsReport>();
            var paymentsItem = new PaymentsReport();
            paymentsItem.VehicleName = "Auto";
            x.Add(paymentsItem);
            return x;
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
