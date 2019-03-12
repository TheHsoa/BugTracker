using System.Collections.Generic;
using BugTracker.BL.Domain;
using BugTracker.BL.Domain.Model;
using BugTracker.BL.Domain.Model.Abstract;

namespace BugTracker.BL.Operations.Audit.ReadModels
{
    public interface IPerformedOperationReadModel
    {
        IReadOnlyCollection<PerformedOperation> GetEntityChanges<TEntity>(EntityReference<TEntity> reference)
            where TEntity : class, IEntity;
    }
}