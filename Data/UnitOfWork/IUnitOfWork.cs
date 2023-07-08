using Data.Repositories.Interfaces;

namespace Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IAppUserRepository AppUsers { get; }

        public IPostRepository Posts { get; }

        public ICommentRepository Comments { get; }

        public Task<int> SaveChangesAsync();
    }
}
