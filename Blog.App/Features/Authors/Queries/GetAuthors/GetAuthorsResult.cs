using System;

namespace Blog.App.Features.Authors.Queries.GetAuthors
{
    public class GetAuthorsResult
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}