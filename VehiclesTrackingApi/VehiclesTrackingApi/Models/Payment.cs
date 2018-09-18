using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehiclesTrackingApi.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        [Column("vehicleId")]
        public int VehicleId { get; set; }
        [Column("day", TypeName = "date")]
        public DateTime Day { get; set; }
        [Column("kilometers", TypeName = "decimal(18, 0)")]
        public decimal? Kilometers { get; set; }
        [Column("fuel", TypeName = "decimal(18, 0)")]
        public decimal? Fuel { get; set; }
        [Column("service", TypeName = "decimal(18, 0)")]
        public decimal? Service { get; set; }
        [Column("parts", TypeName = "decimal(18, 0)")]
        public decimal? Parts { get; set; }
        [Column("insurance", TypeName = "decimal(18, 0)")]
        public decimal? Insurance { get; set; }
        [Column("tax", TypeName = "decimal(18, 0)")]
        public decimal? Tax { get; set; }
        [Column("comment")]
        public string Comment { get; set; }

        [ForeignKey("VehicleId")]
        [InverseProperty("Payment")]
        public Vehicle Vehicle { get; set; }
    }
}
