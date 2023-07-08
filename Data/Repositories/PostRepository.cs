using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class PostRepository : BaseReadWriteRepository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext context) : base(context)
        {
        }

        public override IPostRepository Filter(Expression<Func<Post, bool>> filter)
        {
            return (PostRepository)base.Filter(filter);
        }

        public IPostRepository IncludeAll()
        {
            return this.IncludeAuthor()
                .IncludeComments()
                .IncludeWatches()
                .IncludeLikes()
                .IncludeDislikes();
        }

        public IPostRepository IncludeAuthor()
        {
            _query = _query.Include(e => e.CreatedByUser);
            return this;
        }

        public IPostRepository IncludeComments()
        {
            _query = _query.Include(e => e.Comments);
            return this;
        }

        public IPostRepository IncludeWatches()
        {
            _query = _query.Include(e => e.WatchedBy);
            return this;
        }

        public IPostRepository IncludeLikes()
        {
            _query = _query.Include(e => e.LikedBy);
            return this;
        }

        public IPostRepository IncludeDislikes()
        {
            _query = _query.Include(e => e.DislikedBy);
            return this;
        }
    }
}
