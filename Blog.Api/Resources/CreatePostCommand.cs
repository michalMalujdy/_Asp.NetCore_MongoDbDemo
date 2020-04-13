using System;

namespace Blog.Api.Resources
{
    public class CreatePostCommand
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}