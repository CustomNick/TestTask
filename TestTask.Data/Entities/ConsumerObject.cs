using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Data.Entities {
    [Table("consumer_objects")]
    public class ConsumerObject {
        [Column("id")]
        public long Id { get; set; }

        public Organisation Organisation { get; set; } = null!;
        [Required]
        [Column("organisation_id")]
        public long OrganisationId { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column("address")]
        public string Address { get; set; } = string.Empty;
    }
}