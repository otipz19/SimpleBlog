using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property<DateTime>("CreatedAt")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(comment => comment.CreatedByUser)
                .WithMany(user => user.CreatedComments)
                .HasForeignKey(comment => comment.CreatedByUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(comment => comment.ParentPost)
                .WithMany(post => post.Comments)
                .HasForeignKey(comment => comment.ParentPostId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(comment => comment.ParentComment)
                .WithMany(comment => comment.Anwsers)
                .HasForeignKey(comment => comment.ParentCommentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
