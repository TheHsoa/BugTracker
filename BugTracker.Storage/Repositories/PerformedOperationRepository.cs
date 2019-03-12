using System;
using System.Collections.Generic;
using BugTracker.BL.Domain;
using BugTracker.BL.Domain.Model;
using BugTracker.Storage.Dal;
using BugTracker.Storage.Model;

namespace BugTracker.Storage.Repositories
{
    public class PerformedOperationRepository : Repository<PerformedOperation>
    {
        public PerformedOperationRepository(DatabaseContext context) : base(context)
        {
        }

        public override void Update(PerformedOperation entity)
        {
            throw new NotImplementedException();
        }

        public override EntityReference<PerformedOperation> Add(PerformedOperation entity)
        {
            var newPerformedOperation = new PersistencePerformedOperation
            {
                OperationId = entity.OperationId,
                PerformedOn = entity.PerformedOn
            };

            Context.PerformedOperations.Add(newPerformedOperation);

            Context.SaveChanges();

            return new EntityReference<PerformedOperation>(newPerformedOperation.Id);
        }

        public override PerformedOperation Get(EntityReference<PerformedOperation> id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<PerformedOperation> Get()
        {
            throw new NotImplementedException();
        }
    }
}