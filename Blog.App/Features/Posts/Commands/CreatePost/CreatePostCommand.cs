using System;
using Blog.App.Resources;
using MediatR;

namespace Blog.App.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<IdResource>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
    }
}