using Microsoft.AspNetCore.Identity;

namespace Data.Entities
{
    public class AppUser : IdentityUser
    {
        public string About { get; set; }

        public virtual List<AppUser> Followers { get; set; } = new();

        public virtual List<AppUser> Follows { get; set; } = new();

        public virtual List<Post> CreatedPosts { get; set; } = new();

        public virtual List<Post> WatchedPosts { get; set; } = new();

        public virtual List<Post> LikedPosts { get; set; } = new();

        public virtual List<Post> DislikedPosts { get; set; } = new();

        public virtual List<Comment> CreatedComments { get; set; } = new();

        public virtual List<Comment> LikedComments { get; set; } = new();

        public virtual List<Comment> DislikedComments { get; set; } = new();
    }
}
