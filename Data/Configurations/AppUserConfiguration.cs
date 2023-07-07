using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasMany(user => user.Followers)
                .WithMany(user => user.Follows)
                .UsingEntity(join => join.ToTable("UsersFollowers"));

            builder.HasMany(user => user.CreatedPosts)
                .WithOne(post => post.CreatedByUser)
                .HasForeignKey(post => post.CreatedByUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(user => user.WatchedPosts)
                .WithMany(post => post.WatchedBy)
                .UsingEntity(join => join.ToTable("PostsWatches"));

            builder.HasMany(user => user.LikedPosts)
                .WithMany(post => post.LikedBy)
                .UsingEntity(join => join.ToTable("PostsLikes"));

            builder.HasMany(user => user.DislikedPosts)
                .WithMany(post => post.DislikedBy)
                .UsingEntity(join => join.ToTable("PostsDislikes"));

            builder.HasMany(user => user.CreatedComments)
                .WithOne(comment => comment.CreatedByUser)
                .HasForeignKey(comment => comment.CreatedByUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(user => user.LikedComments)
                .WithMany(comment => comment.LikedBy)
                .UsingEntity(join => join.ToTable("CommentsLikes"));

            builder.HasMany(user => user.DislikedComments)
                .WithMany(comment => comment.DislikedBy)
                .UsingEntity(join => join.ToTable("CommentsDislikes"));
        }
    }
}
