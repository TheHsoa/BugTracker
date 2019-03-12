using System;
using BugTracker.BL.Domain.Model.Abstract;
using BugTracker.BL.Identities.Operations;

namespace BugTracker.BL.Operations.Issues.Services
{
    public interface IAuditService
    {
        void LogOperation<TEntity, TOperation>(TEntity entityBeforeChange, TEntity entityAfterChange,
            DateTime operationTime)
            where TEntity : class, IEntity where TOperation : OperationIdentityBase<TOperation>, new();
    }
}