using Data.Pagination;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Data.Repositories.Interfaces
{
    public interface IBaseReadWriteRepository<T> : IBaseWriteRepository<T>
        where T : class
    {
        public IBaseReadWriteRepository<T> Filter(Expression<Func<T, bool>> filter);

        public Task<T> FirstOrDefaultAsync(int id);

        public Task<List<T>> ToListAsync();

        public Task<PaginatedList<T>> ToPaginatedListAsync(int pageSize, int pageIndex);
    }
}
