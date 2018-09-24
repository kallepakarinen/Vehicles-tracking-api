using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehiclesTrackingApi.Models
{
    public class PaymentsReport
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        [JsonProperty("Fuel")]
        public List<PaymentQuartal> Fuel { get; set; }
        public List<PaymentQuartal> Service { get; set; }
        public List<PaymentQuartal> Parts { get; set; }
        public List<PaymentQuartal> Insurance { get; set; }
        public List<PaymentQuartal> Tax { get; set; }
        public decimal? YearlySum { get; set; }
        public List<PaymentQuartal> QuarterlySum { get; set; }

    }

    public class PaymentQuartal {
        [JsonProperty("Quartal")]
        int Quartal;
        [JsonProperty("Sum")]
        decimal? QuartalSum;

        public PaymentQuartal(int quartal, decimal? quartalSum)
        {
            this.Quartal = quartal;
            this.QuartalSum = quartalSum;
        }
    }
}
