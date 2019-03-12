using System;
using System.Collections.Generic;
using System.Linq;
using BugTracker.BL.Dal;
using BugTracker.BL.Domain;
using BugTracker.BL.Domain.Audit;
using BugTracker.BL.Domain.Model;
using BugTracker.BL.Domain.Model.Abstract;
using BugTracker.BL.Identities.Entities;
using BugTracker.BL.Identities.Operations;
using BugTracker.BL.Operations.Issues.Services;

namespace BugTracker.Storage.Audit
{
    public sealed class AuditService : IAuditService
    {
        private readonly IRepository<PerformedOperation> _operationRepository;
        private readonly IRepository<EntityChange> _entityChangeRepository;

        public AuditService(IRepository<EntityChange> entityChangeRepository,
            IRepository<PerformedOperation> operationRepository)
        {
            _operationRepository = operationRepository;
            _entityChangeRepository = entityChangeRepository;
        }

        //узнать надо ли логировать пустые операции
        public void LogOperation<TEntity, TOperation>(TEntity entityBeforeChange, TEntity entityAfterChange,
            DateTime operationTime) where TEntity : class, IEntity
            where TOperation : OperationIdentityBase<TOperation>, new()
        {
            var operation = new PerformedOperation(OperationIdentityBase<TOperation>.Instance.Id, operationTime,
                new List<EntityChange>());

            var operationReference = _operationRepository.Add(operation);

            var entityChanges = GetEntityChanges(entityBeforeChange, entityAfterChange, operationReference);

            foreach (var entityChange in entityChanges)
            {
                _entityChangeRepository.Add(entityChange);
            }
        }

        private IEnumerable<EntityChange> GetEntityChanges<TEntity>(TEntity entityBeforeChange,
            TEntity entityAfterChange, EntityReference<PerformedOperation> performedOperation) where TEntity : IEntity
        {
            var auditingProperties = typeof(TEntity).GetProperties()
                .Where(x => Attribute.IsDefined(x, typeof(AuditingPropertyAttribute)));

            return (from auditingProperty in auditingProperties
                    let propertyValueBeforeChange = auditingProperty.GetValue(entityBeforeChange)
                    let propertyValueAfterChange = auditingProperty.GetValue(entityAfterChange)
                    where propertyValueBeforeChange != propertyValueAfterChange
                    select new EntityChange(performedOperation.Id, typeof(TEntity).GetEntityId().Id,
                        entityBeforeChange.Id,
                        auditingProperty.Name, propertyValueBeforeChange.ToString(),
                        propertyValueAfterChange.ToString()))
                .ToList();
        }
    }
}