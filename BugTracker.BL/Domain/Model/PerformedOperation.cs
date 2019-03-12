using System;
using System.Collections.Generic;
using System.Text;
using BugTracker.BL.Domain.Model.Abstract;

namespace BugTracker.BL.Domain.Model
{
    public class PerformedOperation : IEntity
    {

        public long Id { get; }
        public long OperationId { get; }
        public DateTime PerformedOn { get; }
        public ICollection<EntityChange> EntityChanges { get; }

        public PerformedOperation(long id, long operationId, DateTime performedOn,
            ICollection<EntityChange> entityChanges)
        {
            Id = id;
            OperationId = operationId;
            PerformedOn = performedOn;
            EntityChanges = entityChanges;
        }

        public PerformedOperation(long operationId, DateTime performedOn, ICollection<EntityChange> entityChanges)
        {
            OperationId = operationId;
            PerformedOn = performedOn;
            EntityChanges = entityChanges;
        }
    }

    public class EntityChange : IEntity
    {
        public long Id { get; }
        public long PerformedOperationId { get; }
        public long EntityType { get; }
        public long EntityId { get; }
        public string Property { get; }
        public string OriginalValue { get; }
        public string ModifiedValue { get; }

        public EntityChange(long id, long performedOperationId, long entityType, long entityId, string property,
            string originalValue, string modifiedValue)
        {
            Id = id;
            PerformedOperationId = performedOperationId;
            EntityType = entityType;
            EntityId = entityId;
            Property = property;
            OriginalValue = originalValue;
            ModifiedValue = modifiedValue;
        }

        public EntityChange(long performedOperationId, long entityType, long entityId, string property,
            string originalValue, string modifiedValue)
        {
            PerformedOperationId = performedOperationId;
            EntityType = entityType;
            EntityId = entityId;
            Property = property;
            OriginalValue = originalValue;
            ModifiedValue = modifiedValue;
        }
    }
}