using System;

namespace Blog.Core.Domain.Models
{
    public class Comment : EntityBase
    {
        public string Nickname { get; set; }

        public string Content { get; set; }

        public Guid PostId { get; set; }
    }
}