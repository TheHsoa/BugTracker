using System.Collections.Generic;
using BugTracker.BL.Domain.Model.Abstract;

namespace BugTracker.BL.Dal
{
    public interface IRepository<T> where T: class, IEntity
    {
        void Update(T entity);
        long Create(T entity);
        T Get(long id);
        IEnumerable<T> Get();
    }
}
