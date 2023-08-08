using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Data.Entities {
    [Table("organisations")]
    public class Organisation {
        [Column("id")]
        public long Id { get; set; }
        public Organisation? ParentOrganisation { get; set; }
        [Column("parent_organisation_id")]
        public long? ParentOrganisationId { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Column("address")]
        public string Address { get; set; } = string.Empty;
    }
}