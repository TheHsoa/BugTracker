using BugTracker.BL.Domain.Model.Abstract;

namespace BugTracker.BL.Domain
{
    public class EntityReference<TEntity> where TEntity : class, IEntity
    {
        public long Id { get; }

        public EntityReference(long id)
        {
            Id = id;
        }
    }
}
