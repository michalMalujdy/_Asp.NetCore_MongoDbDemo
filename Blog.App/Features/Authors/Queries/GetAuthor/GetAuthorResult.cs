using System;

namespace Blog.App.Features.Authors.Queries.GetAuthor
{
    public class GetAuthorResult
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}