using System;
using System.Text.Json.Serialization;
using MediatR;

namespace Blog.App.Features.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest
    {
        [JsonIgnore]
        public Guid CommentId { get; set; }

        public string Nickname { get; set; }

        public string Content { get; set; }
    }
}