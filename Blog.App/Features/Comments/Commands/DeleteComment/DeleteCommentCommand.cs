using System;
using MediatR;

namespace Blog.App.Features.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest<Unit>
    {
        public Guid CommentId { get; set; }
    }
}