using System.Linq;
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

        public abstract void Create(T entity);
        public abstract void Delete(T entity);
        public abstract IQueryable<T> Get();
        public abstract void Update(T entity);
    }
}