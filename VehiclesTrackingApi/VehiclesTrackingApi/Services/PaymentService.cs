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

        public List<PaymentsReport> GetReport()
        {
            // Test
            // return _paymentRepository.GetReport(new PaymentsReport());

            // Get vehicles, using vehicle service or vehicle repository to get data
            List<PaymentsReport> paymentsReport = new List<PaymentsReport>();
   
            var vehicles = _vehicleService.GetVehicles();
            var payments = _paymentRepository.Get();

            //           var kysy = payments.GroupBy(item => item.Day.Year = 2018);

             // var paymentsQuartalQuery = payments.GroupBy(item => ((item.Day.Month - 1) / 3));




            /*   IEnumerable<DateTime> paymentsQuery =
                    from payment in payments
                    where (payment.Day.Month >= 7 && payment.Day.Month <= 9)
                    select payment.Day; 

               foreach(DateTime i in paymentsQuery)
               {
                var  x=  i;
               }*/

            //IEnumerable<IGrouping<int, Payment>> paymentsQuartalQuery = payments.GroupBy(item => ((item.Day.Month - 1) / 3));

            foreach (var vehicle in vehicles)
            {          
                var reportItem = new PaymentsReport();
                reportItem.VehicleId = vehicle.Id;
                reportItem.VehicleName = vehicle.Registration;

                // Get payments by vehicle id
                var vehiclePayments = payments.Where(p => p.VehicleId == vehicle.Id).ToList();

                // Filter by Fuel, group by quartal

                var vehicleFuelPayments = vehiclePayments.Where(p => p.Fuel != null);
                var vehicleQuarterlyFuelPayments = vehicleFuelPayments.GroupBy(item => ((item.Day.Month - 1) / 3), (key, group) => new PaymentQuartal(key + 1, group.Sum(p => p.Fuel))).ToList();

                reportItem.Fuel = new List<PaymentQuartal>();

                foreach(var p in vehicleQuarterlyFuelPayments)
                {
                    reportItem.Fuel.Add(p);
                }
                // Repeat for other payment types


                //       reportItem.Fuel[0] = paymentsQuartalQuery.Where(item => item.VehicleId == vehicle.Id).Sum(item => item.fuel[0]);
                //  reportItem.Fuel = payments.Where(item => item.VehicleId == vehicle.Id).Sum(item => item.Fuel);
                // reportItem.YearlySum = payments.Where(item => item.VehicleId == vehicle.Id).Sum(item => item.Fuel);        
                // Build report for each vehicle, use payment repository to get data

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
