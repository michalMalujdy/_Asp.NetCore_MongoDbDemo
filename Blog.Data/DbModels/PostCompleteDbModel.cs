using Blog.Core.Domain.Models;

namespace Blog.Data.DbModels
{
    public class PostCompleteDbModel : Post
    {
        public Author[] Authors { get; set; }

        public Comment[] Comments { get; set; }
    }
}