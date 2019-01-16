using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Storage.Model
{
    [Table("Issue", Schema = "Issues")]
    public class PersistenceIssue
    {
        [Key]
        public long Id { get; set; }

        [Required, StringLength(128)]
        public string Title { get; set; }

        [Required, StringLength(1024)]
        public string Notes { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime ModifiedOn { get; set; }
    }
}