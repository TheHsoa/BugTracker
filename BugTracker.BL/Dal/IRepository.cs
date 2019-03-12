using System.Collections.Generic;
using BugTracker.BL.Domain;
using BugTracker.BL.Domain.Model.Abstract;

namespace BugTracker.BL.Dal
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        void Update(TEntity entity);
        EntityReference<TEntity> Add(TEntity entity);
        TEntity Get(EntityReference<TEntity> entityReference);
        IEnumerable<TEntity> Get();
    }
}