using System;
using System.Collections.Generic;
using Blog.App.Features.Common.Author;

namespace Blog.App.Features.Posts.Queries.GetPost
{
    public class GetPostResult
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public AuthorCommonResult Author { get; set; }

        public List<Comment> Comments { get; set; }

        public class Comment
        {
            public Guid Id { get; set; }

            public string Nickname { get; set; }

            public string Content { get; set; }

            public DateTimeOffset CreatedAt { get; set; }

            public DateTimeOffset UpdatedAt { get; set; }
        }
    }
}