using System.Collections.Generic;
using BugTracker.BL.Domain.Model;
using BugTracker.BL.Domain.Model.Abstract;

namespace BugTracker.BL.Operations.Audit.Services
{
    public interface IGetEntityChangesOperationService
    {
        IReadOnlyCollection<PerformedOperation> GetChanges<TEntity>(TEntity entity) where TEntity : class, IEntity;
    }
}