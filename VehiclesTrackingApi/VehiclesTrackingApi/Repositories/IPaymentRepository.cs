using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiclesTrackingApi.Models;

namespace VehiclesTrackingApi.Repositories
{
    public interface IPaymentRepository
    {
        List<Payment> Get();
        List<PaymentsReport> GetReport(PaymentsReport paymentsReport);
        Payment Get(int id);
        Payment Create(Payment payment);
        Payment Update(Payment payment);
        void Delete(int id);
    }
}
