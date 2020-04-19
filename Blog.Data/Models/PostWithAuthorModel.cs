using Blog.Core.Domain.Models;

namespace Blog.Data.Models
{
    public class PostWithAuthorModel : Post
    {
        public Author[] Authors { get; set; }
    }
}