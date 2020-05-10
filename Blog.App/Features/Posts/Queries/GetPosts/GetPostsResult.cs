using System;
using Blog.App.Features.Common.Author;

namespace Blog.App.Features.Posts.Queries.GetPosts
{
    public class GetPostsResult
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public AuthorCommonResult Author { get; set; }
    }
}