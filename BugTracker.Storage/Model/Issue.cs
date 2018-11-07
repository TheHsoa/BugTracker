using System;

namespace BugTracker.Storage.Model
{
    public class Issue
    {
        public string Title { get; set; }

        public string Notes { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public long Id { get; set; }
    }
}