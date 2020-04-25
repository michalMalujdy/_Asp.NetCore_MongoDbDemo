using System;

namespace Blog.App.Features.Posts.Queries.GetPost
{
    public class GetPostResult
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public Guid AuthorId { get; set; }

        public class AuthorResult
        {
            public Guid Id { get; set; }
        
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}