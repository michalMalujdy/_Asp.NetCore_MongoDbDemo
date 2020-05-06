using System;

namespace Blog.Core.Domain.Models
{
    public class EntityBase
    {
        public Guid Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}