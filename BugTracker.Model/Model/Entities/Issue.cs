using System;
using System.ComponentModel.DataAnnotations;
using BugTracker.Dal.Model.Abstract;

namespace BugTracker.Dal.Model.Entities
{
    public class Issue : IEntityKey, IAuditableEntity
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
