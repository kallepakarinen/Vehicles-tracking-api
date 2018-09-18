using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiclesTrackingApi.Models;
using VehiclesTrackingApi.Repositories;

namespace VehiclesTrackingApi.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository PaymentRepository)
        {
            _paymentRepository = PaymentRepository;
        }
        public List<Payment> GetPayments()
        {
            return _paymentRepository.Get();
        }
        public Payment GetPaymentById(int id)
        {
            return _paymentRepository.Get(id);
        }
        public Payment CreatePayment(Payment payment)
        {
            return _paymentRepository.Create(payment);
        }
        public Payment UpdatePayment(int id, Payment payment)
        {
            var savedPayment = _paymentRepository.Get(id);
            if (savedPayment == null)
            {
                throw new Exception("Payment not found");
            }
            else
            {
                return _paymentRepository.Update(payment);
            }
        }
    }
}
