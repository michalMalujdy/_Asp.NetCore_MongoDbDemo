using System;

namespace Blog.Core.Domain.Models
{
    public class Author
    {
        public Guid Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}