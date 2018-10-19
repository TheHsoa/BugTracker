using System;

namespace BugTracker.Dal.Model.Abstract
{
    interface IAuditableEntity
    {
        DateTime CreatedOn { get; set; }
        DateTime ModifiedOn { get; set; }
    }
}
