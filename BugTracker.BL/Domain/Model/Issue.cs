using System;
using BugTracker.BL.Domain.Audit;
using BugTracker.BL.Domain.Model.Abstract;

namespace BugTracker.BL.Domain.Model
{
    public class Issue : IEntity
    {
        public long Id { get; }
        
        [AuditingProperty]
        public string Title { get; }

        [AuditingProperty]
        public string Notes { get; }

        public DateTime CreatedOn { get; }

        public DateTime ModifiedOn { get; }

        public Issue(long id, string title, string notes, DateTime createdOn, DateTime modifiedOn)
        {
            Id = id;
            Title = title;
            Notes = notes;
            CreatedOn = createdOn;
            ModifiedOn = modifiedOn;
        }

        public Issue(string title, string notes, DateTime createdOn, DateTime modifiedOn)
        {
            Title = title;
            Notes = notes;
            CreatedOn = createdOn;
            ModifiedOn = modifiedOn;
        }
    }
}