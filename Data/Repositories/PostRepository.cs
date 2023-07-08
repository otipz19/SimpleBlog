using Data.Entities;
using Data.Pagination;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class PostRepository
    {
        private DbSet<Post> _set;
        private IQueryable<Post> _query;

        public PostRepository(AppDbContext context)
        {
            _set = context.Posts;
            _query = _set.AsQueryable();
        }

        public void Add(Post post)
        {
            _set.Add(post);
        }

        public void AddRange(IEnumerable<Post> posts)
        {
            _set.AddRange(posts);
        }

        public void Update(Post post)
        {
            _set.Update(post);
        }

        public void Remove(Post post)
        {
            _set.Remove(post);
        }

        public PostRepository Filter(Expression<Func<Post, bool>> filter)
        {
            _query.Where(filter);
            return this;
        }

        public PostRepository IncludeAll()
        {
            return this.IncludeAuthor().IncludeComments().IncludeWatches().IncludeLikes().IncludeDislikes();
        }

        public PostRepository IncludeAuthor()
        {
            _query.Include(e => e.CreatedByUser);
            return this;
        }

        public PostRepository IncludeComments()
        {
            _query.Include(e => e.Comments);
            return this;
        }

        public PostRepository IncludeWatches()
        {
            _query.Include(e => e.WatchedBy);
            return this;
        }

        public PostRepository IncludeLikes()
        {
            _query.Include(e => e.LikedBy);
            return this;
        }

        public PostRepository IncludeDislikes()
        {
            _query.Include(e => e.DislikedBy);
            return this;
        }

        public async Task<Post> FirstOrDefaultAsync(int id)
        {
            Post result = await _query.FirstOrDefaultAsync(e => e.Id == id);
            _query = _set.AsQueryable();
            return result;
        }

        public async Task<List<Post>> ToListAsync()
        {
            List<Post> result = await _query.ToListAsync();
            _query = _set.AsQueryable();
            return result;
        }

        public async Task<PaginatedList<Post>> ToPaginatedListAsync(int pageSize, int pageIndex)
        {
            PaginatedList<Post> result = await PaginatedList<Post>.CreateAsync(_query, pageSize, pageIndex);
            _query = _set.AsQueryable();
            return result;
        }
    }
}
