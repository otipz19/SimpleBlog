using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class AppUserRepository : BaseReadWriteRepository<AppUser>
    {
        public AppUserRepository(AppDbContext context) : base(context)
        {
        }

        public override AppUserRepository Filter(Expression<Func<AppUser, bool>> filter)
        {
            return (AppUserRepository)base.Filter(filter);
        }

        public AppUserRepository IncludeFollows()
        {
            _query = _query.Include(e => e.Follows);
            return this;
        }

        public AppUserRepository IncludeFollowers()
        {
            _query = _query.Include(e => e.Followers);
            return this;
        }

        public AppUserRepository IncludeCreatedPosts()
        {
            _query = _query.Include(e => e.CreatedPosts);
            return this;
        }

        public AppUserRepository IncludeWatchedPosts()
        {
            _query = _query.Include(e => e.WatchedPosts);
            return this;
        }

        public AppUserRepository IncludeLikedPosts()
        {
            _query = _query.Include(e => e.LikedPosts);
            return this;
        }
        
        public AppUserRepository IncludeDislikedPosts()
        {
            _query = _query.Include(e => e.DislikedPosts);
            return this;
        }

        public AppUserRepository IncludeCreatedComments()
        {
            _query = _query.Include(e => e.CreatedComments);
            return this;
        }

        public AppUserRepository IncludeLikedComments()
        {
            _query = _query.Include(e => e.LikedComments);
            return this;
        }

        public AppUserRepository IncludeDislikedComments()
        {
            _query = _query.Include(e => e.DislikedComments);
            return this;
        }
    }
}
