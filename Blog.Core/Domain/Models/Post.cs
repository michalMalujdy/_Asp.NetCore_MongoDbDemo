using System;

namespace Blog.Core.Domain.Models
{
    public class Post
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public Post()
        {
        }
    }
}