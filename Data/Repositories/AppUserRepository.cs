using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class AppUserRepository : BaseReadWriteRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(AppDbContext context) : base(context)
        {
        }

        public override IAppUserRepository Filter(Expression<Func<AppUser, bool>> filter)
        {
            return (AppUserRepository)base.Filter(filter);
        }

        public IAppUserRepository IncludeFollows()
        {
            _query = _query.Include(e => e.Follows);
            return this;
        }

        public IAppUserRepository IncludeFollowers()
        {
            _query = _query.Include(e => e.Followers);
            return this;
        }

        public IAppUserRepository IncludeCreatedPosts()
        {
            _query = _query.Include(e => e.CreatedPosts);
            return this;
        }

        public IAppUserRepository IncludeWatchedPosts()
        {
            _query = _query.Include(e => e.WatchedPosts);
            return this;
        }

        public IAppUserRepository IncludeLikedPosts()
        {
            _query = _query.Include(e => e.LikedPosts);
            return this;
        }
        
        public IAppUserRepository IncludeDislikedPosts()
        {
            _query = _query.Include(e => e.DislikedPosts);
            return this;
        }

        public IAppUserRepository IncludeCreatedComments()
        {
            _query = _query.Include(e => e.CreatedComments);
            return this;
        }

        public IAppUserRepository IncludeLikedComments()
        {
            _query = _query.Include(e => e.LikedComments);
            return this;
        }

        public IAppUserRepository IncludeDislikedComments()
        {
            _query = _query.Include(e => e.DislikedComments);
            return this;
        }
    }
}
