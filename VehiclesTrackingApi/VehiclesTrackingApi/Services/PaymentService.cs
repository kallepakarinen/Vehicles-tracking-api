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
        private readonly IVehicleService _vehicleService;

        public PaymentService(IPaymentRepository PaymentRepository, IVehicleService VehicleService)
        {
            _paymentRepository = PaymentRepository;
            _vehicleService = VehicleService;
        }

        public List<Payment> GetPayments()
        {
            return _paymentRepository.Get();
        }

        public List<PaymentsReport> GetReport(int year)
        {
        
            // Get vehicles, using vehicle service or vehicle repository to get data
            List<PaymentsReport> paymentsReport = new List<PaymentsReport>();
   
            var vehicles = _vehicleService.GetVehicles();
            var payments = _paymentRepository.Get();
            var paymentsYear = year;
            foreach (var vehicle in vehicles)
            {          
                var reportItem = new PaymentsReport();
                reportItem.VehicleId = vehicle.Id;
                reportItem.VehicleName = vehicle.Registration + ' ' +  vehicle.Mark;
                         
                // Get payments by vehicle id
                var vehiclePayments = payments.Where(p => p.VehicleId == vehicle.Id && p.Day.Year == paymentsYear).ToList();

                // Filter by Payments, group by quartal
                var vehicleFuelPayments = vehiclePayments.Where(p => p.Fuel != null);
                var vehicleServicePayments = vehiclePayments.Where(p => p.Service != null);
                var vehiclePartsPayments = vehiclePayments.Where(p => p.Parts != null);
                var vehicleInsurancePayments = vehiclePayments.Where(p => p.Insurance != null);
                var vehicleTaxPayments = vehiclePayments.Where(p => p.Tax != null);
           
                var vehicleQuarterlyFuelPayments = vehicleFuelPayments.GroupBy(item => ((item.Day.Month - 1) / 3),
                    (key, group) => new PaymentQuartal(key + 1, group.Sum(p => p.Fuel))).ToList();

                var vehicleQuarterlyServicePayments = vehicleServicePayments.GroupBy(item => ((item.Day.Month - 1) / 3),
                    (key, group) => new PaymentQuartal(key + 1, group.Sum(p => p.Service))).ToList();

                reportItem.Fuel = new List<PaymentQuartal>();
                reportItem.Service = new List<PaymentQuartal>();
                var collectionList = new List<PaymentQuartal>();
                
                reportItem.QuarterlySum = new List<PaymentQuartal>();
              
                foreach(var p in vehicleQuarterlyFuelPayments)
                {
                    reportItem.Fuel.Add(p);
                    collectionList.Add(p);
                }

                foreach (var p in vehicleQuarterlyServicePayments)
                {
                    reportItem.Service.Add(p);
                    collectionList.Add(p);
                }
            
               // Sum payments per quartal
              for(int i = 1; i <=4; i++)
                {
                    var reportListItem = new PaymentQuartal();
                    reportListItem.QuartalSum = collectionList.Where(a => a.Quartal == i).Sum(s=>s.QuartalSum);
                    reportListItem.Quartal = i;
                    reportItem.QuarterlySum.Add(reportListItem);               
                }
                
                // Payments per year
                reportItem.YearlySum = collectionList.Sum(s => s.QuartalSum);
                          
                // Adding assorted items
                paymentsReport.Add(reportItem);                     
            }

            // Return report
            return paymentsReport;
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

        public void DeletePayment(int id)
        {
            _paymentRepository.Delete(id);
        }
    }
}
