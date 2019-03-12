using System;
using System.Collections.Generic;
using BugTracker.BL.Domain;
using BugTracker.BL.Domain.Model;
using BugTracker.Storage.Dal;
using BugTracker.Storage.Model;

namespace BugTracker.Storage.Repositories
{
    public class EntityChangeRepository : Repository<EntityChange>
    {
        public EntityChangeRepository(DatabaseContext context) : base(context)
        {
        }

        public override void Update(EntityChange entity)
        {
            throw new NotImplementedException();
        }

        public override EntityReference<EntityChange> Add(EntityChange entity)
        {
            var newEntityChange = new PersistenceEntityChange
            {
                PerformedOperationId = entity.PerformedOperationId,
                EntityType = entity.EntityType,
                EntityId = entity.EntityId,
                Property = entity.Property,
                OriginalValue = entity.OriginalValue,
                ModifiedValue = entity.ModifiedValue
            };

            Context.EntityChanges.Add(newEntityChange);

            Context.SaveChanges();

            return new EntityReference<EntityChange>(newEntityChange.Id);
        }

        public override EntityChange Get(EntityReference<EntityChange> id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<EntityChange> Get()
        {
            throw new NotImplementedException();
        }
    }
}