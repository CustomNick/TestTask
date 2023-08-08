using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Data.Entities {
    [Table("measures")]
    public class Measure {
        public MeasuringPoint MeasuringPoint { get; set; } = null!;
        [Required]
        [Column("measuring_point_id")]
        public long MeasuringPointId { get; set; }

        public DeliveryPoint DeliveryPoint { get; set; } = null!;
        [Required]
        [Column("delivery_point_id")]
        public long DeliveryPointId { get; set; }

        [Required]
        [Column("measure_date")]
        public DateTimeOffset MeasureDate { get; set; }
    }
}