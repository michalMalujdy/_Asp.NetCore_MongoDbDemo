using System;
using System.Text.Json.Serialization;
using MediatR;

namespace Blog.App.Features.Posts.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest
    {
        [JsonIgnore]
        public Guid PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Guid AuthorId { get; set; }
    }
}