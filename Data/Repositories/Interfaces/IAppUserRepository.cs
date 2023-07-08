using Data.Entities;
using System.Linq.Expressions;

namespace Data.Repositories.Interfaces
{
    public interface IAppUserRepository : IBaseReadWriteRepository<AppUser>
    {
        public new IAppUserRepository Filter(Expression<Func<AppUser, bool>> filter);

        public IAppUserRepository IncludeFollows();

        public IAppUserRepository IncludeFollowers();

        public IAppUserRepository IncludeCreatedPosts();

        public IAppUserRepository IncludeWatchedPosts();

        public IAppUserRepository IncludeLikedPosts();

        public IAppUserRepository IncludeDislikedPosts();

        public IAppUserRepository IncludeCreatedComments();

        public IAppUserRepository IncludeLikedComments();

        public IAppUserRepository IncludeDislikedComments();
    }
}
