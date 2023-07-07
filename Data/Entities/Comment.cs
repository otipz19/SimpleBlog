using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required]
        public string CreatedByUserId { get; set; }

        public virtual AppUser CreatedByUser { get; set; }

        [Required]
        public string Content { get; set; }

        public int? ParentPostId { get; set; }

        public virtual Post ParentPost { get; set; }

        public int? ParentCommentId { get; set; }

        public virtual Comment ParentComment { get; set; }

        public virtual List<Comment> Anwsers { get; set; } = new();

        public virtual List<AppUser> LikedBy { get; set; } = new();

        public virtual List<AppUser> DislikedBy { get; set; } = new();
    }
}
