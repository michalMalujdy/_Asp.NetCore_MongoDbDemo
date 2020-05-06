using System;

namespace Blog.Core.Domain.Models
{
    public class Post : EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public Guid AuthorId { get; set; }
    }
}