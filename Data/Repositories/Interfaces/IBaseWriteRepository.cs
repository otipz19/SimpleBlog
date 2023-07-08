using System.Collections.Generic;

namespace Data.Repositories.Interfaces
{
    public interface IBaseWriteRepository<T>
        where T : class
    {
        public void Add(T entity);

        public void AddRange(IEnumerable<T> entities);

        public void Update(T entity);

        public void Remove(T entity);
    }
}
