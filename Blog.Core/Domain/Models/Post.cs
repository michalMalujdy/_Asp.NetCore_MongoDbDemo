using System;

namespace Blog.Core.Domain.Models
{
    public class Post
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public Post(string title, string content)
        {
            Title = title;
            Content = content;
            CreatedAt = DateTimeOffset.Now;
        }
    }
}