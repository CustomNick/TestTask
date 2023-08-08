using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Data.Entities {
    [Table("measuring_points")]
    public class MeasuringPoint {
        [Column("id")]
        public long Id { get; set; }

        public ConsumerObject ConsumerObject { get; set; } = null!;
        [Required]
        [Column("consumer_object_id")]
        public long ConsumerObjectId { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Column("counter_number")]
        public long CounterNumber { get; set; }
        [Required]
        [Column("counter_type")]
        public short CounterType { get; set; }
        [Required]
        [Column("counter_check_date")]
        public DateTimeOffset CounterCheckDate { get; set; }

        [Required]
        [Column("current_transformator_number")]
        public long CurrentTransformatorNumber { get; set; }
        [Required]
        [Column("current_transformator_type")]
        public short CurrentTransformatorType { get; set; }
        [Required]
        [Column("current_transformator_check_date")]
        public DateTimeOffset CurrentTransormatorCheckDate { get; set; }
        [Required]
        [Column("current_transformator_coefficient")]
        public float CurrentTransformatorCoefficient { get; set; }

        [Required]
        [Column("voltage_transformator_number")]
        public long VoltageTransformatorNumber { get; set; }
        [Required]
        [Column("voltage_transformator_type")]
        public short VoltageTransformatorType { get; set; }
        [Required]
        [Column("voltage_transformator_check_date")]
        public DateTimeOffset VoltageTransormatorCheckDate { get; set; }
        [Required]
        [Column("voltage_transformator_coefficient")]
        public float VoltageTransformatorCoefficient { get; set; }
    }
}