using Data.Entities;
using System.Linq.Expressions;

namespace Data.Repositories.Interfaces
{
    public interface ICommentRepository : IBaseReadWriteRepository<Comment>
    {
        public new ICommentRepository Filter(Expression<Func<Comment, bool>> filter);

        public ICommentRepository IncludeAll();

        public ICommentRepository IncludeAuthor();

        public ICommentRepository IncludeParentPost();

        public ICommentRepository IncludeParentComment();

        public ICommentRepository IncludeAnswers();

        public ICommentRepository IncludeLikes();

        public ICommentRepository IncludeDislikes();
    }
}
