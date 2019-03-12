using System.Collections.Generic;
using System.Transactions;
using BugTracker.BL.Domain;
using BugTracker.BL.Domain.Model;
using BugTracker.BL.Domain.Model.Abstract;
using BugTracker.BL.Operations.Audit.ReadModels;
using BugTracker.BL.Operations.Audit.Services;

namespace BugTracker.Operations.Audit.OperationServices
{
    public sealed class GetEntityChangesOperationService : IGetEntityChangesOperationService
    {
        private readonly IPerformedOperationReadModel _performedOperationReadModel;

        public GetEntityChangesOperationService(IPerformedOperationReadModel performedOperationReadModel)
        {
            _performedOperationReadModel = performedOperationReadModel;
        }

        public IReadOnlyCollection<PerformedOperation> GetChanges<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            using (var scope = new TransactionScope())
            {
                var changes = _performedOperationReadModel.GetEntityChanges(entity.ToEntityReference());

                scope.Complete();

                return changes;
            }
        }
    }
}