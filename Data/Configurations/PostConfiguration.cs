using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property<DateTime>("CreatedAt")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(post => post.CreatedByUser)
                .WithMany(user => user.CreatedPosts)
                .HasForeignKey(post => post.CreatedByUserId)
                .HasForeignKey(post => post.CreatedByUserId);

            builder.HasMany(post => post.Comments)
                .WithOne(comment => comment.ParentPost)
                .HasForeignKey(comment => comment.ParentPostId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
