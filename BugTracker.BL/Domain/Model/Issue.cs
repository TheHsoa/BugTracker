using System;
using BugTracker.BL.Domain.Model.Abstract;

namespace BugTracker.BL.Domain.Model
{
    public class Issue : IEntity
    {
        public long Id { get; }
        
        public string Title { get; set; }

        public string Notes { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public Issue(long id, string title, string notes, DateTime createdOn, DateTime modifiedOn)
        {
            Id = id;
            Title = title;
            Notes = notes;
            CreatedOn = createdOn;
            ModifiedOn = modifiedOn;
        }

        public  Issue() { }
    }
}