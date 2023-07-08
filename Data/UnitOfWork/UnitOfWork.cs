using Data.Repositories.Interfaces;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context,
            IAppUserRepository appUserRepository,
            IPostRepository postRepository,
            ICommentRepository commentRepository)
        {
            _context = context;
            AppUsers = appUserRepository;
            Posts = postRepository;
            Comments = commentRepository;
        }

        public IAppUserRepository AppUsers { get; private set; }

        public IPostRepository Posts { get; private set; }

        public ICommentRepository Comments { get; private set; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
