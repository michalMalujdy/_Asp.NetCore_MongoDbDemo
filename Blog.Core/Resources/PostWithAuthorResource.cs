using Blog.Core.Domain.Models;

namespace Blog.Core.Resources
{
    public class PostWithAuthorResource : Post
    {
        public Author Author { get; set; }
    }
}