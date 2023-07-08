using Data.Entities;
using Data.Pagination;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public abstract class BaseReadWriteRepository<T> : BaseWriteRepository<T>, IBaseReadWriteRepository<T>
        where T : class
    {
        protected IQueryable<T> _query;

        protected BaseReadWriteRepository(AppDbContext context) : base(context)
        {
            _query = _set.AsQueryable();
        }

        public virtual IBaseReadWriteRepository<T> Filter(Expression<Func<T, bool>> filter)
        {
            _query = _query.Where(filter);
            return this;
        }

        public async Task<T> FirstOrDefaultAsync(int id)
        {
            T result = await _set.FindAsync(id);
            _query = _set.AsQueryable();
            return result;
        }

        public async Task<List<T>> ToListAsync()
        {
            List<T> result = await _query.ToListAsync();
            _query = _set.AsQueryable();
            return result;
        }

        public async Task<PaginatedList<T>> ToPaginatedListAsync(int pageSize, int pageIndex)
        {
            PaginatedList<T> result = await PaginatedList<T>.CreateAsync(_query, pageSize, pageIndex);
            _query = _set.AsQueryable();
            return result;
        }
    }
}
