using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehiclesTrackingApi.Models
{
    [Table("Vehicle")]
    public class Vehicle
    {
        [Key]
        public int id { get; set; }
        public string registration { get; set; }
        public string mark { get; set; }
        public string acquisitionDay { get; set; }
        public decimal price { get; set; }
        public decimal resaleValue { get; set; }
        public bool active { get; set; }
    }
}
