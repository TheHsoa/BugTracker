using System.Collections.Generic;
using System.Linq;
using BugTracker.BL.Domain;
using BugTracker.BL.Domain.Model;
using BugTracker.BL.Domain.Model.Abstract;
using BugTracker.BL.Identities.Entities;
using BugTracker.BL.Operations.Audit.ReadModels;
using BugTracker.Storage.Dal;

namespace BugTracker.Storage.ReadModels
{
    public sealed class PerformedOperationReadModel : IPerformedOperationReadModel
    {
        private readonly DatabaseContext _databaseContext;

        public PerformedOperationReadModel(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IReadOnlyCollection<PerformedOperation> GetEntityChanges<TEntity>(EntityReference<TEntity> reference)
            where TEntity : class, IEntity
        {
            var entityTypeId = typeof(TEntity).GetEntityId().Id;

            var entityChangesQuery = _databaseContext.EntityChanges.AsQueryable();
            var changes =
                _databaseContext.PerformedOperations.Where(
                        x => x.EntityChanges.Any(ec => ec.EntityType == entityTypeId && ec.EntityId == reference.Id))
                    .AsEnumerable().Select(x => new PerformedOperation(x.Id, x.OperationId, x.PerformedOn,
                        entityChangesQuery.Where(ec =>
                            ec.PerformedOperationId == x.Id && ec.EntityType == entityTypeId &&
                            ec.EntityId == reference.Id).AsEnumerable().Select(ec =>
                            new EntityChange(ec.Id, ec.PerformedOperationId, ec.EntityType, ec.EntityId, ec.Property,
                                ec.OriginalValue, ec.ModifiedValue)).ToList()
                    )).ToList();

            return changes;
        }
    }
}