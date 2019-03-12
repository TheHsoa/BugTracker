using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Storage.Model
{
    [Table("EntityChange", Schema = "Audit")]
    public class PersistenceEntityChange
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long PerformedOperationId { get; set; }

        [Required]
        public long EntityType { get; set; }

        [Required]
        public long EntityId { get; set; }

        [Required]
        public string Property { get; set; }

        public string OriginalValue { get; set; }

        public string ModifiedValue { get; set; }
    }
}