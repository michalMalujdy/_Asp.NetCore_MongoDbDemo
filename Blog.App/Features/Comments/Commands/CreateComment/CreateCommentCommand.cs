using System;
using Blog.App.Resources;
using MediatR;

namespace Blog.App.Features.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<IdResource>
    {
        public string Nickname { get; set; }

        public string Content { get; set; }

        public Guid PostId { get; set; }
    }
}