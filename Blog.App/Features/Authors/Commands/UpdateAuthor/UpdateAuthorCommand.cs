using System;
using System.Text.Json.Serialization;
using MediatR;

namespace Blog.App.Features.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest
    {
        [JsonIgnore]
        public Guid AuthorId { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
    }
}