using Microsoft.EntityFrameworkCore;

namespace Data.Pagination
{
    public class PaginatedList<T> : List<T>
    {
        public PaginatedList(IEnumerable<T> items, int totalPages, int currentIndex)
        {
            this.AddRange(items);
            TotalPages = totalPages;
            CurrentIndex = currentIndex;
        }

        public int TotalPages { get; private set; }

        public int CurrentIndex { get; private set; }

        public bool HasNext => CurrentIndex < TotalPages;

        public bool HasPrevious => CurrentIndex > 0;

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> query, int pageSize, int pageIndex)
        {
            List<T> items = await query.Skip(pageSize * pageIndex).Take(pageSize).ToListAsync();
            int totalPages = (int)Math.Ceiling(await query.CountAsync() / (double)pageSize);
            return new PaginatedList<T>(items, totalPages, pageIndex);
        }
    }
}
