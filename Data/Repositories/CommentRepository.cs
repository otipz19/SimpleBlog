using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class CommentRepository : BaseReadWriteRepository<Comment>
    {
        public CommentRepository(AppDbContext context) : base(context) { }

        public override CommentRepository Filter(Expression<Func<Comment, bool>> filter)
        {
            return (CommentRepository)base.Filter(filter);
        }

        public CommentRepository IncludeAll()
        {
            return this.IncludeAuthor()
                .IncludeParentPost()
                .IncludeParentComment()
                .IncludeAnswers()
                .IncludeLikes()
                .IncludeDislikes();
        }

        public CommentRepository IncludeAuthor()
        {
            _query = _query.Include(e => e.CreatedByUser);
            return this;
        }

        public CommentRepository IncludeParentPost()
        {
            _query = _query.Include(e => e.ParentPost);
            return this;
        }

        public CommentRepository IncludeParentComment()
        {
            _query = _query.Include(e => e.ParentComment);
            return this;
        }

        public CommentRepository IncludeAnswers()
        {
            _query = _query.Include(e => e.Anwsers);
            return this;
        }

        public CommentRepository IncludeLikes()
        {
            _query = _query.Include(e => e.LikedBy);
            return this;
        }

        public CommentRepository IncludeDislikes()
        {
            _query = _query.Include(e => e.DislikedBy);
            return this;
        }
    }
}
