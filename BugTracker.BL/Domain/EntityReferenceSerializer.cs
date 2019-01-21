using BugTracker.BL.Domain.Model.Abstract;

namespace BugTracker.BL.Domain
{
    public static class EntityReferenceSerializer
    {
        public static EntityReference<TEntity> ToEntityReference<TEntity>(this TEntity entity) where TEntity : class, IEntity
        {
            return new EntityReference<TEntity>(entity.Id);
        }

        public static EntityReference<TEntity> ToEntityReference<TEntity>(this long entityId) where TEntity : class, IEntity
        {
            return new EntityReference<TEntity>(entityId);
        }
    }
}
