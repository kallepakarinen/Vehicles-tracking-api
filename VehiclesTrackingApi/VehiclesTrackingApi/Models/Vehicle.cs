using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehiclesTrackingApi.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Payment = new HashSet<Payment>();
        }

        public int Id { get; set; }
        [Column("registration")]
        [StringLength(10)]
        public string Registration { get; set; }
        [Required]
        [Column("mark")]
        [StringLength(50)]
        public string Mark { get; set; }
        [Column("acquisitionDay", TypeName = "date")]
        public DateTime? AcquisitionDay { get; set; }
        [Column("price", TypeName = "decimal(18, 0)")]
        public decimal? Price { get; set; }
        [Column("resaleValue", TypeName = "decimal(18, 0)")]
        public decimal? ResaleValue { get; set; }
        [Column("active")]
        public bool Active { get; set; }

        [InverseProperty("Vehicle")]
        public ICollection<Payment> Payment { get; set; }
    }
}
