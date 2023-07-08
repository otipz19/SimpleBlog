using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class CommentRepository : BaseReadWriteRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context) { }

        public override ICommentRepository Filter(Expression<Func<Comment, bool>> filter)
        {
            return (CommentRepository)base.Filter(filter);
        }

        public ICommentRepository IncludeAll()
        {
            return this.IncludeAuthor()
                .IncludeParentPost()
                .IncludeParentComment()
                .IncludeAnswers()
                .IncludeLikes()
                .IncludeDislikes();
        }

        public ICommentRepository IncludeAuthor()
        {
            _query = _query.Include(e => e.CreatedByUser);
            return this;
        }

        public ICommentRepository IncludeParentPost()
        {
            _query = _query.Include(e => e.ParentPost);
            return this;
        }

        public ICommentRepository IncludeParentComment()
        {
            _query = _query.Include(e => e.ParentComment);
            return this;
        }

        public ICommentRepository IncludeAnswers()
        {
            _query = _query.Include(e => e.Anwsers);
            return this;
        }

        public ICommentRepository IncludeLikes()
        {
            _query = _query.Include(e => e.LikedBy);
            return this;
        }

        public ICommentRepository IncludeDislikes()
        {
            _query = _query.Include(e => e.DislikedBy);
            return this;
        }
    }
}
