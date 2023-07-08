using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public abstract class BaseWriteRepository<T> : IBaseWriteRepository<T>
        where T : class
    {
        protected DbSet<T> _set;

        protected BaseWriteRepository(AppDbContext context)
        {
            _set = context.Set<T>();
        }

        public void Add(T entity)
        {
            _set.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _set.AddRange(entities);
        }

        public void Update(T entity)
        {
            _set.Update(entity);
        }

        public void Remove(T entity)
        {
            _set.Remove(entity);
        }
    }
}
