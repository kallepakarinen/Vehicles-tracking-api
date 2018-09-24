using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiclesTrackingApi.Models;

namespace VehiclesTrackingApi.Services
{
    public interface IPaymentService
    {
        List<Payment> GetPayments();
        List<PaymentsReport> GetReport();
        Payment GetPaymentById(int id);
        Payment CreatePayment(Payment payment);
        Payment UpdatePayment(int id, Payment payment);
        void DeletePayment(int id);
    }
}
