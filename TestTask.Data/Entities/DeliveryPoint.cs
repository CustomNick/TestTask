using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Data.Entities {
    [Table("delivery_points")]
    public class DeliveryPoint {
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column("max_power")]
        public int MaxPower { get; set; }

        [Required]
        [Column("metering_device_name")]
        public string MeteringDeviceName { get; set; } = string.Empty;
    }
}