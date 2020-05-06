using System.Collections.Generic;
using Blog.Core.Domain.Models;

namespace Blog.Core.Resources
{
    public class PostCompleteResource : Post
    {
        public Author Author { get; set; }

        public List<Comment> Comments { get; set; }
    }
}