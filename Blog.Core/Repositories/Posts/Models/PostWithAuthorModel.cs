using Blog.Core.Domain.Models;

namespace Blog.Core.Repositories.Posts.Models
{
    public class PostWithAuthorModel : Post
    {
        public Author[] Authors { get; set; }
    }
}