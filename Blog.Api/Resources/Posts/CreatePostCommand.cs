using System;

namespace Blog.Api.Resources.Posts
{
    public class CreatePostCommand
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
    }
}