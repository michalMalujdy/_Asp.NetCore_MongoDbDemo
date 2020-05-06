using Blog.Core.Domain.Models;

namespace Blog.Data.DbModels
{
    public class PostWithAuthorsDbModel : Post
    {
        public Author[] Authors { get; set; }
    }
}