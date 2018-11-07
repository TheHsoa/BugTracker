using System.Linq;
using BugTracker.BL.Domain.Model.Abstract;

namespace BugTracker.BL.Dal
{
    public interface IRepository<T> where T: class, IEntity
    {
        void Update(T entity);
        void Create(T entity);
        IQueryable<T> Get();
        void Delete(T entity);
    }
}
