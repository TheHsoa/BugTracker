using System;
using BugTracker.BL.Domain.Model.Abstract;

namespace BugTracker.BL.Domain.Model
{
    public class Issue : IEntity
    {
        public string Title { get; set; }

        public string Notes { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public long Id { get; set; }
    }
}