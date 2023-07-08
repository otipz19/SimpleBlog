using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class PostRepository : BaseReadWriteRepository<Post>
    {
        public PostRepository(AppDbContext context) : base(context)
        {
        }

        public override PostRepository Filter(Expression<Func<Post, bool>> filter)
        {
            return (PostRepository)base.Filter(filter);
        }

        public PostRepository IncludeAll()
        {
            return this.IncludeAuthor()
                .IncludeComments()
                .IncludeWatches()
                .IncludeLikes()
                .IncludeDislikes();
        }

        public PostRepository IncludeAuthor()
        {
            _query = _query.Include(e => e.CreatedByUser);
            return this;
        }

        public PostRepository IncludeComments()
        {
            _query = _query.Include(e => e.Comments);
            return this;
        }

        public PostRepository IncludeWatches()
        {
            _query = _query.Include(e => e.WatchedBy);
            return this;
        }

        public PostRepository IncludeLikes()
        {
            _query = _query.Include(e => e.LikedBy);
            return this;
        }

        public PostRepository IncludeDislikes()
        {
            _query = _query.Include(e => e.DislikedBy);
            return this;
        }
    }
}
