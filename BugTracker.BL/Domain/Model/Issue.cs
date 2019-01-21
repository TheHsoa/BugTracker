using System;
using BugTracker.BL.Domain.Model.Abstract;

namespace BugTracker.BL.Domain.Model
{
    public class Issue : IEntity
    {
        public long Id { get; }
        
        public string Title { get; }

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
            Id = 0;
            Title = title;
            Notes = notes;
            CreatedOn = createdOn;
            ModifiedOn = modifiedOn;
        }
    }
}