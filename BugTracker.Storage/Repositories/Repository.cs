using System.Collections.Generic;
using BugTracker.BL.Dal;
using BugTracker.BL.Domain;
using BugTracker.BL.Domain.Model.Abstract;
using BugTracker.Storage.Dal;

namespace BugTracker.Storage.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DatabaseContext Context;

        protected Repository(DatabaseContext context)
        {
            Context = context;
        }

        public abstract EntityReference<TEntity> Add(TEntity entity);
        public abstract IEnumerable<TEntity> Get();
        public abstract TEntity Get(EntityReference<TEntity> id);
        public abstract void Update(TEntity entity);
    }
}