using System.Collections.Generic;
using BugTracker.BL.Dal;
using BugTracker.BL.Domain.Model.Abstract;
using BugTracker.Storage.Dal;

namespace BugTracker.Storage.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DatabaseContext Context;

        protected Repository(DatabaseContext context)
        {
            Context = context;
        }

        public abstract long Create(T entity);
        public abstract IEnumerable<T> Get();
        public abstract T Get(long id);
        public abstract void Update(T entity);
    }
}