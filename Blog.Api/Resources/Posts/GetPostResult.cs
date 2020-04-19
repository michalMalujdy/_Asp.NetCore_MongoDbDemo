using System;

namespace Blog.Api.Resources.Posts
{
    public class GetPostResult
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public Guid AuthorId { get; set; }
    }
}