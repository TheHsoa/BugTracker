using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Storage.Model
{
    [Table("PerformedOperation", Schema = "Audit")]
    public class PersistencePerformedOperation
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long OperationId { get; set; }
        [Required]
        public DateTime PerformedOn { get; set; }
        
        public ICollection<PersistenceEntityChange> EntityChanges { get; set; }
    }
}