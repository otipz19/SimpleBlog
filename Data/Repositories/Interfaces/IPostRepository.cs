using Data.Entities;
using System.Linq.Expressions;

namespace Data.Repositories.Interfaces
{
    public interface IPostRepository : IBaseReadWriteRepository<Post>
    {
        public new IPostRepository Filter(Expression<Func<Post, bool>> filter);

        public IPostRepository IncludeAll();

        public IPostRepository IncludeAuthor();

        public IPostRepository IncludeComments();

        public IPostRepository IncludeWatches();

        public IPostRepository IncludeLikes();

        public IPostRepository IncludeDislikes();
    }
}
