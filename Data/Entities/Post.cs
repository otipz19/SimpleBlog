﻿using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Post
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required]
        public string CreatedByUserId { get; set; }

        public virtual AppUser CreatedByUser { get; set; }

        [Required]
        public string Title { get; set; }

        public int TimeToRead { get; set; }

        [Required]
        public string Content { get; set; }
       
        public virtual List<Comment> Comments { get; set; } = new();

        public virtual List<AppUser> WatchedBy { get; set; } = new();

        public virtual List<AppUser> LikedBy { get; set; } = new();

        public virtual List<AppUser> DislikedBy { get; set; } = new();
    }
}
